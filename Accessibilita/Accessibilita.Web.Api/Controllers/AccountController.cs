using System.Web.Http;
using System.Linq;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using Accessibilita.Data.Entities;
using Accessibilita.Web.Api.Controllers.Base;
using Accessibilita.Web.Api.Models;

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
        public Result<bool> Register(string name, string lastName, string email, string phone, string password)
        {            
            return this.GetResult(_accountService.Register(name, lastName,  email, phone, password));
        }

        [HttpPost]
        public Result<bool> UpdateAccount(string name, string lastName, string email, string phone)
        {           

            return this.GetResult(_accountService.UpdateAccount(ADMIN_CONST_ID, name, lastName, email, phone));
        }
    }
}
