using System.Windows;
using System.Windows.Controls;

namespace PocAPI.WPF.Utils
{
    public static class WPFExtencoes
    {
        public static void PerformClick(this Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}