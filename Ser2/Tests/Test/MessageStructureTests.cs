using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ser2.MessagesStructs;
using Ser2.Initializers;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 16 * 2;
            Assert.AreEqual(32, a);
        }
        [TestMethod]
        public void StatusMessageStructure()
        {
            StatusMessage testStatusMessageSize = new StatusMessage();
            MessageInitializers.StatusMessageFieldSizeInitializer(out testStatusMessageSize);
            int statusMessageSize = (int)(testStatusMessageSize.OpCode + testStatusMessageSize.MessageCounter
                                                         + testStatusMessageSize.IDPart1
                                                         + testStatusMessageSize.IDPart2
                                                         + testStatusMessageSize.IDPart3
                                                         + testStatusMessageSize.TimeSource
                                                         + testStatusMessageSize.GPSYear
                                                         + testStatusMessageSize.GPSMonth
                                                         + testStatusMessageSize.GPSDay
                                                         + testStatusMessageSize.GPSHour
                                                         + testStatusMessageSize.GPSMinute
                                                         + testStatusMessageSize.GPSSecond
                                                         + testStatusMessageSize.GPSMiliSec
                                                         + testStatusMessageSize.Mode
                                                         + testStatusMessageSize.RTA
                                                         + testStatusMessageSize.BCS
                                                         + testStatusMessageSize.IMUStatus
                                                         + testStatusMessageSize.FDS
                                                         + testStatusMessageSize.RCChannels);
            Assert.AreEqual(32, statusMessageSize);
        }
    }
}
