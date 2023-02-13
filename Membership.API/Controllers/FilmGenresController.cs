using Membership.Database.Entities;
using Membership.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmGenresController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmGenresController(IDbService db)
        {
            _db = db;
        }
       

        // POST api/<FilmGenresController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmGenreDTO dto)
        {
            try
            {
                if (dto is null) return Results.BadRequest();
                var entity = await _db.AddReferenceAsync<FilmGenre, FilmGenreDTO>(dto);
                if (await _db.SaveChangeAsync()) return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }

        // DELETE api/<FilmGenresController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(FilmGenreDTO dto)
        {
            try
            {
                if (!_db.Delete<FilmGenre, FilmGenreDTO>(dto)) return Results.NotFound();
                if (await _db.SaveChangeAsync())
                    return Results.NoContent();
            }
            catch { }

            return Results.BadRequest();
        }
    }
}
