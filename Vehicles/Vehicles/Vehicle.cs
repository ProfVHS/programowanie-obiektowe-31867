namespace Lab3;

public abstract class Vehicle
{
    public double EngineCapacity { get; protected set; }
    public string Model { get; protected set; }
    public int Year { get; protected set; }

    public Vehicle(double engineCapacity, string model, int year)
    {
        EngineCapacity = engineCapacity;
        Model = model;
        Year = year;
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle started.");
    }

    public virtual void Stop()
    {
        Console.WriteLine("Vehicle stopped.");
    }
}