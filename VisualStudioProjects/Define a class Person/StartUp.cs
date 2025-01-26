using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        

        Person person = new Person("Peter", 20);

        Person person1 = new Person();

        person1.Name = "George";
        person1.Age = 18;
    }
}
