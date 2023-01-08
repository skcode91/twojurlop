using TwojUrlop.DomainModel.Common;
using TwojUrlop.DomainModel.Common.Models;

namespace TwojUrlop.DomainModel.User.Queries.GetUserVacationYearInfo;
public class GetUserVacationYearInfoResponse
{
    public required UserDto User { get; set; }
    public IEnumerable<VacationDto> Vacations { get; set; } = default!;
    public IEnumerable<VacationRequestDto> Requests { get; set; } = default!;
    public int DaysTotal { get; set; }
    public int DaysLeft { get; set; }
    public int Year { get; set; }
}