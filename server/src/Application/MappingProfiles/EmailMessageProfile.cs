using Application.DTO.EmailMessage;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class EmailMessageProfile : Profile
    {
        public EmailMessageProfile()
        {
            CreateMap<AdminpanelEmailmessage, EmailMessageDto>()
                .ForMember(d => d.SenderUsername, o => o.MapFrom(s => s.Sender.Username))
                .ForMember(d => d.RecipientUsername, o => o.MapFrom(s => s.Recipient.Username));
        }
    }
}