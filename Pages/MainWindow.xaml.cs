using DnsSnap.Core;
using DnsSnap.Function;
using DnsSnap.Pages;
using System.Windows;
using System.Windows.Input;


namespace DnsSnap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            NavigationService navigationService = new NavigationService(MainView);
        }

        private void MoveOnDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Hide();
            Notificon.ChangeVisible();
        }
        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainView.Content = new Setting();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainView.NavigationService.Content = new Connect();
        }
    }
}