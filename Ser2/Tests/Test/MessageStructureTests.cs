using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ser2.MessagesStructs;
using Ser2.Initializers;

namespace Tests.MessageStructure
{
    [TestClass]
    public class MessageSructureTests
    {
        [TestMethod]
        public void BasicMathTest()
        {
            int a = 16 * 2;
            Assert.AreEqual(32, a);
        }

        [TestMethod]
        public void StatusMessageSize()
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

        [TestMethod]
        public void StatusMessageVsIndex()
        {
            
            StatusMessage testStatusMessageSize = new StatusMessage();
            StatusMessage testStatusMessageIndex = new StatusMessage();

            MessageInitializers.StatusMessageFieldSizeInitializer(out testStatusMessageSize);
            MessageInitializers.StatusMessageFieldIndexInitializer(out testStatusMessageIndex);


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
            Assert.AreEqual(testStatusMessageIndex.RCChannels, statusMessageSize - testStatusMessageSize.RCChannels);
        }

        [TestMethod]
        public void PhysicalMessageSize()
        {
            PhysicalMessage testPhysicalMessageSize = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldSizeInitializer(out testPhysicalMessageSize);

            int physicalMessageSize = (int)(testPhysicalMessageSize.OpCode + testPhysicalMessageSize.MessageCounter
                                            + testPhysicalMessageSize.IDPart1
                                            + testPhysicalMessageSize.IDPart2
                                            + testPhysicalMessageSize.IDPart3
                                            + testPhysicalMessageSize.TimeSource
                                            + testPhysicalMessageSize.GPSYear
                                            + testPhysicalMessageSize.GPSMonth
                                            + testPhysicalMessageSize.GPSDay
                                            + testPhysicalMessageSize.GPSHour
                                            + testPhysicalMessageSize.GPSMinute
                                            + testPhysicalMessageSize.GPSSecond
                                            + testPhysicalMessageSize.GPSMiliSec
                                            + testPhysicalMessageSize.NumberOfSatellites
                                            + testPhysicalMessageSize.Latitude
                                            + testPhysicalMessageSize.Longitude
                                            + testPhysicalMessageSize.GPSAltitude
                                            + testPhysicalMessageSize.GPSVelocity
                                            + testPhysicalMessageSize.GPSAngle
                                            + testPhysicalMessageSize.GPSGroundSpeed
                                            + testPhysicalMessageSize.Temperature
                                            + testPhysicalMessageSize.Humidity
                                            + testPhysicalMessageSize.UVAUVB);
            Assert.AreEqual(48, physicalMessageSize);
        }

        [TestMethod]
        public void PhysicalMessageSizeVsIndex()
        {
            PhysicalMessage testPhysicalMessageSize = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldSizeInitializer(out testPhysicalMessageSize);

            PhysicalMessage testPhysicalMessageIndex = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldIndexInitializer(out testPhysicalMessageIndex);

            int physicalMessageSize = (int)(testPhysicalMessageSize.OpCode + testPhysicalMessageSize.MessageCounter
                                            + testPhysicalMessageSize.IDPart1
                                            + testPhysicalMessageSize.IDPart2
                                            + testPhysicalMessageSize.IDPart3
                                            + testPhysicalMessageSize.TimeSource
                                            + testPhysicalMessageSize.GPSYear
                                            + testPhysicalMessageSize.GPSMonth
                                            + testPhysicalMessageSize.GPSDay
                                            + testPhysicalMessageSize.GPSHour
                                            + testPhysicalMessageSize.GPSMinute
                                            + testPhysicalMessageSize.GPSSecond
                                            + testPhysicalMessageSize.GPSMiliSec
                                            + testPhysicalMessageSize.NumberOfSatellites
                                            + testPhysicalMessageSize.Latitude
                                            + testPhysicalMessageSize.Longitude
                                            + testPhysicalMessageSize.GPSAltitude
                                            + testPhysicalMessageSize.GPSVelocity
                                            + testPhysicalMessageSize.GPSAngle
                                            + testPhysicalMessageSize.GPSGroundSpeed
                                            + testPhysicalMessageSize.Temperature
                                            + testPhysicalMessageSize.Humidity
                                            + testPhysicalMessageSize.UVAUVB);
            Assert.AreEqual(testPhysicalMessageIndex.UVAUVB, physicalMessageSize-testPhysicalMessageSize.UVAUVB);
        }

