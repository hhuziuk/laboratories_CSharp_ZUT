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

class CarBenzine : CarInterface
{
    private bool isRunning;
    private bool isRefueled;

    public void Start()
    {
        Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");
        isRunning = true;
    }

    public void Stop()
    {
        Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");
        isRunning = false;
    }

    public void Refuel()
    {
        Console.WriteLine(!isRefueled ? "Refueling the car with benzine" : "Car is already refueled");
        isRefueled = true;
    }

    public void Drive()
    {
        if (isRunning && isRefueled)
        {
            Console.WriteLine("Driving with benzine");
            isRefueled = false;
        }
        else if (!isRunning)
            Console.WriteLine("Car is not running");
        else
            Console.WriteLine("Benzine is finished. Please refuel.");
    }
}

class CarGas : CarInterface, GasCarInterface
{
    private bool isRunning;
    private bool isGasRefueled;

    public void Start()
    {
        Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");
        isRunning = true;
    }

    public void Stop()
    {
        Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");
        isRunning = false;
    }

    public void Refuel()
    {
        RefuelGas();
    }

    public void Drive()
    {
        if (isRunning && isGasRefueled)
        {
            Console.WriteLine("Driving with gas");
            isGasRefueled = false;
        }
        else if (!isRunning)
            Console.WriteLine("Car is not running");
        else
            Console.WriteLine("Gas is finished. Please refuel.");
    }

    public void RefuelGas()
    {
        Console.WriteLine(!isGasRefueled ? "Refueling the car with gas" : "Car is already refueled");
        isGasRefueled = true;
    }
}

class CarElectric : CarInterface, ElectricCarInterface
{
    private bool isRunning;
    private bool isCharged;

    public void Start()
    {
        Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");
        isRunning = true;
    }

    public void Stop()
    {
        Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");
        isRunning = false;
    }

    public void Refuel()
    {
        Recharge();
    }

    public void Drive()
    {
        if (isRunning && isCharged)
        {
            Console.WriteLine("Driving with electricity");
            isCharged = false;
        }
        else if (!isRunning)
            Console.WriteLine("Car is not running");
        else
            Console.WriteLine("Electricity is finished. Please recharge.");
    }

    public void Recharge()
    {
        Console.WriteLine(!isCharged ? "Charging the car" : "Car is already charged");
        isCharged = true;
    }
}

class CarBenzineGas : CarInterface, GasCarInterface
{
    private bool isRunning;
    private bool isGasRefueled;
    private bool isBenzineRefueled;

    public void Start()
    {
        Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");
        isRunning = true;
    }

    public void Stop()
    {
        Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");
        isRunning = false;
    }

    public void RefuelBenzine()
    {
        Console.WriteLine(!isBenzineRefueled ? "Refueling the car with benzine" : "Car is already refueled");
        isBenzineRefueled = true;
    }
    
    public void Refuel()
    {
        RefuelBenzine();
        RefuelGas();
    }

    public void Drive()
    {
        if (isRunning)
        {
            if (isGasRefueled && isBenzineRefueled)
            {
                Console.WriteLine("Driving with both benzine and gas");
                isGasRefueled = false;
                isBenzineRefueled = false;
            }
            else if (!isGasRefueled && isBenzineRefueled)
            {
                Console.WriteLine("Gas is finished. Driving with benzine.");
                isBenzineRefueled = false;
            }
            else if (isGasRefueled && !isBenzineRefueled)
            {
                Console.WriteLine("Benzine is finished. Driving with gas.");
                isGasRefueled = false;
            }
            else
            {
                Console.WriteLine("Gas and benzine are finished. Please refuel.");
            }
        }
        else
        {
            Console.WriteLine("Car is not running");
        }
    }

    public void RefuelGas()
    {
        Console.WriteLine(!isGasRefueled ? "Refueling the car with gas" : "Car is already refueled");
        isGasRefueled = true;
    }
}


class CarBenzineElectric : CarInterface, ElectricCarInterface
{
    private bool isRunning;
    private bool isCharged;
    private bool isBenzineRefueled;

    public void Start()
    {
        Console.WriteLine(!isRunning ? "Starting the car" : "The car is already running");
        isRunning = true;
    }

    public void Stop()
    {
        Console.WriteLine(isRunning ? "Stopping the car" : "The car is already stopped");
        isRunning = false;
    }

    public void RefuelBenzine()
    {
        Console.WriteLine(!isBenzineRefueled ? "Refueling the car with benzine" : "Car is already refueled");
        isBenzineRefueled = true;
    }

    public void Refuel()
    {
        RefuelBenzine();
        Recharge();
    }
    
    public void Drive()
    {
        if (isRunning)
        {
            if (isCharged && isBenzineRefueled)
            {
                Console.WriteLine("Driving with both electricity and benzine");
                isCharged = false;
                isBenzineRefueled = false;
            }
            else if (!isCharged && isBenzineRefueled)
            {
                Console.WriteLine("Electricity is finished. Driving with benzine.");
                isBenzineRefueled = false;
            }
            else if (isCharged && !isBenzineRefueled)
            {
                Console.WriteLine("Benzine is finished. Driving with electricity.");
                isCharged = false;
            }
            else
            {
                Console.WriteLine("Electricity and benzine are finished. Please refuel or recharge.");
            }
        }
        else
        {
            Console.WriteLine("Car is not running");
        }
    }

    public void Recharge()
    {
        Console.WriteLine(!isCharged ? "Recharging the car with electricity" : "Car is already charged");
        isCharged = true;
    }
}

class Program
{
    static void TestDrive(CarInterface car)
    {
        car.Refuel();
        car.Refuel();
        car.Drive();
        car.Start();
        car.Start();
        car.Drive();
        car.Drive();
        car.Stop();
        car.Stop();
    }

    static void Main()
    {
        CarBenzine carBenzine = new CarBenzine();
        CarGas carGas = new CarGas();
        CarElectric carElectric = new CarElectric();
        CarBenzineGas carBenzineGas = new CarBenzineGas();
        CarBenzineElectric carBenzineElectric = new CarBenzineElectric();
        TestDrive(carBenzine);
        TestDrive(carGas);
        TestDrive(carElectric);
        TestDrive(carBenzineGas);
        TestDrive(carBenzineElectric);
    }
}
