using Microsoft.UI.Xaml.Controls;

using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

public sealed partial class MainStartGamePage : Page
{
    public MainStartGameViewModel ViewModel
    {
        get;
    }

    public MainStartGamePage()
    {
        ViewModel = App.GetService<MainStartGameViewModel>();
        InitializeComponent();
    }

    private void StartGameBtn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }
}
