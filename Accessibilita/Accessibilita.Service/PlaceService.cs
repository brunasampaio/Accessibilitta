using System.Linq;
using Accessibilita.Data.Entities;
using Accessibilita.Data.Entities.Enumerators;
using Accessibilita.Data.Repositories;
using Accessibilita.Data.Repositories.Interfaces;
using Accessibilita.Service.Base;
using Accessibilita.Service.Interfaces;

namespace Accessibilita.Service
{
    public class PlaceService : Service<Place>, IPlaceService
    {
        private IPlaceRepository _repository;
        public PlaceService()
        {
            _repository = new PlaceRepository(_context);
        }

        public Place[] GetTopAvailabilited(int limit)
        {
            return _repository.GetAll().Where(p => p.AverageRating > 0).OrderByDescending(p => p.AverageRating).Take(limit).ToArray();
        }

        public Place[] GetRatedPlaceByAccount(int accountId)
        {
            return (from p in _context.Places
                    join r in _context.Rates on p.PlaceID equals r.PlaceID
                    where r.AccountID == accountId
                    select p).Distinct().ToArray();
        }

        public void InsertIfNotExist(Place place)
        {
            Place exist = _repository.Get(p => p.ExternalId == place.ExternalId && p.SourceType == SourceType.FourSquare).SingleOrDefault();
            if (exist == null)
            {
                _repository.Insert(place);
                _repository.Save();
            }
            else
            {
                place.PlaceID = exist.PlaceID;
                place.AverageRating = exist.AverageRating;
            }
        }
    }
}
