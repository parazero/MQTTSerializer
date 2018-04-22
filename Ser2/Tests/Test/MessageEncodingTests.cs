using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ser2.MessagesStructs;
using Ser2.Initializers;
using Ser2.Serializer;

namespace Test.Encoding
{
    [TestClass]
    public class MessageEncodingTests
    {
        [TestMethod]
        public void StatusMessageEncodingTests()
        {
            StatusMessage testStatusMessageSize = new StatusMessage();
            StatusMessage testStatusMessageIndex = new StatusMessage();

            MessageInitializers.StatusMessageFieldSizeInitializer(out testStatusMessageSize);
            MessageInitializers.StatusMessageFieldIndexInitializer(out testStatusMessageIndex);

            List<Byte> messageValuesList = new List<Byte>();

            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.OpCode, (uint)2,
                                                                           messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.MessageCounter,
                                                                           (uint)0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testStatusMessageSize.IDPart1,
                                                                           600, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testStatusMessageSize.IDPart2,
                                                                           700, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testStatusMessageSize.IDPart3,
                                                                           800, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.TimeSource,
                                                                           (uint)2, messageValuesList);//Accurate
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.GPSYear,
                                                                           (uint)0, messageValuesList);//Year
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.GPSMonth,
                                                                           (uint)0, messageValuesList);//Month
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.GPSDay,
                                                                           (uint)0, messageValuesList);//Day
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.GPSHour,
                                                                           (uint)0, messageValuesList);//Hour
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.GPSMinute,
                                                                           (uint)0, messageValuesList);//Min
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.GPSSecond,
                                                                           (uint)0, messageValuesList);//Sec
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.GPSMiliSec,
                                                                           (uint)0, messageValuesList);//Mili
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.Mode,
                                                                           (uint)4, messageValuesList);//Mode
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.RTA,
                                                                           (uint)1, messageValuesList);//Ready To Arm
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.BCS,
                                                                           (uint)160, messageValuesList);//Battery LSB=0.1
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.IMUStatus,
                                                                           (uint)1, messageValuesList);//IMU
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.FDS,
                                                                           (uint)3, messageValuesList);//Flash
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testStatusMessageSize.RCChannels,
                                                                           (uint)1, messageValuesList);//RC
            //Convert list to Array
            Byte[] messageinValues = messageValuesList.ToArray();
            Byte[] ExpectedArray = { 2, 0, 0, 88, 2, 0, 0, 188, 2, 0, 0, 32, 3, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 160, 0, 1, 3, 1 };
            Assert.AreEqual(Convert.ToBase64String(ExpectedArray), Convert.ToBase64String(messageinValues));
        }

        [TestMethod]
        public void PhysicalMessageEncodingTests()
        {
            PhysicalMessage testPhysicalMessageSize = new PhysicalMessage();
            PhysicalMessage testPhysicalMessageIndex = new PhysicalMessage();

            MessageInitializers.PhysicalMessageFieldSizeInitializer(out testPhysicalMessageSize);
            MessageInitializers.PhysicalMessageFieldIndexInitializer(out testPhysicalMessageIndex);

            List<Byte> messageValuesList = new List<Byte>();

            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.OpCode, 3, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.MessageCounter, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testPhysicalMessageSize.IDPart1, 600, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testPhysicalMessageSize.IDPart2, 700, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testPhysicalMessageSize.IDPart3, 800, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.TimeSource, 2, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSYear, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSMonth, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSDay, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSHour, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSMinute, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSSecond, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSMiliSec, 0, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.NumberOfSatellites, 17, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.Latitude, 32100000, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.Longitude, 35200000, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSAltitude, 3000, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSVelocity, 3, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSAngle, 5, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.GPSGroundSpeed, 15, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.Temperature, 32, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.Humidity, 3000, messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testPhysicalMessageSize.UVAUVB, 0, messageValuesList);
            //Convert list to Array
            Byte[] messageinValues = messageValuesList.ToArray();
            Byte[] ExpectedArray = { 3, 0, 0, 88, 2, 0, 0, 188, 2, 0, 0, 32, 3, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 160, 206, 233, 1, 0, 28, 25, 2, 184, 11, 3, 0 , 5, 0 ,15, 0, 32, 0, 184, 11, 0, 0 };
            Assert.AreEqual(Convert.ToBase64String(ExpectedArray), Convert.ToBase64String(messageinValues));
        }

        [TestMethod]
        public void KinematicMessageEncodingTests()
        {
            KinematicMessage testKinematicMessageSize = new KinematicMessage();
            KinematicMessage testKinematicMessageIndex = new KinematicMessage();

            MessageInitializers.KinematicMessageFieldSizeInitializer(out testKinematicMessageSize);
            MessageInitializers.KinematicMessageFieldIndexInitializer(out testKinematicMessageIndex);

            List<Byte> messageValuesList = new List<Byte>();

            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.OpCode, 4,            messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.MessageCounter, 0,    messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testKinematicMessageSize.IDPart1, 600,    messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testKinematicMessageSize.IDPart2, 700,    messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList((int)testKinematicMessageSize.IDPart3, 800,    messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.TimeSource, 2,        messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GPSYear, 0,           messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GPSMonth, 0,          messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GPSDay, 0,            messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GPSHour, 0,           messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GPSMinute, 0,         messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GPSSecond, 0,         messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GPSMiliSec, 0,        messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.BaroHeight, 17,       messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.Pressure, 3200,       messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.AccX, 3500,           messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.AccY, 3000,           messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.AccZ, 3,              messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.MagX, 5,              messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.MagY, 15,             messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.MagZ, 32,             messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GyroX, 3000,          messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GyroY, 0,             messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GyroZ, 0,             messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.Heading, 10,          messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.Roll, 20,             messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.Pitch, 40,            messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.OrientationX, 0,      messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.OrientationY, 0,      messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.OrientationZ, 0,      messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.OrientationW, 0,      messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.LinearAccX, 0,        messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.LinearAccY, 0,        messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.LinearAccZ, 0,        messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GravX, 0,             messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GravY, 0,             messageValuesList);
            messageValuesList = ManualSerializer.EncodeValuesAsBytesInList(testKinematicMessageSize.GravZ, 0,             messageValuesList);
            //Convert list to Array
            Byte[] messageinValues = messageValuesList.ToArray();
            Byte[] ExpectedArray = { 4, 0, 0, 88, 2, 0, 0, 188, 2, 0, 0, 32, 3, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0, 128, 12, 172, 13, 184, 11, 3, 0, 5, 0, 15, 0, 32, 0, 184, 11, 0, 0, 0, 0, 10, 0, 20, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            Assert.AreEqual(Convert.ToBase64String(ExpectedArray), Convert.ToBase64String(messageinValues));
        }

    }
}
