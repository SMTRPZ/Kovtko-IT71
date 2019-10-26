using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SMTRPZ.Lab2;

namespace XUnitTests
{
    public class HabitationsTests
    {
        public static IEnumerable<object[]> HabitationsTestData = new List<object[]>
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
        [MemberData(nameof(HabitationsTestData))]
        public void HabitationReturnsValidDataAboutAnimal(Animal a, Habitation habitation)
        {
            Assert.Equal(a.Name, habitation.GetAnimalName());
            Assert.Equal(a.FoodWeight, habitation.GetFoodWeight());
        }
    }
}
