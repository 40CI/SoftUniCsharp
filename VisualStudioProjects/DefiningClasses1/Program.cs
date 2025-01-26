using DefiningClasses1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split();
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                int displacement = -1;
                if (engineInfo.Length == 4)
                {
                    bool isDisplacement = int.TryParse(engineInfo[2], out displacement);
                    if (!isDisplacement)
                    {
                        displacement = -1;
                    }
                }
                else if (engineInfo.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineInfo[2], out displacement);
                    if (!isDisplacement)
                    {
                        displacement = -1;
                    }
                }

                string efficiency = "n/a";
                if (engineInfo.Length == 4)
                {
                    efficiency = engineInfo[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                string engineModel = carInfo[1];
                Engine engine = engines.Find(x => x.Model == engineModel);

                int weight = -1;
                if (carInfo.Length == 4)
                {
                    bool isWeight = int.TryParse(carInfo[2], out weight);
                    if (!isWeight)
                    {
                        weight = -1;
                    }
                }
                else if (carInfo.Length == 3)
                {
                    bool isWeight = int.TryParse(carInfo[2], out weight);
                    if (!isWeight)
                    {
                        weight = -1;
                    }
                }

                string color = "n/a";
                if (carInfo.Length == 4)
                {
                    color = carInfo[3];
                }

                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
                Console.WriteLine(car.Engine.Model);
                Console.WriteLine(" Power: " + car.Engine.Power);
                Console.WriteLine(" Displacement: " + (car.Engine.Displacement.ToString()));
                 Console.WriteLine(" Efficiency: " + (string.IsNullOrEmpty(car.Engine.Efficiency) ? "n/a" : car.Engine.Efficiency));
                    Console.WriteLine("Weight: " + (car.Weight.ToString()));
                 Console.WriteLine("Color: " + (string.IsNullOrEmpty(car.Color) ? "n/a" : car.Color));
            }

        }
    }
}
