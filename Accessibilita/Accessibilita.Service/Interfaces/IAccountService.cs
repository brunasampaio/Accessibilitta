using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilita.Data.Entities;
using Accessibilita.Service.Base;

namespace Accessibilita.Service.Interfaces
{
    public interface IAccountService : IService<Account>, IDisposable
    {
        Account Authenticate(string userName, string password);
        bool Register(string name, string lastName, string email, string phone, string password);
        bool UpdateAccount(int id, string name, string lastName, string email, string phone, string password);
    }
}
