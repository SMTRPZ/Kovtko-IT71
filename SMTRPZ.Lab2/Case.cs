using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class Case
    {
        private VoiceHandler voiceHandler;
        private IHabitationUnit storageRoot;
        public Case(HabitationsGroup unit)
        {
            storageRoot = unit;
            voiceHandler = new DayTimeHandler(storageRoot);
        }

        public Case()
        {
            storageRoot = new HabitationsGroup();
            voiceHandler = new DayTimeHandler(storageRoot);
        }

        public void SetTimeToNight()
        {
            voiceHandler = new NightTimeHandler(storageRoot);
        }
        public void SetTimeToDay()
        {
            voiceHandler = new DayTimeHandler(storageRoot);
        }

        public string GetAnimalVoice(string name)
        {
            return voiceHandler.HandleVoice(name);
        }

        public string GetAllVoices()
        {
            return voiceHandler.HandleAllVoices();
        }

        public int GetTotalFoodWeight()
        {
            return storageRoot.GetFoodWeight();
        }

        public float GetAverageFoodWeight()
        {
            return (float)storageRoot.GetFoodWeight() / storageRoot.GetCount();
        }

        public int GetCount()
        {
            return storageRoot.GetCount();
        }

        public void AddAnimal(Animal a)
        {
            storageRoot.AddContainer(HandlersCreator.CreateHabitationHandlers().Handle(a));
        }

        public void AddContainer(IHabitationUnit unit)
        {
            storageRoot.AddContainer(unit);
        }

        public void RandomEncounter()
        {
            Random rnd = new Random();
            AddAnimal(HandlersCreator.CreateRandomEncounterHandlers().Handle(rnd.Next(10)));
        }

        public Habitation GetAnimalContainer(string animalName)
        {
            return storageRoot.GetAnimalContainer(animalName);
        }

        public bool RemoveAnimal(string animalName)
        {
            return storageRoot.RemoveAnimal(animalName);
        }

        public bool RemoveContainer(IHabitationUnit habitation)
        {
            return storageRoot.RemoveContainer(habitation);
        }
    }
}
