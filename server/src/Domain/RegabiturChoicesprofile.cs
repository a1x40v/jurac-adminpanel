#nullable disable

namespace Domain
{
    public partial class RegabiturChoicesprofile
    {
        public RegabiturChoicesprofile()
        {
            RegabiturAdditionalinfoEducationProfiles = new HashSet<RegabiturAdditionalinfoEducationProfile>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RegabiturAdditionalinfoEducationProfile> RegabiturAdditionalinfoEducationProfiles { get; set; }
    }
}
