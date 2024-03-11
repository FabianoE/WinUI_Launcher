using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WinUI_Launcher.Classes.Structs;
using WinUI_Launcher.Views;

namespace WinUI_Launcher.Classes;


public static class RegionListHelper
{
    public static UserInfo userInfo = new ();
    public static HomeAnnounce regionAnnounce = new();
    public static HomeGames regionGames = new();
}

public class HomeAnnounce
{
    public IList<AnnounceStruct> News { get; set; } = new List<AnnounceStruct>();
    public IList<AnnounceStruct> Images { get; set; } = new List<AnnounceStruct>();

    public void AddAnnounce(AnnounceStruct announceStruct)
    {
        if (News.Contains(announceStruct) || Images.Contains(announceStruct))
            return;

        if (announceStruct.title == "IMG")
        {
            Images.Add(announceStruct);
            return;
        }

        if (string.IsNullOrEmpty(announceStruct.img))
        {
            News.Add(announceStruct);
            return;
        }    
    }
}

public class HomeGames
{
    public int GameIdSelected { get; set; } = 0;

    public IList<GameStruct> Games { get; set; } = new List<GameStruct>();

    public void SetGame(int gameId)
    {
        GameIdSelected = gameId;
        RunEvents.RunEvent(Events.EventsTypes.SelectedGame, GetCurrentGame());
    }

    public GameStruct GetCurrentGame()
    {
        if (!Games.Any())
        {
            return new GameStruct
            {
                GameName = "Test"
            };
        }

        return GetGame(GameIdSelected);
    }

    public GameStruct GetGame(int id)
    {
        return Games.Where(x => x.GameId == id).FirstOrDefault();
    }

    public void AddGame(GameStruct gameStruct)
    {
        if(Games.Contains(gameStruct)) 
            return;

        Games.Add(gameStruct);
    }
}
