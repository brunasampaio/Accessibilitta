using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Accessibilita.Data.Entities;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using Accessibilita.Web.Api.Controllers.Base;
using Accessibilita.Web.Api.Models;

namespace Accessibilita.Web.Api.Controllers
{
    public class RateTypeController : BaseController
    {
        IRateTypeService _service;

        public RateTypeController()
        {
            _service = new RateTypeService();
        }

        [Authorize]
        [HttpGet]        
        public Result<RateType[]> GetAll()
        {
            return this.GetResult(_service.GetAll().ToArray());
        }
    }
}
