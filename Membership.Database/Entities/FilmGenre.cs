using Membership.Database.Interfaces;

namespace Membership.Database.Entities;

public class FilmGenre 
{
    public int FilmId { get; set; }
    public int GenreId { get; set; }

    public Film? FilmName { get; set; }
    public Genre? GenreCategory { get; set; }
}
