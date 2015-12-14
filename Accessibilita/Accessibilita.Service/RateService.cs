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

        public bool RatePlace(int accountId, int placeId, Rate[] rates)
        {
            bool hasError = false;
            if (rates == null)
            {
                hasError = true;
            }
            else
            {
                Place place = _placeRepository.GetById(placeId);
                foreach (var rate in rates)
                {
                    rate.AccountID = accountId;
                    rate.PlaceID = placeId;

                    Rate existRate = _repository.Get(r => r.PlaceID == placeId && r.AccountID == accountId && r.RateTypeID == rate.RateTypeID).FirstOrDefault();
                    if (existRate != null)
                    {
                        existRate.Rating = rate.Rating;
                        this.Update(existRate);
                    }
                    else
                        this.Insert(rate);

                    if (hasError == false)
                        hasError = (existRate == null && rate.RateID == 0);
                }

                if (place != null)
                {
                    place.AverageRating = this._repository.Get(r => r.PlaceID == placeId).Average(r => r.Rating);
                    _placeRepository.Update(place);
                    _placeRepository.Save();
                }
            }

            return !hasError;
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

