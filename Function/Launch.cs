using AutoUpdaterDotNET;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows;

namespace DnsSnap.Function
{
    class Launch
    {
        public static bool IsAdmin = false;

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
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            startInfo.Verb = "runas";
            try
            {
                Process.Start(startInfo);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to request admin access: " + ex.Message);
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
