using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace Accessibilita.Web.Api.Models
{
    public class Result<T>
    {

        public Result(T data, bool hasError = false, string errorMessage = null)
        {
            this.Data = data;
            this.HasError = hasError;
            this.ErrorMessage = errorMessage;
        }

        public T Data { get; private set; }
        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }
    }
}