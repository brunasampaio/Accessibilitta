﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessibilita.Data.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);        
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        int Save();
    }
}
