using DomainDrivenDesign.Logic.Common;
using DomainDrivenDesign.Logic.Managment;

namespace DomainDrivenDesign.Logic
{
    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
            HeadOfficeInstance.Init();
            DomainEvents.Init();
        }
    }
}
