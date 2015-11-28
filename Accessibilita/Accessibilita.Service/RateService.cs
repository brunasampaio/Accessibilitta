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
        public RateService()
        {
            _repository = new RateRepository(_context);
        }
    }
}
