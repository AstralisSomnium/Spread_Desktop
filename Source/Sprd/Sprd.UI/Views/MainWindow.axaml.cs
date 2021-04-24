using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Sprd.UI.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void Exit_FromMenu(object? sender, RoutedEventArgs e)
        {
            Close();
        }

        void ViewGithub_FromMenu(object? sender, RoutedEventArgs e)
        {
            OpenUrl("https://github.com/AstralisSomnium/Spread_Desktop");
        }

        void VisitSpread_FromMenu(object? sender, RoutedEventArgs e)
        {
            OpenUrl("https://sprd-pool.org/");
        }

        void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        void OpenLogs_FromMenu(object? sender, RoutedEventArgs e)
         {
             var logPath = Path.Join(Path.GetTempPath(), "SPRD");
             Process.Start("explorer.exe", logPath);
         }
    }
}
