
interface CarInterface
{
    void Start();
    void Stop();
    void Refuel();
    void Drive();
}

interface GasCarInterface
{
    void RefuelGas();
}

interface ElectricCarInterface
{
    void Recharge();
}

class GasCar : CarInterface, GasCarInterface
{
    private bool isRunning;
    private bool isRefueled;

    public void Start() => Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");

    public void Stop() => Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");

    public void Refuel() => Console.WriteLine(!isRefueled ? "Refueling the car with gas" : "Car is already refueled");

    public void Drive() => Console.WriteLine(isRunning && isRefueled ? "Driving with gas" : !isRunning ? "Car is not running" : "No gas to drive");

    public void RefuelGas() => Refuel();
}

class ElectricCar : CarInterface, ElectricCarInterface
{
    private bool isRunning;
    private bool isCharged;

    public void Start() => Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");

    public void Stop() => Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");

    public void Refuel() => Console.WriteLine(!isCharged ? "Charging the car" : "Car is already charged");

    public void Drive() => Console.WriteLine(isRunning && isCharged ? "Driving with electricity" : !isRunning ? "Car is not running" : "No charge to drive");

    public void Recharge() => Refuel();
}

class GasCarHybrid : CarInterface, GasCarInterface, ElectricCarInterface
{
    private bool isRunning;
    private bool isGasRefueled;
    private bool isCharged;

    public void Start() => Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");

    public void Stop() => Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");

    public void RefuelGas() => Console.WriteLine(!isGasRefueled ? "Refueling the gas tank" : "Gas tank is already full");

    public void Recharge() => Console.WriteLine(!isCharged ? "Charging the battery" : "Battery is already charged");

    public void Drive() => Console.WriteLine(isRunning && isGasRefueled && isCharged ? "Driving using both gas and electricity" : !isRunning ? "Car is not running" : "Not enough fuel to drive");

    public void Refuel() { RefuelGas(); Recharge(); }
}

class Program
{
    static void TestDrive(CarInterface car)
    {
        car.Start();
        car.Drive();
        car.Stop();
    }

    static void Main()
    {
        GasCar gasCar = new GasCar();
        ElectricCar electricCar = new ElectricCar();
        GasCarHybrid gasCarHybrid = new GasCarHybrid();

        TestDrive(gasCar);
        TestDrive(electricCar);
        TestDrive(gasCarHybrid);
    }
}
