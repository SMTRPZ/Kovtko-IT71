using System;
using System.Collections.Generic;
using System.Text;
using SMTRPZ.Lab2;
using Xunit;

namespace XUnitTests
{
    public class HabitationGroupTests
    {
        private HabitationsGroup group;
        
        public HabitationGroupTests()
        {
            InitGroup();
        }

        private void InitGroup()
        {
            group = new HabitationsGroup();
            group.AddContainer(CommonTestData.pasture);
            group.AddContainer(CommonTestData.room);
            group.AddContainer(CommonTestData.aviary);
        }

        public static IEnumerable<object[]> HabitationGroupTestData = new List<object[]>
        {
            new object[] {CommonTestData.occamy},
            new object[] {CommonTestData.demiguise},
            new object[] { CommonTestData.bowtruckle }
        };

        [Fact]
        public void GetAllVoicesReturnsCorrectOutput()
        {
            string expected = CommonTestData.bowtruckle.Speak() + CommonTestData.demiguise.Speak() + CommonTestData.occamy.Speak();
            string recieved = group.GetAllVoices();
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }

        [Fact]
        public void GetAnimalVoiceReturnsNullForNonExistingName()
        {
            string recieved = group.GetAnimalVoice("Fish");
            Assert.Null(recieved);
        }

        [Theory]
        [MemberData(nameof(HabitationGroupTestData))]
        public void GetAnimalVoiceReturnsCorrectAnswerForValidInput(Animal a)
        {
            string expected = a.Speak();
            string recieved = group.GetAnimalVoice(a.Name);
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }

        [Fact]
        public void GetAnimalContainerReturnsNullForNonExistingName()
        {
            IHabitationUnit recieved = group.GetAnimalContainer("Fish");
            Assert.Null(recieved);
        }

        [Theory]
        [MemberData(nameof(HabitationGroupTestData))]
        public void GetAnimalContainerReturnsCorrectAnswerForValidInput(Animal a)
        {
            Habitation expected = new HabitationHandlersChain().PickHabitation(a);
            Habitation recieved = group.GetAnimalContainer(a.Name);
            Assert.NotNull(recieved);
            Assert.Equal(expected.GetAnimal(), recieved.GetAnimal());
            Assert.Equal(expected.GetType(), recieved.GetType());
        }

        [Fact]
        public void GetCountReturnsCorrectOutput()
        {
            int expected = 3;
            int recieved = group.GetCount();
            Assert.Equal(expected, recieved);
        }

        [Fact]
        public void RemoveContainerReturnsFalseForNonExistingContainer()
        {
            bool recieved = group.RemoveContainer(new HabitationHandlersChain().PickHabitation(new Occamy("Fish",44)));
            Assert.False(recieved);
        }

        [Fact]
        public void RemoveAnimalReturnsFalseForNonExistingName()
        {
            bool recieved = group.RemoveAnimal("Fish");
            Assert.False(recieved);
        }

        [Fact]
        public void RemoveContainerReturnsTrueForValidInput()
        {
            int expectedCount = 2;
            bool recieved = group.RemoveContainer(CommonTestData.room);
            Assert.True(recieved);
            Assert.Equal(expectedCount, group.GetCount());
            InitGroup();
        }

        [Fact]
        public void AddContainerAddsContainer()
        {
            int expectedCount = 4;
            group.AddContainer(new HabitationHandlersChain().PickHabitation(new Bowtruckle("Tree",24)));
            Assert.Equal(expectedCount, group.GetCount());
            InitGroup();
        }
    }
}
