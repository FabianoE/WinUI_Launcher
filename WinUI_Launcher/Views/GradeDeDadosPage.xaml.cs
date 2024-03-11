using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUI_Launcher.Classes.Files;
using WinUI_Launcher.Classes.Files.Update;
using WinUI_Launcher.Contracts.Services;
using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class GradeDeDadosPage : Page
{
    public GradeDeDadosViewModel ViewModel
    {
        get;
    }

    public GradeDeDadosPage()
    {
        ViewModel = App.GetService<GradeDeDadosViewModel>();
        InitializeComponent();
    }

    private async void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.ButtonEnabled = false;
        ViewModel.ChangeVerifyText("EEEE");
        await UpdateClient.StartDownloadFile();
    }
}
