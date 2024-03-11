using Microsoft.UI.Xaml.Controls;

using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class ExibiçãoDaWebPage : Page
{
    public ExibiçãoDaWebViewModel ViewModel
    {
        get;
    }

    public ExibiçãoDaWebPage()
    {
        ViewModel = App.GetService<ExibiçãoDaWebViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
