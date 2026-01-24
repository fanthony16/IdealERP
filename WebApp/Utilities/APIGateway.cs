using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApp.Utilities
{
    public class APIGateway
    {
        private readonly static HttpClient client = new HttpClient();
        private readonly IConfiguration config;

        public APIGateway(IConfiguration config)
        {
            this.config = config;
        }
        public async Task<bool> ApiPostAsync<T>(T obj, string actionPath)

        {
            
            var url = config["BaseURL"] + actionPath;
            var jsonContent = JsonSerializer.Serialize(obj);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //Console.WriteLine($"Created Product: {json}");
                return true;
            }
            else
            {
                //Console.WriteLine($"Failed to create user. Status: {response.StatusCode}");
                var error = await response.Content.ReadAsStringAsync();

                return false;
                //Console.WriteLine($"Error details: {error}");
            }
        }

        public  async  Task<string> ApiGetAsync(string actionPath)

        {
            //var jsonContent = JsonSerializer.Serialize(obj);
            //var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var url = config["BaseURL"]+ actionPath;
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //Console.WriteLine($"Created Product: {json}");
                return json;
            }
            else
            {
                //Console.WriteLine($"Failed to create user. Status: {response.StatusCode}");
                var error = await response.Content.ReadAsStringAsync();
                //Console.WriteLine($"Error details: {error}");
                return error;
            }

            
        }

    }
}
