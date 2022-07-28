using Application.DTO.PublishRecTab;
using Domain.Enums;

namespace Application.Contracts.Application
{
    public interface IPublishRecTabService
    {
        Dictionary<EduProfileType, List<PublishRecTabDeployDto>> GetDeployedTabs(ICollection<PublishRecTabDto> recTabs);
    }
}