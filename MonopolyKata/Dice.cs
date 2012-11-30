namespace MonopolyKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Dice
    {
        private static Random rand;
        private Int32 currentRoll;

        public Dice()
        {
            rand = new Random();
        }

        public void Roll()
        {
            currentRoll = rand.Next(1, 12);
        }

        public Int32 GetRoll()
        {
            return currentRoll;
        }
    }
}
