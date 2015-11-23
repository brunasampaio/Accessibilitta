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
    public class RateService : Service<Rate>, IRateService
    {
        private IRateRepository _repository;
        public RateService()
        {
            _repository = new RateRepository(_context);
        }
    }
}
