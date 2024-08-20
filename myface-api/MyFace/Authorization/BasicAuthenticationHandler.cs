using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyFace.Models.Database;
using MyFace.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MyFace.Authorization
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly MyFaceDbContext _context;
        public BasicAuthenticationHandler(MyFaceDbContext context, IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization header"));
            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();

            if (!authorizationHeader.StartsWith("Basic ", System.StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header does not start with 'Basic'"));
            }

            var authBase64Decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationHeader.Replace("Basic ", "", StringComparison.OrdinalIgnoreCase)));
            var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);


            //Frontend creates the header with "Basic" => Basic a3BsYWNpZG8wOmtwbGFjaWRvMA==
            //From here, the backed extract the data removing "Basic " and separating username and passowrd
            // => a3BsYWNpZG8wOmtwbGFjaWRvMA==
            // => kplacido0:kplacido0
            // => username:password
            // backend assigns these values to the variables
            // => clientId: kplacido0
            // => clientSecret: kplacido0
            // finally we combine the secret with the salt to get a hashedPassword
            // and compare it to the hashedPassword stored in the database
            // if they match, the authentication is correct


            if (authSplit.Length != 2)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization header format"));
            }

            var clientId = authSplit[0];
            var clientSecret = authSplit[1];

            // get user from database
            var user = _context.Users.Where(user => user.Username == clientId).FirstOrDefault<User>();

            // return null if user not found
            if (user == null) return null;

            // get the hashed password from the database
            string dbPassword = user.HashedPassword;

            // get the salt from the database
            byte[] dbSalt = user.Salt;

            // hash the clientSecret with the salt from the database
            string hashedClientSecret = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: clientSecret,
                salt: dbSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            ));

            if (clientId != user.Username || hashedClientSecret != dbPassword)
            {
                return Task.FromResult(AuthenticateResult.Fail(string.Format("The secret is incorrect for the client '{0}'", clientId)));
            }

            var client = new BasicAuthenticationClient
            {
                AuthenticationType = BasicAuthenticationDefaults.AuthenticationScheme,
                IsAuthenticated = true,
                Name = clientId
            };

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
			{
				new Claim(ClaimTypes.Name, clientId)
			}));

			return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }
    }
}