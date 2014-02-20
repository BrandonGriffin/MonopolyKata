using System;
using MonopolyKata.RentStrategies;

namespace MonopolyKata.Spaces
{
    public class RealEstate : IBoardSpace
    {
        public String Owner { get; private set; }
        
        protected Banker banker;

        private Int32 price;
        private Int32 baseRent;
        private IRentStrategy rentStrategy;

        public RealEstate(Banker banker, Int32 price, Int32 baseRent, IRentStrategy rentStrategy)
        {
            this.banker = banker;
            this.price = price;
            this.baseRent = baseRent;
            this.rentStrategy = rentStrategy;
        }

        public void LandOnSpace(String player)
        {
            if (IsUnowned())
                Purchase(player);
            else if (IsNotOwnedBy(player))
                PayRent(player);
        }

        private Boolean IsUnowned()
        {
            return Owner == null;
        }

        private void Purchase(String player)
        {            
            banker.Debit(player, price);
            Owner = player;
        }

        private Boolean IsNotOwnedBy(String player)
        {
            return Owner != player && Owner != null;
        }

        private void PayRent(String player)
        {
            banker.Transfer(CalculateRent(), player, Owner);
        }

        private Int32 CalculateRent()
        {
            return rentStrategy.CalculateRent(this.Owner, baseRent);
        }
    }
}
