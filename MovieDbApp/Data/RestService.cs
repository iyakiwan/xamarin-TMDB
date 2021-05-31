using MovieDbApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<MovieData> GetMovieData(string query)
        {
            MovieData movieData = null;
            try
            {
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    movieData = JsonConvert.DeserializeObject<MovieData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR SOalle {0}", ex.Message);
            }

            return movieData;
        }
    }
}
