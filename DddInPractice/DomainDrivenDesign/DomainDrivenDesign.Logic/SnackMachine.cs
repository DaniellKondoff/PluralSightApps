using System;
using System.Collections.Generic;
using System.Linq;
using static DomainDrivenDesign.Logic.Money;

namespace DomainDrivenDesign.Logic
{
    public class SnackMachine : AggregateRoot
    {
        public virtual Money MoneyInSide { get; protected set; }

        public virtual decimal MoneyInTransaction { get; protected set; }

        protected virtual IList<Slot> Slots { get; set; }

        public SnackMachine()
        {
            MoneyInSide = None;
            MoneyInTransaction = 0;
            Slots = new List<Slot>
            {
                new Slot(this,1),
                new Slot(this,2),
                new Slot(this,3)
            };
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
            {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money.Amount;
            MoneyInSide += money;
        }

        public virtual void ReturnMoney()
        {
            Money moneyToReturn = MoneyInSide.Allocate(MoneyInTransaction);
            MoneyInSide -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public virtual void BuySnack(int position)
        {
            Slot slot = GetSlot(position);
            if (slot.SnackPile.Price > MoneyInTransaction)
                throw new InvalidOperationException();

            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInSide.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            if (change.Amount < MoneyInTransaction - slot.SnackPile.Price) 
                throw new InvalidOperationException();

            MoneyInSide -= change;
            MoneyInTransaction = 0;
        }

        public virtual void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public virtual SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInSide += money;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(s => s.Position == position);
        }
    }
}
