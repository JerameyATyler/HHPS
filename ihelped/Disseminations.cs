using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class Disseminations
    {
        public int DisseminationId { get; set; }
        public int NodeId { get; set; }

        public Nodes Node { get; set; }
    }
}
