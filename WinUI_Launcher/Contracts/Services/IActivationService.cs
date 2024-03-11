namespace WinUI_Launcher.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
