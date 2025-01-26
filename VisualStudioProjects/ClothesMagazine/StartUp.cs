using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ClothesMagazine;

namespace ClothesMagazine
{
    public class StartUp
    {
        static void Main(string[] args)
        {   
            
            
                
                var magazine = new Magazine("Summer", 3);
                var cloth1 = new Cloth("red", 10, "shirt");
                var cloth2 = new Cloth("blue", 12, "jeans");
                var cloth3 = new Cloth("green", 8, "t-shirt");

                magazine.AddCloth(cloth1);
                magazine.AddCloth(cloth2);
                magazine.AddCloth(cloth3);

                Console.WriteLine(magazine.Report()); ///Clothes by size

                magazine.RemoveCloth("red");
                Console.WriteLine(magazine.GetClothCount()); // Prints 2

                Console.WriteLine(magazine.GetSmallestCloth()); // Prints the green t-shirt
                Console.WriteLine(magazine.GetCloth("blue")); // Prints the blue jeans
            
        }
    }
    
}
