using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Utility : Space
    {
        private Dice Dice { get; set; }
        public Player Owner { get; set; }
        public Int32 BuyingCost { get; protected set; }
        public List<Utility> Grouping { get; protected set; }

        public Utility(String name, Int32 location, Int32 cost, List<Utility> grouping, Banker banker, Dice dice) 
            : base(name, location,  banker) 
        {
            Name = name;
            Location = location;
            BuyingCost = cost;
            Grouping = grouping;
            Banker = banker;
            Dice = dice;
        }

        public override void LandOn(Player player)
        {
            if (Owner == null)
            {
                Owner = player;
                Banker.CreditPlayerAccount(player, BuyingCost);
            }
            else if (OneUtilityIsOwned())
            {
                Banker.TransferRentPayment(player, Owner, 4 * Dice.CurrentRoll);
            }
            else 
            {
                Banker.TransferRentPayment(player, Owner, 10 * Dice.CurrentRoll);
            }
        }

        private bool OneUtilityIsOwned()
        {
            return Grouping.Count(g => g.Owner != null) == 1;
        }
    }
}
