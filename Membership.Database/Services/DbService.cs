using Membership.Database.Interfaces;

namespace Membership.Database.Services;

public class DbService : IDbService
{
    private readonly MembershipContext _db;
    private readonly IMapper _mapper;

    public DbService(MembershipContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) 
        where TEntity : class, IEntity => 
            await _db.Set<TEntity>().AnyAsync(expression);
    

    public async Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity
    {
        try
        {
            var entity = await SingleAsync<TEntity>(e => e.Id == id);
            if (entity is null) return false;
            _db.Remove(entity);
        } catch(Exception ex)
        {
            throw;
        }
        return true;
    }

    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class, IEntity
        where TDto : class
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        var dtos = _mapper.Map<List<TDto>>(entities);
        return dtos;
    }

    public async Task<List<TDto>> GetAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entities = await _db.Set<TEntity>().Where(expression).ToListAsync();
        var dtos = _mapper.Map<List<TDto>>(entities);
        return dtos;
    }

    public string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity
        => $"/{typeof(TEntity).Name.ToLower()}s/{entity.Id}";

    public async Task<bool> SaveChangeAsync() => await _db.SaveChangesAsync() > 0;

    public async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity => await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
    

    public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity =  await SingleAsync(expression);
        return _mapper.Map<TDto>(entity);
    }

    public void Update<TEntity, TDto>(int id, TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _db.Set<TEntity>().Update(entity);
    }

    public void Include<TEntity>()
        where TEntity : class, IEntity
    {
        var propertyNames= _db.Model.FindEntityType(typeof(TEntity))?.GetNavigations().Select(e => e.Name);

        if (propertyNames is null) return;

        foreach (var names in propertyNames)
            _db.Set<TEntity>().Include(names).Load();

    }

    public async Task<TEntity> AddReferenceAsync<TEntity, TDto>(TDto dto)
        where TEntity : class, IReferenceEntity
        where TDto : class
    {
        var refEntity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(refEntity);
        return refEntity;
    }
}
