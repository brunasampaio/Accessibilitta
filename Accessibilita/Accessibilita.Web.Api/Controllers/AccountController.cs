using System.Web.Http;
using System.Linq;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using Accessibilita.Data.Entities;
using Accessibilita.Web.Api.Controllers.Base;
using Accessibilita.Web.Api.Models;
using Newtonsoft.Json.Linq;

namespace Accessibilita.Web.Api.Controllers
{
    public class AccountController : BaseController
    {
        IAccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        [HttpPost]
        public Result<bool> Register(JObject data)
        {
            string name = data.Value<string>("name");
            string lastName = data.Value<string>("lastName");
            string email = data.Value<string>("email");
            string phone = data.Value<string>("phone");
            string password = data.Value<string>("password");

            return this.GetResult(_accountService.Register(name, lastName, email, phone, password));
        }

        [HttpPost]
        [Authorize]
        public Result<bool> Update(JObject data)
        {
            string name = data.Value<string>("name");
            string lastName = data.Value<string>("lastName");
            string email = data.Value<string>("email");
            string phone = data.Value<string>("phone");
            string password = data.Value<string>("password");

            return this.GetResult(_accountService.UpdateAccount(this.GetAuthenticatedAccountId(), name, lastName, email, phone, password));
        }

        [HttpGet]
        [Authorize]
        public Result<object> GetInfo()
        {
            Account account = _accountService.GetById(this.GetAuthenticatedAccountId());

            return this.GetResult<object>(new { account.AccountID, account.Name, account.LastName, account.Email, account.Phone });
        }
    }
}
