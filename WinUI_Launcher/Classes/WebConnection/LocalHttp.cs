using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_Launcher.Classes.WebConnection;
public class LocalHttp
{
    private HttpListener HttpListener
    {
        get; set;
    }

    public LocalHttp(string route)
    {
        HttpListener = new HttpListener();
        HttpListener.Prefixes.Add($"http://127.0.0.1:3456/{route}/");

        HttpListener.Start();
        _ = Handler();
    }

    private async Task Handler()
    {
        while (true)
        {
            var response = await HttpListener.GetContextAsync();
            var request = response.Request;

            Receive(request, response.Response);
        }
    }

    public virtual void Receive(HttpListenerRequest req, HttpListenerResponse res) { }
}
