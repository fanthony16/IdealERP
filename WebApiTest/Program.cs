using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiTest
{
    class Program
    {
        private readonly static HttpClient client = new HttpClient();
        //private const string BaseUrl = "http://idealerp.com/api/User/RegisterUser";
        private const string BaseUrl = "http://idealerp.com/api/User/ValidateUser";
        //ValidateUser

        static async Task Main(string[] args)
        {
            //Console.WriteLine("Registrating User!");
            //var nwUser = new User()
            //{
            //     Email = "fanthony16@yahoo.com",
            //     FirstName ="Oluwafemi",
            //     LastName="Taiwo",
            //     PhoneNumber="07475958358",
            //     Password = "STaiwo16.."
            //};
            //await CreateUserAsync(nwUser);
            //Console.WriteLine("User Successfully!");


            var valUser = new ValidateUser()
            {
                Email = "fanthony16@yahoo.com",
                Password = "STaiwo16.."
            };
            await ValidateUserAsync(valUser);
            Console.WriteLine("User Validated Successfully!");






        }

        private static async Task CreateUserAsync(User _user)

        {
            var jsonContent = JsonSerializer.Serialize(_user);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BaseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Created Product: {json}");
            }
            else
            {
                Console.WriteLine($"Failed to create user. Status: {response.StatusCode}");
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error details: {error}");
            }
        }

        private static async Task ValidateUserAsync(ValidateUser _loginuser)

        {
            var jsonContent = JsonSerializer.Serialize(_loginuser);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BaseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Created Product: {json}");
            }
            else
            {
                Console.WriteLine($"Failed to create user. Status: {response.StatusCode}");
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error details: {error}");
            }
        }

        class User
        {
            
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

        }

        class ValidateUser
        {

            public string Email { get; set; }

            public string Password { get; set; }

        }
    }
}
