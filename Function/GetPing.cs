using DnsSnap.Pages;
using DnsSnap.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DnsSnap.Function
{
    public class GetPing
    {
        public static string ShowPing()
        {
            string done;
            try
            {
                Ping ping = new Ping();
                PingReply Replay;
                string Host = Settings.Default.Host;
                Replay = ping.Send(Host);
                if (Replay.Status == IPStatus.Success)
                {
                    done = "Ping to " + Host.ToString() + "[" + Replay.Address.ToString() + "]" + " Successful"
                       + " Response delay = " + Replay.RoundtripTime.ToString() + " ms" + "\n";

                }
                else
                {
                    done = "Failed (No network connection or invalid server) ";
                }
                return done;
            }
            catch
            {
                done = "Failed (No network connection or invalid server) ";
                return done;
                

            }
        }                    

    }
}
