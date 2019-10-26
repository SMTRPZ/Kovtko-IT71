using System;
using System.Collections.Generic;

namespace SMTRPZ.Lab2
{
    public abstract class Habitation : IHabitationUnit
    {
        protected Animal animal;
        public Habitation(Animal Animal)
        {
            animal = Animal;
        }

        public void AddContainer(IHabitationUnit unit)
        {
        }
        bool IHabitationUnit.RemoveContainer(IHabitationUnit unit)
        {
            return false;
        }

        bool IHabitationUnit.RemoveAnimal(string animalName)
        {
            return false;
        }
        public int GetFoodWeight()
        {
            return animal.FoodWeight;
        }

        public string GetAnimalName()
        {
            return animal.Name;
        }
        public int GetCount() {
            return 1;
        }
        public string GetAnimalVoice(string name)
        {
            if(animal.Name == name)
            {
                return animal.Speak();
            }
            return null;
        }
        public Habitation GetAnimalContainer(string animalName)
        {
            return animal.Name == animalName ? this : null;
        }
        public string GetAllVoices()
        {
            return animal.Speak();
        }

        public Animal GetAnimal()
        {
            return animal;
        }
    }
}