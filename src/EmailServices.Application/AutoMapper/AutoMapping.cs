using AutoMapper;
using EmailServices.Communication.Requests;
using EmailServices.Communication.Response;
using EmailServices.Domain.Entities;

namespace EmailServices.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterTenant, Tenant>()
            .ForMember(dest => dest.Create_at, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Update_at, opt => opt.MapFrom(_ => DateTime.UtcNow));

    }

    private void EntityToResponse()
    {

        //User
        CreateMap<Tenant, ResponseRegisterTenant>();

        //Accounts
    }
}