        [TestMethod]
        public void KinematiclMessageSize()
        {
            KinematicMessage testKinematicMessageSize = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldSizeInitializer(out testKinematicMessageSize);

            int kinematicMessageSize = (int)(testKinematicMessageSize.OpCode + testKinematicMessageSize.MessageCounter
                                             + testKinematicMessageSize.IDPart1
                                             + testKinematicMessageSize.IDPart2
                                             + testKinematicMessageSize.IDPart3
                                             + testKinematicMessageSize.TimeSource
                                             + testKinematicMessageSize.GPSYear
                                             + testKinematicMessageSize.GPSMonth
                                             + testKinematicMessageSize.GPSDay
                                             + testKinematicMessageSize.GPSHour
                                             + testKinematicMessageSize.GPSMinute
                                             + testKinematicMessageSize.GPSSecond
                                             + testKinematicMessageSize.GPSMiliSec
                                             + testKinematicMessageSize.BaroHeight
                                             + testKinematicMessageSize.Pressure
                                             + testKinematicMessageSize.AccX
                                             + testKinematicMessageSize.AccY
                                             + testKinematicMessageSize.AccZ
                                             + testKinematicMessageSize.MagX
                                             + testKinematicMessageSize.MagY
                                             + testKinematicMessageSize.MagZ
                                             + testKinematicMessageSize.GyroX
                                             + testKinematicMessageSize.GyroY
                                             + testKinematicMessageSize.GyroZ
                                             + testKinematicMessageSize.Heading
                                             + testKinematicMessageSize.Roll
                                             + testKinematicMessageSize.Pitch
                                             + testKinematicMessageSize.OrientationX
                                             + testKinematicMessageSize.OrientationY
                                             + testKinematicMessageSize.OrientationZ
                                             + testKinematicMessageSize.OrientationW
                                             + testKinematicMessageSize.LinearAccX
                                             + testKinematicMessageSize.LinearAccY
                                             + testKinematicMessageSize.LinearAccZ
                                             + testKinematicMessageSize.GravX
                                             + testKinematicMessageSize.GravY
                                             + testKinematicMessageSize.GravZ);
            Assert.AreEqual(73, kinematicMessageSize);
        }

        [TestMethod]
        public void KinematiclMessageSizeVsIndex()
        {
            KinematicMessage testKinematicMessageSize = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldSizeInitializer(out testKinematicMessageSize);

            KinematicMessage testKinematicMessageIndex = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldIndexInitializer(out testKinematicMessageIndex);

            int kinematicMessageSize = (int)(testKinematicMessageSize.OpCode + testKinematicMessageSize.MessageCounter
                                             + testKinematicMessageSize.IDPart1
                                             + testKinematicMessageSize.IDPart2
                                             + testKinematicMessageSize.IDPart3
                                             + testKinematicMessageSize.TimeSource
                                             + testKinematicMessageSize.GPSYear
                                             + testKinematicMessageSize.GPSMonth
                                             + testKinematicMessageSize.GPSDay
                                             + testKinematicMessageSize.GPSHour
                                             + testKinematicMessageSize.GPSMinute
                                             + testKinematicMessageSize.GPSSecond
                                             + testKinematicMessageSize.GPSMiliSec
                                             + testKinematicMessageSize.BaroHeight
                                             + testKinematicMessageSize.Pressure
                                             + testKinematicMessageSize.AccX
                                             + testKinematicMessageSize.AccY
                                             + testKinematicMessageSize.AccZ
                                             + testKinematicMessageSize.MagX
                                             + testKinematicMessageSize.MagY
                                             + testKinematicMessageSize.MagZ
                                             + testKinematicMessageSize.GyroX
                                             + testKinematicMessageSize.GyroY
                                             + testKinematicMessageSize.GyroZ
                                             + testKinematicMessageSize.Heading
                                             + testKinematicMessageSize.Roll
                                             + testKinematicMessageSize.Pitch
                                             + testKinematicMessageSize.OrientationX
                                             + testKinematicMessageSize.OrientationY
                                             + testKinematicMessageSize.OrientationZ
                                             + testKinematicMessageSize.OrientationW
                                             + testKinematicMessageSize.LinearAccX
                                             + testKinematicMessageSize.LinearAccY
                                             + testKinematicMessageSize.LinearAccZ
                                             + testKinematicMessageSize.GravX
                                             + testKinematicMessageSize.GravY
                                             + testKinematicMessageSize.GravZ);
            Assert.AreEqual(testKinematicMessageIndex.GravZ, kinematicMessageSize-testKinematicMessageSize.GravZ);
        }

    }
}
