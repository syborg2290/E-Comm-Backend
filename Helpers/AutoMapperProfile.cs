namespace backend.Helpers;

using AutoMapper;
using backend.Entities;
using backend.Models.Users;
using backend.Models.Customer;
using backend.Models.Address;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> User
        CreateMap<CreateRequest, User>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));

        // CreateRequest -> Customer
        CreateMap<CreateRequestCustomer, Customer>();
        CreateMap<CreateCustomer, Customer>();
        CreateMap<CreateRequestAddress, Address>();
    }
}