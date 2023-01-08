using Mapster;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DomainModel.Authorization.Commands.SignUp;
public class SignUpRequestMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SignUpRequest, User>()
        .IgnoreNonMapped(true)
        .Map(dest => dest.Email, src => src.Email)
        .Map(dest => dest.NormalizedEmail, src => src.Email.ToUpperInvariant())
        .Map(dest => dest.FirstName, src => src.FirstName)
        .Map(dest => dest.GenderId, src => src.GenderId)
        .Map(dest => dest.LastName, src => src.LastName)
        .Map(dest => dest.HiringDate, src => src.HiringDate )
        .Map(dest => dest.NumberOfYearsWorkedOnHiringDate, src => src.NumberOfYearsWorkedOnHiringDate);
    }
}
