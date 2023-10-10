abstract class Car
{
    protected bool isRunning;
    protected string fuelType;

    public void Start()
    {
        if (!isRunning)
        {
            Console.WriteLine("Starting the car");
            isRunning = true;
        }
        else
        {
            Console.WriteLine("The car is already running");
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            Console.WriteLine("Stopping the car");
            isRunning = false;
        }
        else
        {
            Console.WriteLine("The car is already stopped");
        }
    }

    public virtual void Refuel()
    {
        Console.WriteLine($"Refueling with {fuelType}");
    }

    public virtual void Drive()
    {
        if (isRunning)
        {
            Console.WriteLine("Driving with " + fuelType);
        }
        else
        {
            Console.WriteLine("The car is not running. Start the car first.");
        }
    }
}

class GasCar : Car
{
    public GasCar()
    {
        fuelType = "gas";
    }
}

class GasolineCar : Car
{
    public GasolineCar()
    {
        fuelType = "gasoline";
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
        Console.WriteLine("Charging the batteries");
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

    static void Main(string[] args)
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