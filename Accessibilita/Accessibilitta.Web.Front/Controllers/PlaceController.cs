using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accessibilita.Data.Entities;
using Accessibilita.Service;

namespace Accessibilitta.Web.Front.Controllers
{
    public class PlaceController : Controller
    {
        public ActionResult Home() {
            Place[] places = GetTopAvailabilited();
            //Place[] places = new Place[0];
            return View(places);
        }

        private Place[] GetTopAvailabilited() {
            PlaceService placeService = new PlaceService();

            Place[] places = placeService.GetTopAvailabilited(10);

            return places;
        }
    }
}