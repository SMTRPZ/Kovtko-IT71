using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class NoSuitableEncounterHandlerException : Exception
    {
        public NoSuitableEncounterHandlerException() : base("No suitable EncounterHandler found")
        {

        }
    }
}
