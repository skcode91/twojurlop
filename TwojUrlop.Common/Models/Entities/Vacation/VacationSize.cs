namespace TwojUrlop.Common.Models.Entities;
public class VacationSize
{
    public int Id { get; set; }
    public int Value { get; set; }
    public virtual IList<UserVacationInfo> VacationInfos { get; set; } = default!;
}