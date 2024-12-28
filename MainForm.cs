using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Diagnostics;
using Tomlyn;
using Tomlyn.Model;
using System.Text.Json;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.WinForms;

using RainDroplets;
using Metadata;
using Weather;

namespace dgw {

    public partial class MainForm : Form {

        private System.Windows.Forms.Timer timer;

        private string config_path = "Config.toml";
        private string api_key;

        private static bool city_flag = true;
        private static bool play_flag = false;

        private int limit = 1;

        private List<int> first_hourly_temps, second_hourly_temps;
        private List<int> first_hourly_wind_degs, second_hourly_wind_degs;
        private List<decimal> first_hourly_wind_speeds, second_hourly_wind_speeds;
        private List<decimal> first_hourly_rain_precs, second_hourly_rain_precs;
        private List<decimal> first_hourly_snow_precs, second_hourly_snow_precs;

        private List<DateTime> validDates = new List<DateTime>();

        private bool is_column_series = false;
        private int wind_deg;

        private string old_file_filepath;

        public int snow_or_rain = -1;

        public MainForm() {

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {


            cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;

            get_api_key();
            load_old_data();

            this.reorder_daylist();

            string[] cities = { "Amasya", "Ankara", "Istanbul" };

            foreach (string city in cities) {
                comboBox1.Items.Add(city);
            }

            comboBox1.ForeColor = Color.Gray;
            this.Size = new Size(990, 595);

        }

        private async void refresh_button_Click(object sender, EventArgs e) {


            progressBar2.Value = 0;

            this.reorder_daylist();
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

        public void reorder_daylist(string startDay) {
            string[] originalDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Dictionary<string, int> dayToIndex = new Dictionary<string, int>();
            for (int i = 0; i < originalDays.Length; i++) {
                dayToIndex[originalDays[i]] = i;
            }

            if (!dayToIndex.ContainsKey(startDay)) {
                throw new ArgumentException("Invalid day string.");
            }

            int startDayIndex = dayToIndex[startDay];
            List<Label> labels = this.get_daylist();

            if (labels.Count != originalDays.Length) {
                throw new InvalidOperationException("Day list size mismatch.");
            }

            for (int i = 0; i < labels.Count; i++) {
                int reorderedIndex = (startDayIndex + i) % originalDays.Length;
                labels[i].Text = originalDays[reorderedIndex];
            }
        }

        public void reorder_daylist() {
            string[] originalDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int today_index = (int)DateTime.Now.DayOfWeek;

            today_index = (today_index == 0) ? 6 : today_index - 1;

            List<Label> labels = this.get_daylist();

            if (labels.Count != originalDays.Length) {
                throw new InvalidOperationException("Day list size mismatch.");
            }

            for (int i = 0; i < labels.Count; i++) {
                int reorderedIndex = (today_index + i) % originalDays.Length;
                labels[i].Text = originalDays[reorderedIndex];
            }
        }

        public string degrees_to_direction(double degrees) {

            // this is not needed because api already returns the degree lower than 360 : x < 360
            //degrees = degrees % 360;
            //if (degrees < 0) degrees += 360;

            string[] compass = {
            "N", "NE", "E", "SE",
            "S", "SW", "W", "NW"
            };//

            int index = (int)Math.Round(degrees / 45) % 8;

            return compass[index];

        }

        private async Task<int> draw_graphs() {

            var time_list = this.create_timelist();

            var chart_list = new List<CartesianChart>();

            cartesianChart1.Series = new ISeries[] {
                new LineSeries<int>
                {
                    Values = this.first_hourly_temps,
                    YToolTipLabelFormatter = point => {
                        return $"{point.Coordinate.PrimaryValue} �C";
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
                        return $"{point.Coordinate.PrimaryValue}� / {degrees_to_direction(point.Coordinate.PrimaryValue)}";
                    }
                },
            };

            cartesianChart3.XAxes = new List<Axis> {
                new Axis {
                    Labels = time_list
                }
            };

            cartesianChart4.Series = new ISeries[] {
                new LineSeries<decimal>
                {
                    Values = this.first_hourly_rain_precs,
                    YToolTipLabelFormatter = point => {
                        return $"{point.Coordinate.PrimaryValue}mm";
                    }
                },
            };

            cartesianChart4.XAxes = new List<Axis> {
                new Axis {
                    Labels = time_list
                }
            };

            cartesianChart5.Series = new ISeries[] {
                new LineSeries<decimal>
                {
                    Values = this.first_hourly_snow_precs,
                    YToolTipLabelFormatter = point => {
                        return $"{point.Coordinate.PrimaryValue}mm";
                    }
                },
            };

            cartesianChart5.XAxes = new List<Axis> {
                new Axis {
                    Labels = time_list
                }
            };

            chart_list.Add(cartesianChart1);
            chart_list.Add(cartesianChart2);
            chart_list.Add(cartesianChart3);
            chart_list.Add(cartesianChart4);
            chart_list.Add(cartesianChart5);

            foreach (var chart in chart_list) {
                chart.ZoomMode = ZoomAndPanMode.X;
            }

            return 1;
        }


        private void update_charts(
            List<int> temperatures,
            List<decimal> wind_speeds,
            List<int> wind_degrees,
            List<decimal> rain_precs,
            List<decimal> snow_precs
            ) {
            cartesianChart1.Series = new ISeries[] {
                new LineSeries<int> {
                    Values = temperatures,
                    YToolTipLabelFormatter = point => $"{point.Coordinate.PrimaryValue} �C"
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
                        return $"{point.Coordinate.PrimaryValue}� / {degrees_to_direction(point.Coordinate.PrimaryValue)}";
                    }
                }
            };
            cartesianChart4.Series = new ISeries[] {
                new LineSeries<decimal> {
                    Values = rain_precs,
                    YToolTipLabelFormatter = point => $"{point.Coordinate.PrimaryValue}mm"
                }
            };
            cartesianChart5.Series = new ISeries[] {
                new LineSeries<decimal> {
                    Values = snow_precs,
                    YToolTipLabelFormatter = point => $"{point.Coordinate.PrimaryValue}mm"
                }
            };
        }

        private void load_old_data() {
            WeatherClient weather_client = new WeatherClient();
            var filenames = MetaData.get_old_files();
            Debug.WriteLine($"Filenames count: {filenames?.Count ?? 0}");

            List<string> city_names = MetaData.get_old_file_parts(0);
            var dates = MetaData.get_old_file_parts(1);
            var times = MetaData.get_old_file_parts(2);

            List<DateTime> dates_as_datetime = new List<DateTime>();
            List<DateTime> times_as_datetime = new List<DateTime>();

            Dictionary<string, List<DateTime>> city_dates = new Dictionary<string, List<DateTime>>();
            Dictionary<string, List<DateTime>> city_times = new Dictionary<string, List<DateTime>>();

            for (int i = 0; i < city_names.Count; i++) {
                if (DateTime.TryParseExact(dates[i], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsed_date)) {
                    dates_as_datetime.Add(parsed_date);
                } else {
                    Debug.WriteLine($"Invalid date format: {dates[i]}");
                }

                string timeString = times[i].Replace('-', ':');
                if (DateTime.TryParseExact(timeString, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsed_time)) {
                    times_as_datetime.Add(parsed_time);
                } else {
                    Debug.WriteLine($"Invalid time format: {times[i]}");
                }

                if (!city_dates.ContainsKey(city_names[i])) {
                    city_dates[city_names[i]] = new List<DateTime>();
                    city_times[city_names[i]] = new List<DateTime>();
                }

                city_dates[city_names[i]].Add(dates_as_datetime[i]);
                city_times[city_names[i]].Add(times_as_datetime[i]);

                string cityName = city_names[i];
                string formatted_city_name = char.ToUpper(cityName[0]) + cityName.Substring(1);

                if (!comboBoxOCity.Items.Contains(formatted_city_name)) {
                    comboBoxOCity.Items.Add(formatted_city_name);
                }

                //richTextBox3.AppendText($"{city_names[i]} / {dates[i]} / {times[i]}\n");
            }

            foreach (var city in city_dates) {
                Debug.WriteLine($"City: {city.Key}, Dates: {string.Join(", ", city.Value)}");
            }

            comboBoxOCity.SelectedIndexChanged += (sender, e) => {
                comboBoxODate.Items.Clear();
                comboBoxOTime.Items.Clear();

                string selected_city = comboBoxOCity.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selected_city)) {
                    Debug.WriteLine($"Selected City: {selected_city}");

                    if (city_dates.ContainsKey(selected_city.ToLower())) {
                        foreach (var date in city_dates[selected_city.ToLower()]) {
                            string formatted_date = date.ToString("yyyy-MM-dd");

                            if (!comboBoxODate.Items.Contains(formatted_date)) {
                                comboBoxODate.Items.Add(formatted_date);
                                Debug.WriteLine($"Adding Date: {formatted_date}");
                            }
                        }
                    } else {
                        Debug.WriteLine($"City {selected_city} not found in city_dates.");
                    }
                } else {
                    Debug.WriteLine("No city selected.");
                }
            };

