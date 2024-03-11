using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using WinUI_Launcher.Classes.Network;
using static System.Net.Mime.MediaTypeNames;

namespace WinUI_Launcher.Classes.WebConnection;
public class RouteDiscord : LocalHttp
{
    private static RouteDiscord Instance
    {
        get; set;
    }

    public static RouteDiscord _Instance()
    {
        if (Instance == null)
        {
            Instance = new RouteDiscord();
        }

        return Instance;
    }

    public RouteDiscord() : base("discord")
    {
        MessageBox.NewMessageBox("Login", "Waiting for the browser's response", false);
    }


    public override void Receive(HttpListenerRequest req, HttpListenerResponse res)
    {
        MessageBox.CloseLastDialog();
        Stream ResponseBody = res.OutputStream; 
        string html = "Go back to the Launcher.";

        byte[] buffer = Encoding.UTF8.GetBytes(html);
       
        res.ContentLength64 = buffer.Length;
        ResponseBody.Write(buffer, 0, buffer.Length);
        res.Redirect("https://github.com/FabianoE/");


        Client.SendDiscordResponse(req.QueryString["code"]);
        RunEvents.RunEvent(Classes.Events.EventsTypes.Logged, null);
        res.Close();
    }
}
