using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

using WinUI_Launcher.Contracts.Services;
using WinUI_Launcher.ViewModels;
using WinUI_Launcher.Views;

namespace WinUI_Launcher.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<MainViewModel, MainPage>();
        Configure<ExibiçãoDaWebViewModel, ExibiçãoDaWebPage>();
        Configure<ListarDetalhesViewModel, ListarDetalhesPage>();
        Configure<GradeDeConteúdoViewModel, GradeDeConteúdoPage>();
        Configure<GradeDeConteúdoDetailViewModel, GradeDeConteúdoDetailPage>();
        Configure<GradeDeDadosViewModel, GradeDeDadosPage>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<MainNewsInfoViewModel, MainNewsInfoPage>();
        Configure<MainStartGameViewModel, MainStartGamePage>();
        Configure<MenuGamesViewModel, MenuGamesPage>();
        Configure<LoginViewModel, LoginPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
