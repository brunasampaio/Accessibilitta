using System.Web.Http;
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
        public Result<object[]> GetRatesByPlace(int placeId)
        {

            return this.GetResult(_rateService.RatesByPlace(placeId));
        }

        [HttpPost]
        [Authorize]
        public Result<bool> RatePlace(int placeId, int rateTypeId, int rating)
        {
            return this.GetResult(_rateService.RatePlace(ADMIN_CONST_ID, placeId, rateTypeId, rating));
        }
    }
}
