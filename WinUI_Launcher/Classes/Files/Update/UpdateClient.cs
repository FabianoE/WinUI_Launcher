using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace WinUI_Launcher.Classes.Files.Update;

public class UpdateClient
{
    public static WebClient client = new();

    public static List<UpdateInfo>? UpdateInfos = new();

    private static int _currentFileIndex = -1;

    public static bool _downloadFinished = _currentFileIndex == -1 || _currentFileIndex != -1 && _currentFileIndex == UpdateInfos.Count - 1;

    public delegate void OnVerifyingFile(int currentIndex, List<UpdateInfo> updateInfos);

    public delegate void OnDownloadProgressChanged(int progress, string progressDownloadSpeed);

    public delegate void OnDownloadFileCompleted(int currentIndex, List<UpdateInfo> updateInfos);

    public delegate void OnDownloadCompleted();

    static OnDownloadCompleted onDownloadCompleted;
    private static OnVerifyingFile onVerifyingFile;
    private static readonly Stopwatch stopwatch = new();


    public static bool DownloadJsonString()
    {
        try
        {
            UpdateInfos =
                JsonConvert.DeserializeObject<List<UpdateInfo>>(
                    client.DownloadString(client.BaseAddress + "/launcherUpdates.json"));
        }
        catch (Exception e)
        {
            File.WriteAllText("D:\\xampp\\htdocs\\newlauncher\\testerror.txt", e.Message);
            return false;
        }

        return true;
    }

    public static void Initialize(OnVerifyingFile _onVerifyingFile, OnDownloadProgressChanged onDownloadProgress,
        OnDownloadFileCompleted onDownloadFileCompleted, OnDownloadCompleted _onDownloadCompleted)
    {
        var hexString = "687474703a2f2f6c6f63616c686f73742f6e65776c61756e63686572";
        client.BaseAddress = Utils.HexToString(hexString);

        onVerifyingFile = _onVerifyingFile;
        onDownloadCompleted = _onDownloadCompleted;

        client.DownloadProgressChanged += (sender, e) =>
        {
            var downloadProgress = e.ProgressPercentage + "%";
            var downloadSpeed = string.Format("{0} MB/s",
                (e.BytesReceived / 1024.0 / 1024.0 / stopwatch.Elapsed.TotalSeconds).ToString("0.00"));
            var downloadedMBs = Math.Round(e.BytesReceived / 1024.0 / 1024.0) + " MB";
            var totalMBs = Math.Round(e.TotalBytesToReceive / 1024.0 / 1024.0) + " MB";

            var progress =
                $"{downloadedMBs}/{totalMBs} ({downloadProgress}) @ {downloadSpeed}"; // 10 MB / 100 MB (10%) @ 1.23 MB/s

            onDownloadProgress(e.ProgressPercentage, progress);
        };

        client.DownloadFileCompleted += (sender, args) =>
        {
            stopwatch.Reset();
            ChangeIndexFile();
            onDownloadFileCompleted(_currentFileIndex, UpdateInfos);

            if (_currentFileIndex == UpdateInfos.Count - 1)
            {
                onDownloadCompleted();
            }
        };
    }

    public static async Task StartDownloadFile()
    {
        try
        {
            if (_currentFileIndex == -1)
            {
                _currentFileIndex = 0;
            }

            var updateInfo = UpdateInfos[_currentFileIndex];
            onVerifyingFile(_currentFileIndex, UpdateInfos);

            var exists = File.Exists("." + updateInfo.FilePath);

            if (!exists)
            {
                await DownloadFile(updateInfo.FilePath);
                return;
            }

            var fileLenght = new FileInfo("." + updateInfo.FilePath).Length;

            MessageBox.NewMessageBox(client.BaseAddress + updateInfo.FilePath, client.BaseAddress + updateInfo.FilePath);

            if (fileLenght != updateInfo.FileLenght)
            {
                await DownloadFile(updateInfo.FilePath);
                return;
            }

            var res = await Utils.VerifyFileHash(updateInfo.FilePath, updateInfo.FileHash);

            if (!res)
            {
                await DownloadFile(updateInfo.FilePath);
                return;
            }

            ChangeIndexFile();
        }
        catch (Exception e)
        {
            MessageBox.NewMessageBox(e.Message, e.Message);
            throw;
        }
    }

    public static Task DownloadFile(string filePath)
    {
        stopwatch.Start();
        Directory.CreateDirectory("." + Path.GetDirectoryName(filePath));
        client.DownloadFileAsync(new Uri(client.BaseAddress + filePath), "." + filePath);
        MessageBox.NewMessageBox(client.BaseAddress + filePath, client.BaseAddress + filePath);
        return Task.CompletedTask;
    }

    private static async Task ChangeIndexFile()
    {
        if (UpdateInfos?[_currentFileIndex + 1] != null)
        {
            _currentFileIndex += 1;

            if (_currentFileIndex == UpdateInfos.Count - 1)
            {
                onDownloadCompleted();
                return;
            }

            await StartDownloadFile();
        }
    }
}