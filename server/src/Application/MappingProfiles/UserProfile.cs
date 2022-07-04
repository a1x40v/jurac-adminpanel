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

            CreateMap<AuthUser, UserDto>()
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.DateOfBirth : DateTime.MinValue))
                .ForMember(d => d.Patronymic, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.Patronymic : String.Empty))
                .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.PhoneNumber : String.Empty))
                .ForMember(d => d.SendingStatus, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.SendingStatus : String.Empty))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.Address : String.Empty))
                .ForMember(d => d.CommentAdmin, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.CommentAdmin : String.Empty))
                .ForMember(d => d.DateOfDoc, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.DateOfDoc : String.Empty))
                .ForMember(d => d.NameUz, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.NameUz : String.Empty))
                .ForMember(d => d.Passport, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.Passport : String.Empty))
                .ForMember(d => d.Snils, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.Snils : String.Empty))

                .ForMember(d => d.CompleteFlag, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.CompleteFlag : false))
                .ForMember(d => d.AgreementFlag, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.AgreementFlag : false))
                .ForMember(d => d.WorkFlag, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.WorkFlag : false))
                .ForMember(d => d.SuccessFlag, o => o.MapFrom(s => s.RegabiturCustomuser != null ? s.RegabiturCustomuser.SuccessFlag : false))

                .ForMember(d => d.Documents, o => o.MapFrom(s => s.RegabiturDocumentusers))
                .ForMember(d => d.ChoicesProfiles, o => o.MapFrom(s =>
                    s.RegabiturAdditionalinfo.RegabiturAdditionalinfoEducationProfiles
                        .Select(x => x.Choicesprofile.Description)));
        }
    }
}