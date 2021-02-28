using System;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Serilog;

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

         void OpenLogs_FromMenu(object? sender, RoutedEventArgs e)
         {
             var logPath = Path.Join(Path.GetTempPath(), "SPRD");
             Process.Start("explorer.exe", logPath);
         }
    }
}
