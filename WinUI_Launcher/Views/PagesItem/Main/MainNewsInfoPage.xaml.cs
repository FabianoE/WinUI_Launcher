using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using WinUI_Launcher.Classes;
using WinUI_Launcher.Classes.Structs;
using WinUI_Launcher.Contracts.Services;
using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

public sealed partial class MainNewsInfoPage : Page
{

    public MainNewsInfoViewModel ViewModel
    {
        get;
    }

    public MainNewsInfoPage()
    {
        ViewModel = App.GetService<MainNewsInfoViewModel>();
        InitializeComponent();
    }

    private void OpenButtonLinkFromTag(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var tagContent = ((ButtonBase)sender).Tag.ToString();

        var tagProperty = tagContent.Split('$');

        if (tagProperty.Length > 1)
        {
            bool isOpenUrlIfCancel = tagProperty.Contains("OpenUrlIfCancel");
            if (!isOpenUrlIfCancel) return;
        }

        RegionListHelper.regionGames.SetGame(1);
        RunEvents.RunEvent(Classes.Events.EventsTypes.OpenWebView, new Uri(tagProperty[0]));
    }
}
