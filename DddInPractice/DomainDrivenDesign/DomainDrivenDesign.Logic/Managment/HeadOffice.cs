using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Logic.Managment
{
    public class HeadOffice : AggregateRoot
    {
        public virtual decimal Balance { get; protected set; }

        public virtual Money Cash { get; protected set; } = Money.None;

        public virtual void ChangeBalance(decimal delta)
        {
            Balance += delta;
        }
    }
}
