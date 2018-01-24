using System;
using System.Collections.Generic;

namespace ihelped
{
    public partial class Users
    {
        public Users()
        {
            BuyIns = new HashSet<BuyIns>();
            Nodes = new HashSet<Nodes>();
            Pot = new HashSet<Pot>();
        }

        public int UserId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<BuyIns> BuyIns { get; set; }
        public ICollection<Nodes> Nodes { get; set; }
        public ICollection<Pot> Pot { get; set; }
    }
}
