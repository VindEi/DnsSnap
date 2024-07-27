using DnsSnap.Dns;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnsSnap.Pages
{
    /// <summary>
    /// Interaction logic for DnsManaging.xaml
    /// </summary>
    public partial class DnsManaging : Page
    {
        public DnsManaging()
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

        private void Retake()
        {
            try
            {
                DnsManager.alldns = new(SaveData.ReadData());
                DnsNames = new(DnsManager.alldns.Select(d => d.DnsName.ToString()).ToList());

            }
            catch (Exception ex) { }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Nametxt.Text) && !String.IsNullOrEmpty(Firsttxt.Text) && !String.IsNullOrEmpty(secondtxt.Text))
            {
                DnsManager.AddDns(Nametxt.Text, Firsttxt.Text, secondtxt.Text);
                MessageBox.Show("Hopefully added " + Nametxt.Text, "Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                Retake();
            }
            else
            {
                MessageBox.Show("Please fill dns information first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (DnsList.SelectedItems.Count >0)
            {
                string selected = "";
                foreach (var dns in DnsList.SelectedItems)
                {
                    DnsManager.RemoveDns(DnsList.SelectedItem.ToString());
                    selected = selected + " " + dns.ToString();
                }
                MessageBox.Show("Hopefully Deleted " + selected, "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                Retake();

            }
            else
            {
                MessageBox.Show("No item selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetCurrent_Click(object sender, RoutedEventArgs e)
        {
            string[] activedns = DnsManager.CurrentDns();

            if (activedns.Length > 1)
            {
                Firsttxt.Text = activedns[0];
                secondtxt.Text = activedns[1];
            }
        }

        private void Firsttxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9\.]$"))
            {
                e.Handled = true;
            }
            else
            {
                // Check if the length exceeds 16 characters
                if (Firsttxt.Text.Length >= 16)
                {
                    e.Handled = true;
                }
            }
        }

        private void secondtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9\.]$"))
            {
                e.Handled = true;
            }
            else
            {
                // Check if the length exceeds 16 characters
                if (secondtxt.Text.Length >= 16)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
