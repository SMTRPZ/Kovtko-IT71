using System;

namespace SMTRPZ.Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Case mainCase = new Case();
            Occamy occamy = new Occamy("Flying Fish", 15);
            Bowtruckle bowtruckle = new Bowtruckle("Green bean", 6);
            Demiguise demiguise = new Demiguise("Snorlax", 78);

            mainCase.AddAnimal(occamy);
            mainCase.AddAnimal(demiguise);
            mainCase.AddAnimal(bowtruckle);

            Console.WriteLine(mainCase.GetAnimalVoice(occamy.Name));
            Console.WriteLine(mainCase.GetAllVoices());
            Console.WriteLine(mainCase.GetTotalFoodWeight());
            Console.WriteLine(mainCase.GetAverageFoodWeight());

            mainCase.SetTimeToNight();
            Console.WriteLine(mainCase.GetAllVoices());

            mainCase.RandomEncounter();
            mainCase.RandomEncounter();
            mainCase.SetTimeToDay();

            Console.WriteLine(mainCase.GetAllVoices());
            Console.WriteLine(mainCase.GetTotalFoodWeight());

            HabitationsGroup habitationsGroup = new HabitationsGroup();
            habitationsGroup.AddContainer(HandlersCreator.CreateHabitationHandlers().Handle(new Demiguise("Old Snorlax", 59)));
            mainCase.AddContainer(habitationsGroup);

            Console.WriteLine(mainCase.GetAllVoices());

            mainCase.RemoveContainer(habitationsGroup);
            mainCase.RemoveAnimal("Snorlax");

            Console.WriteLine(mainCase.GetAllVoices());
            Console.ReadKey();
        }
    }
}
