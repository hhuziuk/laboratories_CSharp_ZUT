abstract class Car
{
    protected bool isRunning;
    protected string fuelType;

    public void Start()
    {
        string message = !isRunning ? "Starting the car" : "The car is already running";
        Console.WriteLine(message);
        isRunning = true;
    }

    public void Stop()
    {
        string message = isRunning ? "Stopping the car" : "The car is already stopped";
        Console.WriteLine(message);
        isRunning = isRunning ? false : true;
    }

    public abstract void Refuel();

    public void Drive()
    {
        string message = isRunning ? "Driving with " + fuelType : "The car is not running. Start the car first.";
        Console.WriteLine(message);
        isRunning = isRunning ? true : false;

    }
}

class GasCar : Car
{
    public GasCar()
    {
        fuelType = "gas";
    }
    public override void Refuel()
    {
        Console.WriteLine($"Refueling with {fuelType}");
    }
}

class GasolineCar : Car
{
    public GasolineCar()
    {
        fuelType = "gasoline";
    }
    public override void Refuel()
    {
        Console.WriteLine($"Refueling with {fuelType}");
    }
}

class ElectricCar : Car
{
    public ElectricCar()
    {
        fuelType = "electricity";
    }

    public override void Refuel()
    {
        Console.WriteLine($"Refueling with {fuelType}");
    }
}

class Program
{
    static void TestDrive(Car car)
    {
        Console.WriteLine("Testing the car:");
        car.Start();
        car.Refuel();
        car.Drive();
        car.Stop();
    }

    static void Main()
    {
        List<Car> cars = new List<Car>
        {
            new GasolineCar(),
            new ElectricCar(),
            new GasCar()
        };

        foreach (var car in cars)
        {
            TestDrive(car);
        }
    }
}