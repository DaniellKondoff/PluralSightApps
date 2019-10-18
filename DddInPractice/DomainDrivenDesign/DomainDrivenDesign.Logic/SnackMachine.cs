using System;
using System.Linq;
using static DomainDrivenDesign.Logic.Money;

namespace DomainDrivenDesign.Logic
{
    public class SnackMachine : Entity
    {
        public virtual Money MoneyInSide { get; protected set; } = None;

        public virtual Money MoneyInTransaction { get; protected set; } = None;

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
            {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public virtual void BuySnack()
        {
            MoneyInSide += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
