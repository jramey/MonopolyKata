using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class FakeDice : Dice
    {
        private Stack<Int32> fakeRolls;

        public FakeDice()
        {
            fakeRolls = new Stack<Int32>();
        }

        public void SetFakeRolls(IEnumerable<Int32> fakeRolls)
        {
            this.fakeRolls = new Stack<Int32>(fakeRolls);
        }

        public override void Roll()
        {
            diOne = fakeRolls.Pop();
            diTwo = fakeRolls.Pop();
        }
    }
}
