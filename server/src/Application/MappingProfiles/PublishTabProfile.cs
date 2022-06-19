using Application.DTO.PublishTab;
using Application.Features.PublishTab.Requests.Commands;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class PublishTabProfile : Profile
    {
        public PublishTabProfile()
        {
            CreateMap<RegabiturPublishtab, PublishTabDto>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"));

            CreateMap<CreatePublishTabCommand, RegabiturPublishtab>();

            CreateMap<UpdatePublishTabCommand, RegabiturPublishtab>();
        }
    }
}