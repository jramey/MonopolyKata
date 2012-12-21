using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Banker
    {
        private List<Property> properties;
        private List<Space> spaces;
        public Int32 rentAmount;

        public Banker()
        {
            spaces = new List<Space>();
            properties = new List<Property>();
        }

        public void DebitPlayerAccount(Player player, Int32 amount)
        {
            player.Balance = player.Balance + amount;
        }

        public void CreditPlayerAccount(Player player, Int32 amount)
        {
            player.Balance = player.Balance - amount;
        }

        public void TransferRentPayment(Player renter, Player owner, Int32 rent)
        {
            renter.Balance = renter.Balance - rent;
            owner.Balance = owner.Balance + rent;
        }    
    }
}
