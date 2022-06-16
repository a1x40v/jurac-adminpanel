﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AbiturOrder
    {
        public int Id { get; set; }
        public string NameOrder { get; set; }
        public string NumberOrder { get; set; }
        public DateTime DatePub { get; set; }
        public DateOnly DateOrder { get; set; }
        public string File { get; set; }
        public int EducationalFormId { get; set; }

        public virtual AbiturEducationalform EducationalForm { get; set; }
    }
}
