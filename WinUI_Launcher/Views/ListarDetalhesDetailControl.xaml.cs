using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using WinUI_Launcher.Core.Models;

namespace WinUI_Launcher.Views;

public sealed partial class ListarDetalhesDetailControl : UserControl
{
    public SampleOrder? ListDetailsMenuItem
    {
        get => GetValue(ListDetailsMenuItemProperty) as SampleOrder;
        set => SetValue(ListDetailsMenuItemProperty, value);
    }

    public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(ListarDetalhesDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

    public ListarDetalhesDetailControl()
    {
        InitializeComponent();
    }

    private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ListarDetalhesDetailControl control)
        {
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
