namespace Projekt;

public class Room
{
    public int Number { get; }
    public int RowsNumber { get; }
    public int SeatsPerRow { get; }

    public Room(int number, int rowsNumber, int seatsPerRow)
    {
        Number = number;
        RowsNumber = rowsNumber;
        SeatsPerRow = seatsPerRow;
    }

    public int getSeatsCount()
    {
        return RowsNumber * SeatsPerRow;
    }
}