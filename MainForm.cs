using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using System.Security.Policy;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using dgw.Weather;
using System.Runtime.CompilerServices;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Diagnostics;
using Tomlyn;
using Tomlyn.Model;

namespace dgw {

    public partial class MainForm : Form {

        private System.Windows.Forms.Timer timer;


        private string config_path = "Config.toml";
        private string api_key;


        private int limit = 1;

        private List<int> first_hourly_temps, second_hourly_temps;
        private List<int> first_hourly_wind_degs, second_hourly_wind_degs;
        private List<decimal> first_hourly_wind_speeds, second_hourly_wind_speeds;


        private bool is_column_series = false;
        private int wind_deg;


        public MainForm() {

            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e) {

            cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;

            get_api_key();
            this.reorder_daylist();
            string[] cities = { "Amasya", "Ankara", "Istanbul" };

            foreach (string city in cities) {
                comboBox1.Items.Add(city);
            }

        }

        private async void refresh_button_Click(object sender, EventArgs e) {


            progressBar2.Value = 0;

            await init_data();

            progressBar2.Value = 100;


        }

        private void get_api_key() {
            string config_content = System.IO.File.ReadAllText(config_path);
            TomlTable config_table = Toml.Parse(config_content).ToModel();

            if (config_table.ContainsKey("api")) {
                TomlTable api_section = config_table["api"] as TomlTable;
                string api_key = api_section?["api_key"]?.ToString();

                if (api_key != null) {
                    //Debug.WriteLine($"API Key: {api_key}");
                    this.api_key = api_key;
                } else {
                    Debug.WriteLine("API key not found in 'api' section");
                }
            } else {
                Debug.WriteLine("API section not found in the config");
            }
        }


        public async Task<int> init_data() {

            string city = comboBox1.Text;

            string geoUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit={limit}&appid={api_key}";
            GeoLocationClient geolocationClient = new GeoLocationClient();
            GeoLocation location = await geolocationClient.get_geolocation(geoUrl);

            List<Label> temp_labels = this.get_temp_list();
            List<PictureBox> picture_boxes = this.get_picturebox_list();



            if (location != null) {

                // reset picturebox colors

                richTextBox1.Text = $"Name: {location.name}\nLatitude: {location.lat}\nLongitude: {location.lon}";

                // this gets weather data using lat and lon
                string weatherUrl = $"https://api.openweathermap.org/data/3.0/onecall?lat={location.lat}&lon={location.lon}&appid={api_key}&units=metric";
                WeatherClient weatherClient = new WeatherClient();
                WeatherResponse weather = await weatherClient.GetWeatherAsync(weatherUrl);

                if (weather != null) {

                    var minmax_temps = await weatherClient.get_temps(weather);
                    var icons = await weatherClient.get_icons(weather);
                    var (first_hourly_temps, second_hourly_temps) = await weatherClient.get_hourly_temps(weather);
                    var (first_hourly_wind_degs, second_hourly_wind_degs) = await weatherClient.get_hourly_wind_degrees(weather);
                    var (first_hourly_wind_speeds, second_hourly_wind_speeds) = await weatherClient.get_hourly_wind_speeds(weather);

                    pictureBox1.BackColor = Color.Turquoise;
                    pictureBox2.BackColor = Color.SkyBlue;

                    // store the hourly data here for future use
                    (this.first_hourly_temps, this.second_hourly_temps) = (first_hourly_temps, second_hourly_temps);
                    (this.first_hourly_wind_degs, this.second_hourly_wind_degs) = (first_hourly_wind_degs, second_hourly_wind_degs);
                    (this.first_hourly_wind_speeds, this.second_hourly_wind_speeds) = (first_hourly_wind_speeds, second_hourly_wind_speeds);

                    await this.draw_graphs();


                    richTextBox1.AppendText($"\n\nWeather Information:\n");
                    richTextBox1.AppendText($"Temperature: {weather.current.temp}°C\n");
                    richTextBox1.AppendText($"Feels Like: {weather.current.feelsLike}°C\n");
                    richTextBox1.AppendText($"Humidity: {weather.current.humidity}%\n");
                    richTextBox1.AppendText($"Weather: {weather.current.weather[0].description}");

                    this.wind_deg = weather.current.wind_deg;
                    string wind_deg_string = this.degrees_to_direction(wind_deg);

                    // this changes the top information
                    //if (weather.current.rain.oneHour != null) {
                    //    label18.Text = $"Precipitation: {weather.current.rain.oneHour}";
                    //}
                    label19.Text = $"Humidity: {weather.current.humidity}";
                    label21.Text = $"Wind: {weather.current.wind_speed} m/s";
                    label22.Text = $"Wind Degree: {weather.current.wind_deg}° / {wind_deg_string}";


                    // this changes the temp values
                    int index = 0;
                    foreach (var (min, max) in minmax_temps) {
                        temp_labels[index].Text = $"{((int)min)} °C / {((int)max)}°C";

                        index++;

                        if (temp_labels.Count == index) {
                            break;
                        }
                    }
                    index = 0;

                    // this is for icons and for primary
                    var primary_icon = weather.current.weather[0].icon;
                    var primary_temp = weather.current.temp;
                    pictureBox8.Image = Image.FromFile($"./icons/{primary_icon}.png");
                    label16.Text = ((int)primary_temp).ToString();

                    foreach (var icon in icons) {
                        richTextBox2.AppendText($"{icon}\n");
                        picture_boxes[index].Image = Image.FromFile($"./icons/{icon}.png");

                        index++;

                        if (picture_boxes.Count == index) {
                            break;
                        }
                    }

                    progressBar2.Value = 100;
                }
            } else {
                richTextBox1.Text = "No geolocation data found.";
            }
            return 1;
        }

