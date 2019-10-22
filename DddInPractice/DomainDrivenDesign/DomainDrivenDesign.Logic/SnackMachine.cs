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

        public virtual string CanBuySnack(int position)
        {
            SnackPile snackPile = GetSnackPile(position);

            if (snackPile.Quantity == 0)
                return "The snack pile is empty";

            if (MoneyInTransaction < snackPile.Price)
                return "Not enough money";

            if (!MoneyInSide.CanAllocate(MoneyInTransaction - snackPile.Price))
                return "Not enough change";

            return string.Empty;
        }

        public virtual void BuySnack(int position)
        {
            if (CanBuySnack(position) != string.Empty)
                throw new InvalidOperationException();

            Slot slot = GetSlot(position);
            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInSide.Allocate(MoneyInTransaction - slot.SnackPile.Price);
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

        public virtual IReadOnlyList<SnackPile> GetAllSnackPiles()
        {
            return Slots
                .OrderBy(s=>s.Position)
                .Select(s => s.SnackPile).ToList();
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(s => s.Position == position);
        }
    }
}
