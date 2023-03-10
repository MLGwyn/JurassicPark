using System;
using System.Collections.Generic;

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
            Console.WriteLine($"Ah yes, The {Name}. Classic {DietType} weighing in at {Weight}lbs.\nReceived at: {WhenAcquired}\nPen Location: {EnclosureNumber}");
        }

    }
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine().ToUpper();
            return userInput;
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
            // While the user hasn't said QUIT yet
            while (keepGoing)
            {
                // Insert a blank line then prompt them and get their answer (force uppercase)
                Console.WriteLine();
                Console.WriteLine("What can I help you with?\n(V)iew\n(A)dd\n(R)emove\n(T)ransfer\n(S)ummary\n(Q)uit");
                var choice = Console.ReadLine().ToUpper();
                if (choice == "Q")
                {
                    // They said quit, so set our keepGoing to false
                    keepGoing = false;
                }
                else
                {
                    // Make a new employee object
                    var dino = new Dino();
                    dinos.Add(dino);
                }
            }
        }
    }
}

