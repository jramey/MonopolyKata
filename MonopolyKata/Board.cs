using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Board
    {
        List<Space> spaces;

        public Board()
        {
            spaces = new List<Space>();
            BuildBoard();
        }

        private void BuildBoard()
        {
            spaces.Add(new Go("Go", 0));
            spaces.Add(new Property("Property", 1, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 2, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 3, 100, 12, "Purple"));
            spaces.Add(new IncomeTax("Income Tax", 4));
            spaces.Add(new Property("Property", 5, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 6, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 7, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 8, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 9, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 10, 100, 12, "Purple"));

            spaces.Add(new Property("Property", 11, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 12, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 13, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 14, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 15, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 16, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 17, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 18, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 19, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 20, 100, 12, "Purple"));

            spaces.Add(new Property("Property", 21, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 22, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 23, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 24, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 25, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 26, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 27, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 28, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 29, 100, 12, "Purple"));
            
                    
            spaces.Add(new GoToJail("Go To Jail", 30));
            spaces.Add(new Property("Property", 31, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 32, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 33, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 34, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 35, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 36, 100, 12, "Purple"));
            spaces.Add(new Property("Property", 37, 100, 12, "Purple"));
            spaces.Add(new LuxuryTax("Luxuray Tax", 38));
            spaces.Add(new Property("Property", 40, 100, 12, "Purple"));

        }

        public Space GetSpaceAtLocation(Int32 location)
        {
            return spaces.ElementAt(location);
        }
    }
}