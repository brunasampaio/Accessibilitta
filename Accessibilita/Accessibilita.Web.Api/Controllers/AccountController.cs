using System.Web.Http;
using System.Linq;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using Accessibilita.Data.Entities;
using Accessibilita.Web.Api.Controllers.Base;

namespace Accessibilita.Web.Api.Controllers
{
    public class AccountController : BaseController
    {
        IAccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        [HttpGet]
        [Authorize]
        public Account[] Teste()
        {
            var teste = _accountService.GetAll();
            return teste.ToArray();
        }
    }
}
