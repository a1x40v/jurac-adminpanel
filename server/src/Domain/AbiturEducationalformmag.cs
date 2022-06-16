using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AbiturEducationalformmag
    {
        public AbiturEducationalformmag()
        {
            AbiturOrdersmags = new HashSet<AbiturOrdersmag>();
            AbiturRecommendedlistmags = new HashSet<AbiturRecommendedlistmag>();
            AbiturResultmags = new HashSet<AbiturResultmag>();
        }

        public int Id { get; set; }
        public string NameEducationalForm { get; set; }

        public virtual ICollection<AbiturOrdersmag> AbiturOrdersmags { get; set; }
        public virtual ICollection<AbiturRecommendedlistmag> AbiturRecommendedlistmags { get; set; }
        public virtual ICollection<AbiturResultmag> AbiturResultmags { get; set; }
    }
}
