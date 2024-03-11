using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WinUI_Launcher.Classes;
using WinUI_Launcher.Contracts.Services;

namespace WinUI_Launcher.ViewModels;

public partial class MainNewsInfoViewModel : ObservableRecipient
{
    public MainNewsInfoViewModel()
    {
        RegionListHelper.regionAnnounce.AddAnnounce(new AnnounceStruct
        {
            title = $"[{PostCarouselType.ANNOUNCE}] Notice 1",
            url = "http://localhost:8000/",
            show_time = "18/11",
            type = PostCarouselType.ANNOUNCE
        });

        RegionListHelper.regionAnnounce.AddAnnounce(new AnnounceStruct
        {
            title = $"[{PostCarouselType.INFO}] Notice 2",
            url = "http://www.google.comm",
            show_time = "18/11",
            type = PostCarouselType.ANNOUNCE
        });

        RegionListHelper.regionAnnounce.AddAnnounce(new AnnounceStruct
        {
            title ="IMG",
            img = "https://windows-cdn.softpedia.com/screenshots/Starward_3.png",
        });

        RegionListHelper.regionAnnounce.AddAnnounce(new AnnounceStruct
        {
            title = "IMG",
            img = "https://windows-cdn.softpedia.com/screenshots/Starward_3.png",
        });
    }
}
