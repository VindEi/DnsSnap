using DnsSnap.Dns;
using DnsSnap.Function;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using System.Windows.Input;

namespace DnsSnap
{
    /// <summary>
    /// Provides bindable properties and commands for the NotifyIcon. In this sample, the
    /// view model is assigned to the NotifyIcon in XAML. Alternatively, the startup routing
    /// in App.xaml.cs could have created this view model, and assigned it to the NotifyIcon.
    /// </summary>
    public class NotifyIconViewModel
    {
        /// <summary>
        /// Connects to selected Dns.
        /// </summary>
        public static ICommand ConnectCommand(string s)
        {
            return new DelegateCommand
            {
                CommandAction = () =>
                {
                    if (Launch.IsAdmin)
                    {
                        DnsManager.SetDns(s);
                        Notificon.Notifyicon.ShowBalloonTip("DnsSnap", $"Connected to {s} :)", BalloonIcon.Info);
                    }
                    else Launch.Admin();
                }
            };

        }

        /// <summary>
        /// Connects to selected Dns.
        /// </summary>
        public static ICommand DisconnectCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () =>
                    {
                        DnsManager.UnsetDNS();
                        Notificon.Notifyicon.ShowBalloonTip("DnsSnap", "Dissconnected :)", BalloonIcon.Info);
                    }
                };
            }

        }

        /// <summary>
        /// Shows a window, if none is already open.
        /// </summary>
        public ICommand ShowWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () =>
                    {
                        Application.Current.MainWindow.Show();
                        Notificon.ChangeVisible();
                    }
                };
            }
        }

        /// <summary>
        /// Shows the current ping.
        /// </summary>

        public ICommand PingCommand
        {
            get
            {
                return new DelegateCommand { CommandAction = () => Notificon.Notifyicon.ShowBalloonTip("DnsSnap", GetPing.ShowPing(), BalloonIcon.Info) };
            }
        }


        /// <summary>
        /// Shuts down the application.
        /// </summary>
        public ICommand ExitApplicationCommand
        {
            get
            {
                return new DelegateCommand { CommandAction = () => Application.Current.Shutdown() };
            }
        }
    }


    /// <summary>
    /// Simplistic delegate command for the demo.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        public Action CommandAction { get; set; }
        public Func<bool> CanExecuteFunc { get; set; }

        public void Execute(object parameter)
        {
            CommandAction();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc == null || CanExecuteFunc();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
