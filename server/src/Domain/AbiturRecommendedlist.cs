﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AbiturRecommendedlist
    {
        public int Id { get; set; }
        public string NameRecList { get; set; }
        public DateTime DatePub { get; set; }
        public DateOnly DateOrder { get; set; }
        public string File { get; set; }
        public int EducationalFormId { get; set; }

        public virtual AbiturEducationalform EducationalForm { get; set; }
    }
}
