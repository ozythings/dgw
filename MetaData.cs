using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Weather;

namespace Metadata {

    public class MetaData {
        public string file_path { get; set; }
        public DateTime creation_time { get; set; }
        public string city { get; set; }
        public string metadata_path { get; set; }

        public static void save_metadata_to_json(string filename, DateTime creation_time, string city, string metadata_path) {
            var metadata = new {
                file_path = filename,
                creation_time = creation_time,
                city = city
            };

            var options = new JsonSerializerOptions {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            string json_content = JsonSerializer.Serialize(metadata, options);

            if (File.Exists(metadata_path)) {
                string existing_content = File.ReadAllText(metadata_path);
                List<dynamic> metadata_list = JsonSerializer.Deserialize<List<dynamic>>(existing_content) ?? new List<dynamic>();
                metadata_list.Add(metadata);

                string updated_content = JsonSerializer.Serialize(metadata_list, options);
                File.WriteAllText(metadata_path, updated_content);
            } else {
                List<dynamic> metadata_list = new List<dynamic> { metadata };
                string initial_content = JsonSerializer.Serialize(metadata_list, options);
                File.WriteAllText(metadata_path, initial_content);
            }
        }

        public static List<WeatherResponse> get_old_weather_data(
            string city,
            DateTime creation_time
            ) {

            string metadata_path = "metadata.json";

            if (File.Exists(metadata_path)) {
                string existing_content = File.ReadAllText(metadata_path);
                WeatherResponse metadata_list = JsonSerializer.Deserialize<WeatherResponse>(existing_content);
            }


            List<WeatherResponse> weather_list = new List<WeatherResponse>();

            return weather_list;

        }
        // i might deprecate this
        public static List<FileInfo> get_old_files() {
            string folderPath = "./old";

            if (!Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
                Debug.WriteLine("Created 'old' folder.");
            }

            DirectoryInfo directory = new DirectoryInfo(folderPath);
            FileInfo[] files = directory.GetFiles("*.json");
            List<FileInfo> filename_list = new List<FileInfo>();

            foreach (var filename in files) {
                filename_list.Add(filename);
            }

            foreach (var filename in filename_list) {
                Debug.WriteLine($"{filename}");
            }

            return filename_list;
        }
        // part indicates which part you want of the file name
        // 0 -> city name
        // 1 -> date
        // 2 -> time
        public static List<string> get_old_file_parts(int part) {

            DirectoryInfo directory = new DirectoryInfo($"./");
            FileInfo[] files = directory.GetFiles("./old/*.json");
            List<string> part_list = new List<string>();

            foreach (var file in files)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);

                string[] parts = fileNameWithoutExtension.Split('_');
                if (parts.Length > 0)
                {
                    part_list.Add(parts[part]);
                }
            }

            // Debug output
            foreach (var p in part_list)
            {
                Debug.WriteLine($"{p}");
            }

            return part_list;
        }

    }
}
