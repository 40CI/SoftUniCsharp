using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var programmerTimes = Console.ReadLine().Split().Select(int.Parse).ToList();
        var taskNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        var duckCounts = new Dictionary<string, int>
        {
            {"Darth Vader Ducky", 0},
            {"Thor Ducky", 0},
            {"Big Blue Rubber Ducky", 0},
            {"Small Yellow Rubber Ducky", 0}
        };

        while (programmerTimes.Count > 0 && taskNumbers.Count > 0)
        {
            var time = programmerTimes.First() * taskNumbers.Last();

            if (time <= 60)
            {
                duckCounts["Darth Vader Ducky"]++;
                programmerTimes.RemoveAt(0);
                taskNumbers.RemoveAt(taskNumbers.Count - 1);
            }
            else if (time <= 120)
            {
                duckCounts["Thor Ducky"]++;
                programmerTimes.RemoveAt(0);
                taskNumbers.RemoveAt(taskNumbers.Count - 1);
            }
            else if (time <= 180)
            {
                duckCounts["Big Blue Rubber Ducky"]++;
                programmerTimes.RemoveAt(0);
                taskNumbers.RemoveAt(taskNumbers.Count - 1);
            }
            else if (time <= 240)
            {
                duckCounts["Small Yellow Rubber Ducky"]++;
                programmerTimes.RemoveAt(0);
                taskNumbers.RemoveAt(taskNumbers.Count - 1);
            }
            else
            {
                taskNumbers[taskNumbers.Count - 1] -= 2;
                var lastProgrammerTime = programmerTimes.First();
                programmerTimes.RemoveAt(0);
                programmerTimes.Add(lastProgrammerTime);
            }
        }

        Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
        Console.WriteLine($"Darth Vader Ducky: {duckCounts["Darth Vader Ducky"]}");
        Console.WriteLine($"Thor Ducky: {duckCounts["Thor Ducky"]}");
        Console.WriteLine($"Big Blue Rubber Ducky: {duckCounts["Big Blue Rubber Ducky"]}");
        Console.WriteLine($"Small Yellow Rubber Ducky: {duckCounts["Small Yellow Rubber Ducky"]}");
    }
}
