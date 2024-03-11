using CommunityToolkit.Mvvm.ComponentModel;
using WinUI_Launcher.Classes;
using WinUI_Launcher.Classes.Structs;

namespace WinUI_Launcher.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    [ObservableProperty]
    private GameStruct gameStruct;

    public MainViewModel()
    {
        SetValues();
        RegisterEvents();
    }

    private void SetValues()
    {
        GameStruct = Classes.RegionListHelper.regionGames.GetCurrentGame();
    }

    private void RegisterEvents()
    {
        RunEvents.RegisterEvent(Classes.Events.EventsTypes.SelectedGame, (obj) =>
        {
            GameStruct = (GameStruct)obj;
        });
    }
}
