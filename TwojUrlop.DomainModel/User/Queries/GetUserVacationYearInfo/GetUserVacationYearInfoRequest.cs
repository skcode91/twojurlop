namespace TwojUrlop.DomainModel.User.Queries.GetUserVacationYearInfo;
public class GetUserVacationYearInfoRequest
{
    public int CurrentUserId { get; set; }
    public int UserId { get; set; }
    public int Year { get; set; }
}