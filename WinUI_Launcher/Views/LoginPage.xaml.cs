using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using WinUI_Launcher.Classes;
using WinUI_Launcher.Classes.ClassTests;
using WinUI_Launcher.Classes.Network;
using WinUI_Launcher.Classes.WebConnection;
using WinUI_Launcher.ViewModels;
using WinUIEx.Messaging;

namespace WinUI_Launcher.Views;

public sealed partial class LoginPage : Page
{
    public LoginViewModel ViewModel
    {
        get;
    }

    public LoginPage()
    {
        ViewModel = App.GetService<LoginViewModel>();
        InitializeComponent();
    }


    private void onClick(object sender, RoutedEventArgs e)
    {
        onClickAsync();
    }
    private async Task onClickAsync()
    {
        GamesTestStatics.isLogged = true;
        //Client.Connect();
        RouteDiscord._Instance();

        Process.Start(new ProcessStartInfo
        {
            FileName = Client.loginDiscordLink,
            UseShellExecute = true,
        });
    }
}
