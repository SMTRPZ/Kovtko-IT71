using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class NightTimeHandler : VoiceHandler
    {
        public NightTimeHandler(IHabitationUnit root) : base (root)
        {

        }

        public override string HandleAllVoices()
        {
            return Options.NightTimeAllVoicesError;
        }

        public override string HandleVoice(string animalName)
        {
            return root.GetAnimalVoice(animalName);
        }
    }
}
