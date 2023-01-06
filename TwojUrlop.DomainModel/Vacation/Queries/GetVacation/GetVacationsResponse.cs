namespace TwojUrlop.DomainModel.Vacation.Queries.GetVacations;

public class GetVacationsResponse
{
    public IEnumerable<VacationsResponseItem>? Vacations {get; set;}
}