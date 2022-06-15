using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AbiturEducationalformspec
    {
        public AbiturEducationalformspec()
        {
            AbiturOrdersspecs = new HashSet<AbiturOrdersspec>();
        }

        public int Id { get; set; }
        public string NameEducationalForm { get; set; }

        public virtual ICollection<AbiturOrdersspec> AbiturOrdersspecs { get; set; }
    }
}
