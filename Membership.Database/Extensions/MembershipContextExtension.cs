using Common.DTOs;
using Membership.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Database.Extensions
{
    public static class MembershipContextExtension
    {
        public static async Task SeedMembershipData(this IDbService service)
        {
            var description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In porta urna urna, eu consequat elit egestas eu. Fusce tincidunt, nisl aliquam porta efficitur, arcu velit auctor ipsum, non congue diam turpis in erat. Proin sapien purus, tempus sit amet leo et, faucibus sollicitudin risus. Proin non sem hendrerit, volutpat ipsum sit amet, interdum lacus. Donec dictum sagittis interdum. Mauris nec lorem et felis efficitur commodo. Suspendisse ornare augue pharetra ullamcorper porttitor. Nulla vel augue lacus. Curabitur ac commodo lorem, eget vulputate erat. Aliquam pretium elit risus, quis porta nisi lobortis id. Praesent vel luctus risus, vulputate sagittis lectus. Integer sem velit, molestie quis tincidunt eu, facilisis ac elit. Proin nisl nisl, varius vel dui non, vehicula tincidunt lacus. Nunc tincidunt sapien sed risus placerat, sodales dictum leo mattis. Ut molestie urna non risus consequat, vitae facilisis dui mollis.";
            try
            {
                // I have to start with director, then do the genres.
                // then seed the films and assign directorid and genreid to the film
                // I think then it will fill up filmgenre table automatically ???
                // about the similar films, maybe I should fetch a list of film through a get method with this filter
                // that fetch the genreid for the parentfilm and find films with the similar genre id and return them and their ids.
                // pubic async Task<List<Film>> GetAsync<TEntity, TDto>(TDto dto) {
                //  var entity= await _db.Set<Film>.SingleAsync(e=> Film.id==dto.id);
                //  var genres = entity.genre().tolistasync();
                //  foreach (var genre in genres){ ????
                //  
                //  }
                // }

                service.SaveChangeAsync();

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
