using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MonopolyKata
{
    public class Dice 
    {
        private static Random rand;
        protected Int32 diOne;
        protected Int32 diTwo;

        public Boolean IsDoubles { get { return diOne == diTwo; } }
        public Int32 CurrentRoll { get { return diOne + diTwo; } } 

        public Dice()
        {
            rand = new Random();
        }

        public virtual void Roll()
        {
            diOne = rand.Next(1, 7);
            diTwo = rand.Next(1, 7);
        }
    }
}
