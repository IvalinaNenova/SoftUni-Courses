using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car car = new Car();
            car.Make = "BMW";
            car.Model = "X5";
            car.Year = 2016;
            car.FuelQuantity = 80;
            car.FuelConsumption = fuelConsumption;
            Console.WriteLine(car.WhoAmI());
            Car firstCar = new Car();

            Console.WriteLine(firstCar.WhoAmI());

            Car secondCar = new Car(make, "Yaris", year);
            Console.WriteLine(secondCar.WhoAmI());

            Car thirdCar = new Car("Opel", model, 2016, 300, fuelConsumption);

            thirdCar.DriveCar(200);
            Console.WriteLine(thirdCar.WhoAmI());
        }
    }
}
