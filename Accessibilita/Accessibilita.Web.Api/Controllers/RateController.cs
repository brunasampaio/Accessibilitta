﻿using System.Web.Http;
using Accessibilita.Data.Entities;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using Accessibilita.Web.Api.Controllers.Base;
using Accessibilita.Web.Api.Models;

namespace Accessibilita.Web.Api.Controllers
{
    public class RateController : BaseController
    {
        IAccountService _accountService;
        IRateService _rateService;
        IRateTypeService _rateTypeService;
        IPlaceService _placeService;


        public RateController()
        {
            this._rateService = new RateService();
            this._rateTypeService = new RateTypeService();
            this._accountService = new AccountService();
            this._placeService = new PlaceService();
        }

        [HttpGet]
        [Authorize]
        public Result<Rate[]> GetRates(int placeId)
        {

            return this.GetResult(_rateService.RatesByPlace(placeId));
        }

        [HttpPost]
        [Authorize]
        public Result<bool> RatePlace(int placeId, int rateTypeId, int rating)
        {
            Account user = _accountService.GetById(ADMIN_CONST_ID);
            Place place = _placeService.GetById(placeId);
            RateType rateType = _rateTypeService.GetById(rateTypeId);

            Rate newRate = new Rate
            {
                Rating = rating,
                Place = place,
                User = user,
                Type = rateType
            };
            _rateService.Insert(newRate);

            return this.GetResult(newRate.Id > 0);
        }
    }
}
