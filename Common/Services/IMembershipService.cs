namespace Common.Services
{
    public interface IMembershipService
    {
        Task<FilmDTO> GetFilmAsync(int id);
        Task<List<FilmDTO>> GetFilmsAsync(bool freeOnly);

        //Task<SimilarFilmDTO> GetSimilarFilmsAsync();
        //Task<List<SimilarFilmDTO>> GetSimilarFilmAsync(int id);

        //Task<GenreDTO> GetGenresAsync();
        //Task<List<GenreDTO>> GetGenreAsync(int id);
    }
}