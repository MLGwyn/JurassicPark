using System;

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
}

