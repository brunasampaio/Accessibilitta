using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
