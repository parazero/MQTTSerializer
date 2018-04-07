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

    public struct KinematicMessage
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
        public Int16 BaroHeight;
        public Int16 Pressure;
        public Int16 AccX;
        public Int16 AccY;
        public Int16 AccZ;
        public Int16 MagX;
        public Int16 MagY;
        public Int16 MagZ;
        public Int16 GyroX;
        public Int16 GyroY;
        public Int16 GyroZ;
        public Int16 Heading;
        public Int16 Roll;
        public Int16 Pitch;
        public Int16 OrientationX;
        public Int16 OrientationY;
        public Int16 OrientationZ;
        public Int16 LinearAccX;
        public Int16 LinearAccY;
        public Int16 LinearAccZ;
        public Int16 GravX;
        public Int16 GravY;
        public Int16 GravZ;
    }
}
