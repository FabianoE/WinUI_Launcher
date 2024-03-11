using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WinUI_Launcher.Classes.Files.Update;
using WinUI_Launcher.Classes.Structs;

namespace WinUI_Launcher.Classes.Files;
public class UpdateSystem
{
    public static IList<UpdateInfo> FilesList
    {
        get; set;
    }

    public static void Initialize()
    {
        UpdateClient.Initialize(onVerify, onDownloadProgress, onDownloadedFile, onDownloadsFinish);
        UpdateClient.DownloadJsonString();

        FilesList = UpdateClient.UpdateInfos;
    }

    private static void onVerify(int currentIndex, List<UpdateInfo> updateInfos)
    {

    }

    private static void onDownloadProgress(int progress, string progressDownloadSpeed)
    {

    }

    private static void onDownloadedFile(int currentIndex, List<UpdateInfo> updateInfos)
    {

    }

    private static void onDownloadsFinish()
    {

    }
}
