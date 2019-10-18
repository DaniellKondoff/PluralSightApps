using DomainDrivenDesign.Logic;
using System.Windows;

namespace DomainDrivenDesign.UI
{
    public partial class App : Application
    {
        public App()
        {
            Initer.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");
        }
    }
}
