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
    public class AccountService : Service<Account>, IAccountService
    {
        private IAccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository(_context);
        }

        public Account Authenticate(string userName, string password)
        {
            return _repository.Get(a => a.Email == userName && a.Password == password).FirstOrDefault();
        }

        public bool UpdateAccount(int id, string name, string lastName, string email, string phone, string password)
        {
            Account account = _repository.GetById(id);
            if (account != null)
            {
                account.Name = name;
                account.LastName = lastName;
                account.Email = email;
                account.Phone = phone;
                account.Password = password;

                if (IsValid(account))
                {
                    this.Update(account);
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public bool Register(string name, string lastName, string email, string phone, string password)
        {
            Account newUser = new Account()
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Password = password
            };
            if (IsValid(newUser))
            {
                this.Insert(newUser);
                return newUser.AccountID > 0;
            }
            else
                return false;
        }

        private bool IsValid(Account account)
        {
            if (string.IsNullOrEmpty(account.Name))
                return false;
            if (string.IsNullOrEmpty(account.LastName))
                return false;
            if (string.IsNullOrEmpty(account.Email))
                return false;
            if (string.IsNullOrEmpty(account.Password))
                return false;
            return true;
        }
    }
}
