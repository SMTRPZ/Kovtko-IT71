using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public abstract class VoiceHandler
    {
        protected IHabitationUnit root;
        public VoiceHandler(IHabitationUnit unit)
        {
            root = unit;
        }
        public abstract string HandleAllVoices();
        public abstract string HandleVoice(string animalName);
    }
}
