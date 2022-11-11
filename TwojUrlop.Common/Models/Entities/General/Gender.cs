namespace TwojUrlop.Common.Models.Entities;
public class Gender
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<User> Users { get; set; } = default!;
}