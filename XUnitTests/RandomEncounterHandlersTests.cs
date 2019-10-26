using System;
using System.Collections.Generic;
using System.Text;
using SMTRPZ.Lab2;
using Xunit;

namespace XUnitTests
{
    public class RandomEncounterHandlersTests
    {
        public static IEnumerable<object[]> RandomEncounterHandlersTestData = new List<object[]>
        {
            new object[] {1, new Bowtruckle("test", 25).GetType()},
            new object[] {5, new Demiguise("test", 25).GetType()},
            new object[] {9, new Occamy("test", 25).GetType() }
        };

        [Theory]
        [MemberData(nameof(RandomEncounterHandlersTestData))]
        public void HandlersReturnCorrectAnimalForValidChance(int chance, Type expected)
        {
            var recievedAnimal = RandomEncounterHandler.CreateHandlers().HandleEncounter(chance);
            Assert.NotNull(recievedAnimal);
            Assert.Equal(expected, recievedAnimal.GetType());
        }

        [Fact]
        public void WrongHandlerThrowsNoSuitableEncounterException()
        {
            int chance = 9;
            RandomEncounterHandler handler = new BowtruckleEncounterHandler();
            handler.SetNextHandler(new DemiguiseEncounterHandler());
            Action act = () => handler.HandleEncounter(chance);

            Assert.Throws<NoSuitableEncounterHandlerException>(act);
        }
    }
}
