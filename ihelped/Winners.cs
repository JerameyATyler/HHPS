using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class Winners
    {
        public int PotId { get; set; }
        public int UserId { get; set; }
        public int? Payout { get; set; }

        public Pot Pot { get; set; }
        public Users User { get; set; }
    }
}
