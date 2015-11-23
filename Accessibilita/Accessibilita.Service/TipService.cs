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
    public class TipService : Service<Tip>, ITipService
    {
        private ITipRepository _repository;
        public TipService()
        {
            _repository = new TipRepository(_context);
        }
    }
}
