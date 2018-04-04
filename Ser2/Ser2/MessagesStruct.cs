using System;
namespace Ser2.MessagesStructs
{
    public struct StatusMessage
    {
        public SByte OpCode;
        public Int16 MessageCounter;
        public UInt32 IDPart1;
        public UInt32 IDPart2;
        public UInt32 IDPart3;
        public SByte TimeSource;
        public Int16 GPSYear;
        public SByte GPSMonth;
        public SByte GPSDay;
        public SByte GPSHour;
        public SByte GPSMinute;
        public SByte GPSSecond;
        public Int16 GPSMiliSec;
        public SByte Mode;
        public SByte RTA;
        public Int16 BCS;
        public SByte IMUStatus;
        public SByte FDS;
        public SByte RCChannels;
    }

    public struct PhysicalMessage
    {
        public SByte OpCode;
        public Int16 MessageCounter;
        public UInt32 IDPart1;
        public UInt32 IDPart2;
        public UInt32 IDPart3;
        public SByte TimeSource;
        public Int16 GPSYear;
        public SByte GPSMonth;
        public SByte GPSDay;
        public SByte GPSHour;
        public SByte GPSMinute;
        public SByte GPSSecond;
        public Int16 GPSMiliSec;
        public SByte NumberOfSatellites;
        public Int32 Latitude;
        public Int32 Longitude;
        public Int16 GPSAltitude;
        public Int16 GPSVelocity;
        public Int16 GPSAngle;
        public Int16 GPSGroundSpeed;
        public Int16 Temperature;
        public Int16 Humidity;
        public Int16 UVAUVB;
    }
}
