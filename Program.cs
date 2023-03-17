using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("          🔥                            🔥");
            Console.WriteLine("         🔥🔥         WELCOME          🔥🔥");
            Console.WriteLine("      🔥 🔥🔥🔥         TO          🔥 🔥🔥🔥");
            Console.WriteLine("      🔥🔥🔥🔥🔥     JURASSIC       🔥🔥🔥🔥🔥");
            Console.WriteLine("      🔥🔥🔥🔥🔥       PARK!        🔥🔥🔥🔥🔥");
            Console.WriteLine("      🔥🔥🔥🔥🔥      🦖🦟🦕         🔥🔥🔥🔥");
            Console.WriteLine("        🔥🔥🔥     ::cue music::      🔥🔥");
        }
        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine().ToUpper();
            return userInput;
        }
        static string PromptForDietType()
        {
            string userInput = "";
            while (userInput != "O" && userInput != "H")
            {
                Console.WriteLine("(O)mnivore or (H)erbivore? ");
                userInput = Console.ReadLine().ToUpper();
                if (userInput == "H")
                    return "Herbivore";
                else if (userInput == "O")
                    return "Omnivore";
                else
                { Console.WriteLine($"I'm sorry {userInput} is not valid. "); }
            }
            return "ERROR";

        }
        static int PromptForInteger(string prompt)
        {
            var isThisGoodInput = false;
            while (isThisGoodInput == false)
            {
                Console.Write(prompt);
                int userInput;
                isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
                if (isThisGoodInput)
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("I'm sorry that is not a valid response. ");
                }

            }
            return 0;

        }

        static void Main(string[] args)
        {


            var database = new DinoDatabase();

            var keepGoing = true;

            DisplayGreeting();
            while (keepGoing)
            {

                Console.WriteLine();
                Console.WriteLine("What would you like to do?\n(V)iew\n(A)dd\n(R)emove\n(T)ransfer\n(S)ummary\n(Q)uit");
                var choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "S":
                        DinoSummary(database);
                        break;
                    case "T":
                        TransferDino(database);
                        break;
                    case "R":
                        RemoveDino(database);
                        break;
                    case "A":
                        AddDino(database);
                        break;
                    case "V":
                        ViewDino(database);
                        break;
                    default:
                        Console.WriteLine($"I'm sorry {choice} is not a valid option. ");
                        break;
                }
            }
        }
        private static void TransferDino(DinoDatabase database)
        {
            var dinoToTransfer = PromptForString("What Dinosaur would you like to transfer? ");
            var foundDino = database.FindADino(dinoToTransfer);
            if (foundDino == null)
            {
                Console.WriteLine($"I'm sorry {dinoToTransfer} was not found. ");
            }
            else
            {
                Console.WriteLine($"{foundDino.Name} is in pen {foundDino.EnclosureNumber} ");
                foundDino.EnclosureNumber = PromptForInteger("Where would you like to transfer them? ");
                Console.WriteLine($"{foundDino.Name} is now in pen {foundDino.EnclosureNumber} ");

            }
        }
        private static void ViewDino(DinoDatabase database)
        {
            if (database.GetAllDinos().Count == 0)
            {
                Console.WriteLine("\nNo Dinos Here.\n\nNo refunds either.\n ");
            }
            else
            {
                var response = PromptForString("Would you like to view by (N)ame or (P)en Location? ");
                if (response == "N")
                {
                    var byName = database.GetAllDinos().OrderBy(d => d.Name);
                    foreach (var d in byName)
                    {
                        d.Description();
                    }
                }
                else if (response == "P")
                {
                    var byPen = database.GetAllDinos().OrderBy(d => d.EnclosureNumber);
                    foreach (var d in byPen)
                    {
                        d.Description();
                    }
                }
                else
                {
                    Console.WriteLine("I'm sorry I didn't understand.");
                }
            }
        }
        private static void RemoveDino(DinoDatabase database)
        {
            var dinoToRemove = PromptForString("What Dinosaur would you like to remove? ");
            var foundDino = database.FindADino(dinoToRemove);
            if (foundDino == null)
            {
                Console.WriteLine($"I'm sorry {dinoToRemove} was not found. ");
            }
            else
            {
                foundDino.Description();
                var response = PromptForString($"Are you sure you want to delete {foundDino.Name}? [Y/N] ");
                if (response == "Y")
                {
                    database.RemoveDino(foundDino);
                    Console.WriteLine($"You have deleted {foundDino.Name}. ");
                }
            }
        }
        private static void AddDino(DinoDatabase database)
        {
            var dino = new Dino();
            dino.Name = PromptForString("Name of dinosaur? ");
            dino.DietType = PromptForDietType();
            dino.Weight = PromptForInteger("What is the dinosaurs weight in pounds? ");
            dino.EnclosureNumber = PromptForInteger("Pen location number? [1-500]");
            dino.Description();

            database.AddDino(dino);
        }
        private static void DinoSummary(DinoDatabase database)
        {
            var herbivores = database.GetAllDinos().Where(herb => herb.DietType == "Herbivore").Select(herb => herb.Name);
            var omnivores = database.GetAllDinos().Where(omn => omn.DietType == "Omnivore").Select(omn => omn.Name);
            Console.WriteLine($"There are {herbivores.Count()} herbivores: ");
            foreach (var herb in herbivores)
            {
                Console.WriteLine(herb);
            }
            Console.WriteLine($"There are {omnivores.Count()} omnivores: ");
            foreach (var omn in omnivores)
            {
                Console.WriteLine(omn);
            }
        }
    }
}

