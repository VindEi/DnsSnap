using DnsSnap.Dns;

namespace DnsSnap
{
    public class DnsBoxViewModel
    {


        public DnsBoxViewModel()
        {
        }

        public static List<string> GetdnsProfiles()
        {
            var output = new List<string>();
            output = SaveData.ReadData().Select(d => d.DnsName.ToString()).ToList();
            return output;
        }
    }
}
