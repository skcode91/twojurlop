using Mapster;
using Entities = TwojUrlop.Common.Models.Entities;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;
public class GetUserBaseInfoResponseMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entities.User, GetUserBaseInfoResponse>()
        .IgnoreNonMapped(true)
        .Map(dest => dest.Email, src => src.Email)
        .Map(dest => dest.FirstName, src => src.FirstName)
        .Map(dest => dest.LastName, src => src.LastName)
        .Map(dest => dest.GenderId, src => src.GenderId)
        .Map(dest => dest.RoleId, src => src.RoleId)
        .Map(dest => dest.HiringDate, src => src.HiringDate)
        .Map(dest => dest.NumberOfYearsWorkedOnHiringDate, src => src.NumberOfYearsWorkedOnHiringDate);
    }
}