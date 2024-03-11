using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using WinUI_Launcher.Classes;
using WinUI_Launcher.Classes.Files;
using WinUI_Launcher.Classes.Files.Update;
using WinUI_Launcher.Classes.Structs;
using WinUI_Launcher.Contracts.ViewModels;
using WinUI_Launcher.Core.Contracts.Services;
using WinUI_Launcher.Core.Models;

namespace WinUI_Launcher.ViewModels;


public partial class GradeDeDadosViewModel : ObservableRecipient, INavigationAware
{
    [ObservableProperty]
    private string _verifyText;

    [ObservableProperty]
    private bool _buttonEnabled;

    public GradeDeDadosViewModel(ISampleDataService sampleDataService)
    {
        RunEvents.RegisterEvent(Classes.Events.EventsTypes.UpdateSystem_ChangeText, (x) =>
        {
            ChangeVerifyText(x as string);
        });

        ButtonEnabled = UpdateClient._downloadFinished;
    }

    public async void OnNavigatedTo(object parameter)
    {

    }

    public void OnNavigatedFrom()
    {
    }


    public void ChangeVerifyText(string text)
    {
        VerifyText = text;
    }
}
