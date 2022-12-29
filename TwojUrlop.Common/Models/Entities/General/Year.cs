namespace TwojUrlop.Common.Models.Entities;
public class Year
{
    public int Id { get; set; }
    public int Value { get; set; }
    public virtual IList<UserVacationInfo> UserVacationInfos { get; set; } = default!;
    public virtual IList<VacationYear> VacationYears { get; set; } = default!;
    public virtual IList<VacationRequestYear> VacationRequestYears { get; set; } = default!;
}