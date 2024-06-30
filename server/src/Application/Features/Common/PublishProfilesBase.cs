namespace Application.Features.Common
{
    public class PublishProfilesBase
    {
        /*  bak */
        public bool BakOfoGp { get; set; }
        public bool BakOfoUp { get; set; }
        public bool BakZfoGp { get; set; }
        public bool BakZfoUp { get; set; }
        public bool BakOzfoGp { get; set; }
        public bool BakOzfoUp { get; set; }

        /*  spec */
        public bool SpecOfoSd { get; set; }
        public bool SpecZfoSd { get; set; }

        /*  mag */
        public bool MagOfoPo { get; set; }
        public bool MagZfoPo { get; set; }
        public bool MagOfoTp { get; set; }
        public bool MagZfoTp { get; set; }
        public bool MagOfoCorp { get; set; }
        public bool MagZfoCorp { get; set; }
        public bool MagOfoMed { get; set; }
        public bool MagZfoMed { get; set; }

        /*  asp */
        public bool AspOfoGp { get; set; }
        public bool AspOfoUgp { get; set; }

        /*  deprecated */
        // public bool AspOfoTip { get; set; }
        // public bool AspZfoTip { get; set; }
        // public bool AspOfoUp { get; set; }
        // public bool AspZfoUp { get; set; }
        // public bool AspOfoKs { get; set; }
        // public bool AspZfoKs { get; set; }
    }
}