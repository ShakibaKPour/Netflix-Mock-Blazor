using Membership.Database.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Database.Entities;

public class SimilarFilm 
{
    public int FilmId { get; set; }
    public virtual Film Film { get; set; }
    public int SimilarFilmId { get; set; }
    [ForeignKey("SimilarFilmId")]
    public virtual Film Similar { get; set; }
}
