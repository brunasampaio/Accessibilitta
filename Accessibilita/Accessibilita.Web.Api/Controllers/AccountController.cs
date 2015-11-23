using System.Web.Http;
using System.Linq;
using Accessibilitta.Service;
using Accessibilitta.Service.Interfaces;
using Accessibilitta.Data.Entities;

namespace Accessibilitta.Web.Api.Controllers
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

        [HttpGet]
        public bool Login(string email, string password)
        {
            return true;
        }
    }
}
