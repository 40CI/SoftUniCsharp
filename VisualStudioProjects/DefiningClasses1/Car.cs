using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses1
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine, int weight = -1, string color = "n/a")
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            return $"{Model}: {Engine.Model}: Power: {Engine.Power} Displacement: {Engine.Displacement} Efficiency: {Engine.Efficiency} Weight: {Weight} Color: {Color}";
        }
    }
}
