using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.WebManager;

namespace WebApp.Utilities
{
    public class APIGateway
    {
        private readonly static HttpClient client = new HttpClient();
        private readonly IConfiguration config;
        private readonly ISessionManager sessionManager;

        public APIGateway(IConfiguration config, ISessionManager sessionManager)
        {
            this.config = config;
            this.sessionManager = sessionManager;
        }
        public async Task<string> ApiPostAsync<T>(T obj, string actionPath)

        {

            var username = sessionManager.GetSessionObject("email");
            var password = sessionManager.GetSessionObject("pwd");
            
            // Encode username:password

            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));

            var url = config["BaseURL"] + actionPath;

            var jsonContent = JsonSerializer.Serialize(obj);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Add("X-App-Id", this.config["ApplicationID"]);
            client.DefaultRequestHeaders.Add("X-App-Secret", this.config["ApplicationSecret"]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var response = await client.PostAsync(url, content);
            
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

                return (error == "") ? response.StatusCode.ToString() : error;

                
                //Console.WriteLine($"Error details: {error}");
            }
        }

        public  async  Task<string> ApiGetAsync(string actionPath)

        {
            //var jsonContent = JsonSerializer.Serialize(obj);
            //var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var url = config["BaseURL"]+ actionPath;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-App-Id", this.config["ApplicationID"]);
            client.DefaultRequestHeaders.Add("X-App-Secret", this.config["ApplicationSecret"]);

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

                return (error == "") ? response.StatusCode.ToString() : error;

            }

            
        }

    }
}
