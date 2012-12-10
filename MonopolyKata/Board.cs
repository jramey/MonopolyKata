using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Board
    {
        List<ISpace> spaces;

        public Board()
        {
            spaces = new List<ISpace>();
            spaces.Add(new Go());

            for (int i = 0; i < 39; i++)
                spaces.Add(new NormalSpace());

            spaces[4] = new IncomeTax();
            spaces[30] = new GoToJail();
            spaces[38] = new LuxuryTax();
        }
 
        public ISpace GetSpaceAtLocation(Int32 location)
        {
            return spaces.ElementAt(location);
        }
    }
}