            comboBoxODate.SelectedIndexChanged += (sender, e) => {
                comboBoxOTime.Items.Clear();

                string selected_city = comboBoxOCity.SelectedItem?.ToString();
                string selected_date = comboBoxODate.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selected_city) && !string.IsNullOrEmpty(selected_date)) {
                    Debug.WriteLine($"Selected City: {selected_city}");
                    Debug.WriteLine($"Selected Date: {selected_date}");

                    if (city_dates.ContainsKey(selected_city.ToLower()) && city_times.ContainsKey(selected_city.ToLower())) {
                        var city_dates_list = city_dates[selected_city.ToLower()];
                        var city_times_list = city_times[selected_city.ToLower()];

                        // Find matching times for the selected date
                        for (int i = 0; i < city_dates_list.Count; i++) {
                            if (city_dates_list[i].ToString("yyyy-MM-dd") == selected_date) {
                                string formattedTime = city_times_list[i].ToString("HH:mm:ss");

                                if (!comboBoxOTime.Items.Contains(formattedTime)) {
                                    comboBoxOTime.Items.Add(formattedTime);
                                    Debug.WriteLine($"Adding Time: {formattedTime}");
                                }
                            }
                        }
                    } else {
                        Debug.WriteLine($"City {selected_city} not found in city_dates or city_times.");
                    }
                } else {
                    Debug.WriteLine("City or date not selected.");
                }
            };

            Debug.WriteLine($"Parsed Dates: {string.Join(", ", dates_as_datetime)}");
            Debug.WriteLine($"Parsed Times: {string.Join(", ", times_as_datetime)}");
        }

        // is this the best way to do it? hell no.
        // was i supposed to use metadata.json for this? yes.
        // why didn't i do it? i was sleepy so i might implement that later.
        // this function became a shit code.
        void get_old_data() {
            string selected_city = comboBoxOCity.SelectedItem?.ToString();

            DateTime? selected_date = null;

            if (comboBoxODate.SelectedItem != null) {
                string selected_dateString = comboBoxODate.SelectedItem.ToString();
                if (DateTime.TryParse(selected_dateString, out DateTime parsed_date)) {
                    selected_date = parsed_date;
                } else {
                    Debug.WriteLine($"Invalid date format: {selected_dateString}");
                }
            } else {
                Debug.WriteLine("No date selected.");
            }

            string selected_timeString = comboBoxOTime.SelectedItem?.ToString();
            DateTime? selected_time = null;

            if (!string.IsNullOrEmpty(selected_timeString)) {
                if (DateTime.TryParseExact(selected_timeString, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsed_time)) {
                    selected_time = parsed_time;
                } else {
                    Debug.WriteLine($"Invalid time format: {selected_timeString}");
                }
            }

            Debug.WriteLine($"Selected Time: {selected_time}");

            Debug.WriteLine($"Selected City: {selected_city} -- Selected Date: {selected_date} -- Selected Time: {selected_time}");

            if (selected_city == null || selected_date == null || selected_time == null) {
                MessageBox.Show("Please select a city, date, and time.");
                return;
            }

            string date = selected_date?.ToString("yyyy-MM-dd");
            string formattedTime = selected_time?.ToString("HH:mm:ss").Replace(":", "-");

            Debug.WriteLine($"Formatted Date: {date} -- Formatted Time: {formattedTime}");

            string day_name = selected_date?.ToString("dddd");

            Debug.WriteLine($"Day Name: {day_name}");

            this.reorder_daylist(day_name);

            var files = MetaData.get_old_files();

            var matching_files = files.Where(file => {
                string filename_without_extension = Path.GetFileNameWithoutExtension(file.Name);
                string[] parts = filename_without_extension.Split('_');

                return parts.Length >= 3 &&
                       parts[0].Equals(selected_city, StringComparison.OrdinalIgnoreCase) &&
                       parts[1].Equals(date) &&
                       parts[2].Equals(formattedTime);
            }).ToList();

            if (matching_files.Count == 0) {
                MessageBox.Show("No matching data found.");
                return;
            }

            foreach (var file in matching_files) {
                string filepath = file.FullName;
                Debug.WriteLine($"Found matching file: {filepath}");
                old_file_filepath = filepath;

                //richTextBox3.AppendText($"File found: {file.Name}\n");
                string file_contents = File.ReadAllText(filepath);
                //richTextBox3.AppendText($"Contents:\n{file_contents}\n");
            }
        }

        // this inits weather data from a JSON response or file

        public async Task<int> init_data(bool is_old = false, string jsonFilePath = "") {
            WeatherResponse weather = null;
            WeatherClient weather_client = new WeatherClient();
            string city = "";

            if (is_old) {
                if (File.Exists(jsonFilePath)) {
                    string file_contents = File.ReadAllText(jsonFilePath);
                    weather = JsonSerializer.Deserialize<WeatherResponse>(file_contents);
                    city = comboBoxOCity.Text;
                    richTextBox1.Text = $"Name: {city}\nLatitude: {weather.lat}\nLongitude: {weather.lon}";
                } else {
                    richTextBox1.Text = "No saved weather data found in the specified file.";
                    return 0;
                }
            } else {
                city = comboBox1.Text;
                string geoUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit={limit}&appid={api_key}";
                GeoLocationClient geolocationClient = new GeoLocationClient();
                GeoLocation location = await geolocationClient.get_geolocation(geoUrl);

                if (location == null) {
                    richTextBox1.Text = "No geolocation data found.";
                    return 0;
                }

                richTextBox1.Text = $"Name: {location.name}\nLatitude: {location.lat:F4}\nLongitude: {location.lon:F4}";

                string weatherUrl = $"https://api.openweathermap.org/data/3.0/onecall?lat={location.lat}&lon={location.lon}&appid={api_key}&units=metric";
                weather = await weather_client.get_weather_async(weatherUrl);

                if (weather != null) {
                    DateTime creation_time = DateTime.Now;
                    string metadata_path = $"./metadata.json";
                    await weather_client.save_weather_to_json(weather, city, metadata_path, creation_time);
                    Debug.WriteLine("Metadata saved to JSON.");
                }
            }

            if (weather != null) {
                List<Label> temp_labels = this.get_temp_list();
                List<PictureBox> picture_boxes = this.get_picturebox_list();

                var minmax_temps = await weather_client.get_temps(weather);
                var icons = await weather_client.get_icons(weather);
                var (first_hourly_temps, second_hourly_temps) = await weather_client.get_hourly_temps(weather);
                var (first_hourly_wind_degs, second_hourly_wind_degs) = await weather_client.get_hourly_wind_degrees(weather);
                var (first_hourly_wind_speeds, second_hourly_wind_speeds) = await weather_client.get_hourly_wind_speeds(weather);
                var (first_hourly_rain_precs, second_hourly_rain_precs) = await weather_client.get_hourly_precs(weather);
                var (first_hourly_snow_precs, second_hourly_snow_precs) = await weather_client.get_hourly_precs(weather, false);

                pictureBox1.BackColor = Color.Turquoise;
                pictureBox2.BackColor = Color.SkyBlue;

                // store the hourly data here for future use
                (this.first_hourly_temps, this.second_hourly_temps) = (first_hourly_temps, second_hourly_temps);
                (this.first_hourly_wind_degs, this.second_hourly_wind_degs) = (first_hourly_wind_degs, second_hourly_wind_degs);
                (this.first_hourly_wind_speeds, this.second_hourly_wind_speeds) = (first_hourly_wind_speeds, second_hourly_wind_speeds);
                (this.first_hourly_rain_precs, this.second_hourly_rain_precs) = (first_hourly_rain_precs, second_hourly_rain_precs);
                (this.first_hourly_snow_precs, this.second_hourly_snow_precs) = (first_hourly_snow_precs, second_hourly_snow_precs);

                await this.draw_graphs();

                //richTextBox1.AppendText($"\n\nWeather Information:\n");
                //richTextBox1.AppendText($"Temperature: {weather.current.temp}�C\n");
                //richTextBox1.AppendText($"Feels Like: {weather.current.feelsLike}�C\n");
                //richTextBox1.AppendText($"Humidity: {weather.current.humidity}%\n");
                //richTextBox1.AppendText($"Weather: {weather.current.weather[0].description}");

                this.wind_deg = weather.current.wind_deg;
                string wind_deg_string = this.degrees_to_direction(wind_deg);


                // this changes the top information
                //if (weather.current.rain.oneHour != null) {
                //    label18.Text = $"Precipitation: {weather.current.rain.oneHour}";

                label19.Text = $"Humidity: {weather.current.humidity}%";
                label21.Text = $"Wind: {weather.current.wind_speed} m/s";
                label22.Text = $"Wind Degree: {weather.current.wind_deg}� / {wind_deg_string}";
                label23.Text = $"Pressure: {weather.current.pressure} hPa";
                label20.Text = $"Visibility: {weather.current.visibility / 1000} km";
                label2.Text = $"UV Index: {weather.current.uvi}";

                // this changes the temp values
                int index = 0;
                foreach (var (min, max) in minmax_temps) {
                    temp_labels[index].Text = $"{((int)min)} �C / {((int)max)}�C";
                    index++;
                    if (temp_labels.Count == index) break;
                }

                // this is for icons and for primary
                var primary_icon = weather.current.weather[0].icon;

                // this looks for first daily weather icon
                var daily_icon = weather.daily[0].weather[0].icon;

                // if it rains or snows that day playground works accordingly.
                if (
                    daily_icon == "09d" || daily_icon == "09n" ||
                    daily_icon == "10d" || daily_icon == "10d"
                    ) {

                    this.snow_or_rain = 1;

                } else if (
                    daily_icon == "13d" || daily_icon == "13n"
                    ) {
                    this.snow_or_rain = 0;
                }


                var primary_temp = weather.current.temp;
                var description = weather.current.weather[0].description;
                pictureBox8.Image = Image.FromFile($"./icons/{primary_icon}.png");
                label16.Text = ((int)primary_temp).ToString();
                if (!is_old) label1.Text = description;

                index = 0;
                foreach (var icon in icons) {
                    picture_boxes[index].Image = Image.FromFile($"./icons/{icon}.png");
                    index++;
                    if (picture_boxes.Count == index) break;
                }

                progressBar2.Value = 100;
                return 1;
            }

            return 0;
        }

        private void old_refresh_button_Click(object sender, EventArgs e) {
            load_old_data();
        }

        private async void get_data_button_Click(object sender, EventArgs e) {
            get_old_data();
            await init_data(true, old_file_filepath);
        }

        private void comboBox1_Click(object sender, EventArgs e) {

            if (city_flag) {
                comboBox1.ForeColor = Color.Black;
                comboBox1.Text = string.Empty;
                city_flag = false;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            pictureBox1.BackColor = Color.Turquoise;
            pictureBox2.BackColor = Color.SkyBlue;
            this.update_charts(
                first_hourly_temps,
                first_hourly_wind_speeds,
                first_hourly_wind_degs,
                first_hourly_rain_precs,
                first_hourly_snow_precs
                );
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            pictureBox1.BackColor = Color.SkyBlue;
            pictureBox2.BackColor = Color.Turquoise;
            this.update_charts(
                second_hourly_temps,
                second_hourly_wind_speeds,
                second_hourly_wind_degs,
                second_hourly_rain_precs,
                second_hourly_snow_precs
                );
        }


        private void panelPlay_MouseEnter(object sender, EventArgs e) {
            Cursor.Hide();
        }

        private void panelPlay_MouseLeave(object sender, EventArgs e) {
            Cursor.Show();
        }

        private void buttonPlay_Click(object sender, EventArgs e) {
            if (play_flag == false) {

                this.Size = new Size(1200, 595);
                play_flag = true;
                this.buttonPlay.Text = "Stop";
                this.panelPlay.Controls.Clear();
                this.panelPlay.BackColor = Color.White;

                if (this.snow_or_rain == 1) {

                    var rain = new RainSimulationControl {
                        Dock = DockStyle.Fill
                    };
                    rain.MouseEnter += panelPlay_MouseEnter;
                    rain.MouseLeave += panelPlay_MouseLeave;

                    this.panelPlay.Controls.Add(rain);
                } else if (this.snow_or_rain == 0) {

                    this.panelPlay.BackColor = Color.Black;

                    var snow = new RainSimulationControl(300, 50f, 10f, 10) {
                        Dock = DockStyle.Fill,
                        Color = Brushes.White
                    };
                    snow.MouseEnter += panelPlay_MouseEnter;
                    snow.MouseLeave += panelPlay_MouseLeave;

                    this.panelPlay.Controls.Add(snow);
                }
            } else {

                this.Size = new Size(990, 595);

                this.panelPlay.Controls.Clear();
                play_flag = false;
                this.buttonPlay.Text = "Playground";
            }
        }

        // button1 and button2 is for debug purposes
        private void button1_Click(object sender, EventArgs e) {

             if (play_flag == false) {

                this.Size = new Size(1200, 595);
                play_flag = true;
                this.buttonPlay.Text = "Stop";

                this.panelPlay.Controls.Clear();
                this.panelPlay.BackColor = Color.White;
                var rain = new RainSimulationControl {
                    Dock = DockStyle.Fill
                };

                rain.MouseEnter += panelPlay_MouseEnter;
                rain.MouseLeave += panelPlay_MouseLeave;

                this.panelPlay.Controls.Add(rain);

            } else {

                this.Size = new Size(990, 595);

                this.panelPlay.Controls.Clear();
                play_flag = false;
                this.buttonPlay.Text = "Playground";
            }
        }

        private void button2_Click(object sender, EventArgs e) {

             if (play_flag == false) {

                this.Size = new Size(1200, 595);
                play_flag = true;
                this.buttonPlay.Text = "Stop";

                this.panelPlay.Controls.Clear();
                this.panelPlay.BackColor = Color.Black;
                var snow = new RainSimulationControl(300, 50f, 10f, 10) {
                    Dock = DockStyle.Fill
                };

                snow.MouseEnter += panelPlay_MouseEnter;
                snow.MouseLeave += panelPlay_MouseLeave;

                snow.Color = Brushes.White;
                this.panelPlay.Controls.Add(snow);

            } else {

                this.Size = new Size(990, 595);

                this.panelPlay.Controls.Clear();
                play_flag = false;
                this.buttonPlay.Text = "Playground";
            }
        }
    }
}



