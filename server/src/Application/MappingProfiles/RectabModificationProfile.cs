using Application.DTO.RectabModification;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class RectabModificationProfile : Profile
    {
        public RectabModificationProfile()
        {
            CreateMap<AdminpanelRectabmodification, RectabModificationDto>()
                .ForMember(d => d.StudentName, o => o.MapFrom(s => $"{s.Abiturient.FirstName} {s.Abiturient.LastName}"))
                .ForMember(d => d.AbiturientId, o => o.MapFrom(s => s.Abiturient.Id));
        }
    }
}