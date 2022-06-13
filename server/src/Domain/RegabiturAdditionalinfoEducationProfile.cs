#nullable disable

namespace Domain
{
    public partial class RegabiturAdditionalinfoEducationProfile
    {
        public int Id { get; set; }
        public int AdditionalinfoId { get; set; }
        public int ChoicesprofileId { get; set; }

        public virtual RegabiturAdditionalinfo Additionalinfo { get; set; }
        public virtual RegabiturChoicesprofile Choicesprofile { get; set; }
    }
}
