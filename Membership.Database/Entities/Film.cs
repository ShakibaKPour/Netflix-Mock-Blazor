using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Database.Entities
{
    public class Film : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? Title { get; set; }
        [MaxLength(200), Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? Released { get; set;}
        public int? DirectorId { get; set;}
        [Required]
        public bool? Free { get; set;}
        [MaxLength(1024), Required]
        public string? FilmUrl { get; set; }
        [MaxLength(225), Required]
        public string? ImageUrl { get; set; }
        public Director? Directors { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }

        public virtual ICollection<SimilarFilms>? SimilarFilms { get;set; }

    }
}
