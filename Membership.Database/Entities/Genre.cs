using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Database.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? Name { get; set; }

        public virtual ICollection<Film>? Films { get; set; }
    }
}
