using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Accessibilita.Data.Entities;
using Accessibilita.Service;
using Accessibilita.Service.Interfaces;
using FourSquare.SharpSquare.Core;
using FourSquare.SharpSquare.Entities;

namespace Accessibilita.Web.Api.Controllers
{
    public class PlaceController : ApiController
    {
        IPlaceService _placeService;
        SharpSquare _FSClient;

        public PlaceController()
        {
            _placeService = new PlaceService();
            _FSClient = new SharpSquare(ConfigurationManager.AppSettings["FourSquareClientId"], ConfigurationManager.AppSettings["FourSquareClientSecret"]);
        }

        [HttpGet]
        public JsonResult<List<Place>> SearchPlace(string latitude, string longitude, string query)
        {
            List<Place> result = new List<Place>();
            List<Venue> apiResult = _FSClient.SearchVenues(new Dictionary<string, string>() {
                { "ll", string.Format("{0},{1}", latitude, longitude) },
                { "query", query}
            });
            foreach (var venue in apiResult)
            {
                result.Add(new Place()
                {
                    Name = venue.name,
                    Description = venue.description,
                    Latitude = venue.location.lat.ToString(),
                    Longitude = venue.location.lng.ToString()
                });
            }
            return Json(result);
        }
    }
}
