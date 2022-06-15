using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AbiturEducationalformasp
    {
        public AbiturEducationalformasp()
        {
            AbiturOrdersasps = new HashSet<AbiturOrdersasp>();
            AbiturRecommendedlistasps = new HashSet<AbiturRecommendedlistasp>();
            AbiturResultasps = new HashSet<AbiturResultasp>();
        }

        public int Id { get; set; }
        public string NameEducationalForm { get; set; }

        public virtual ICollection<AbiturOrdersasp> AbiturOrdersasps { get; set; }
        public virtual ICollection<AbiturRecommendedlistasp> AbiturRecommendedlistasps { get; set; }
        public virtual ICollection<AbiturResultasp> AbiturResultasps { get; set; }
    }
}
