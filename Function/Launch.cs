using AutoUpdaterDotNET;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows;
using System.Windows.Documents.Serialization;

namespace DnsSnap.Function
{
    class Launch
    {
        public static bool IsAdmin = false;
        public static string AppPath = Environment.ProcessPath;
        public static void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string AppName = "DnsSnap";

            if (Properties.Settings.Default.Startup)
            {
                rk.SetValue(AppName, Environment.ProcessPath);

            }
            else
            {
                rk.DeleteValue(AppName, false);
            }
        }
        public static void Admin()
        {
            if (!IsAdmin)
            {
                GetAdminAccess();
            }
        }

        private static void GetAdminAccess()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                var processInfo = new ProcessStartInfo(AppPath);
                processInfo.UseShellExecute = true;
                
                processInfo.Verb = "runas";
                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBoxResult res = MessageBox.Show("Would you like to change asking admin from on launch to on connect ?", "Failed to request admin (Fuctions require admin) ", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                    if (res == MessageBoxResult.Yes)
                    {
                        Properties.Settings.Default.Admin = "OnConnect";
                       Properties.Settings.Default.Save();
                    }

                }
                Environment.Exit(0);
            }
        }
            public static void CheckForUpdates()
        {
            try
            {
                AutoUpdater.Start("https://raw.githubusercontent.com/VindEi/DnsSnap/master/version.xml");
            }
            catch
            {

            }
        }

    }
}
