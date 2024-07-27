using System.Media;

namespace DnsSnap.Function
{
    public class Sound
    {
        public static SoundPlayer Connect = new SoundPlayer(Properties.Resources.generic);
        public static SoundPlayer Disconnect = new SoundPlayer(Properties.Resources.generic);
    }
}
