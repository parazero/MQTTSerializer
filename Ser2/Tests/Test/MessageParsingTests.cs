using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ser2.MessagesStructs;
using Ser2.Initializers;
using Ser2.Serializer;
using Ser2.Parser;

namespace Tests.MessageParsing
{
    [TestClass]
    public class MessageParsingTests
    {
        [TestMethod]
        public void dataPlayerStatusMessageParseFromByteArray()
        {
            StatusMessage statusMessagetoParse = new StatusMessage();
            StatusMessage statusMessagetoCompare = new StatusMessage();

            StatusMessage StatusMessageFieldsSize = new StatusMessage();
            MessageInitializers.StatusMessageFieldSizeInitializer(out StatusMessageFieldsSize);

            StatusMessage StatusMessageFieldsIndex = new StatusMessage();
            MessageInitializers.StatusMessageFieldIndexInitializer(out StatusMessageFieldsIndex);

            Byte[] statusbyteArray = Encoding.UTF8.GetBytes("023f00470020001751353235363633020000000000002700000602a100020000");

            MessageParser.StatusMessageParserFromByteArray(out statusMessagetoParse, StatusMessageFieldsIndex, StatusMessageFieldsSize, statusbyteArray);

            statusMessagetoCompare.OpCode = 2;
            statusMessagetoCompare.MessageCounter = 63;
            statusMessagetoCompare.IDPart1 = 2097223;
            statusMessagetoCompare.IDPart2 = 842354967;
            statusMessagetoCompare.IDPart3 = 859190837;
            statusMessagetoCompare.TimeSource = 2;
            statusMessagetoCompare.GPSYear = 0;
            statusMessagetoCompare.GPSMonth = 0;
            statusMessagetoCompare.GPSDay = 0;
            statusMessagetoCompare.GPSHour = 0;
            statusMessagetoCompare.GPSMinute = 0;
            statusMessagetoCompare.GPSSecond = 39;
            statusMessagetoCompare.GPSMiliSec = 0;
            statusMessagetoCompare.Mode = 6;
            statusMessagetoCompare.RTA = 2;
            statusMessagetoCompare.BCS = 161;
            statusMessagetoCompare.IMUStatus = 2;
            statusMessagetoCompare.FDS = 0;
            statusMessagetoCompare.RCChannels = 0;
            Assert.AreEqual(statusMessagetoCompare,statusMessagetoParse);
        }

        [TestMethod]
        public void dataPlayerPhysicalMessageParseFromByteArray()
        {
            PhysicalMessage physicalMessagetoParse = new PhysicalMessage();
            PhysicalMessage physicalMessagetoCompare = new PhysicalMessage();

            PhysicalMessage PhysicalMessageFieldsSize = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldSizeInitializer(out PhysicalMessageFieldsSize);

            PhysicalMessage PhysicalMessageFieldsIndex = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldIndexInitializer(out PhysicalMessageFieldsIndex);

            Byte[] statusbyteArray = Encoding.UTF8.GetBytes("03280126003f001751353235363633020000000000183bc00200000000000000000000000000000000003b0e5a020000");

            MessageParser.PhysicalMessageParserFromByteArray(out physicalMessagetoParse, PhysicalMessageFieldsIndex, PhysicalMessageFieldsSize, statusbyteArray);

            physicalMessagetoCompare.OpCode = 3;
            physicalMessagetoCompare.MessageCounter = 296;
            physicalMessagetoCompare.IDPart1 = 4128806;
            physicalMessagetoCompare.IDPart2 = 842354967;
            physicalMessagetoCompare.IDPart3 = 859190837;
            physicalMessagetoCompare.TimeSource = 2;
            physicalMessagetoCompare.GPSYear = 0;
            physicalMessagetoCompare.GPSMonth = 0;
            physicalMessagetoCompare.GPSDay = 0;
            physicalMessagetoCompare.GPSHour = 0;
            physicalMessagetoCompare.GPSMinute = 24;
            physicalMessagetoCompare.GPSSecond = 59;
            physicalMessagetoCompare.GPSMiliSec = 704;
            physicalMessagetoCompare.NumberOfSatellites = 2;
            physicalMessagetoCompare.Latitude = 0;
            physicalMessagetoCompare.Longitude = 0;
            physicalMessagetoCompare.GPSAltitude = 0;
            physicalMessagetoCompare.GPSVelocity = 0;
            physicalMessagetoCompare.GPSAngle = 0;
            physicalMessagetoCompare.GPSGroundSpeed = 0;
            physicalMessagetoCompare.Temperature = 3643;
            physicalMessagetoCompare.Humidity = 602;
            physicalMessagetoCompare.UVAUVB = 0;

            Assert.AreEqual(physicalMessagetoCompare, physicalMessagetoParse);
        }

