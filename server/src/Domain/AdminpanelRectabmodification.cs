using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class AdminpanelRectabmodification
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public ushort Type { get; set; }
        public int RectabId { get; set; }

        public virtual RegabiturPublishrectab Rectab { get; set; }
    }
}
