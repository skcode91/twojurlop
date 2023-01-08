using Mapster;
using TwojUrlop.DomainModel.Common.Models;
using Entities = TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DomainModel.Common;
public class VacationRequestDtoMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entities.VacationRequest, VacationRequestDto>()
            .IgnoreNonMapped(true)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.DaysCount, src => src.DaysCount)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.User, src => src.User)
            .Map(dest => dest.StatusId, src => src.StatusId);
    }
}