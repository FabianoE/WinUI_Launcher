using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

public sealed partial class ListarDetalhesPage : Page
{
    public ListarDetalhesViewModel ViewModel
    {
        get;
    }

    public ListarDetalhesPage()
    {
        ViewModel = App.GetService<ListarDetalhesViewModel>();
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