        public List<PictureBox> get_picturebox_list() {

            List<PictureBox> picture_boxes = new List<PictureBox>();
            picture_boxes.Add(this.pictureBox1);
            picture_boxes.Add(this.pictureBox2);
            picture_boxes.Add(this.pictureBox3);
            picture_boxes.Add(this.pictureBox4);
            picture_boxes.Add(this.pictureBox5);
            picture_boxes.Add(this.pictureBox6);
            picture_boxes.Add(this.pictureBox7);

            return picture_boxes;
        }

        public List<Label> get_temp_list() {
            List<Label> labels = new List<Label>();
            labels.Add(this.label9);
            labels.Add(this.label10);
            labels.Add(this.label11);
            labels.Add(this.label12);
            labels.Add(this.label13);
            labels.Add(this.label14);
            labels.Add(this.label15);
            return labels;
        }

        public List<Label> get_daylist() {
            List<Label> labels = new List<Label>();
            labels.Add(this.label_day1);
            labels.Add(this.label_day2);
            labels.Add(this.label_day3);
            labels.Add(this.label_day4);
            labels.Add(this.label_day5);
            labels.Add(this.label_day6);
            labels.Add(this.label_day7);
            return labels;
        }

        public List<string> create_timelist() {
            var temp_list = new List<string>();
            var current_hour = DateTime.Now.Hour;

            for (int i = 0; i < 24; i++) {
                int hour = (current_hour + i) % 24;
                temp_list.Add($"{hour:D2}:00");
                // used D2 here for instance 2 -> 02
            }

            return temp_list;
        }

        public void reorder_daylist() {

            int today_index = (int)DateTime.Now.DayOfWeek;
            today_index = (today_index == 0) ? 6 : today_index - 1;

            List<Label> labels = this.get_daylist();

            List<string> reorderedTexts = new List<string>();

            for (int i = 0; i < labels.Count; i++) {
                int index = (today_index + i) % labels.Count;
                reorderedTexts.Add(labels[index].Text);
            }

            for (int i = 0; i < labels.Count; i++) {
                labels[i].Text = reorderedTexts[i];
            }
        }

        public string degrees_to_direction(double degrees) {

            // this is not needed because api already returns the degree lower than 360 : x < 360
            //degrees = degrees % 360;
            //if (degrees < 0) degrees += 360;

            string[] compass = {
            "N", "NE", "E", "SE",
            "S", "SW", "W", "NW"
            };

            int index = (int)Math.Round(degrees / 45) % 8;

            return compass[index];

        }

        private async Task<int> draw_graphs() {

            var time_list = this.create_timelist();

            cartesianChart1.Series = new ISeries[] {
                new LineSeries<int>
                {
                    Values = this.first_hourly_temps,
                    YToolTipLabelFormatter = point => {
                        return $"{point.Coordinate.PrimaryValue} °C";
                    }
                },
            };

            cartesianChart1.XAxes = new List<Axis> {
                new Axis {
                    Labels = time_list
                }
            };

            cartesianChart2.Series = new ISeries[] {
                new ColumnSeries<decimal>
                {
                    Values = this.first_hourly_wind_speeds,
                    YToolTipLabelFormatter = point => $"{point.Coordinate.PrimaryValue} m/s"
                },
            };

            cartesianChart2.XAxes = new List<Axis> {
                new Axis {
                    Labels = time_list
                }
            };

            cartesianChart3.Series = new ISeries[] {
                new ColumnSeries<int>
                {
                    Values = this.first_hourly_wind_degs,
                    YToolTipLabelFormatter = point => {
                        return $"{point.Coordinate.PrimaryValue}° / {degrees_to_direction(point.Coordinate.PrimaryValue)}";
                    }   
                },
            };

            cartesianChart3.XAxes = new List<Axis> {
                new Axis {
                    Labels = time_list
                }
            };

            return 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            pictureBox1.BackColor = Color.Turquoise;
            pictureBox2.BackColor = Color.SkyBlue;
            update_charts(first_hourly_temps, first_hourly_wind_speeds, first_hourly_wind_degs);
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            pictureBox1.BackColor = Color.SkyBlue;
            pictureBox2.BackColor = Color.Turquoise;
            update_charts(second_hourly_temps, second_hourly_wind_speeds, second_hourly_wind_degs);
        }

        private void update_charts(List<int> temperatures, List<decimal> wind_speeds, List<int> wind_degrees) {
            cartesianChart1.Series = new ISeries[] {
                new LineSeries<int> {
                    Values = temperatures,
                    YToolTipLabelFormatter = point => $"{point.Coordinate.PrimaryValue} °C"
                }
            };

            cartesianChart2.Series = new ISeries[] {
                new ColumnSeries<decimal> {
                    Values = wind_speeds,
                    YToolTipLabelFormatter = point => $"{point.Coordinate.PrimaryValue} m/s"
                }
            };

            cartesianChart3.Series = new ISeries[] {
                new ColumnSeries<int> {
                    Values = wind_degrees,
                    YToolTipLabelFormatter = point => {
                        return $"{point.Coordinate.PrimaryValue}° / {degrees_to_direction(point.Coordinate.PrimaryValue)}";
                    }   
                }
            };
        }
        

    }
}



