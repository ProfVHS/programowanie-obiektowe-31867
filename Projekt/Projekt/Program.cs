using System.Text.Json;
using Projekt;

var showsPath = Path.Combine(Directory.GetCurrentDirectory(), "shows.json");
var showsJson = File.ReadAllText(showsPath);

var moviesPath = Path.Combine(Directory.GetCurrentDirectory(), "movies.json");
var moviesJson = File.ReadAllText(moviesPath);

var roomsPath = Path.Combine(Directory.GetCurrentDirectory(), "rooms.json");
var roomsJson = File.ReadAllText(roomsPath);

var shows = JsonSerializer.Deserialize<List<Show>>(showsJson);
var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);
var rooms = JsonSerializer.Deserialize<List<Room>>(roomsJson);

bool exitProgram = false;
while (!exitProgram)
{
    Console.Clear();
    Console.WriteLine("== CINEMA ==");
    Console.WriteLine("[1] Manage Shows \n[2] Manage Rooms \n[3] Manage Movie \n[4] Exit");

    string choice1 = Console.ReadLine();

    switch (choice1)
    {
        case "1":
            ManageShows();
            break;
        case "2":
            ManageRooms();
            break;
        case "3":
            ManageMovies();
            break;
        case "4":
            exitProgram = true;
            break;
    }
}

void ManageShows()
{
    bool exit = false;
    Console.WriteLine("== SHOWS ==\n");

    while (!exit)
    {
        Console.Clear();

        Console.WriteLine("[1] Create show");
        Console.WriteLine("[2] Delete show");
        Console.WriteLine("[3] Duplicate show");
        Console.WriteLine("[4] Show all");
        Console.WriteLine("[5] Show seats for show");
        Console.WriteLine("[6] Create seat reservation");
        Console.WriteLine("[7] Remove seat reservation");
        Console.WriteLine("[8] Go back");

        var choice = Console.ReadLine();
        Console.Clear();

        switch (choice)
        {
            case "1":
                CreateShow();
                break;
            case "2":
                DeleteShow();
                break;
            case "3":
                DuplicateShow();
                break;
            case "4":
                WriteAllShows();
                PauseApplication();
                break;
            case "5":
                WriteAllSeatsForShow();
                PauseApplication();
                break;
            case "6":
                CreateSeatReservation();
                break;
            case "7":
                RemoveSeatReservation();
                break;
            case "8":
                exit = true;
                break;
        }
    }
}

void ManageMovies()
{
    bool exit = false;
    Console.WriteLine("== MOVIES ==\n");

    while (!exit)
    {
        Console.Clear();
        Console.WriteLine("[1] Create movie");
        Console.WriteLine("[2] Delete movie");
        Console.WriteLine("[3] Show all");
        Console.WriteLine("[4] Go back");

        var choice = Console.ReadLine();
        Console.Clear();

        switch (choice)
        {
            case "1":
                CreateMovie();
                break;
            case "2":
                DeleteMovie();
                break;
            case "3":
                WriteAllMovies();
                PauseApplication();
                break;
            case "4":
                exit = true;
                break;
        }
    }
}

void ManageRooms()
{
    bool exit = false;
    Console.WriteLine("== Rooms ==\n");

    while (!exit)
    {
        Console.Clear();
        Console.WriteLine("[1] Create room");
        Console.WriteLine("[2] Delete room");
        Console.WriteLine("[3] Show all");
        Console.WriteLine("[4] Go back");

        var choice = Console.ReadLine();
        Console.Clear();

        switch (choice)
        {
            case "1":
                CreateRoom();
                break;
            case "2":
                DeleteRoom();
                break;
            case "3":
                WriteAllRooms();
                PauseApplication();
                break;
            case "4":
                exit = true;
                break;
        }
    }
}

