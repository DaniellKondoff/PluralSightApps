using DomainDrivenDesign.Logic.Atms;
using DomainDrivenDesign.Logic.Common;

namespace DomainDrivenDesign.Logic.Managment
{
    public class BalanceChangedEventHandler : IHandler<BalanceChangedEvent>
    {
        public void Handle(BalanceChangedEvent domainEvent)
        {
            var repository = new HeadOfficeRepository();
            var headOffice = HeadOfficeInstance.Instance;
            headOffice.ChangeBalance(domainEvent.Delta);
            repository.Save(headOffice);
        }
    }
}