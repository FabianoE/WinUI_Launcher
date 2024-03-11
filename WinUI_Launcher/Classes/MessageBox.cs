using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace WinUI_Launcher.Classes;
public class MessageBox
{
    private static ContentDialog _lastDialog;

    public static async Task<ContentDialog> NewMessageBox(string title, string message, bool okButton = true)
    {
        if (_lastDialog != null)
            _lastDialog.Hide();

        _lastDialog = new ContentDialog()
        {
            Title = title,
            Content = message,
            CloseButtonText = okButton ? "OK" : null,
            HorizontalAlignment= Microsoft.UI.Xaml.HorizontalAlignment.Center,
        };

        _lastDialog.XamlRoot = App.MainWindow.Content.XamlRoot;
        _ = await _lastDialog.ShowAsync();

        return _lastDialog;
    }

    public static void CloseLastDialog()
    {
        _lastDialog?.Hide();
    }
}
