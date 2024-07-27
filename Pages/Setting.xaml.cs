using System.Windows;
using System.Windows.Controls;
using DnsSnap.Dns;
using System.ComponentModel;
using System.Net;
using MessageBox = System.Windows.MessageBox;

namespace DnsSnap.Pages
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Page
    {
        public Setting()
        {
            InitializeComponent();
        }
        private void ManageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DnsManaging());
        }

        private void OpenMinisBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MiniMenu());
        }

        private void GetDnsBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = @"https://raw.githubusercontent.com/VindEi/DnsSnap/master/Dns.json";
            WebClient client = new();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            string messege = "Note that by clicking yes you will lose all your dns and download the default dns file(containing 5 dns)";
            MessageBoxResult result =MessageBox.Show(messege, "Are You Sure You Want To Continue?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                client.DownloadFileAsync(new Uri(url), DnsManager.filePath);
            }
        }


        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File downloaded");
        }

        private void Customize_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Customize());

        }
    }
}
