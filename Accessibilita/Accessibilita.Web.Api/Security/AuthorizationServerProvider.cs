using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Accessibilita.Data.Entities;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using Microsoft.Owin.Security.OAuth;

namespace Accessibilita.Web.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            using (IAccountService service = new AccountService())
            {
                Account user = service.Authenticate(context.UserName, context.Password);
                if (user != null)
                {
                    

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("sub", context.UserName));
                    identity.AddClaim(new Claim("role", "user"));
                    context.Validated(identity);
                    return Task.FromResult<object>(null);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return Task.FromResult<object>(null);
                }
            }


        }
    }
}