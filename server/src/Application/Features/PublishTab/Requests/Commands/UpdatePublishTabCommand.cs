using Application.Features.Common;
using MediatR;

namespace Application.Features.PublishTab.Requests.Commands
{
    public class UpdatePublishTabCommand : PublishProfilesBase, IRequest
    {
        public int UserId { get; set; }
        public string IndividualStr { get; set; }
        public string TestType { get; set; }
    }
}