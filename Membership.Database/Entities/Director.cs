namespace Membership.Database.Entities;

public class Director
{
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string Name { get; set; }


}
