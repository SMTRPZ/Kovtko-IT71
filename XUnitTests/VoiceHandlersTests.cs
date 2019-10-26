using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SMTRPZ.Lab2;

namespace XUnitTests
{
    public class VoiceHandlersTests
    {
        private IHabitationUnit root;
        
        public VoiceHandlersTests()
        {
            InitRoot();
        }

        private void InitRoot()
        {
            root = new HabitationsGroup();

            Pasture pasture = new Pasture(CommonTestData.bowtruckle);
            Room room = new Room(CommonTestData.demiguise);
            Aviary aviary = new Aviary(CommonTestData.occamy);

            root.AddContainer(pasture);
            root.AddContainer(room);
            root.AddContainer(aviary);
        }

        [Fact]
        public void NightTimeHandlerReturnsErrorMsgForAllVoices()
        {
            string expected = Options.NightTimeAllVoicesError;

            VoiceHandler nightHandler = new NightTimeHandler(root);
            string recieved = nightHandler.HandleAllVoices();
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void NightTimeHandlerReturnsValidVoiceForGivenAnimalName()
        {
            string expected = CommonTestData.occamy.Speak();

            VoiceHandler nightHandler = new NightTimeHandler(root);
            string recieved = nightHandler.HandleVoice(CommonTestData.occamy.Name);
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void NightTimeHandlerReturnsNullForNonExistingName()
        {
            VoiceHandler nightHandler = new NightTimeHandler(root);
            string recieved = nightHandler.HandleVoice("fish");
            Assert.Null(recieved);
        }
        [Fact]
        public void DayTimeHandlerReturnsValidVoicesForAllVoices()
        {
            string expected = CommonTestData.bowtruckle.Speak() + CommonTestData.demiguise.Speak() + CommonTestData.occamy.Speak();

            VoiceHandler nightHandler = new DayTimeHandler(root);
            string recieved = nightHandler.HandleAllVoices();
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void DayTimeHandlerReturnsValidVoiceForGivenAnimalName()
        {
            string expected = CommonTestData.occamy.Speak();

            VoiceHandler nightHandler = new DayTimeHandler(root);
            string recieved = nightHandler.HandleVoice(CommonTestData.occamy.Name);
            Assert.NotNull(recieved);
            Assert.Equal(expected, recieved);
        }
        [Fact]
        public void DayTimeHandlerReturnsNullForNonExistingName()
        {
            VoiceHandler nightHandler = new DayTimeHandler(root);
            string recieved = nightHandler.HandleVoice("fish");
            Assert.Null(recieved);
        }
    }
}
