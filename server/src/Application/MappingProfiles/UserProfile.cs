using Application.DTO.Documentuser;
using Application.DTO.User;
using Application.Features.Users.Requests.Commands;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Documentuser
            CreateMap<RegabiturDocumentuser, DocumentuserDto>();

            // User
            CreateMap<UpdateUserCommand, AuthUser>();
            CreateMap<UpdateUserCommand, RegabiturCustomuser>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<AuthUser, UserDto>();

            CreateMap<RegabiturCustomuser, UserDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.User.Id))
                .ForMember(d => d.Documents, o => o.MapFrom(s => s.User.RegabiturDocumentusers))
                .IncludeMembers(s => s.User);
        }
    }
}