using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class FilmGenre
    {
        public int FilmId { get; set; } = default;
        public int GenreId { get; set; } = default;

        public FilmGenre(int filmId, int genreId)
        {
            FilmId= filmId;
            GenreId= genreId;
        }
    }
}
