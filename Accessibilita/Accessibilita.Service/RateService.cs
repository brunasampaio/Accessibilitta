using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilita.Data.Entities;
using Accessibilita.Data.Repositories;
using Accessibilita.Data.Repositories.Interfaces;
using Accessibilita.Service.Base;
using Accessibilita.Service.Interfaces;

namespace Accessibilita.Service
{
    public class RateService : Service<Rate>, IRateService
    {
        private IRateRepository _repository;
        private IPlaceRepository _placeRepository;

        public RateService()
        {
            _repository = new RateRepository(_context);
            _placeRepository = new PlaceRepository(_context);
        }

        public bool RatePlace(int accountId, int placeId, int rateTypeId, int rating)
        {
            Place place = _placeRepository.GetById(placeId);
            Rate newRate = new Rate
            {
                Rating = rating,
                PlaceID = placeId,
                AccountID = accountId,
                RateTypeID = rateTypeId
            };
            this.Insert(newRate);

            if (place != null)
            {
                place.AverageRating = this._repository.Get(r => r.PlaceID == placeId).Average(r => r.Rating);
                _placeRepository.Update(place);
                _placeRepository.Save();
            }
            return newRate.RateID > 0;
        }

        public object[] RatesByPlace(int placeId)
        {
            //TODO:
            return (from r in _context.Rates
                    join rt in _context.RateTypes on r.RateTypeID equals rt.RateTypeID
                    join p in _context.Places on r.PlaceID equals p.PlaceID
                    select new { r.RateID, p.PlaceID, r.RateTypeID, r.Rating, RateTypeName = rt.Name, PlaceName = p.Name }).ToArray();
        }
    }
}

