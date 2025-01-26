using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Read input
        int[] times = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] tasks = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // Initialize duck counts
        int darthVaderCount = 0;
        int thorCount = 0;
        int bigBlueCount = 0;
        int smallYellowCount = 0;

        // Process tasks
        int i = 0;
        while (i < tasks.Length)
        {
            int time = times[0] * tasks[i + tasks.Length - 1];
            if (time >= 0 && time <= 60)
            {
                darthVaderCount++;
                times = RemoveFirstElement(times);
                tasks = RemoveLastElement(tasks);
            }
            else if (time > 60 && time <= 120)
            {
                thorCount++;
                times = RemoveFirstElement(times);
                tasks = RemoveLastElement(tasks);
            }
            else if (time > 120 && time <= 180)
            {
                bigBlueCount++;
                times = RemoveFirstElement(times);
                tasks = RemoveLastElement(tasks);
            }
            else if (time > 180 && time <= 240)
            {
                smallYellowCount++;
                times = RemoveFirstElement(times);
                tasks = RemoveLastElement(tasks);
            }
            else
            {
                tasks[i + tasks.Length - 1] -= 2;
                times = MoveFirstElementToEnd(times);
                i++;
            }
        }

        // Output results
        Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
        Console.WriteLine($"Darth Vader Ducky: {darthVaderCount}");
        Console.WriteLine($"Thor Ducky: {thorCount}");
        Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueCount}");
        Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowCount}");
    }

    static int[] RemoveFirstElement(int[] arr)
    {
        int[] result = new int[arr.Length - 1];
        Array.Copy(arr, 1, result, 0, result.Length);
        return result;
    }

    static int[] MoveFirstElementToEnd(int[] arr)
    {
        int[] result = new int[arr.Length];
        Array.Copy(arr, 1, result, 0, result.Length - 1);
        result[result.Length - 1] = arr[0];
        return result;
    }
}
