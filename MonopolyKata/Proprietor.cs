using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Proprietor
    {
        private Banker banker;
 
        public Proprietor(Banker banker)
        {
            this.banker = banker;
        }

        public void MortgageProperty(Player player, Property property)
        {
            if (CannotMortgageProperty(player, property))
                throw new InvalidOperationException("Property can not be mortgaged.");

            property.IsMortgaged = true;
            banker.DebitPlayerAccount(player, property.BuyingCost / 10 * 9);
        }

        public void CollectMortgagePayment(Player player, Property property)
        {
            if (CannotCollectMortgagePayment(player, property))
                throw new InvalidOperationException("Payment cannot be collected.");

            property.IsMortgaged = false;
            banker.CreditPlayerAccount(player, property.BuyingCost);
        }

        private Boolean CannotMortgageProperty(Player player, Property property)
        {
            return (property.IsMortgaged == true || property.Owner != player);
        }

        private Boolean CannotCollectMortgagePayment(Player player, Property property)
        {
            return (property.IsMortgaged == false || property.Owner != player);
        }
    }
}
