using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NbaLibrary.Models;

namespace WPF
{
    static internal class RestHelper
    {
        static JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private static HttpClient httpClient = new HttpClient();

        #region Login
        public static async Task<List<Customer>> Method_WindowLoaded()
        {
            HttpResponseMessage httpRequest = await httpClient.GetAsync("https://localhost:7234/api/customer");

            if (httpRequest.IsSuccessStatusCode == true)
            {
                List<Customer> customerList = new List<Customer>();
                customerList = JsonSerializer.Deserialize<List<Customer>>(await httpRequest.Content.ReadAsStringAsync(), options);
                return customerList;
            }
            else
            {
                return null;
            }

        }
        #endregion


        #region StartShopping

        public static async Task<IEnumerable<string>> GetTeamNameFromEast()
        {
            HttpResponseMessage httpRequest = await httpClient.GetAsync("https://localhost:7234/api/Nba/Team/Coast/East/Name");
            if (httpRequest.IsSuccessStatusCode == true)
            {
                string content = await httpRequest.Content.ReadAsStringAsync();
                IEnumerable<string> teameast = JsonSerializer.Deserialize<IEnumerable<string>>(content);
                return teameast;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public static async Task<IEnumerable<string>> GetTeamNameFromWest()
        {
            HttpResponseMessage httpRequest = await httpClient.GetAsync("https://localhost:7234/api/Nba/Team/Coast/West/Name");
            if (httpRequest.IsSuccessStatusCode == true)
            {
                string content = await httpRequest.Content.ReadAsStringAsync();
                IEnumerable<string> teameast = JsonSerializer.Deserialize<IEnumerable<string>>(content);
                return teameast;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }


        public static async Task<IEnumerable<Jersey>> Method_btnNewJersey_Click(Jersey newj)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(newj), Encoding.UTF8, "application/json");
            HttpResponseMessage httpRequest = await httpClient.PostAsync($"https://localhost:7234/api/jersey", content);

            if (httpRequest.IsSuccessStatusCode == true)
            {
                IEnumerable<Jersey> newJersey = null;
                newJersey = JsonSerializer.Deserialize<IEnumerable<Jersey>>(await httpRequest.Content.ReadAsStringAsync(), options);
                return newJersey;
            }
            else
            {
                return null;
            }
        }




        #endregion
    }

}