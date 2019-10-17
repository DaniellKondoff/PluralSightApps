using System;
using System.Linq;
using static DomainDrivenDesign.Logic.Money;

namespace DomainDrivenDesign.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInSide { get; private set; } = None;

        public Money MoneyInTransaction { get; private set; } = None;

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
            {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInSide += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
