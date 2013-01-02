using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Property : Space
    {
        public Player Owner { get;  set; }
        public Int32 BuyingCost { get;  protected set;}
        public Int32 Rent { get;  protected set; }
        public List<Property> Grouping { get; protected set; }

        public Property(String name, Int32 location, Int32 cost, Int32 rent, List<Property> grouping, Banker banker) 
            : base(name, location,  banker) 
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
            else if (Grouping.Where(g => g.Owner == Owner).Count() == Grouping.Count)
            { 
                Banker.TransferRentPayment(player, Owner, 2 * Rent);
            }
            else
            {
                Banker.TransferRentPayment(player, Owner, Rent);
            }
        }
    }
}
