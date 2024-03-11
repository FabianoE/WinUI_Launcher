using Microsoft.UI.Xaml.Controls;

using WinUI_Launcher.ViewModels;

namespace WinUI_Launcher.Views;

public sealed partial class GradeDeConteúdoPage : Page
{
    public GradeDeConteúdoViewModel ViewModel
    {
        get;
    }

    public GradeDeConteúdoPage()
    {
        ViewModel = App.GetService<GradeDeConteúdoViewModel>();
        InitializeComponent();
    }
}
