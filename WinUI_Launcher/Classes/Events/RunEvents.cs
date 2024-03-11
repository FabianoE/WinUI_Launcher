using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUI_Launcher.Classes.Events;
using WinUI_Launcher.Classes.Files;
using WinUI_Launcher.Classes.Network;
using WinUI_Launcher.Contracts.Services;
using WinUI_Launcher.Views;

namespace WinUI_Launcher.Classes;

public class RunEvents
{
    public delegate void RegionEventHandler(object args);
    private static List<KeyValuePair<EventsTypes, RegionEventHandler>> registeredEvents = new();

    static RunEvents()
    {
        BaseEvents();
    }

    public static void RunEvent(EventsTypes eventsType, object arg)
    {
        PreCallEvents(eventsType);
        registeredEvents.ForEach(e =>
        {
            if (e.Key != eventsType)
                return;

            e.Value.Invoke(arg);
        });
    }

    public static void RegisterEvent(EventsTypes eventsType, RegionEventHandler reg)
    {
        registeredEvents.Add(new KeyValuePair<EventsTypes, RegionEventHandler>(eventsType, reg));
    }

    private static void BaseEvents()
    {
        RegisterEvent(EventsTypes.Started, (x) =>
        {
            Client.Connect();
            MessageBox.NewMessageBox("Connecting", "Wait", false);
            ClassTests.GamesTestStatics.SetTestGames();
        });
    }

    private static void PreCallEvents(EventsTypes eventsType)
    {
        switch (eventsType)
        {
            case EventsTypes.OpenWebView:
                App.GetService<INavigationService>().NavigateTo("WinUI_Launcher.ViewModels.ExibiçãoDaWebViewModel");
                break;
            case EventsTypes.Logged:
                App.MainWindow.Content = App.GetService<ShellPage>();
                App.GetService<INavigationService>().NavigateTo("WinUI_Launcher.ViewModels.MainViewModel");
                UpdateSystem.Initialize();
                break;
        }
    }
}
