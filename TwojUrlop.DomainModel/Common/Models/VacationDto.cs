namespace TwojUrlop.DomainModel.Common.Models;
public class VacationDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    public int UserId { get; set; }
    public virtual UserDto User { get; set; } = default!;
}