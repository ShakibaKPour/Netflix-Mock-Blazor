using Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IDbService _db;

        public GenresController(IDbService db)
        {
            _db = db;
        }
        // GET: api/<GenresController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                _db.Include<Genre>();
                _db.IncludeRef<FilmGenre>();
                var entities = await _db.GetAsync<Genre, GenreDTO>();
                return Results.Ok(entities);
            }
            catch { }
            return Results.NotFound();
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            { 
                _db.Include<Genre>();
                _db.IncludeRef<FilmGenre>();

                var entity = _db.SingleAsync<Genre, GenreDTO>(g=> g.Id == id);
                return Results.Ok(entity);

            }catch { }

            return Results.NotFound();
        }

        // POST api/<GenresController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] GenreCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                var entity = await _db.AddAsync<Genre, GenreCreateDTO>(dto);
                var success = await _db.SaveChangeAsync();
                if (!success) return Results.BadRequest();
                return Results.Created(_db.GetURI<Genre>(entity),entity);
            }
            catch { }
            return Results.BadRequest();
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] GenreEditDTO dto)
        {
            try
            {
                if (dto == null || dto.Id != id) return Results.NotFound();

                var exists = await _db.AnyAsync<Genre>(g => g.Id == id);
                if (!exists) return Results.NotFound("Could not find entity");

                _db.Update<Genre, GenreEditDTO>(dto.Id, dto);

                var success = await _db.SaveChangeAsync();
                if (!success) return Results.BadRequest();
                return Results.NoContent();
            }
            catch { }
            return Results.BadRequest("Unable to update the entity");

        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var success= await _db.DeleteAsync<Genre>(id); 
                if (!success) return Results.NotFound();
                success = await _db.SaveChangeAsync();
                if (!success) return Results.BadRequest();

                return Results.NoContent();

            }catch { }
            return Results.BadRequest("Unable to delete the entity"); ;
        }
    }
}
