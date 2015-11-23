using System;
using Accessibilitta.Data.Context;
using Accessibilitta.Data.Entities;
using Accessibilitta.Data.Repositories.Base;
using Accessibilitta.Data.Repositories.Interfaces;

namespace Accessibilitta.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AccessibilittaContext context) : base(context) { }

        public void Teste()
        {

        }

        public bool Login(string email, string password)
        {
            return true;
        }
        
    }
}
