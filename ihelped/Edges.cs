using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class Edges
    {
        public int EdgeId { get; set; }
        public int NodeA { get; set; }
        public int NodeB { get; set; }

        public Nodes NodeANavigation { get; set; }
        public Nodes NodeBNavigation { get; set; }
    }
}
