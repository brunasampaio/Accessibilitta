using Accessibilita.Data.Context;
using Accessibilita.Data.Entities;
using Accessibilita.Data.Repositories.Base;
using Accessibilita.Data.Repositories.Interfaces;

namespace Accessibilita.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AccessibilitaContext context) : base(context) { }
    }
}
