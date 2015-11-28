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
    public class PlaceService : Service<Place>, IPlaceService
    {
        private IPlaceRepository _repository;
        public PlaceService()
        {
            _repository = new PlaceRepository(_context);
        }
    }
}