        [TestMethod]
        public void dataPlayerKinematicMessageParseFromByteArray()
        {
            KinematicMessage kinematicMessagetoParse = new KinematicMessage();
            KinematicMessage kinematicMessagetoCompare = new KinematicMessage();

            KinematicMessage KinematicMessageFieldsSize = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldSizeInitializer(out KinematicMessageFieldsSize);

            KinematicMessage KinematicMessageFieldsIndex = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldIndexInitializer(out KinematicMessageFieldsIndex);

            Byte[] statusbyteArray = Encoding.UTF8.GetBytes("04500826003f00175135323536363302000000000023049d030000ff4800007600b703f469800900cd0100f6ff02005605710000000000000000000000000000000000000000000000");

            MessageParser.KinematicMessageParserFromByteArray(out kinematicMessagetoParse, KinematicMessageFieldsIndex, KinematicMessageFieldsSize, statusbyteArray);

            kinematicMessagetoCompare.OpCode = 4;
            kinematicMessagetoCompare.MessageCounter = 2128;
            kinematicMessagetoCompare.IDPart1 = 4128806;
            kinematicMessagetoCompare.IDPart2 = 842354967;
            kinematicMessagetoCompare.IDPart3 = 859190837;
            kinematicMessagetoCompare.TimeSource = 2;
            kinematicMessagetoCompare.GPSYear = 0;
            kinematicMessagetoCompare.GPSMonth = 0;
            kinematicMessagetoCompare.GPSDay = 0;
            kinematicMessagetoCompare.GPSHour = 0;
            kinematicMessagetoCompare.GPSMinute = 35;
            kinematicMessagetoCompare.GPSSecond = 4;
            kinematicMessagetoCompare.GPSMiliSec = 925;
            kinematicMessagetoCompare.BaroHeight = 0;
            kinematicMessagetoCompare.Pressure = 18687;
            kinematicMessagetoCompare.AccX = 0;
            kinematicMessagetoCompare.AccY = 118;
            kinematicMessagetoCompare.AccZ = 951;
            kinematicMessagetoCompare.MagX = 27124;
            kinematicMessagetoCompare.MagY = 2432;
            kinematicMessagetoCompare.MagZ = -13056;
            kinematicMessagetoCompare.GyroX = 1;
            kinematicMessagetoCompare.GyroY = -10;
            kinematicMessagetoCompare.GyroZ = 2;
            kinematicMessagetoCompare.Heading = 1366;
            kinematicMessagetoCompare.Roll = 113;
            kinematicMessagetoCompare.Pitch = 0;
            kinematicMessagetoCompare.OrientationX = 0;
            kinematicMessagetoCompare.OrientationY = 0;
            kinematicMessagetoCompare.OrientationZ = 0;
            kinematicMessagetoCompare.OrientationW = 0;
            kinematicMessagetoCompare.LinearAccX = 0;
            kinematicMessagetoCompare.LinearAccY = 0;
            kinematicMessagetoCompare.LinearAccZ = 0;
            kinematicMessagetoCompare.GravX = 0;
            kinematicMessagetoCompare.GravY = 0;
            kinematicMessagetoCompare.GravZ = 0;

            Assert.AreEqual(kinematicMessagetoCompare, kinematicMessagetoParse);
        }
    }
}
