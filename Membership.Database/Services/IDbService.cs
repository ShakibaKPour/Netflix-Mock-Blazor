using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Database.Services
{
    public interface IDbService
    {
        Task<List<TDto>> GetAsync<TEntity, TDto>()
            where TDto : class
            where TEntity : IEntity;

        Task<TDto> SingleAsync<TEntity, TDto>(
            Expression<Func<TEntity, bool>> expression)
            where TDto : class
            where TEntity: IEntity;

        Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
            where TDto : class
            where TEntity : IEntity;

        void Update<TEntity, TDto> (int id, TDto dto)
            where TDto : class
            where TEntity : IEntity;

        Task <bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : IEntity;

        Task<bool> DeleteAsync<TEntity> (int id)
            where TEntity : IEntity;

        Task<bool> SaveChangeAsync();

        public string GetURI<TEntity>(TEntity entity) 
            where TEntity : IEntity;

    }
}
