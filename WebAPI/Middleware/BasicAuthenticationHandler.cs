using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model.Services;

namespace WebAPI.Middleware
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IdealERPContext dbContext;
        private readonly IPasswordHasher hasher;
        
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,ILoggerFactory logger,UrlEncoder encoder, IdealERPContext context)
           : base(options, logger, encoder, null)
        {

            dbContext = context;

        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {

                if (!Request.Headers.ContainsKey("Authorization"))
                {

                    return AuthenticateResult.Fail("Missing Authorization Header");

                }

                //var headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                //if (!"Basic".Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase))
                //{
                //    return AuthenticateResult.Fail("Invalid Authorization Scheme");
                //}

                //var credentialBytes = Convert.FromBase64String(headerValue.Parameter!);

                // var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);

                //if (credentials.Length != 2)
                //{

                //    return AuthenticateResult.Fail("Invalid Authorization Header");
                //}

                // var email = credentials[0];
                // var password = credentials[1];

                var user = await dbContext.TblUserOrganizations.Where(x => x.User.Email == "").ToListAsync();

                //if (user.Count() != 0 || !hasher.VerifyPassword(user[0].User.PasswordHash, password))
                //{
                //    return AuthenticateResult.Fail("Invalid Username or Password");
                //}

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "123"), // Unique user ID
                    new Claim(ClaimTypes.Name, "Oluwafemi Taiwo"), // Username or email
                    new Claim(ClaimTypes.Role, "Admin") // Username or email
                };

                //foreach (var usr in user)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, usr.Role.Name));
                //}

                var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
                // Create ClaimsPrincipal that holds the ClaimsIdentity (and potentially multiple identities).
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                // Create an AuthenticationTicket which encapsulates the user's identity (ClaimsPrincipal) and scheme info.
                // AuthenticationTicket is the object used by ASP.NET Core to store and
                // track the authenticated user’s ClaimsPrincipal during an authentication session.
                var authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
                // Return success result with the AuthenticationTicket indicating successful authentication.

                //return AuthenticateResult.Success(authenticationTicket);

                return AuthenticateResult.Success(authenticationTicket);

            }
            catch
            {
                // If any unexpected error occurs during authentication, fail with a generic error.
                return AuthenticateResult.Fail("Error occurred during authentication");
            }

        }
    }
}
