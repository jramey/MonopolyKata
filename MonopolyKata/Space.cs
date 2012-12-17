using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Space : ISpace
    {
        public String Name { get;  set; }
        public Int32 Location { get;  set; }

        public Space(String name, Int32 location)
        {
            Name = name;
            Location = location;
        }

        public virtual void LandOn(Player player)
        {
            
        }
    }
}
