using System;

interface ICar
{
    void Start();
    void Stop();
    void Refuel();
    void Drive();
}

interface ICarGasoline : ICar
{
    bool GasEngine { get; set; }
    bool Tank { get; set; }
    void StartGasEngine();
    void StopGasEngine();
}

interface ICarGas : ICar
{
    bool GasEngine { get; set; }
    bool Cylinder { get; set; }
    void StartGasEngine();
    void StopGasEngine();
}

interface ICarElectric : ICar
{
    bool ElectricEngine { get; set; }
    bool Battery { get; set; }
    void StartElectricEngine();
    void StopElectricEngine();
}

class CarGasoline : ICar, ICarGasoline
{
    public bool GasEngine { get; set; }
    public bool Tank { get; set; }

    public void Start()
    {
        if (!GasEngine)
        {
            Console.WriteLine("Starting the gasoline engine");
            GasEngine = true;
        }
        else
        {
            Console.WriteLine("The engine is already running");
        }
    }

    public void Stop()
    {
        if (GasEngine)
        {
            Console.WriteLine("Stopping the gasoline engine");
            GasEngine = false;
        }
        else
        {
            Console.WriteLine("The engine is already stopped");
        }
    }

    public void Refuel()
    {
        if (!Tank)
        {
            Console.WriteLine("Refueling the car with gasoline");
            Tank = true;
        }
        else
        {
            Console.WriteLine("The car is already refueled");
        }
    }

    public void Drive()
    {
        if (GasEngine && Tank)
        {
            Console.WriteLine("Driving with gasoline");
            Tank = false;
        }
        else if (!GasEngine)
        {
            Console.WriteLine("Car engine is not running");
        }
        else
        {
            Console.WriteLine("Gasoline is finished. Please refuel.");
        }
    }

    public void StartGasEngine()
    {
        if (!GasEngine)
        {
            Console.WriteLine("Starting the gasoline engine");
            GasEngine = true;
        }
    }

    public void StopGasEngine()
    {
        if (GasEngine)
        {
            Console.WriteLine("Stopping the gasoline engine");
            GasEngine = false;
        }
    }
}

class CarGas : ICar, ICarGas
{
    public bool GasEngine { get; set; }
    public bool Cylinder { get; set; }

    public void Start()
    {
        if (!GasEngine)
        {
            Console.WriteLine("Starting the gas engine");
            GasEngine = true;
        }
        else
        {
            Console.WriteLine("The engine is already running");
        }
    }

    public void Stop()
    {
        if (GasEngine)
        {
            Console.WriteLine("Stopping the gas engine");
            GasEngine = false;
        }
        else
        {
            Console.WriteLine("The engine is already stopped");
        }
    }

    public void Refuel()
    {
        if (!Cylinder)
        {
            Console.WriteLine("Refueling the car with gas");
            Cylinder = true;
        }
        else
        {
            Console.WriteLine("The car is already refueled");
        }
    }

    public void Drive()
    {
        if (GasEngine && Cylinder)
        {
            Console.WriteLine("Driving with gas");
            Cylinder = false;
        }
        else if (!GasEngine)
        {
            Console.WriteLine("Car engine is not running");
        }
        else
        {
            Console.WriteLine("Gas is finished. Please refuel.");
        }
    }

    public void StartGasEngine()
    {
        if (!GasEngine)
        {
            Console.WriteLine("Starting the gas engine");
            GasEngine = true;
        }
    }

    public void StopGasEngine()
    {
        if (GasEngine)
        {
            Console.WriteLine("Stopping the gas engine");
            GasEngine = false;
        }
    }
}

class CarElectric : ICar, ICarElectric
{
    public bool ElectricEngine { get; set; }
    public bool Battery { get; set; }

    public void Start()
    {
        if (!ElectricEngine)
        {
            Console.WriteLine("Starting the electric engine");
            ElectricEngine = true;
        }
        else
        {
            Console.WriteLine("The engine is already running");
        }
    }

    public void Stop()
    {
        if (ElectricEngine)
        {
            Console.WriteLine("Stopping the electric engine");
            ElectricEngine = false;
        }
        else
        {
            Console.WriteLine("The engine is already stopped");
        }
    }

    public void Refuel()
    {
        if (!Battery)
        {
            Console.WriteLine("Charging the car");
            Battery = true;
        }
        else
        {
            Console.WriteLine("The car is already charged");
        }
    }

    public void Drive()
    {
        if (ElectricEngine && Battery)
        {
            Console.WriteLine("Driving with electricity");
            Battery = false;
        }
        else if (!ElectricEngine)
        {
            Console.WriteLine("Car engine is not running");
        }
        else
        {
            Console.WriteLine("Electricity is finished. Please recharge.");
        }
    }

    public void StartElectricEngine()
    {
        if (!ElectricEngine)
        {
            Console.WriteLine("Starting the electric engine");
            ElectricEngine = true;
        }
    }

    public void StopElectricEngine()
    {
        if (ElectricEngine)
        {
            Console.WriteLine("Stopping the electric engine");
            ElectricEngine = false;
        }
    }
}

