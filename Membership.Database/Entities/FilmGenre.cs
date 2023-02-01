using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Database.Entities
{
    public class FilmGenre : IReferenceEntity
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public Film? FilmName { get; set; }
        public Genre? GenreCategory { get; set; }
    }
}
