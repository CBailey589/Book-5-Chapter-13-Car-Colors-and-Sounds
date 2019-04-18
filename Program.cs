using System;
using System.Collections.Generic;

namespace myApp
{
    public class Vehicle
    {
        public string MainColor { get; set; }
        public string MaximumOccupancy { get; set; }
        public virtual void Drive()
        {
            Console.WriteLine("This Vehicle is driving!...");
        }
        public virtual void Turn(string direction)
        {
            Console.WriteLine("This Vehicle is Turning!...");
        }
        public virtual void Stop()
        {
            Console.WriteLine("This Vehicle is Stopped!...");
        }
    }

    public class GasStation : IReEnergizingStation<IGasPowered>
    {
        public int Capacity { get; set; }
        public void Refuel(List<IGasPowered> list)
        {
           foreach (IGasPowered veh in list)
           {
               veh.RefuelTank();
           }
        }
    }
    public class ChargingStation : IReEnergizingStation<IElectricPowered>
    {
        public int Capacity { get; set; }
        public void Refuel(List<IElectricPowered> list)
        {
           foreach (IElectricPowered veh in list)
           {
               veh.ChargeBattery();
           }
        }
    }
    public interface IReEnergizingStation<T>
    {
        int Capacity {get;set;}
        void Refuel(List<T> list);
    }

    public interface IElectricPowered
    {
        double BatteryKWh { get; set; }
        void ChargeBattery();
    }

    public interface IGasPowered
    {
        double FuelCapacity { get; set; }
        void RefuelTank();
    }
    public class Zero : Vehicle, IElectricPowered
    {  // Electric motorcycle
        public double BatteryKWh { get; set; }
        public void ChargeBattery()
        {
            Console.WriteLine($"The {MainColor} Zero is charging...");
        }

        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Zero zooms by!");
        }
        public override void Turn(string direction)
        {
            Console.WriteLine($"The {MainColor} Zero leans way over to the {direction}!");
        }
        public override void Stop()
        {
            Console.WriteLine($"The {MainColor} Zero screeches to a halt on its front wheel!");
        }
    }
    public class Cessna : Vehicle, IGasPowered
    {  // Propellor light aircraft
        public double FuelCapacity { get; set; }
        public void RefuelTank()
        {
            Console.WriteLine($"The {MainColor}Cessna is refueling...");
        }
        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Cessna flies by!");
        }
        public override void Turn(string direction)
        {
            Console.WriteLine($"The {MainColor} Cessna banks to the {direction}!");
        }
        public override void Stop()
        {
            Console.WriteLine($"The {MainColor} Cessna slowly rolls to a standstill!");
        }
    }
    public class Tesla : Vehicle, IElectricPowered
    {  // Electric car
        public double BatteryKWh { get; set; }
        public void ChargeBattery()
        {
            Console.WriteLine($"The {MainColor} Tesla is charging...");
        }
        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Tesla zaps by!");
        }
        public override void Turn(string direction)
        {
            Console.WriteLine($"The {MainColor} Tesla driver doesn't use their turn signal to turn {direction}!");
        }
        public override void Stop()
        {
            Console.WriteLine($"The {MainColor} Tesla parks way away from the other vehicles and takes up two spaces!");
        }
    }
    public class Ram : Vehicle, IGasPowered
    {  // Gas powered truck
        public double FuelCapacity { get; set; }
        public void RefuelTank()
        {
            Console.WriteLine($"The {MainColor} Ram is refueling...");
        }
        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Ram blasts by!");
        }
        public override void Turn(string direction)
        {
            Console.WriteLine($"The {MainColor} Ram turns {direction}, cuts you off, and rolls enough coal to reduce the lifespan of the earth by several weeks!");
        }
        public override void Stop()
        {
            Console.WriteLine($"The {MainColor} Ram slams through two cars in front of it to stop!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ram Ram2500 = new Ram();
            Ram2500.MainColor = "Black";
            Cessna Cessna172 = new Cessna();
            Cessna172.MainColor = "Red and White";
            Zero ZeroFx = new Zero();
            ZeroFx.MainColor = "Yellow";
            Tesla TeslaModelX = new Tesla();
            TeslaModelX.MainColor = "Silver";

            Ram2500.RefuelTank();
            Cessna172.RefuelTank();
            ZeroFx.ChargeBattery();
            TeslaModelX.ChargeBattery();

            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.Add(Ram2500);
            vehicles.Add(Cessna172);
            vehicles.Add(ZeroFx);
            vehicles.Add(TeslaModelX);

            foreach (Vehicle veh in vehicles)
            {
                Console.WriteLine("");
                veh.Drive();
                veh.Turn("left");
                veh.Stop();
            }

            GasStation ConnorsGasStation = new GasStation();
            ChargingStation ConnorsBatteryStation = new ChargingStation();

            List<IGasPowered> GasVehicles = new List<IGasPowered>() {
                Ram2500,Cessna172
            };
            List<IElectricPowered> ElectricVehicles = new List<IElectricPowered>() {
                ZeroFx, TeslaModelX
            };

            ConnorsGasStation.Refuel(GasVehicles);
            ConnorsBatteryStation.Refuel(ElectricVehicles);


        }
    }
}
