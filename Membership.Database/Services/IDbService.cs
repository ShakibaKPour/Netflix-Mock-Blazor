namespace Membership.Database.Services;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TDto : class
        where TEntity : class, IEntity;

    Task<TDto> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TDto : class
        where TEntity: class, IEntity;

    Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TDto : class
        where TEntity : class, IEntity;

    Task<TEntity> AddReferenceAsync<TEntity, TDto>(TDto dto)
        where TEntity : class, IReferenceEntity
        where TDto : class;

    void Update<TEntity, TDto> (int id, TDto dto)
        where TDto : class
        where TEntity : class, IEntity;

    Task <bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;

    Task<bool> DeleteAsync<TEntity> (int id)
        where TEntity : class, IEntity;

    Task<bool> SaveChangeAsync();

    public string GetURI<TEntity>(TEntity entity) 
        where TEntity : class, IEntity;

    void Include<TEntity>()
        where TEntity : class, IEntity;

    
}
