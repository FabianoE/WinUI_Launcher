using CommunityToolkit.Mvvm.ComponentModel;

using WinUI_Launcher.Contracts.ViewModels;
using WinUI_Launcher.Core.Contracts.Services;
using WinUI_Launcher.Core.Models;

namespace WinUI_Launcher.ViewModels;

public partial class GradeDeConteúdoDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? item;

    public GradeDeConteúdoDetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