void CreateShow()
{
    WriteAllMovies();
    Console.WriteLine("Enter Movie Number: ");
    var movieId = int.Parse(Console.ReadLine());
    Console.Clear();

    WriteAllRooms();
    Console.WriteLine("Enter Room Number:\n");
    var roomId = int.Parse(Console.ReadLine());
    Console.Clear();

    Console.WriteLine("Enter Start Date (YYYY-MM-DD): ");
    var stringDate = Console.ReadLine();

    Console.WriteLine("Enter Start Time (HH:MM:SS): ");
    var stringTime = Console.ReadLine();

    var startDate = DateTime.Parse($"{stringDate}T{stringTime}");

    if (movieId > movies.Count)
    {
        Console.WriteLine($"Movie with ID: {movieId} doesn't exsits");
        PauseApplication();
        return;
    }

    if (roomId > rooms.Count)
    {
        Console.WriteLine($"Room with ID: {roomId} doesn't exsits");
        PauseApplication();
        return;
    }

    shows.Add(new Show(movies[movieId - 1], rooms[roomId - 1], startDate));
    SaveShowsJson();
}

void DeleteShow()
{
    WriteAllShows();

    Console.WriteLine("Enter Show Number: ");
    var showId = int.Parse(Console.ReadLine());
    if (showId > shows.Count)
    {
        Console.WriteLine($"Show with ID: {showId} doesn't exists");
        PauseApplication();
        return;
    }

    shows.RemoveAt(showId - 1);
    SaveShowsJson();
}

void DuplicateShow()
{
    WriteAllShows();

    Console.WriteLine("Enter Show Number: ");
    var showId = int.Parse(Console.ReadLine());
    if (showId > shows.Count)
    {
        Console.WriteLine($"Show with ID: {showId} doesn't exists");
        PauseApplication();
        return;
    }

    shows.Add(shows[showId - 1]);
    SaveShowsJson();
}

void WriteAllSeatsForShow()
{
    WriteAllShows();
    Console.WriteLine("Enter Show Number: ");

    var showId = int.Parse(Console.ReadLine());

    try
    {
        Console.WriteLine($"All Seats For Show Nr.{showId}: ");
        shows[showId - 1].WriteAllSeats();
    }
    catch (Exception _)
    {
        Console.WriteLine("Incorrect number entered.");
        PauseApplication();
        throw;
    }
}

void WriteAllShows()
{
    int i = 0;
    Console.WriteLine("All Shows:");
    foreach (var show in shows)
    {
        i++;
        Console.WriteLine($"\n{i}.{show}");
    }
}

void CreateSeatReservation()
{
    Show selectedShow;

    WriteAllShows();
    Console.WriteLine("Enter Show Number: ");
    var showId = int.Parse(Console.ReadLine());
    int seatRow;
    int seatNumber;

    try
    {
        selectedShow = shows[showId - 1];
        selectedShow.WriteAllSeats();
    }
    catch (Exception _)
    {
        Console.WriteLine("Incorrect number entered.");
        PauseApplication();
        throw;
    }

    Console.WriteLine("\nEnter Seat Row: ");
    seatRow = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter Seat Number: ");
    seatNumber = int.Parse(Console.ReadLine());

    try
    {
        selectedShow.ReserveSeat(seatRow, seatNumber);
        SaveShowsJson();
    }
    catch (Exception _)
    {
        Console.WriteLine("Incorrect seat number or row.");
        PauseApplication();
        throw;
    }
}

void RemoveSeatReservation()
{
    WriteAllShows();
    Console.WriteLine("\nEnter Show Number: ");
    var showId = Console.ReadLine();
    Show selectedShow;
    int seatRow;
    int seatNumber;

    try
    {
        selectedShow = shows[int.Parse(showId) - 1];
        selectedShow.WriteAllSeats();
        SaveShowsJson();
    }
    catch (Exception _)
    {
        Console.WriteLine("Incorrect number entered.");
        throw;
    }

    Console.WriteLine("\nEnter Seat Row: ");
    seatRow = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter Seat Number: ");
    seatNumber = int.Parse(Console.ReadLine());

    try
    {
        selectedShow.RemoveSeatReservation(seatRow, seatNumber);
        SaveShowsJson();
    }
    catch (Exception _)
    {
        Console.WriteLine("Incorrect seat number or row.");
        throw;
    }
}

