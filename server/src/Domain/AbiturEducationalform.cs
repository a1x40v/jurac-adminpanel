using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AbiturEducationalform
    {
        public AbiturEducationalform()
        {
            AbiturOrders = new HashSet<AbiturOrder>();
            AbiturRecommendedlists = new HashSet<AbiturRecommendedlist>();
            AbiturResults = new HashSet<AbiturResult>();
        }

        public int Id { get; set; }
        public string NameEducationalForm { get; set; }

        public virtual ICollection<AbiturOrder> AbiturOrders { get; set; }
        public virtual ICollection<AbiturRecommendedlist> AbiturRecommendedlists { get; set; }
        public virtual ICollection<AbiturResult> AbiturResults { get; set; }
    }
}
