namespace Application.Common.QueryString
{
    public class UserQueryParameters : QueryParameters
    {
        public string DocStatuses { get; set; }
        public DateTime MinDateJoined { get; set; } = DateTime.MinValue;
        public DateTime MaxDateJoined { get; set; } = DateTime.UtcNow;
        public bool ValidDateJoinedRange => MaxDateJoined > MinDateJoined;

        public UserQueryParameters()
        {
            OrderBy = "dateJoined desc";
        }
    }
}