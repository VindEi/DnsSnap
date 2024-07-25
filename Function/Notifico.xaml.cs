using System.Net;
using System.Windows;
using System.Windows.Controls;


namespace DnsSnap.Function
{
    public partial class Notifico : ResourceDictionary
    {
        private void NotificoContextMenu_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var dns in Notificon.TrayDnsNames)
            {
                MenuItem item = new MenuItem()
                {
                    Name = dns,
                    Header = dns,
                    Command = NotifyIconViewModel.ConnectCommand(dns)
                };
                if (!ConnectMenuItem.Items.Contains(item))
                {
                    ConnectMenuItem.Items.Add(item);

                }
            }
        }

        private void NotificoContextMenu_Unloaded(object sender, RoutedEventArgs e)
        {
            ConnectMenuItem.Items.Clear();

            MenuItem item = new MenuItem()
            {
                Name = default,
                Header = default,
                Command = NotifyIconViewModel.DisconnectCommand
            };
            ConnectMenuItem.Items.Add(item);
        }
    }
}

