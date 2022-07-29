using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class RegabiturPublishrectab
    {
        public int Id { get; set; }
        public string TestType { get; set; }
        public DateTime? DatePub { get; set; }
        public string Sogl { get; set; }
        public string SostType { get; set; }
        public string Advantage { get; set; }
        public short Individ { get; set; }
        public short RusPoint { get; set; }
        public short ObshPoint { get; set; }
        public short KpPoint { get; set; }
        public short SpecPoint { get; set; }
        public short SumPoints { get; set; }
        public bool BakOfoGp { get; set; }
        public bool BakOfoUp { get; set; }
        public bool BakZfoGp { get; set; }
        public bool BakZfoUp { get; set; }
        public bool BakOzfoGp { get; set; }
        public bool BakOzfoUp { get; set; }
        public bool SpecOfoSd { get; set; }
        public bool MagOfoPo { get; set; }
        public bool MagZfoPo { get; set; }
        public bool MagOfoTp { get; set; }
        public bool MagZfoTp { get; set; }
        public bool AspOfoTip { get; set; }
        public bool AspZfoTip { get; set; }
        public bool AspOfoUp { get; set; }
        public bool AspZfoUp { get; set; }
        public bool AspOfoKs { get; set; }
        public bool AspZfoKs { get; set; }
        public int UserId { get; set; }
        public short ForeignLanguagePoint { get; set; }
        public short GpPoint { get; set; }
        public short HistoryPoint { get; set; }
        public short OkpPoint { get; set; }
        public short TgpPoint { get; set; }
        public short UpPoint { get; set; }
        public bool AspOfoGp { get; set; }
        public bool AspOfoUgp { get; set; }
        public bool IsPublished { get; set; }
        public string Comment { get; set; }

        public virtual AuthUser User { get; set; }
    }
}
