using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilitta.Data.Entities;
using Accessibilitta.Data.Repositories;
using Accessibilitta.Data.Repositories.Interfaces;
using Accessibilitta.Service.Base;
using Accessibilitta.Service.Interfaces;

namespace Accessibilitta.Service
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
