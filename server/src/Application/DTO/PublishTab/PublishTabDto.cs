using Application.Features.Common;

namespace Application.DTO.PublishTab
{
    public class PublishTabDto : PublishProfilesBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string IndividualStr { get; set; }
        public string TestType { get; set; }

        public string FullName { get; set; }
    }
}