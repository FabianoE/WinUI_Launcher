﻿namespace WinUI_Launcher.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);
}
