using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Accessibilita.Web.Api.Models;

namespace Accessibilita.Web.Api.Controllers.Base
{
    public class BaseController : ApiController
    {
        public Result<T> GetResult<T>(T data, bool hasError = false, string message = "")
        {
            return new Result<T>(data, hasError, message);
        }

        protected int GetAuthenticatedAccountId()
        {
            int accountId = 0;
            Claim claim = this.Request.GetOwinContext().Authentication.User.Claims.FirstOrDefault(c => c.Type == "AccountID");
            if (claim != null)
            {
                int.TryParse(claim.Value, out accountId);
            }
            return accountId;
        }
    }
}
