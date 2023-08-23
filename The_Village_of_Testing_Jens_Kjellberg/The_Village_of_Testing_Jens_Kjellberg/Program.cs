using System;

namespace The_Village_of_Testing_Jens_Kjellberg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Village village = new Village();
            while (true)
            {
                PrintStats(village);
                PrintCommands();
                ReadCommands(village);
                Console.Clear();
            }
        }
        static void PrintCommands()
        {
            Console.WriteLine("type \"printlist\" to print a list of workers or buildings");
            Console.WriteLine("type \"addworker\" to create a new worker");
            Console.WriteLine("type \"addproject\" to add a building to the village");
            Console.WriteLine("type \"day\" to progress a day");
            Console.WriteLine("type \"quit\" to quit the game");
        }
        static void ReadCommands(Village v)
        {
            string command = Console.ReadLine();
            switch (command)
            {
                case "printlist":
                    PrintList(v);
                    break;
                case "addworker":
                    CreateWorker(v);
                    break;
                case "addproject":
                    CreateProject(v);
                    break;
                case "day":
                    v.Day();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("invalid input. try again");
                    ReadCommands(v);
                    return;

            }
        }
        static void PrintList(Village v) 
        {
            Console.WriteLine("Press 1 to print Workers");
            Console.WriteLine("Press 2 to print Buildings");
            Console.WriteLine("Press 3 to print Buildprojects");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    printWorkers(v);
                    break;
                case '2':
                    printBuildings(v);
                    break;
                case '3':
                    printBuildProjects(v);
                    break;
                default:
                    PrintList(v);
                    break;
            }
        }
        static void CreateProject(Village v)
        {
            Console.WriteLine();
            Console.WriteLine("Press 1 to start building a House");
            Console.WriteLine("Requiers: 5 wood and 0 metal. Takes 3 days to complete");
            Console.WriteLine();
            Console.WriteLine("Press 2 to start building a Woodmill");
            Console.WriteLine("Requiers: 5 wood and 1 metal. Takes 5 days to complete");
            Console.WriteLine();
            Console.WriteLine("Press 3 to start building a Quarry");
            Console.WriteLine("Requiers: 3 wood and 5 metal. Takes 7 days to complete");
            Console.WriteLine();
            Console.WriteLine("Press 4 to start building a Farm");
            Console.WriteLine("Requiers: 5 wood and 2 metal. Takes 5 days to complete");
            Console.WriteLine();
            Console.WriteLine("Press 5 to start building a Castle");
            Console.WriteLine("Requiers: 50 wood and 50 metal. Takes 50 days to complete");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    if (v.AddProject(1))
                    {
                        Console.WriteLine();
                        Console.WriteLine("you have started building a House");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("you do not have enough resourses to start this project");
                    }
                    break;
                case '2':
                    if (v.AddProject(2))
                    {
                        Console.WriteLine();
                        Console.WriteLine("you have started building a Woodmill");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("you do not have enough resourses to start this project");
                    }
                    break;
                case '3':
                    if (v.AddProject(3))
                    {
                        Console.WriteLine();
                        Console.WriteLine("you have started building a Quarry");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("you do not have enough resourses to start this project");
                    }
                    break;
                case '4':
                    if (v.AddProject(4))
                    {
                        Console.WriteLine();
                        Console.WriteLine("you have started building a Farm");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("you do not have enough resourses to start this project");
                    }
                    break;
                case '5':
                    if (v.AddProject(5))
                    {
                        Console.WriteLine();
                        Console.WriteLine("you have started building a Castle");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("you do not have enough resourses to start this project");
                    }
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("invalid input. try again");
                    CreateProject(v);
                    break;
            }
            Console.ReadKey(true);
        }
        static void PrintStats(Village v)
        {
            Console.WriteLine("Days past " + v.Day_Count);
            Console.WriteLine("Buildings in your village " + v.Buildings.Count());
            Console.WriteLine("Buildprojects in your village "+v.Buildprojects.Count());
            Console.WriteLine("Workers in your village "+v.Workers.Count());
            Console.WriteLine("Amount of Food "+v.Food_Count);
            Console.WriteLine("Amount of Wood "+v.Wood_Count);
            Console.WriteLine("Amount of Metal "+v.Metal_Count);
            Console.WriteLine();
        }
        static void CreateWorker(Village v)
        {
            Console.WriteLine("press 1 to create a Lumberjack");
            Console.WriteLine("press 2 to create a Miner");
            Console.WriteLine("press 3 to create a Farmer");
            Console.WriteLine("press 4 to create a Builder");
            char worker = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch(worker)
            {
                case '1':
                    if (v.AddWorker(1))
                    {
                        Console.WriteLine("you have succesfully added a Lumberjack!");
                    }
                    else
                    {
                        Console.WriteLine("you do not have enough housing to add a worker");
                    }
                    break;
                case '2':
                    if(v.AddWorker(2))
                    {
                        Console.WriteLine("you have succesfully added a Miner!");
                    }
                    else
                    {
                        Console.WriteLine("you do not have enough housing to add a worker");
                    }
                    break;
                case '3':
                    if(v.AddWorker(3))
                    {
                        Console.WriteLine("you have succesfully added a Farmer!");
                    }
                    else
                    {
                        Console.WriteLine("you do not have enough housing to add a worker");
                    }
                    break;
                case '4': 
                    if(v.AddWorker(4))
                    {
                        Console.WriteLine("you have succesfully added a Builder!");
                    }
                    else
                    {
                        Console.WriteLine("you do not have enough housing to add a worker");
                    }
                    break;
                default:
                    Console.WriteLine("invalid input. try again");
                    CreateWorker(v);
                    return;
            }
            Console.ReadKey(true);
        }
        public static void GameOver()
        {
            Console.WriteLine("Game Over");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        public static void GameWon()
        {
            Console.WriteLine("Your Castle is complete! Your Won!");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static void printWorkers(Village v)
        {
            Console.WriteLine();
            foreach(var worker in v.Workers) 
            { 
                Console.WriteLine(worker);
            }
            Console.ReadKey(true);
        }
        static void printBuildings(Village v)
        {
            Console.WriteLine();
            foreach (var building in v.Buildings)
            {
                Console.WriteLine(building);
            }
            Console.ReadKey(true);
        }
        static void printBuildProjects(Village v)
        {
            Console.WriteLine();
            foreach(var building in v.Buildprojects) { Console.WriteLine(building); }
            Console.ReadKey(true);
        }
    }
}