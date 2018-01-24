using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class Nodes
    {
        public Nodes()
        {
            Disseminations = new HashSet<Disseminations>();
            EdgesNodeANavigation = new HashSet<Edges>();
            EdgesNodeBNavigation = new HashSet<Edges>();
        }

        public int NodeId { get; set; }
        public int UserId { get; set; }
        public int CauseId { get; set; }
        public int State { get; set; }
        public int Plays { get; set; }

        public Causes Cause { get; set; }
        public Users User { get; set; }
        public ICollection<Disseminations> Disseminations { get; set; }
        public ICollection<Edges> EdgesNodeANavigation { get; set; }
        public ICollection<Edges> EdgesNodeBNavigation { get; set; }
    }
}
