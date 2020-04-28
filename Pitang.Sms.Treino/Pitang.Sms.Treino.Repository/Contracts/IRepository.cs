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
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(int id);
        void UnDelete(int id);
        Task<IEnumerable<T>> FindAllAsync(bool getDeleted = false);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate, bool getDeleted = false);
    }
}
