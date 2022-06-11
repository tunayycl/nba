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
    }
}
