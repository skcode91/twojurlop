using Mapster;
using Entities = TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DomainModel.Common;
public class UserDtoMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entities.User, UserDto>()
            .IgnoreNonMapped(true)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.GenderId, src => src.GenderId)
            .Map(dest => dest.StatusId, src => src.StatusId)
            .Map(dest => dest.RoleId, src => src.RoleId)
            .Map(dest => dest.HiringDate, src => src.HiringDate)
            .Map(dest => dest.NumberOfYearsWorkedOnHiringDate, src => src.NumberOfYearsWorkedOnHiringDate);

        config.NewConfig<UserDto, Entities.User>()
            .IgnoreNonMapped(true)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.GenderId, src => src.GenderId)
            .Map(dest => dest.StatusId, src => src.StatusId)
            .Map(dest => dest.RoleId, src => src.RoleId)
            .Map(dest => dest.HiringDate, src => src.HiringDate)
            .Map(dest => dest.NumberOfYearsWorkedOnHiringDate, src => src.NumberOfYearsWorkedOnHiringDate);
    }
}