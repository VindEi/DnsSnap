using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace DnsSnap.Function
{
    public class Sound
    {
        public static SoundPlayer Connect = new SoundPlayer(Properties.Resources.generic);
        public static SoundPlayer Disconnect = new SoundPlayer(Properties.Resources.generic);
    }
}
