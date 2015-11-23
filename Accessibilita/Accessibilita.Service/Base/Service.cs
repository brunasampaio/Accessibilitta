using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilitta.Data.Context;
using Accessibilitta.Data.Repositories.Base;

namespace Accessibilitta.Service.Base
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected AccessibilittaContext _context;
        private Repository<TEntity> _repository;

        public Service()
        {
            _context = new AccessibilittaContext();
            _repository = new Repository<TEntity>(_context);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
            _repository.Save();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(TEntity obj)
        {
            _repository.Insert(obj);
            _repository.Save();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
            _repository.Save();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
