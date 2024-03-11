using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_Launcher.Classes.Structs;

public struct GameStruct
{
    public int GameId
    {
        get; set;
    }
    public string GameName
    {
        get; set;
    }
    public string GameDescription
    {
        get; set;
    }
    public string GameIconUrl
    {
        get; set;
    }
    public IList<AnnounceStruct> GameNoticesJson
    {
        get; set;
    }
    public IList<AnnounceStruct> GameImageNoticesJson
    {
        get; set;
    }
}
