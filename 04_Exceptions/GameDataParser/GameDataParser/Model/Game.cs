namespace GameDataParser.Model;

public class Game(string title, int releaseYear, float rating)
{
    public string Title => title;
    public int ReleaseYear => releaseYear;
    public float Rating => rating;
}