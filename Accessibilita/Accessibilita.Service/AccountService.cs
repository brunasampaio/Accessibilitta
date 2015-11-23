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
    public class AccountService : Service<Account>, IAccountService
    {
        private IAccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository(_context);
        }
    }
}
