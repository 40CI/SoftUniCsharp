using System;
using System.Collections.Generic;
using System.Linq;


namespace SquirrelGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(", ");

            char[,] field = new char[fieldSize, fieldSize];
            int[] squirrelPosition = new int[2];
            int hazelnutCount = 0;

            for (int i = 0; i < fieldSize; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = row[j];

                    if (field[i, j] == 's')
                    {
                        squirrelPosition[0] = i;
                        squirrelPosition[1] = j;
                    }
                    else if (field[i, j] == 'h')
                    {
                        hazelnutCount++;
                    }
                }
            }

            bool isGameOver = false;

            foreach (string command in commands)
            {
                switch (command)
                {
                    case "up":
                        squirrelPosition[0]--;
                        break;
                    case "down":
                        squirrelPosition[0]++;
                        break;
                    case "left":
                        squirrelPosition[1]--;
                        break;
                    case "right":
                        squirrelPosition[1]++;
                        break;
                }

                if (squirrelPosition[0] < 0 || squirrelPosition[0] >= fieldSize ||
                    squirrelPosition[1] < 0 || squirrelPosition[1] >= fieldSize)
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    isGameOver = true;
                    break;
                }
                else if (field[squirrelPosition[0], squirrelPosition[1]] == 'h')
                {
                    hazelnutCount--;
                    field[squirrelPosition[0], squirrelPosition[1]] = '*';
                    if (hazelnutCount == 0)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        isGameOver = true;
                        break;
                    }
                }
                else if (field[squirrelPosition[0], squirrelPosition[1]] == 't')
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    isGameOver = true;
                    break;
                }
            }

            if (!isGameOver)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {3 - hazelnutCount}");
        }
    }
}

