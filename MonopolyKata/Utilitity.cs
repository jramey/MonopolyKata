using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Utilitity : Space
    {
        private Dice Dice { get; set; }
        public Player Owner { get; set; }
        public Int32 BuyingCost { get; protected set; }
        public List<Utilitity> Grouping { get; protected set; }

        public Utilitity(String name, Int32 location, Int32 cost, List<Utilitity> grouping, Banker banker, Dice dice) 
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
            var amount = 0;

            if (Owner == null)
            {
                Owner = player;
                Banker.CreditPlayerAccount(player, BuyingCost);
            }
            else if (Grouping.Where(g => g.Owner != null).Count() == 1)
            {
                amount = 4 * Dice.GetRoll();
                Banker.TransferRentPayment(player, Owner, amount);
            }
            else 
            {
                amount = 4 * Dice.GetRoll();
                Banker.TransferRentPayment(player, Owner, amount);
            }
        }
    }
}
