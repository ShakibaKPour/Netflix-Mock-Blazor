namespace Common.DTOs;

public class FilmGenreDTO
{  
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public List<FilmDTO> Film { get; set; } = null!;
        public List<GenreDTO> Genre { get; set; } = null!;

}
