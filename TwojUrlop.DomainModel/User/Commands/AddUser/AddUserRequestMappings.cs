using Mapster;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;

namespace TwojUrlop.DomainModel.User.Commands.AddUser;

public class AddUserRequestMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddUserRequest, SignUpRequest>()
        .IgnoreNonMapped(true)
        .Map(dest => dest.Email, src => src.Email)
        .Map(dest => dest.FirstName, src => src.FirstName)
        .Map(dest => dest.GenderId, src => src.GenderId)
        .Map(dest => dest.LastName, src => src.LastName)
        .Map(dest => dest.HiringDate, src => src.HiringDate)
        .Map(dest => dest.NumberOfYearsWorkedOnHiringDate, src => src.NumberOfYearsWorkedOnHiringDate)
        .Map(dest => dest.PESEL, src => src.PESEL)
        .Map(dest => dest.Password, src => src.Password);
    }
}