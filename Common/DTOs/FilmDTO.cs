using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        
        public string? Description { get; set; }
       
        public DateTime? Released { get; set; }
        public int? DirectorId { get; set; }
        
        public bool? Free { get; set; }
        public string? ImageUrl { get; set; }
        public string? FilmUrl { get; set; }
    }
}
