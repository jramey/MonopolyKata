using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Space : ISpace
    {
        public String Name { get; protected set; }
        public Int32 Location { get;  protected set; }
        public Banker Banker { get; set; }

        public Space(String name, Int32 location, Banker banker)
        {
            Name = name;
            Location = location;
            Banker = banker;
        }

        public virtual void LandOn(Player player) { }
    }
}
