using System;
using System.Collections.Generic;
using System.Text;
using SMTRPZ.Lab2;
using Xunit;

namespace XUnitTests
{
    public class AnimalsTests
    {
        [Fact]
        public void OccamyVoiceIsNotNull()
        {
            Occamy occamy = new Occamy("Fish", 25);
            Assert.NotNull(occamy);
        }
        [Fact]
        public void DemiguiseVoiceIsNotNull()
        {
            Demiguise demiguise = new Demiguise("Fish", 25);
            Assert.NotNull(demiguise);
        }
        [Fact]
        public void BowtruckleVoiceIsNotNull()
        {
            Bowtruckle bowtruckle = new Bowtruckle("Fish", 25);
            Assert.NotNull(bowtruckle);
        }
    }
}
