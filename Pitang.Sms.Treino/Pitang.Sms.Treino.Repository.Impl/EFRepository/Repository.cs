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

        public async Task<T> AddAsync(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();

            return await Task.FromResult(_entities.FindAsync(entity.Id).Result);
        }      

        public async Task<IEnumerable<T>> FindAllAsync(bool getDeleted = false)
        {
            var query = _entities.AsQueryable();
            query = query.Select(e => e);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate, bool getDeleted = false)
        {
            var query = _entities.AsQueryable();
            query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public void Delete(int id)
        {
            var unDeletedEntity = FindByAsync(e => e.Id == id);
            _entities.FindAsync(unDeletedEntity).Result.IsDeleted = true;
            _context.SaveChanges();
        }

        public void UnDelete(int id)
        {
            var unDeletedEntity = FindByAsync(e => e.Id == id);
            _entities.FindAsync(unDeletedEntity).Result.IsDeleted = false;
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _entities.Attach(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
