using Pitang.Sms.Treino.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Sms.Treino.Repository.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(int id);
        void UnDelete(int id);
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
    }
}
