using System;
using System.Collections.Generic;

namespace Dal.Do
{
    public partial class Yrapholojist
    {
        public Yrapholojist()
        {
            ToMatches = new HashSet<ToMatch>();
        }

        public string TzYrapholojist { get; set; } = null!;
        public string? Sort { get; set; }

        public virtual ICollection<ToMatch> ToMatches { get; set; }
    }
}
