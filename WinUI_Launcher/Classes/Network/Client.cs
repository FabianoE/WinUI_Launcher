namespace WinUI_Launcher.Classes.Network;


public class Client
{

    public static SocketIOClient.SocketIO SocketClient;
    public static bool isLogged = false;
    public static string loginDiscordLink = "";

    Client()
    {

    }

    public static async void Connect()
    {
        SocketClient = new SocketIOClient.SocketIO("http://localhost:3000/");
        SocketClient.Options.ReconnectionAttempts = 1;

        SocketClient.On("loginResponse", response =>
        {
            bool success = response.GetValue<bool>();

            if (success)
            {
                isLogged = true;
                return;
            }

            loginDiscordLink = response.GetValue<string>(1);
        });

        SocketClient.On("userInfo", response =>
        {
            RegionListHelper.userInfo.GlobalName = response.GetValue<string>();
        });


        //Incomplete Notices, not working
        SocketClient.On("notices", response =>
        {
            int count = response.GetValue<int>();

            if (count <= 0)
                return;

            RegionListHelper.regionAnnounce.News.Clear();

            for (int i = 0; i < count; i++)
            {
                //var tit = response.GetValue<string>(1 + i);

                //if (tit == "IMG")
                //{
                //    RegionListHelper.regionAnnounce.AddAnnounce(new AnnounceStruct
                //    {
                //        img = response.GetValue<string>(4 + i)
                //    });
                //    continue;
                //}

                //RegionListHelper.regionAnnounce.AddAnnounce(new AnnounceStruct
                //{
                //    title = tit,
                //    url = response.GetValue<string>(2 + i),
                //    show_time = response.GetValue<string>(3 + i),
                //    type = PostCarouselType.ANNOUNCE
                //});
            }
            
        });

        SocketClient.OnConnected += async (sender, e) =>
        {
            SendHardwareInfo();
        };

        await SocketClient.ConnectAsync();
    }


    //Write your function to get hwid from pc
    public static void SendHardwareInfo()
    {
        SocketClient.EmitAsync("hardware", "ABC-DEF");
    }

    public static void SendDiscordResponse(string code)
    {
        SocketClient.EmitAsync("dscode", code);
    }
}
