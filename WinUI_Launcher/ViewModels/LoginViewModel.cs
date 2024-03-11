using CommunityToolkit.Mvvm.ComponentModel;
using WinUI_Launcher.Classes;
using WinUI_Launcher.Classes.Network;

namespace WinUI_Launcher.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool loginButtonEnabled;


    public LoginViewModel()
    {
        LoginButtonEnabled = false;
        RunEvents.RunEvent(Classes.Events.EventsTypes.Started, "");

        ConnectLoopV();
    }

    private async Task ConnectLoopV()
    {
        int n = 0;
        while (true)
        {
            if (Client.SocketClient.Connected)
            {
                break;
            }

            if (n == 10)
            {
                MessageBox.NewMessageBox("", Client.SocketClient.Connected.ToString(), false);
                break;
            }

            n++;
            await Task.Delay(1000);
        }
        if (Client.isLogged)
        {
            RunEvents.RunEvent(Classes.Events.EventsTypes.Logged, "");
            return;
        }

        LoginButtonEnabled = Client.SocketClient.Connected;
    }
}
