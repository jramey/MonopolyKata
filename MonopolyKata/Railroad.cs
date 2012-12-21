using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Railroad : Property
    {
        public Railroad(String name, Int32 location, Int32 cost, Int32 rent, List<Property> grouping, Banker banker) 
            : base(name, location, cost, rent, grouping, banker)
        {
            Name = name;
            Location = location;
            BuyingCost = cost;
            Rent = rent;
            Grouping = grouping;
            Banker = banker;
        }

        public override void LandOn(Player player)
        {
            if (Owner == null)
            {
                Owner = player;
                Banker.CreditPlayerAccount(player, BuyingCost);
            }
            else if (player != Owner)
            {
                var amount = Rent * (Int32)Math.Pow(2, Grouping.Count(g => g.Owner == Owner) - 1);
                Banker.TransferRentPayment(player, Owner, amount);
            }
        }
    }
}
