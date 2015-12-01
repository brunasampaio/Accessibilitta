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
using Accessibilita.Web.Api.Models;
using Accessibilita.Web.Api.Controllers.Base;
using FourSquare.SharpSquare.Core;
using FourSquare.SharpSquare.Entities;

namespace Accessibilita.Web.Api.Controllers
{
    public class PlaceController : BaseController
    {
        IPlaceService _placeService;
        SharpSquare _FSClient;

        public PlaceController()
        {
            _placeService = new PlaceService();
            _FSClient = new SharpSquare(ConfigurationManager.AppSettings["FourSquareClientId"], ConfigurationManager.AppSettings["FourSquareClientSecret"]);
        }

        [HttpPost]
        public Result<bool> RatePlace(int placeId)
        {
            return this.GetResult(true);
        }

        [HttpGet]
        public Result<Rate[]> GetRatingPlace(int id)
        {            
            Place place = _placeService.GetById(id);
            return this.GetResult(place.Rates.ToArray());
        }

        [HttpGet]
        public Result<Place[]> SearchPlace(string lat, string lng, string query)
        {
            List<Place> result = new List<Place>();
            List<Venue> apiResult = _FSClient.SearchVenues(new Dictionary<string, string>() {
                { "ll", string.Format("{0},{1}", lat, lng) },
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

            return this.GetResult(result.ToArray());
        }
    }
}
