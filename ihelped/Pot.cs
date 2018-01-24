using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class Pot
    {
        public int PotId { get; set; }
        public int CauseId { get; set; }
        public int PotTotal { get; set; }
        public int NextPayout { get; set; }
        public int WinnerId { get; set; }
        public bool? Collected { get; set; }

        public Causes Cause { get; set; }
        public Users Winner { get; set; }
    }
}
