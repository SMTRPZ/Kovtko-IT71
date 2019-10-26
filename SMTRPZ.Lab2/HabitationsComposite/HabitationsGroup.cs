using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SMTRPZ.Lab2
{
    public class HabitationsGroup : IHabitationUnit
    {
        private List<IHabitationUnit> habitations = new List<IHabitationUnit>();

        public Habitation GetAnimalContainer(string animalName)
        {
            Habitation habitation = null;
            foreach(var h in habitations)
            {
                habitation = h.GetAnimalContainer(animalName);
                if(habitation != null)
                {
                    return habitation;
                }
            }
            return null;
        }

        public string GetAllVoices()
        {
            return habitations.Select(u => u.GetAllVoices()).Aggregate("",(acc, x) => acc + x);
        }

        public string GetAnimalVoice(string name)
        {
            string voice = null;
            foreach (var u in habitations)
            {
                voice = u.GetAnimalVoice(name);
                if(voice != null)
                {
                    return voice;
                }
            }
            return null;
        }

        public int GetCount()
        {
            return habitations.Count;
        }

        public int GetFoodWeight()
        {
            return habitations.Select(h => h.GetFoodWeight()).Sum();
        }

        public void AddContainer(IHabitationUnit unit)
        {
            habitations.Add(unit);
        }

        public bool RemoveContainer(IHabitationUnit habitation)
        {
            bool result = false;
            for(int i = 0; i < habitations.Count; i++)
            {
                if(habitations[i] == habitation)
                {
                    habitations.Remove(habitation);
                    return true;
                } else
                {
                    result = habitations[i].RemoveContainer(habitation);
                }
            }
            return result;
        }

        public bool RemoveAnimal(string animalName)
        {
            Habitation container = GetAnimalContainer(animalName);
            if (container == null)
                return false;
            return RemoveContainer(container);
        }
    }
}
