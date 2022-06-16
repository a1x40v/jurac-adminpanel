using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AbiturResult
    {
        public int Id { get; set; }
        public string NameResult { get; set; }
        public string NumberResult { get; set; }
        public DateTime DatePub { get; set; }
        public DateOnly DateResult { get; set; }
        public string File { get; set; }
        public int EducationalFormId { get; set; }

        public virtual AbiturEducationalform EducationalForm { get; set; }
    }
}
