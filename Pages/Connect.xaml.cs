using DnsSnap.Dns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnsSnap.Function;
using DnsSnap.Pages;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;


namespace DnsSnap.Pages
{
    /// <summary>
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Connect : Page
    {
        public Connect()
        {
            InitializeComponent();
            DataContext = this;
            dnsnames = new(DnsManager.alldns.Select(d => d.DnsName.ToString()).ToList());

        }
        private ObservableCollection<string> dnsnames;

        public ObservableCollection<string> DnsNames
        {
            get { return dnsnames; }
            set { dnsnames = value; }
        }
        private void GetDnsBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] activedns = DnsManager.CurrentDns();
            string current;
            if (activedns.Length > 1)
            {
                current = activedns[0] + "  |||  " + activedns[1];
            }
            else
            {
                current = " ||| " + activedns[0] + " ||| ";
            }
            GetDnsBtn.Content = current;
        }
        private void GetDnsBtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string[] activedns = DnsManager.CurrentDns();
            string current;
            if (activedns.Length > 1)
            {
                current = activedns[0] + ","+ activedns[1];
            }
            else
            {
                current =activedns[0];
            }
            Clipboard.SetText(current);
        }
        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectBtn.Content.ToString() == "Connect")
            {
                if (DnsBox.SelectedItem != null)
                {
                    if (Launch.IsAdmin)
                    {
                        DnsManager.SetDns(DnsBox.SelectedItem.ToString(), ConnectBtn);
                        ConnectBtn.Content = "Disconnect";
                        Sound.Connect.Play();
                    }
                    else { Launch.Admin(); }

                }
                else if (DnsBox.SelectedItem == null)
                {
                    MessageBox.Show("Please Select A Dns","No Dns selected",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                }
            }
            else if (ConnectBtn.Content.ToString() == "Disconnect")
            {

                DnsManager.UnsetDNS();
                ConnectBtn.Content = "Connect";
            }
        }


    }
}
