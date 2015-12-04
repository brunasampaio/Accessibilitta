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
                place.Id = exist.Id;
            }
        }
    }
}
