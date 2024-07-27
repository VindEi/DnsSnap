using DnsSnap.Dns;
using Hardcodet.Wpf.TaskbarNotification;
using System.Collections.ObjectModel;
using System.Windows;

namespace DnsSnap.Function
{
    public class Notificon
    {
        private static ObservableCollection<string> traydnsnames;

        public static ObservableCollection<string> TrayDnsNames
        {
            get { return traydnsnames; }
            set { traydnsnames = value; }
        }

        public static TaskbarIcon Notifyicon;
        public static void Run()
        {
            Notifyicon = (TaskbarIcon)Application.Current.FindResource("Notifico");
            Notifyicon.Visibility = Visibility.Hidden;
            traydnsnames = new ObservableCollection<string>(DnsManager.traydns);

        }
        public static void ChangeVisible()
        {
            if (Notifyicon.Visibility == Visibility.Visible)
            {
                Notifyicon.Visibility = Visibility.Hidden;
            }
            else
            {
                Notifyicon.Visibility = Visibility.Visible;
            }
        }
        public static void Dispose()
        {
            Notifyicon.Dispose();
        }


    }
}
