using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class Dino
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; } = DateTime.Now;
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public void Description()
        {
            Console.WriteLine($"-{Name}-.\nDiet: {DietType}\nWeight: {Weight}lbs.\nReceived at: {WhenAcquired}\nPen Location: {EnclosureNumber}");
        }

    }
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("          🔥                            🔥         ");
            Console.WriteLine("         🔥🔥         WELCOME          🔥🔥         ");
            Console.WriteLine("      🔥 🔥🔥🔥         TO          🔥 🔥🔥🔥       ");
            Console.WriteLine("      🔥🔥🔥🔥🔥     JURASSIC       🔥🔥🔥🔥🔥    ");
            Console.WriteLine("      🔥🔥🔥🔥🔥       PARK!        🔥🔥🔥🔥🔥   ");
            Console.WriteLine("      🔥🔥🔥🔥🔥      🦖🦟🦕         🔥🔥🔥🔥      ");
            Console.WriteLine("        🔥🔥🔥     ::cue music::      🔥🔥🔥        ");
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


            var dinos = new List<Dino>();

            var keepGoing = true;

            DisplayGreeting();
            while (keepGoing)
            {

                Console.WriteLine();
                Console.WriteLine("What would you like to do?\n(V)iew\n(A)dd\n(R)emove\n(T)ransfer\n(S)ummary\n(Q)uit");
                var choice = Console.ReadLine().ToUpper();
                if (choice == "Q")
                {
                    keepGoing = false;
                }
                else if (choice == "S")
                {
                    var herbivores = dinos.Where(herb => herb.DietType == "Herbivore").Select(herb => herb.Name);
                    var omnivores = dinos.Where(omn => omn.DietType == "Omnivore").Select(omn => omn.Name);
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
                else if (choice == "T")
                {
                    var dinoToTransfer = PromptForString("What Dinosaur would you like to transfer? ");
                    var foundDino = dinos.FirstOrDefault(d => d.Name == dinoToTransfer);
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
                else if (choice == "R")
                {
                    var dinoToRemove = PromptForString("What Dinosaur would you like to remove? ");
                    var foundDino = dinos.FirstOrDefault(d => d.Name == dinoToRemove);
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
                            dinos.Remove(foundDino);
                            Console.WriteLine($"You have deleted {foundDino.Name}. ");
                        }
                    }

                }
                else if (choice == "V")
                {
                    var response = PromptForString("Would you like to view by (N)ame or (P)en Location? ");
                    if (response == "N")
                    {
                        var byName = dinos.OrderBy(d => d.Name);
                        foreach (var d in byName)
                        {
                            d.Description();
                        }
                    }
                    else if (response == "P")
                    {
                        var byPen = dinos.OrderBy(d => d.EnclosureNumber);
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
                else if (choice == "A")
                {
                    var dino = new Dino();
                    dino.Name = PromptForString("Name of dinosaur? ");
                    dino.DietType = PromptForDietType();
                    dino.Weight = PromptForInteger("What is the dinosaurs weight in pounds? ");
                    dino.EnclosureNumber = PromptForInteger("Pen location number? [1-500]");
                    dino.Description();

                    dinos.Add(dino);

                }
                else Console.WriteLine($"I'm sorry {choice} is not a valid option. ");



            }
        }
    }
}

