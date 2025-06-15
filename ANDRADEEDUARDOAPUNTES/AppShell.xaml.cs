using ANDRADEEDUARDOAPUNTES.Views;

namespace ANDRADEEDUARDOAPUNTES
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NotePage), typeof(Views.NotePage));
            Routing.RegisterRoute(nameof(AllNotesPage), typeof(Views.AllNotesPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(Views.AboutPage));
        }
    }
}
