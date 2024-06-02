using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class ToMatch
    {
        public int CodToMatch { get; set; }
        public string? FileToMatch { get; set; }
        public string? WoritMatch { get; set; }
        public string? Sort { get; set; }
        public string? TzYrapholojist { get; set; }
        public string? TzInscribed { get; set; }

        public virtual Inscribed? TzInscribedNavigation { get; set; }
        public virtual Yrapholojist? TzYrapholojistNavigation { get; set; }
    }
}
