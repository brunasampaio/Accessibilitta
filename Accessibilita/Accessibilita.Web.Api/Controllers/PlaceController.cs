﻿using System;
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
using Accessibilita.Data.Entities.Enumerators;

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

        [HttpGet]
        public Result<Place[]> GetTopAvailabilited(int limit)
        {
            return this.GetResult(_placeService.GetTopAvailabilited(limit));
        }

        [HttpGet]
        [Authorize]
        public Result<Place[]> GetRatedPlaceByAccount()
        {
            return this.GetResult(_placeService.GetRatedPlaceByAccount(this.GetAuthenticatedAccountId()));
        }

        [HttpGet]
        [Authorize]
        public Result<Place[]> SearchPlace(string lat, string lng, string query)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(query))
                parameters.Add("query", query);
            parameters.Add("ll", string.Format("{0},{1}", lat, lng));


            List<Place> result = new List<Place>();
            List<Venue> apiResult = _FSClient.SearchVenues(parameters);

            foreach (var venue in apiResult)
            {
                result.Add(this.ConvertPlace(venue));
            }

            return this.GetResult(result.ToArray());
        }

        private Place ConvertPlace(Venue venue)
        {
            Place newPlace = new Place()
            {
                ExternalId = venue.id,
                Name = venue.name,
                Description = venue.description,
                Latitude = venue.location.lat.ToString(),
                Longitude = venue.location.lng.ToString(),
                SourceType = SourceType.FourSquare
            };
            _placeService.InsertIfNotExist(newPlace);
            return newPlace;
        }
    }
}
