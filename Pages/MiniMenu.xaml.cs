using DnsSnap.Dns;
using DnsSnap.Function;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace DnsSnap.Pages
{
    /// <summary>
    /// Interaction logic for MiniMenu.xaml
    /// </summary>
    public partial class MiniMenu : Page
    {
        public MiniMenu()
        {
            InitializeComponent();
            DataContext = this;
            dnsnames = new(DnsManager.alldns.Select(d => d.DnsName.ToString()).ToList());
            traydnsnames = new(Notificon.TrayDnsNames);
        }
        private ObservableCollection<string> dnsnames;

        public ObservableCollection<string> DnsNames
        {
            get { return dnsnames; }
            set { dnsnames = value; }
        }
        private ObservableCollection<string> traydnsnames;

        public ObservableCollection<string> TrayDnsNames
        {
            get { return traydnsnames; }
            set { traydnsnames = value; }
        }
        private void Retake()
        {
            try
            {
                DnsManager.traydns = new(SaveData.ReadTrayData());
                Notificon.TrayDnsNames.Clear();
                Notificon.TrayDnsNames = new ObservableCollection<string>(DnsManager.traydns);
                TrayDnsNames = new(Notificon.TrayDnsNames);

            }
            catch (Exception ex) { }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string selected = "";

            foreach (var dns in AllDns.SelectedItems)
            {
                DnsManager.AddTrayDns(dns.ToString());
                selected = selected + " " + dns.ToString();

            }
            Retake();
            MessageBox.Show("Hopefully Added " + selected, "Successful", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            string selected = "";
            foreach (var dns in TrayiconDns.SelectedItems)
            {
                DnsManager.RemoveTrayDns(dns.ToString());
                selected = selected + " " + dns.ToString();
            }
            Retake();
            MessageBox.Show("Hopefully Deleted " + selected, "Successful", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }
}

