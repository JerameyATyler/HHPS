using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class BuyIns
    {
        public int BuyInId { get; set; }
        public int UserId { get; set; }
        public int CauseId { get; set; }
        public int Amount { get; set; }

        public Causes Cause { get; set; }
        public Users User { get; set; }
    }
}
