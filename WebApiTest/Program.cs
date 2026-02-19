using System;
using System.Net.Http;
using System.Security.Cryptography;
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
            //using var sha = SHA256.Create();
            //string hsecret =  Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes("Xxq8/35ZpucRhRlHai31YsL9g5F5iLE7W2noOkCnQE4=")));



            // Create a new instance of SHA256 hashing algorithm.
            using var sha256 = SHA256.Create();
            // Convert the input password string into a byte array using UTF-8 encoding.
            var bytes = Encoding.UTF8.GetBytes("Xxq8/35ZpucRhRlHai31YsL9g5F5iLE7W2noOkCnQE4=");
            // Compute the SHA-256 hash of the password bytes.
            var hash = sha256.ComputeHash(bytes);
            // Convert the hashed byte array into a Base64-encoded string to store or compare easily.
            string hsecret = Convert.ToBase64String(hash);




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


            //var valUser = new ValidateUser()
            //{
            //    Email = "****",
            //    Password = "****"
            //};
            //await ValidateUserAsync(valUser);

            // await GetUsers();

            // var appgenregistration = new  ApplicationCredentialGenerator();
            // string appRegStaus = appgenregistration.ApplicationCredentialGeneratorMain();


            Console.WriteLine("User Validated Successfully!");



            


        }

        private static async Task GetUsers()
        {
            client.DefaultRequestHeaders.Add("X-App-Id", "IdealERP-Web");
            client.DefaultRequestHeaders.Add("X-App-Secret", "1111-2222-3333-4444");

            

            var response = await client.GetAsync("http://idealerp.com/api/User/Users?AccountType=U");

            return;
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
