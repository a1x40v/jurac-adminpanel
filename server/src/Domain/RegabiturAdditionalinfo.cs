#nullable disable

namespace Domain
{
    public partial class RegabiturAdditionalinfo
    {
        public RegabiturAdditionalinfo()
        {
            RegabiturAdditionalinfoEducationProfiles = new HashSet<RegabiturAdditionalinfoEducationProfile>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual AuthUser User { get; set; }
        public virtual ICollection<RegabiturAdditionalinfoEducationProfile> RegabiturAdditionalinfoEducationProfiles { get; set; }
    }
}
