using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class DayTimeHandler : VoiceHandler
    {
        public DayTimeHandler(IHabitationUnit root) : base(root)
        {

        }

        public override string HandleAllVoices()
        {
            return root.GetAllVoices();
        }

        public override string HandleVoice(string animalName)
        {
            return root.GetAnimalVoice(animalName);
        }
    }
}
