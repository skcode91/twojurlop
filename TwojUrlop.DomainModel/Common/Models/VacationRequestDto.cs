namespace TwojUrlop.DomainModel.Common.Models;
public class VacationRequestDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual UserDto User { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    public int StatusId { get; set; }
}