using System;

namespace StructurialDesignPatterns.Flyweight
{
    class Vehicle
    {
        public int MaxSpeed;
        public static string Country;

        public Vehicle(ref int maxSpeed)
        {
            MaxSpeed = maxSpeed;
            Country = "Russian Federation";
        }
    }

    class Car : Vehicle
    {
        public Car(ref int maxSpeed) : base(ref maxSpeed)
        {
            MaxSpeed = 110;
        }

        static Car()
        {
            Country = "Czech Republic";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 130;
            var car = new Car(ref a);
            Console.WriteLine($"Max speed is {car.MaxSpeed}, Country is {Vehicle.Country}");
        }
    }
}
