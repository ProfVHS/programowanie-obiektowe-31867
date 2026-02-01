using System.Text.Json.Serialization;

namespace Projekt;

public class Movie
{
    public string Title { get; set; }
    [JsonInclude]
    private int Duration { get; set; }

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

    public DateTime getEndDateTime(DateTime startDate)
    {
        return startDate.AddMinutes(Duration);
    }
}