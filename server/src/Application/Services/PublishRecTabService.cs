using Application.Contracts.Application;
using Application.DTO.PublishRecTab;
using AutoMapper;
using Domain.Enums;

namespace Application.Services
{
    public class PublishRecTabService : IPublishRecTabService
    {
        private readonly IMapper _mapper;
        public PublishRecTabService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static Dictionary<EduProfileType, Func<PublishRecTabDto, bool>> Selectors = new Dictionary<EduProfileType, Func<PublishRecTabDto, bool>>
        {
            {EduProfileType.BakOfoUp, (recTab) => recTab.BakOfoUp},
            {EduProfileType.BakZfoUp, (recTab) => recTab.BakZfoUp},
            {EduProfileType.BakOzfoUp, (recTab) => recTab.BakOzfoUp},
            {EduProfileType.BakOfoGp, (recTab) => recTab.BakOfoGp},
            {EduProfileType.BakZfoGp, (recTab) => recTab.BakZfoGp},
            {EduProfileType.BakOzfoGp, (recTab) => recTab.BakOzfoGp},
            {EduProfileType.SpecOfoSd, (recTab) => recTab.SpecOfoSd},
            {EduProfileType.MagOfoPo, (recTab) => recTab.MagOfoPo},
            {EduProfileType.MagZfoPo, (recTab) => recTab.MagZfoPo},
            {EduProfileType.MagOfoTp, (recTab) => recTab.MagOfoTp},
            {EduProfileType.MagZfoTp, (recTab) => recTab.MagZfoTp},
            {EduProfileType.AspOfoGp, (recTab) => recTab.AspOfoGp},
            {EduProfileType.AspOfoUgp, (recTab) => recTab.AspOfoUgp},
        };

        public Dictionary<EduProfileType, List<PublishRecTabDeployDto>> GetDeployedTabs(ICollection<PublishRecTabDto> recTabs)
        {
            var result = new Dictionary<EduProfileType, List<PublishRecTabDeployDto>>();

            foreach (var key in Selectors.Keys)
            {
                var selector = Selectors[key];
                result[key] = recTabs.Where(selector)
                    .Select(x => _mapper.Map<PublishRecTabDeployDto>(x))
                    .ToList();
            }

            return result;
        }

    }
}