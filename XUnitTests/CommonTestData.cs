using System;
using System.Collections.Generic;
using System.Text;
using SMTRPZ.Lab2;

namespace XUnitTests
{
    public static class CommonTestData
    {
        public static readonly Occamy occamy = new Occamy("Flying Fish", 15);
        public static readonly Aviary aviary = new Aviary(occamy);
        public static readonly Bowtruckle bowtruckle = new Bowtruckle("Green bean", 6);
        public static readonly Pasture pasture = new Pasture(bowtruckle);
        public static readonly Demiguise demiguise = new Demiguise("Snorlax", 78);
        public static readonly Room room = new Room(demiguise);
        
    }
}
