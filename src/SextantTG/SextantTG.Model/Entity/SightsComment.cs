using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model.Entity
{
    public class SightsComment : Comment
    {
        public Sights Sights { get; set; }
    }
}
