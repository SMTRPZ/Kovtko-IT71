using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SMTRPZ.Lab2;

namespace XUnitTests
{
    public class CaseTests
    {
        private Case Case;

        public CaseTests()
        {
            Init();
        }

        private void Init()
        {
            HabitationsGroup mainroot = new HabitationsGroup();
            mainroot.AddContainer(CommonTestData.pasture);
            mainroot.AddContainer(CommonTestData.room);
            mainroot.AddContainer(CommonTestData.aviary);

            Case = new Case(mainroot);
        }

        public static IEnumerable<object[]> CaseTestData = new List<object[]>
        {
            new object[] {CommonTestData.occamy,CommonTestData.aviary},
            new object[] {CommonTestData.demiguise,CommonTestData.room},
            new object[] {CommonTestData.bowtruckle,CommonTestData.pasture}
        };

        [Fact]
        public void CaseReturnsErrorMsgForAllVoicesAtNight()
        {
            string expected = Options.NightTimeAllVoicesError;

            Case.SetTimeToNight();
            string recieved = Case.GetAllVoices();
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void CaseReturnsValidVoiceForGivenAnimalNameAtNight()
        {
            string expected = CommonTestData.occamy.Speak();

            Case.SetTimeToNight();
            string recieved = Case.GetAnimalVoice(CommonTestData.occamy.Name);
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void CaseReturnsNullForNonExistingNameAtNight()
        {
            Case.SetTimeToNight();
            string recieved = Case.GetAnimalVoice("fish");
            Assert.Null(recieved);
        }
        [Fact]
        public void CaseReturnsValidVoicesForAllVoicesAtDay()
        {
            string expected = CommonTestData.bowtruckle.Speak() + CommonTestData.demiguise.Speak() + CommonTestData.occamy.Speak();

            Case.SetTimeToDay();
            string recieved = Case.GetAllVoices();
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void CaseReturnsValidVoiceForGivenAnimalNameAtDay()
        {
            string expected = CommonTestData.occamy.Speak();

            Case.SetTimeToDay();
            string recieved = Case.GetAnimalVoice(CommonTestData.occamy.Name);
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void CaseReturnsNullForNonExistingNameAtDay()
        {
            Case.SetTimeToDay();
            string recieved = Case.GetAnimalVoice("fish");
            Assert.Null(recieved);
        }

        [Fact]
        public void CaseReturnsCorrectFoodWeight()
        {
            int expected = CommonTestData.bowtruckle.FoodWeight + CommonTestData.demiguise.FoodWeight + CommonTestData.occamy.FoodWeight;
            int recieved = Case.GetTotalFoodWeight();
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void CaseReturnsCorrectAverageFoodWeight()
        {
            float expected = (CommonTestData.bowtruckle.FoodWeight + CommonTestData.demiguise.FoodWeight + CommonTestData.occamy.FoodWeight) / 3;
            float recieved = Case.GetAverageFoodWeight();
            Assert.Equal(expected,recieved);
        }

        [Fact]
        public void AddContainerAddsContainer()
        {
            int expectedCount = 4;
            Case.AddContainer(HandlersCreator.CreateHabitationHandlers().Handle(new Bowtruckle("Tree", 24)));
            Assert.Equal(expectedCount, Case.GetCount());
            Init();
        }

        [Fact]
        public void AddAnimalAddsAnimal()
        {
            int expectedCount = 4;
            Case.AddAnimal(new Bowtruckle("Tree", 24));
            Assert.Equal(expectedCount, Case.GetCount());
            Init();
        }

        [Theory]
        [MemberData(nameof(CaseTestData))]
        public void CaseReturnsCorrectContainerForValidInput(Animal a, Habitation expected)
        {
            Habitation received = Case.GetAnimalContainer(a.Name);
            Assert.NotNull(received);
            Assert.Equal(expected, received);
        }

        [Fact]
        public void CaseReturnsNullForNonExistingName()
        {
            Habitation received = Case.GetAnimalContainer("Fish");
            Assert.Null(received);
        }

        [Fact]
        public void RemoveContainerReturnsFalseForNonExistingContainer()
        {
            Assert.False(Case.RemoveContainer(HandlersCreator.CreateHabitationHandlers().Handle(new Occamy("Fish", 44))));
        }

        [Fact]
        public void RemoveAnimalReturnsFalseForNonExistingAnimal()
        {
            Assert.False(Case.RemoveAnimal("Fish"));
        }

        [Fact]
        public void RemoveContainerRemovesContainerForValidInput()
        {
            int expectedCount = 2;

            Case.RemoveContainer(CommonTestData.aviary);
            Assert.Equal(expectedCount, Case.GetCount());
            Init();
        }
        [Fact]
        public void RemoveAnimalRemovesAnimalForValidInput()
        {
            int expectedCount = 2;

            Case.RemoveAnimal(CommonTestData.occamy.Name);
            Assert.Equal(expectedCount, Case.GetCount());
            Init();
        }
        [Fact]
        public void RandomEncounterAddsAnimal()
        {
            int expectedCount = 4;

            Case.RandomEncounter();
            Assert.Equal(expectedCount, Case.GetCount());
            Init();
        }
    }
}
