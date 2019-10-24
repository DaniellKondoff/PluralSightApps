using DomainDrivenDesign.Logic.Common;

namespace DomainDrivenDesign.Logic.Atms
{
    public class BalanceChangedEvent : IDomainEvent
    {
        public decimal Delta { get; private set; }

        public BalanceChangedEvent(decimal delta)
        {
            Delta = delta;
        }
    }
}
