using Membership.Database.Interfaces;

namespace Membership.Database.Entities;

public class FilmGenre 
{
    public int FilmId { get; set; }
    public int GenreId { get; set; }

    public virtual Film FilmName { get; set; } = null!;
    public virtual Genre GenreCategory { get; set; } = null!;
}