void WriteAllMovies()
{
    Console.WriteLine("Movie List");
    int i = 0;
    foreach (var movie in movies)
    {
        i++;
        Console.WriteLine($"[{i}] {movie.Title} - {movie.getDuration()} ");
    }
}

void CreateMovie()
{
    Console.WriteLine("Enter Title: ");
    var title = Console.ReadLine();
    Console.WriteLine("Enter Duration: ");
    var duration = int.Parse(Console.ReadLine());

    if (duration < 1)
    {
        Console.WriteLine("Duration must be greater than or equal to 1.");
        PauseApplication();
        return;
    }

    movies.Add(new Movie(title, duration));
    SaveMoviesJson();
}

void DeleteMovie()
{
    WriteAllMovies();
    Console.WriteLine("Enter Movie Number: ");
    var movieId = int.Parse(Console.ReadLine());

    if (movieId > movies.Count)
    {
        Console.WriteLine($"Movie with ID: {movieId} doesn't exsits");
        PauseApplication();
        return;
    }

    var selectedMovie = movies[movieId - 1];
    var showsToDelete = shows.FindAll(show => show.Movie == selectedMovie);

    if (showsToDelete.Count > 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "If you delete this room, all shows in this room will be deleted. Are you sure you want to delete this movie? Y/N");
        Console.ResetColor();

        var con = Console.ReadLine();
        if (con.ToLower() == "n")
        {
            return;
        }

        if (con.ToLower() == "y")
        {
            shows = shows.FindAll(show => show.Movie != selectedMovie);
            SaveShowsJson();
        }
    }

    movies.RemoveAt(movieId - 1);
    SaveMoviesJson();
}

void CreateRoom()
{
    WriteAllRooms();
    Console.WriteLine("Enter Room Number: ");
    var roomNumber = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the number of rows of seats in the room.");
    int seatsRows = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the number of seats per row.");
    int seatsPerRow = int.Parse(Console.ReadLine());

    if (seatsRows < 0)
    {
        Console.WriteLine("Number of rows of seats must be greater than or equal to 0.");
        PauseApplication();
        return;
    }

    if (seatsPerRow < 0)
    {
        Console.WriteLine("Number of seats per rows must be greater than or equal to 0.");
        PauseApplication();
        return;
    }

    rooms.Add(new Room(roomNumber, seatsRows, seatsPerRow));
    SaveRoomsJson();
}

void DeleteRoom()
{
    WriteAllRooms();
    var roomId = int.Parse(Console.ReadLine());
    if (roomId > rooms.Count)
    {
        Console.WriteLine($"Room with ID: {roomId} doesn't exist");
        Console.ReadLine();
        return;
    }

    var selectedRoom = rooms[roomId - 1];

    var showsToDelete = shows.FindAll(show => show.Room == selectedRoom);
    if (showsToDelete.Count > 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "If you delete this room, all shows in this room will be deleted. Are you sure you want to delete this movie? Y/N");
        Console.ResetColor();

        var con = Console.ReadLine();
        if (con.ToLower() == "n")
        {
            return;
        }

        if (con.ToLower() == "y")
        {
            shows = shows.FindAll(show => show.Room != selectedRoom);
            SaveShowsJson();
        }
    }

    rooms.RemoveAt(roomId - 1);
    SaveRoomsJson();
}

void WriteAllRooms()
{
    Console.WriteLine("Rooms List");
    int i = 0;
    foreach (var room in rooms)
    {
        i++;
        Console.WriteLine($"[{i}] Room nr. {room.Number}: {room.getSeatsCount()} seats");
    }
}

void PauseApplication()
{
    Console.WriteLine("\nPress enter to continue...");
    Console.ReadLine();
}

void SaveShowsJson()
{
    File.WriteAllText(showsPath, JsonSerializer.Serialize(shows));
}

void SaveMoviesJson()
{
    File.WriteAllText(moviesPath, JsonSerializer.Serialize(movies));
}

void SaveRoomsJson()
{
    File.WriteAllText(roomsPath, JsonSerializer.Serialize(rooms));
}