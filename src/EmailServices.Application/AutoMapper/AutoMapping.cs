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
        CreateMap<RequestRegisterTenant, Tenant>();

    }

    private void EntityToResponse()
    {

        //User
        CreateMap<Tenant, ResponseRegisterTenant>();

        //Accounts
    }
}
