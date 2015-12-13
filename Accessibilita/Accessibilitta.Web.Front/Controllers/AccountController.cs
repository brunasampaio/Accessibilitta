using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accessibilita.Data.Entities;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;

namespace Accessibilitta.Web.Front.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection) {

            AccountService accountService = new AccountService();

            Account auth = accountService.Authenticate(formCollection["user"], formCollection["pass"]);
            
            if (auth != null)
            {
                Session.Add("Account", auth);

                PlaceService placeService = new PlaceService();

              //  placeService.

                return View();
            }

            return View();
        }
    }
}