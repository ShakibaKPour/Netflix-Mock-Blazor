using Membership.Database.Interfaces;

namespace Membership.Database.Entities;

public class SimilarFilm 
{
    public int ParentFilmId { get; set; }
    public Film ParentFilm { get; set; }
    public int SimilarFilmId { get; set; }
    public Film Similar { get; set; }
}
