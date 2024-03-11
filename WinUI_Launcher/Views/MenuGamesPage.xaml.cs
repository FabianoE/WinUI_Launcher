using Microsoft.UI.Xaml.Controls;

using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

public sealed partial class MenuGamesPage : Page
{
    public MenuGamesViewModel ViewModel
    {
        get;
    }

    public MenuGamesPage()
    {
        ViewModel = App.GetService<MenuGamesViewModel>();
        InitializeComponent();
    }
}
