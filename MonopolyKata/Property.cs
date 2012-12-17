using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Property : Space
    {
        public Int32 BuyingCost { get; private set;}
        public Int32 Rent { get; private set; }
        public String Grouping { get; private set; }  

        public Property(String name, Int32 location, Int32 cost, Int32 Rent, String Grouping) 
            : base(name, location) 
        {
        
        }

        public override void LandOn(Player player)
        {
            base.LandOn(player);
        }
    }
}
