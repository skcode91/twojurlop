namespace TwojUrlop.Common.Models.Entities;
public class Status
{
    public int Id { get; set; }
    public string Value { get; set; } = default!;
    public virtual IList<User> Users { get; set; } = default!;
}