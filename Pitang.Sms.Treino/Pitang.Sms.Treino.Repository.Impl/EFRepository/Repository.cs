using Microsoft.EntityFrameworkCore;
using Pitang.Sms.Treino.Entities;
using Pitang.Sms.Treino.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Sms.Treino.Repository.Impl.EFRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected DataContext _context;
        protected DbSet<T> _entities;

        public Repository(DataContext dbContext)
        {
            _context = dbContext;
            _entities = _context.Set<T>();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();

            return Task.FromResult(_entities.Find(entity.Id));
        }

        public void Delete(T id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            /* Arrumar isso aqui
            return await _entities.AsAsyncEnumerable(); 
            */
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void UnDelete(T id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
