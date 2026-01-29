namespace Projekt;

public class Show
{
    public Movie Movie { get; }
    public Room Room { get; }
    public DateTime StartAt { get; }
    public DateTime EndAt { get; }

    public List<Seat> seats { get; set; } = new List<Seat>();

    public Show(Movie movie, Room room, DateTime startAt)
    {
        Movie = movie;
        Room = room;
        StartAt = startAt;
        EndAt = StartAt.AddMinutes(movie.Duration);

        for (int i = 1; i <= Room.RowsNumber; i++)
        {
            for (int j = 1; j <= Room.SeatsPerRow; j++)
            {
                if (i == Room.RowsNumber)
                {
                    seats.Add(new VipSeat(i, j));
                }
                else
                {
                    seats.Add(new BasicSeat(i, j));
                }
            }
        }
    }

    public override string ToString()
    {
        string date = StartAt.ToString("dd/MM/yyyy");
        string formattedStartAt = StartAt.ToString("HH:mm");
        string formattedEndAt = EndAt.ToString("HH:mm");
        return
            $"{Movie.Title}: {date} {formattedStartAt}-{formattedEndAt}, Room: {Room.Number}, Available Seats: {EmptySeatsNumber()}";
    }

    public int EmptySeatsNumber()
    {
        return seats.FindAll(s => s.IsEmpty).Count;
    }

    public void WriteAllSeats()
    {
        Console.Write("  ");
        for (int i = 1; i <= Room.SeatsPerRow; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{i,4}");
        }

        int lastRow = 0;
        foreach (var seat in seats)
        {
            if (lastRow != seat.Row)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\n{seat.Row,2}");
            }

            lastRow = seat.Row;
            if (seat.IsEmpty)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

            Console.Write($"{seat.GetSymbol(),4}");
        }
    }

    public void ReserveSeat(int row, int number)
    {
        var seat = seats.Find(s => s.Row == row && s.Number == number);
        if (seat.IsEmpty)
        {
            seat.ToggleIsEmpty();
            Console.WriteLine("Seat reserved successfully.");
        }
        else
        {
            Console.WriteLine("This seat is already reserved.");
        }
    }

    public void RemoveSeatReservation(int row, int number)
    {
        var seat = seats.Find(s => s.Row == row && s.Number == number);
        if (!seat.IsEmpty)
        {
            seat.ToggleIsEmpty();
            Console.WriteLine("Seat reservation successfully removed.");
        }
        else
        {
            Console.WriteLine("This seat is not reserved.");
        }
    }
}