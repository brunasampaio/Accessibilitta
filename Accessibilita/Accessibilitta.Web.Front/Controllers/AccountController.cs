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

                Place[] places = placeService.GetRatedPlaceByAccount(auth.AccountID);

                return View("~/Views/Account/Dashboard.cshtml", places);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection formCollection) {
            AccountService accountService = new AccountService();

            var account = accountService.Register(formCollection["name"], formCollection["lastName"], formCollection["email"], formCollection["phone"], formCollection["password"]);

            return View();
        }

    }
}