using System;
using System.Collections.Generic;
using System.Text;

namespace SMTRPZ.Lab2
{
    public class NoSuitableHabitationHandlerException : Exception
    {
        public NoSuitableHabitationHandlerException() : base("No suitable HabitationHandler found")
        {

        }
    }
}
