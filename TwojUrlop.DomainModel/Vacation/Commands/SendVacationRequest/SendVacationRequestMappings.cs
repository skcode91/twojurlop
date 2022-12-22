using Mapster;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
public class SendVacationRequestMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SendVacationRequestRequest, VacationRequest>()
        .IgnoreNonMapped(true)
        .Map(dest => dest.UserId, src => src.UserId)
        .Map(dest => dest.StartDate, src => src.StartDate)
        .Map(dest => dest.EndDate, src => src.EndDate)
        .Map(dest => dest.DaysCount, src => src.DaysCount);
    }
}