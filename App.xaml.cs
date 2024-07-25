using DnsSnap.Function;
using System.Windows;
using System.Security.Principal;

namespace DnsSnap
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            Notificon.Run();
            Restrict();
            Launch.CheckForUpdates();
            if(DnsSnap.Properties.Settings.Default.Admin == "OnStart")
            {
                Launch.Admin();
            }
            if(IsAdministrator())
            {
                Launch.IsAdmin = true;
            }

            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            Notificon.Dispose();
            base.OnExit(e);
        }
        private static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void Restrict()
        {
            const string appName = "DnsSnap";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                Current.Shutdown();
            }
        }
    }

}
