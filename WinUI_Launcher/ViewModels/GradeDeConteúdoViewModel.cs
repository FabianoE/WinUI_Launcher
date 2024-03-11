using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WinUI_Launcher.Classes.Files;
using WinUI_Launcher.Classes.Structs;
using WinUI_Launcher.Contracts.Services;
using WinUI_Launcher.Contracts.ViewModels;
using WinUI_Launcher.Core.Contracts.Services;
using WinUI_Launcher.Core.Models;

namespace WinUI_Launcher.ViewModels;

public partial class GradeDeConteúdoViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly ISampleDataService _sampleDataService;



    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public GradeDeConteúdoViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
    {
        _navigationService = navigationService;
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetContentGridDataAsync();
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void OnItemClick(SampleOrder? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(GradeDeConteúdoDetailViewModel).FullName!, clickedItem.OrderID);
        }
    }
}
