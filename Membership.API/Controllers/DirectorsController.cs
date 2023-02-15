using Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDbService _db;

        public DirectorsController(IDbService db)
        {
            _db = db;
        }
        // GET: api/<DirectorsController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
               // _db.Include<Film>();

                var directors = await _db.GetAsync<Director, DirectorDTO>();
                return Results.Ok(directors);

            }
            catch { }
            return Results.NotFound();
        }

        // GET api/<DirectorsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                //_db.Include<Film>();
                var director = await _db.GetAsync<Director, DirectorDTO>(d=> d.Id.Equals(id));
                return Results.Ok(director);
            }
            catch { }
            return Results.NotFound();
        }

        // POST api/<DirectorsController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();
                var director = await _db.AddAsync<Director, DirectorCreateDTO>(dto);
                var success = await _db.SaveChangeAsync();
                if (!success) return Results.BadRequest();
                return Results.Created(_db.GetURI<Director>(director), director);
            }
            catch { }
            return Results.BadRequest();
        }

        // PUT api/<DirectorsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DirectorEditDTO dto)
        {
            try
            {
                if (dto== null || id!=dto.Id) return Results.BadRequest();
              
                var exists= await _db.AnyAsync<Director>(d=> d.Id.Equals(id));
                if (!exists) return Results.BadRequest();

                _db.Update<Director, DirectorEditDTO>(id, dto);

                var success = await _db.SaveChangeAsync();
                if (!success) return Results.BadRequest();

                return Results.NoContent();

            }
            catch { }
            return Results.BadRequest("Unable to update the entity");
        }

        // DELETE api/<DirectorsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var entity = await _db.DeleteAsync<Director>(id);
                if (!entity) return Results.NotFound();
                var success = await _db.SaveChangeAsync();
                if (!success) return Results.NotFound();
                return Results.NoContent();

            }
            catch { }
            return Results.BadRequest("Unable to delete the entity");
        }
    }
}
