using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUI_Launcher.Classes.Structs;

namespace WinUI_Launcher.Classes.ClassTests;

public static class GamesTestStatics
{

    public static bool isLogged = false;
    public static void SetTestGames()
    {
        GameStruct game1 = new GameStruct
        {
            GameId = 1,
            GameName = "Test",
            GameDescription = "Test",
            GameIconUrl = "https://w7.pngwing.com/pngs/975/837/png-transparent-crossfire-logo-game-roblox-creative-social-icon-miscellaneous-angle-emblem-thumbnail.png",
            GameImageNoticesJson = new AnnounceStruct[]
            {
                new AnnounceStruct
                {
                    img = "https://miro.medium.com/v2/resize:fit:828/1*aNcW27Hn1Qx2WWcf0h2ztw.jpeg"
                },
                new AnnounceStruct
                {
                    img = "https://i.ytimg.com/vi/w0OhUqwbRyU/maxresdefault.jpg"
                }
            },
            GameNoticesJson = new AnnounceStruct[]
            {
                new AnnounceStruct
                {
                    title = "Test",
                    show_time = "12/11",
                    type = PostCarouselType.INFO,
                    url = "http://google.com",
                }
            }
        };

        GameStruct game2 = new GameStruct
        {
            GameId = 2,
            GameName = "Test 2",
            GameDescription = "Test 2",
            GameIconUrl = "https://e7.pngegg.com/pngimages/11/791/png-clipart-cubed-craft-survival-compass-brand-logo-emblem-crossfire-logo-game-emblem.png",
            GameImageNoticesJson = new AnnounceStruct[]
            {
                new AnnounceStruct
                {
                    img = "https://miro.medium.com/v2/resize:fit:828/1*aNcW27Hn1Qx2WWcf0h2ztw.jpeg"
                },
                new AnnounceStruct
                {
                    img = "https://i.ytimg.com/vi/w0OhUqwbRyU/maxresdefault.jpg"
                }
            },
            GameNoticesJson = new AnnounceStruct[]
            {
                new AnnounceStruct
                {
                    title = "Test 2",
                    show_time = "12/11",
                    type = PostCarouselType.INFO,
                    url = "http://google.com",
                }
            }
        };

        RegionListHelper.regionGames.Games.Clear();
        RegionListHelper.regionGames.AddGame(game1);
        RegionListHelper.regionGames.AddGame(game2);
        RegionListHelper.regionGames.SetGame(2);
    }
}
