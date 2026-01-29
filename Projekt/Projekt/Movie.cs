namespace Projekt;

public class Movie
{
    public string Title { get; }
    public int Duration { get; }

    public Movie(string title, int duration)
    {
        Title = title;
        Duration = duration;
    }

    public string getDuration()
    {
        int hours = Duration / 60;
        int minutes = Duration - (hours * 60);
        return $"{hours}h {minutes}min";
    }
}