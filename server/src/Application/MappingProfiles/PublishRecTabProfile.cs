using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using Domain;
using Domain.Constants;
using Domain.Constants.User;

namespace Application.MappingProfiles
{
    public class PublishRecTabProfile : Profile
    {
        public PublishRecTabProfile()
        {
            CreateMap<RegabiturPublishrectab, PublishRecTabDto>();

            CreateMap<CreatePublishRecTabCommand, RegabiturPublishrectab>()
                .ForMember(d => d.Sogl, (o) => o.MapFrom(s => s.Sogl ? UserSogl.Sent : UserSogl.NotSent))
                .ForMember(d => d.SostType, (o) => o.MapFrom(s => s.SostType ? UserSostType.Rec : UserSostType.NotRec))
                .ForMember(d => d.Advantage, (o) => o.MapFrom(s => s.Advantage ? UserAdvantage.Has : UserAdvantage.HasNot))
                .ForMember(d => d.SumPoints, o => o.MapFrom(s =>
                    s.Individ + s.RusPoint + s.ObshPoint + s.KpPoint + s.SpecPoint + s.ForeignLanguagePoint + s.GpPoint
                    + s.HistoryPoint + s.OkpPoint + s.TgpPoint + s.UpPoint));

            CreateMap<UpdatePublishRecTabCommand, RegabiturPublishrectab>()
                .ForMember(d => d.Sogl, (o) => o.MapFrom(s => s.Sogl ? UserSogl.Sent : UserSogl.NotSent))
                .ForMember(d => d.SostType, (o) => o.MapFrom(s => s.SostType ? UserSostType.Rec : UserSostType.NotRec))
                .ForMember(d => d.Advantage, (o) => o.MapFrom(s => s.Advantage ? UserAdvantage.Has : UserAdvantage.HasNot))
                .ForMember(d => d.SumPoints, o => o.MapFrom(s =>
                    s.Individ + s.RusPoint + s.ObshPoint + s.KpPoint + s.SpecPoint + s.ForeignLanguagePoint + s.GpPoint
                    + s.HistoryPoint + s.OkpPoint + s.TgpPoint + s.UpPoint));

            CreateMap<RegabiturPublishrectab, PublishRecTabDeployDto>()
                .ForMember(d => d.Snils, (o) => o.MapFrom(s => s.User.RegabiturCustomuser.Snils))
                .ForMember(d => d.IndividPoint, (o) => o.MapFrom(s => s.Individ))
                .ForMember(d => d.TestType, (o) => o.MapFrom(s => s.TestType == UserTestType.Ege ? UserTestType.Ege : "ВИ"))
                .ForMember(d => d.ChosenPoint, (o) => o.MapFrom(s => s.TgpPoint > 0 ? s.TgpPoint : s.OkpPoint)) // ТГП / ОКП
                .ForMember(d => d.Advantage, (o) => o.MapFrom(s => s.Advantage == UserAdvantage.Has ? "Да" : "Нет"));
        }
    }
}
