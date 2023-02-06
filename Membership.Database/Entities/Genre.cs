﻿namespace Membership.Database.Entities;

public class Genre
{
    public Genre()
    {
        Films = new HashSet<Film>();
    }
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string Name { get; set; }

    public virtual ICollection<Film> Films { get; set; }
}
