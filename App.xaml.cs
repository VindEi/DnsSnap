using DnsSnap.Function;
using System.Security.Principal;
using System.Windows;

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
            if (DnsSnap.Properties.Settings.Default.Admin == "OnStart")
            {
                Thread.Sleep(5000);
                Launch.Admin();
            }
            if (IsAdministrator())
            {
                Launch.IsAdmin = true;
            }

            Notificon.Run();
            Launch.CheckForUpdates();
            //Launch.SetStartup();
            Restrict();
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
