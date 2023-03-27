using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Repositories.Interfaces
{
    public interface IBaseReposiotry<TEntity> 
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        Task Add(TEntity entity);

        void Update(Guid id, TEntity entity);

        Task Delete(Guid id);

        Task Save();

    }
}