class CarGasolineGas : ICarGas, ICarGasoline
{
    public bool GasEngine { get; set; }
    public bool Cylinder { get; set; }
    public bool Tank { get; set; }

    public void Start()
    {
        StartGasEngine();
        if (!Cylinder)
        {
            Console.WriteLine("Starting the cylinder");
            Cylinder = true;
        }
    }

    public void Stop()
    {
        if (Cylinder)
        {
            Console.WriteLine("Stopping the cylinder");
            Cylinder = false;
        }
        else if (GasEngine)
        {
            Console.WriteLine("Stopping the gas engine");
            GasEngine = false;
        }
        else
        {
            Console.WriteLine("The engine is already stopped");
        }
    }

    public void Refuel()
    {
        if (!Tank)
        {
            Console.WriteLine("Refueling the car with gas");
            Tank = true;
        }
        else
        {
            Console.WriteLine("The car is already refueled");
        }
    }

    public void Drive()
    {
        if (GasEngine && Cylinder && Tank)
        {
            Console.WriteLine("Driving with both gasoline and gas");
            Cylinder = false;
            Tank = false;
        }
        else if (GasEngine && !Cylinder && Tank)
        {
            Console.WriteLine("Gas is finished. Driving with gasoline.");
            Tank = false;
        }
        else if (GasEngine && Cylinder && !Tank)
        {
            Console.WriteLine("Gasoline is finished. Driving with gas.");
            Cylinder = false;
        }
        else
        {
            Console.WriteLine("Gas and gasoline are finished. Please refuel.");
        }
    }

    public void StartGasEngine()
    {
        if (!GasEngine)
        {
            Console.WriteLine("Starting the gas engine");
            GasEngine = true;
        }
    }

    public void StopGasEngine()
    {
        if (GasEngine)
        {
            Console.WriteLine("Stopping the gas engine");
            GasEngine = false;
        }
    }
}

class CarGasolineElectric : ICarElectric, ICarGasoline
{
    public bool ElectricEngine { get; set; }
    public bool Battery { get; set; }
    public bool Tank { get; set; }
    public bool GasEngine { get; set; }

    public void Start()
    {
        StartElectricEngine();
        StartGasEngine();
        if(ElectricEngine && GasEngine)
        {
            Console.WriteLine("Both engines are already running");
        }
    }

    public void Stop()
    {
        StopElectricEngine();
        StopGasEngine();
    }

    public void Refuel()
    {
        if (!Tank)
        {
            Console.WriteLine("Refueling the car with gasoline");
            Tank = true;
        }
        if (!Battery)
        {
            Console.WriteLine("Refueling the car with electricity");
            Battery = true;
        }
    }

    public void Drive()
    {
        if (ElectricEngine && Battery && Tank)
        {
            Console.WriteLine("Driving with both electricity and gasoline");
            Battery = false;
            Tank = false;
        }
        else if (ElectricEngine && !Battery && Tank)
        {
            Console.WriteLine("Electricity is finished. Driving with gasoline.");
            Tank = false;
        }
        else if (ElectricEngine && Battery && !Tank)
        {
            Console.WriteLine("Gasoline is finished. Driving with electricity.");
            Battery = false;
        }
        else
        {
            Console.WriteLine("Electricity and gasoline are finished. Please refuel or recharge.");
        }
    }

    public void StartGasEngine()
    {
        if (!GasEngine)
        {
            Console.WriteLine("Starting the gasoline engine");
            GasEngine = true;
        }
    }

    public void StopGasEngine()
    {
        if (GasEngine)
        {
            Console.WriteLine("Stopping the gasoline engine");
            GasEngine = false;
        }
    }

    public void StartElectricEngine()
    {
        if (!ElectricEngine)
        {
            Console.WriteLine("Starting the electric engine");
            ElectricEngine = true;
        }
    }

    public void StopElectricEngine()
    {
        if (ElectricEngine)
        {
            Console.WriteLine("Stopping the electric engine");
            ElectricEngine = false;
        }
    }
}

class Program
{
    static void TestDrive(ICar car)
    {
        car.Refuel();
        car.Refuel();
        car.Drive();
        car.Start();
        car.Stop();
    }

    static void Main()
    {
        ICar gasolineCar = new CarGasoline();
        ICar electricCar = new CarElectric();
        ICar gasolineGasCar = new CarGasolineGas();
        ICar gasolineElectricCar = new CarGasolineElectric();

        //gasolineGasCar.Start();
        //((ICar)gasolineGasCar).Start();
        gasolineElectricCar.Start();
        ((ICar)gasolineElectricCar).Start();

        // ((ICarGas)gasolineGasCar).StartGasEngine();
        // ((ICarGasoline)gasolineGasCar).StartGasEngine();
        // ((ICarGas)gasolineGasCar).StopGasEngine();
        // ((ICarGasoline)gasolineGasCar).StopGasEngine();
        //
        // ((ICarElectric)gasolineElectricCar).StartElectricEngine();
        // ((ICarGasoline)gasolineElectricCar).StartGasEngine();
        // ((ICarElectric)gasolineElectricCar).StopElectricEngine();
        // ((ICarGasoline)gasolineElectricCar).StopGasEngine();

        // TestDrive(gasolineElectricCar);
    }
}
