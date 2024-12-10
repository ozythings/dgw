using System.Text.Json;
using dgw.Weather;

namespace dgw.Weather {

    public class WeatherResponse {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string timezone { get; set; }
        public int timezoneOffset { get; set; }
        public CurrentWeather current { get; set; }
        public List<MinutelyWeather> minutely { get; set; }
        public List<HourlyWeather> hourly { get; set; }
        public List<DailyWeather> daily { get; set; }
        public List<Alert> alerts { get; set; }
    }

    public class CurrentWeather {
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public decimal temp { get; set; }
        public decimal feelsLike { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public decimal dewPoint { get; set; }
        public int clouds { get; set; }
        public decimal uvi { get; set; }
        public int visibility { get; set; }
        public decimal wind_speed { get; set; }
        public decimal? wind_gust { get; set; }
        public int wind_deg { get; set; }
        public Precipitation rain { get; set; }
        public Precipitation snow { get; set; }
        public List<WeatherCondition> weather { get; set; }
    }

    public class Precipitation {
        public decimal? onehour { get; set; }
    }

    public class WeatherCondition {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class MinutelyWeather {
        public int dt { get; set; }
        public decimal precipitation { get; set; }
    }

    public class HourlyWeather {
        public int dt { get; set; }
        public decimal temp { get; set; }
        public decimal feelsLike { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public decimal dewPoint { get; set; }
        public decimal uvi { get; set; }
        public int clouds { get; set; }
        public int visibility { get; set; }
        public decimal wind_speed { get; set; }
        public decimal? wind_gust { get; set; }
        public int wind_deg { get; set; }
        public decimal? pop { get; set; }
        public Precipitation rain { get; set; }
        public Precipitation snow { get; set; }
        public List<WeatherCondition> weather { get; set; }
    }

    public class DailyWeather {
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public int moonrise { get; set; }
        public int moonset { get; set; }
        public decimal moonPhase { get; set; }
        public Temperature temp { get; set; }
        public FeelsLike feelsLike { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public decimal dewPoint { get; set; }
        public decimal wind_speed { get; set; }
        public decimal? wind_gust { get; set; }
        public int wind_deg { get; set; }
        public int clouds { get; set; }
        public decimal uvi { get; set; }
        public decimal? pop { get; set; }
        public decimal? rain { get; set; }
        public decimal? snow { get; set; }
        public List<WeatherCondition> weather { get; set; }
    }

    public class Temperature {
        public decimal morn { get; set; }
        public decimal day { get; set; }
        public decimal eve { get; set; }
        public decimal night { get; set; }
        public decimal min { get; set; }
        public decimal max { get; set; }
    }

    public class FeelsLike {
        public decimal morn { get; set; }
        public decimal day { get; set; }
        public decimal eve { get; set; }
        public decimal night { get; set; }
    }

    public class Alert {
        public string senderName { get; set; }
        public string Event { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string description { get; set; }
        public List<string> tags { get; set; }
    }

}

public class GeoLocation
{
    public string name { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string country { get; set; }
    public string state { get; set; }
}

public class WeatherClient
{
    public async Task<WeatherResponse> GetWeatherAsync(string url)
    {
        using HttpClient client = new HttpClient();
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            WeatherResponse weather = JsonSerializer.Deserialize<WeatherResponse>(responseBody);

            return weather;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"JSON parsing error: {e.Message}");
            return null;
        }
    }

    public async Task<List<(decimal min, decimal max)>> get_temps(WeatherResponse weather_response) {

        var temps = new List<(decimal min, decimal max)>();

        if (weather_response != null && weather_response.daily != null) {

            foreach (var daily in weather_response.daily) {
                temps.Add((daily.temp.min, daily.temp.max));
            }
        }
        else {
            // TODO IMPLEMENT
        }

        return temps;
    } 

    public async Task<List<string>> get_icons(WeatherResponse weather_response) {

        var icons = new List<string>();

        if (weather_response != null && weather_response.daily != null) {

            foreach (var daily in weather_response.daily) {
                icons.Add(daily.weather[0].icon);
            }
        }
        else {
            // TODO IMPLEMENT
        }

        return icons;
    }

    public async Task<(List<int> first24, List<int> second24)> get_hourly_temps(WeatherResponse weather_response) {
        var first24 = new List<int>();
        var second24 = new List<int>();

        if (weather_response != null && weather_response.hourly != null) {

            var hourly_data = weather_response.hourly.Take(48).ToList();

            first24 = hourly_data.Take(24).Select(h => (int)h.temp).ToList();
            second24 = hourly_data.Skip(24).Take(24).Select(h => (int)h.temp).ToList();
        } else {
            Console.WriteLine("Weather response or hourly data is null.");
        }

        return (first24, second24);
    }

    public async Task<(List<int> first24, List<int> second24)> get_hourly_wind_degrees(WeatherResponse weather_response) {
        var first24 = new List<int>();
        var second24 = new List<int>();

        if (weather_response != null && weather_response.hourly != null) {

            var hourly_data = weather_response.hourly.Take(48).ToList();

            first24 = hourly_data.Take(24).Select(h => h.wind_deg).ToList();
            second24 = hourly_data.Skip(24).Take(24).Select(h => h.wind_deg).ToList();
        } else {
            Console.WriteLine("Weather response or hourly data is null.");
        }

        return (first24, second24);
    }

    public async Task<(List<decimal> first24, List<decimal> second24)> get_hourly_wind_speeds(WeatherResponse weather_response) {
        var first24 = new List<decimal>();
        var second24 = new List<decimal>();

        if (weather_response != null && weather_response.hourly != null) {

            var hourly_data = weather_response.hourly.Take(48).ToList();

            first24 = hourly_data.Take(24).Select(h => h.wind_speed).ToList();
            second24 = hourly_data.Skip(24).Take(24).Select(h => h.wind_speed).ToList();
        } else {
            Console.WriteLine("Weather response or hourly data is null.");
        }

        return (first24, second24);
    }

}

public class GeoLocationClient
{
    public async Task<GeoLocation> get_geolocation(string url)
    {
        using HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            List<GeoLocation> geoResponses = JsonSerializer.Deserialize<List<GeoLocation>>(responseBody);

            // return the first location if available
            if (geoResponses != null && geoResponses.Count > 0)
            {
                return geoResponses[0];
            }
            else
            {
                Console.WriteLine("No geolocation data found.");
                return null;
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"JSON parsing error: {e.Message}");
            return null;
        }
    }
}
