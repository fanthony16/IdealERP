using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApiTest
{
    public class ApplicationCredentialGenerator
    {

        public string ApplicationCredentialGeneratorMain()
        {
            var nwAppReg = new ApplicationRegistration()
            {
                ApplicationId = GenerateApplicationId(),
                ApplicationName = "IdealERPUI",
                IsActive = true,
                Secret = GenerateSecret() 
            };

          var nwPersist = new ApplicationGenerationPersist();
          return  nwPersist.ApplicationRegistration(nwAppReg);

        }

        public static string GenerateApplicationId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateSecret(int size = 32)
        {

            byte[] randomBytes = new byte[size];
            RandomNumberGenerator.Fill(randomBytes);
            return Convert.ToBase64String(randomBytes);

        }
    }

    public class ApplicationRegistration
    {
        public string ApplicationId { get; set; } = default!;
        public string Secret { get; set; } = default!;
        public string ApplicationName { get; set; } = default!;
        public bool IsActive { get; set; }

       
    }

    public class ApplicationGenerationPersist { 
    
        public string ApplicationRegistration(ApplicationRegistration appreg)
        {
            var connectionString = "Data Source=DML01;Initial Catalog=IdealERP;User ID=sa;Password=staiwo16;Connect Timeout=30";

            string cmdstr = "insert into tblApplicationRegistration (ApplicationId,SecretHash,ApplicationName,IsActive) values (@ApplicationId,@SecretHash,@ApplicationName,@IsActive)";

            try
            {
                using var connection = new SqlConnection(connectionString);
                using var command = new SqlCommand(cmdstr, connection);

                command.Parameters.AddWithValue("@ApplicationId", appreg.ApplicationId);
                command.Parameters.AddWithValue("@SecretHash", HashSecret(appreg.Secret));
                command.Parameters.AddWithValue("@ApplicationName", appreg.ApplicationName);
                command.Parameters.AddWithValue("@IsActive", appreg.IsActive);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            } 
            catch (Exception ex)
            {
                return "An Error Occurred";
            }
         
                return $"{appreg.ApplicationId} : {appreg.Secret}";

        }
        public static string HashSecret(string secret)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(secret)));


            
            //using var sha256 = SHA256.Create();
            // Convert the input password string into a byte array using UTF-8 encoding.
            //var bytes = Encoding.UTF8.GetBytes(password);
            // Compute the SHA-256 hash of the password bytes.
            //var hash = sha256.ComputeHash(bytes);
            // Convert the hashed byte array into a Base64-encoded string to store or compare easily.
            //return Convert.ToBase64String(hash);


        }

    }
}
