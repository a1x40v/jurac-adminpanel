using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class PublishRecTabProfile : Profile
    {
        public PublishRecTabProfile()
        {
            CreateMap<RegabiturPublishrectab, PublishRecTabDto>();

            CreateMap<CreatePublishRecTabCommand, RegabiturPublishrectab>()
                .ForMember(d => d.Sogl, (o) => o.MapFrom(s => s.Sogl ? "Подано" : "Не подано"))
                .ForMember(d => d.SostType, (o) => o.MapFrom(s => s.SostType ? "Рекомендован" : "Не рекомендован"))
                .ForMember(d => d.Advantage, (o) => o.MapFrom(s => s.Advantage ? "Имеет" : "Не имеет"))
                .ForMember(d => d.SumPoints, o => o.MapFrom(s => 
                    s.Individ + s.RusPoint + s.ObshPoint + s.KpPoint + s.SpecPoint + s.ForeignLanguagePoint + s.GpPoint 
                    + s.HistoryPoint + s.OkpPoint + s.TgpPoint + s.UpPoint));

            CreateMap<UpdatePublishRecTabCommand, RegabiturPublishrectab>()
                .ForMember(d => d.Sogl, (o) => o.MapFrom(s => s.Sogl ? "Подано" : "Не подано"))
                .ForMember(d => d.SostType, (o) => o.MapFrom(s => s.SostType ? "Рекомендован" : "Не рекомендован"))
                .ForMember(d => d.Advantage, (o) => o.MapFrom(s => s.Advantage ? "Имеет" : "Не имеет"))
                .ForMember(d => d.SumPoints, o => o.MapFrom(s => 
                    s.Individ + s.RusPoint + s.ObshPoint + s.KpPoint + s.SpecPoint + s.ForeignLanguagePoint + s.GpPoint 
                    + s.HistoryPoint + s.OkpPoint + s.TgpPoint + s.UpPoint));
        }
    }
}
