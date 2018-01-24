using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class Causes
    {
        public Causes()
        {
            BuyIns = new HashSet<BuyIns>();
            Nodes = new HashSet<Nodes>();
            Pot = new HashSet<Pot>();
        }

        public int CauseId { get; set; }
        public string Hashtag { get; set; }
        public string CauseText { get; set; }

        public ICollection<BuyIns> BuyIns { get; set; }
        public ICollection<Nodes> Nodes { get; set; }
        public ICollection<Pot> Pot { get; set; }
    }
}
