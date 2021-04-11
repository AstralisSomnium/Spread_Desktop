using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using Sprd.UI.ViewModels;
using Sprd.UI.Views;
using SprdCore.Cardano;

namespace Sprd.UI
{
    public class SprdSettings
    {
        public WalletSettings WalletSettings { get; set; }
    }

    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();


                var currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var settingsFileName = "sprd-settings.json";
                var fullPathSettingsFile = Path.Combine(currentDirectory, settingsFileName);
                var jsonSettings = File.ReadAllText(fullPathSettingsFile);

                var settings = JsonConvert.DeserializeObject<SprdSettings>(jsonSettings);
                settings.WalletSettings.Database = Environment.ExpandEnvironmentVariables(settings.WalletSettings.Database);
                
                desktop.MainWindow.DataContext = new MainWindowViewModel(desktop.MainWindow, settings);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
