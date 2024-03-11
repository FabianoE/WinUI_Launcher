namespace WinUI_Launcher.Classes;

public enum PostCarouselType
{
    INFO,
    ACTIVITY,
    ANNOUNCE
}

public struct AnnounceStruct
{
    private string _url;

    public string img
    {
        get; set;
    }
    public string url
    {
        get => _url;
        set => _url = StripTabsAndNewlines(value);
    }
    public string title
    {
        get; set;
    }

    public string show_time
    {
        get; set;
    }
    public PostCarouselType type
    {
        get; set;
    }

    private unsafe string StripTabsAndNewlines(ReadOnlySpan<char> s)
    {
        int len = s.Length;
        char* newChars = stackalloc char[len];
        char* currentChar = newChars;

        for (int i = 0; i < len; ++i)
        {
            char c = s[i];

            if (c == '\r' || c == '\n' || c == '\t') continue;
            *currentChar++ = c;
        }
        return new string(newChars, 0, (int)(currentChar - newChars));
    }
}
