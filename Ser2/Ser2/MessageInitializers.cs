using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using Ser2.Serializer;
using Ser2.MessagesStructs;

namespace Ser2.Initializers
{
    public class MessageInitializers
    {
        public static void StatusMessageFieldSizeInitializer(out StatusMessage MessageFieldsSize)
        {
            MessageFieldsSize.OpCode = 1;
            MessageFieldsSize.MessageCounter = 2;
            MessageFieldsSize.IDPart1 = 4;
            MessageFieldsSize.IDPart2 = 4;
            MessageFieldsSize.IDPart3 = 4;
            MessageFieldsSize.TimeSource = 1;
            MessageFieldsSize.GPSYear = 2;
            MessageFieldsSize.GPSMonth = 1;
            MessageFieldsSize.GPSDay = 1;
            MessageFieldsSize.GPSHour = 1;
            MessageFieldsSize.GPSMinute = 1;
            MessageFieldsSize.GPSSecond = 1;
            MessageFieldsSize.GPSMiliSec = 2;
            MessageFieldsSize.Mode = 1;
            MessageFieldsSize.RTA = 1;
            MessageFieldsSize.BCS = 2;
            MessageFieldsSize.IMUStatus = 1;
            MessageFieldsSize.FDS = 1;
            MessageFieldsSize.RCChannels = 1;
            //return MessageFieldsSize;
        }
        public static void StatusMessageFieldIndexInitializer(out StatusMessage MessageFieldsIndex)
        {
            MessageFieldsIndex.OpCode           = 0;
            MessageFieldsIndex.MessageCounter   = 1;
            MessageFieldsIndex.IDPart1          = 3;
            MessageFieldsIndex.IDPart2          = 7;
            MessageFieldsIndex.IDPart3          = 11;
            MessageFieldsIndex.TimeSource       = 15;
            MessageFieldsIndex.GPSYear          = 16;
            MessageFieldsIndex.GPSMonth         = 18;
            MessageFieldsIndex.GPSDay           = 19;
            MessageFieldsIndex.GPSHour          = 20;
            MessageFieldsIndex.GPSMinute        = 21;
            MessageFieldsIndex.GPSSecond        = 22;
            MessageFieldsIndex.GPSMiliSec       = 23;
            MessageFieldsIndex.Mode             = 25;
            MessageFieldsIndex.RTA              = 26;
            MessageFieldsIndex.BCS              = 27;
            MessageFieldsIndex.IMUStatus        = 29;
            MessageFieldsIndex.FDS              = 30;
            MessageFieldsIndex.RCChannels       = 31;
            //return MessageFieldsSize;
        }

        public static void PhysicalMessageFieldSizeInitializer(out PhysicalMessage MessageFieldsSize)
        {
            MessageFieldsSize.OpCode            = 1;
            MessageFieldsSize.MessageCounter    = 2;
            MessageFieldsSize.IDPart1           = 4;
            MessageFieldsSize.IDPart2           = 4;
            MessageFieldsSize.IDPart3           = 4;
            MessageFieldsSize.TimeSource        = 1;
            MessageFieldsSize.GPSYear           = 2;
            MessageFieldsSize.GPSMonth          = 1;
            MessageFieldsSize.GPSDay            = 1;
            MessageFieldsSize.GPSHour           = 1;
            MessageFieldsSize.GPSMinute         = 1;
            MessageFieldsSize.GPSSecond         = 1;
            MessageFieldsSize.GPSMiliSec        = 2;
            MessageFieldsSize.NumberOfSatellites = 1;
            MessageFieldsSize.Latitude          = 4;
            MessageFieldsSize.Longitude         = 4;
            MessageFieldsSize.GPSAltitude       = 2;
            MessageFieldsSize.GPSVelocity       = 2;
            MessageFieldsSize.GPSAngle          = 2;
            MessageFieldsSize.GPSGroundSpeed    = 2;
            MessageFieldsSize.Temperature       = 2;
            MessageFieldsSize.Humidity          = 2;
            MessageFieldsSize.UVAUVB            = 2;
            //return MessageFieldsSize;
        }
        public static void PhysicalMessageFieldIndexInitializer(out PhysicalMessage MessageFieldsIndex)
        {
            MessageFieldsIndex.OpCode           = 0;
            MessageFieldsIndex.MessageCounter   = 1;
            MessageFieldsIndex.IDPart1          = 3;
            MessageFieldsIndex.IDPart2          = 7;
            MessageFieldsIndex.IDPart3          = 11;
            MessageFieldsIndex.TimeSource       = 15;
            MessageFieldsIndex.GPSYear          = 16;
            MessageFieldsIndex.GPSMonth         = 18;
            MessageFieldsIndex.GPSDay           = 19;
            MessageFieldsIndex.GPSHour          = 20;
            MessageFieldsIndex.GPSMinute        = 21;
            MessageFieldsIndex.GPSSecond        = 22;
            MessageFieldsIndex.GPSMiliSec       = 23;
            MessageFieldsIndex.NumberOfSatellites = 24;
            MessageFieldsIndex.Latitude         = 28;
            MessageFieldsIndex.Longitude        = 32;
            MessageFieldsIndex.GPSAltitude      = 34;
            MessageFieldsIndex.GPSVelocity      = 36;
            MessageFieldsIndex.GPSAngle         = 38;
            MessageFieldsIndex.GPSGroundSpeed   = 40;
            MessageFieldsIndex.Temperature      = 42;
            MessageFieldsIndex.Humidity         = 44;
            MessageFieldsIndex.UVAUVB           = 46;
        }
    }
}                            
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
