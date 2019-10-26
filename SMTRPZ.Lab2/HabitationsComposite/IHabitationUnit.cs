using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public interface IHabitationUnit
    {
        void AddContainer(IHabitationUnit unit);
        bool RemoveContainer(IHabitationUnit unit);
        bool RemoveAnimal(string animalName);
        int GetFoodWeight();
        int GetCount();
        string GetAnimalVoice(string name);
        Habitation GetAnimalContainer(string animalName);
        string GetAllVoices();
    }
}
