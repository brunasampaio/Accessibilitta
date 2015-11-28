using System.Web.Http;
using System.Linq;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using Accessibilita.Data.Entities;

namespace Accessibilita.Web.Api.Controllers
{
    public class AccountController : ApiController
    {
        IAccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();


        }

        [HttpGet]
        public Account[] Teste()
        {
            var teste = _accountService.GetAll();
            return teste.ToArray();
        }
    }
}
