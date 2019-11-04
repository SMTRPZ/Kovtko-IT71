using System;
using Xunit;
using SMTRPZ.Lab2;
using System.Collections.Generic;
using System.Collections;

namespace XUnitTests
{
    public class HabitationHandlersTests
    {
        public static IEnumerable<object[]> HabitationHandlersTestData = new List<object[]>
        {
            new Func<object[]>(
                ()=>{
                    Demiguise d = new Demiguise("test", 25);
                    return new object[] {d, new Room(d)};
                })(),
            new Func<object[]>(
                ()=>{
                    Bowtruckle b = new Bowtruckle("test", 25);
                    return new object[] { b, new Pasture(b)};
                })(),
            new Func<object[]>(
                ()=>{
                    Occamy o = new Occamy("test", 25);
                    return new object[] {o, new Aviary(o)};
                })()
        };

        [Theory]
        [MemberData(nameof(HabitationHandlersTestData))]
        public void HandlersReturnValidRoomForAnimals(Animal a, Habitation expected)
        {
            var recieved = HabitationHandlersChain.Instance.PickHabitation(a);
            Assert.NotNull(recieved);
            Assert.Equal(expected.GetAnimal(), recieved.GetAnimal());
            Assert.Equal(expected.GetType(), recieved.GetType());
        }

        [Fact]
        public void WrongHandlerThrowsNoSuitableHabitationException()
        {
            Demiguise demiguise = new Demiguise("test", 25);
            HabitationHandler handler = new PastureHandler();
            handler.SetNextHandler(new AviaryHandler());

            Action act = () => handler.Handle(demiguise);

            Assert.Throws<NoSuitableHabitationHandlerException>(act);
        }

    }
}
