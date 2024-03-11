using Microsoft.UI.Xaml.Controls;
using WinUI_Launcher.Classes;
using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }

}
