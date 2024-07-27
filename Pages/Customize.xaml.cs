using DnsSnap.Function;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace DnsSnap.Pages
{
    /// <summary>
    /// Interaction logic for Customize.xaml
    /// </summary>
    public partial class Customize : Page
    {
        public Customize()
        {
            InitializeComponent();
            FCtxt.Text = Properties.Settings.Default.FirstColor.Replace("#",string.Empty);
            SCtxt.Text = Properties.Settings.Default.SecondColor.Replace("#",string.Empty);
            TCtxt.Text = Properties.Settings.Default.ThirdColor.Replace("#", string.Empty);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(FCtxt.Text) && !String.IsNullOrEmpty(SCtxt.Text) && !String.IsNullOrEmpty(TCtxt.Text))
            {
                Properties.Settings.Default.FirstColor = "#" + FCtxt.Text.ToUpper();
                Properties.Settings.Default.SecondColor = "#" + SCtxt.Text.ToUpper();
                Properties.Settings.Default.ThirdColor = "#" + TCtxt.Text.ToUpper();
                Properties.Settings.Default.Save();
                MessageBox.Show("Changes Saved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Please fill all boxes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Startup_Click(object sender, RoutedEventArgs e)
        {
            if (Startup.Content == "On")
            {
                Properties.Settings.Default.Startup = false;
                Startup.Content = "Off";
            }
            else
            {
                Properties.Settings.Default.Startup = true;
                Startup.Content = "On";
            }
            Launch.SetStartup();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            if (Admin.Content == "OnConnect")
            {
                Properties.Settings.Default.Admin = "OnStart";
            }
            else
            {
                Properties.Settings.Default.Admin = "OnConnect";
            }
            Admin.Content = Properties.Settings.Default.Admin;
        }

        private void Soon_Click(object sender, RoutedEventArgs e)
        {
            RR();
        }
        private void RR()
        {
            string url ="https://youtu.be/dQw4w9WgXcQ?si=jok1rrhkt2JvBz4F";
            var yt = new ProcessStartInfo("https://youtu.be/dQw4w9WgXcQ?si=jok1rrhkt2JvBz4F")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            var backup = new ProcessStartInfo("https://streamable.com/lf027o")
            {
                UseShellExecute = true,
                Verb = "open"
            };


            // Create a WebRequest instance
            WebRequest request = WebRequest.Create(url);

            // Set the timeout (in milliseconds)
            request.Timeout = 5000; // 3 seconds

            try
            {
                // Send the request and get the response
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Check the response status code
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Process.Start(yt);
                }
                else
                {
                    Process.Start(backup);
                }
            }
            catch
            {
                Process.Start(backup);

            }

        }

        private void TCtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the input is a number or English alphabet
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[a-zA-Z0-9]$"))
            {
                e.Handled = true;
            }
            else
            {
                // Check if the length exceeds 6 characters
                if (TCtxt.Text.Length >= 6)
                {
                    e.Handled = true;
                }
            }
        }

        private void SCtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the input is a number or English alphabet
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[a-zA-Z0-9]$"))
            {
                e.Handled = true;
            }
            else
            {
                // Check if the length exceeds 6 characters
                if (SCtxt.Text.Length >= 6)
                {
                    e.Handled = true;
                }
            }
        }

        private void FCtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the input is a number or English alphabet
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[a-zA-Z0-9]$"))
            {
                e.Handled = true;
            }
            else
            {
                // Check if the length exceeds 6 characters
                if (FCtxt.Text.Length >= 6)
                {
                    e.Handled = true;
                }
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            FCtxt.Text = "1F1F1F";
            SCtxt.Text= "00C3BA";
            TCtxt.Text = "E8E8E8";
        }
    }
}
