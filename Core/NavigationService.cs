using System.Windows.Controls;

namespace DnsSnap.Core
{
    public class NavigationService
    {
        private Frame _frame;

        public NavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void Navigate(Page page)
        {
            _frame.Content = page;
        }
    }

}
