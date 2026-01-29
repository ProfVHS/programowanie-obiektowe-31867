using System.Text.Json.Serialization;

namespace Projekt;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(BasicSeat), "basic")]
[JsonDerivedType(typeof(VipSeat), "vip")]
public abstract class Seat
{
    public int Number { get; set; }
    public int Row { get; set; }
    public bool IsEmpty { get; set; }
    
    public Seat() { }

    public Seat(int row, int number)
    {
        Row = row;
        Number = number;
        IsEmpty = true;
    }

    public abstract string GetSymbol();

    public void ToggleIsEmpty()
    {
        IsEmpty = !IsEmpty;
    }
}

public class BasicSeat : Seat
{
    public BasicSeat(int row, int number) : base(row, number)
    {
        
    }

    public override string GetSymbol()
    {
        return IsEmpty ? "O" : "X";
    }
}

public class VipSeat : Seat
{
    public VipSeat(int row, int number) : base(row, number)
    {
        
    }

    public override string GetSymbol()
    {
        return IsEmpty ? "V" : "#";
    }
}