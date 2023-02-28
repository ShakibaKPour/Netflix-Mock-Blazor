namespace Common.DTOs;

public class SimilarFilmDTO
{
    public int FilmId { get; set; }
    public int SimilarFilmId { get; set; }

   // public FilmInfoDTO? Similar { get; set; }
}

public class SimilarFilmInfoDTO : SimilarFilmDTO
{
    public FilmInfoDTO? Similar { get; set; }
}
