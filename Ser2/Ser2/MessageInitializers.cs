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

        public static void KinematicMessageFieldSizeInitializer(out KinematicMessage MessageFieldsSize)
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
            MessageFieldsSize.BaroHeight = 2;
            MessageFieldsSize.Pressure = 2;
            MessageFieldsSize.AccX = 2;
            MessageFieldsSize.AccY = 2;
            MessageFieldsSize.AccZ = 2;
            MessageFieldsSize.MagX = 2;
            MessageFieldsSize.MagY = 2;
            MessageFieldsSize.MagZ = 2;
            MessageFieldsSize.GyroX = 2;
            MessageFieldsSize.GyroY = 2;
            MessageFieldsSize.GyroZ = 2;
            MessageFieldsSize.Heading = 2;
            MessageFieldsSize.Roll = 2;
            MessageFieldsSize.Pitch = 2;
            MessageFieldsSize.OrientationX = 2;
            MessageFieldsSize.OrientationY = 2;
            MessageFieldsSize.OrientationZ = 2;
            MessageFieldsSize.OrientationW = 2;
            MessageFieldsSize.LinearAccX = 2;
            MessageFieldsSize.LinearAccY = 2;
            MessageFieldsSize.LinearAccZ = 2;
            MessageFieldsSize.GravX = 2;
            MessageFieldsSize.GravY = 2;
            MessageFieldsSize.GravZ = 2;
            //return MessageFieldsSize;
        }
        public static void KinematicMessageFieldIndexInitializer(out KinematicMessage MessageFieldsIndex)
        {
            MessageFieldsIndex.OpCode = 0;
            MessageFieldsIndex.MessageCounter = 1;
            MessageFieldsIndex.IDPart1 = 3;
            MessageFieldsIndex.IDPart2 = 7;
            MessageFieldsIndex.IDPart3 = 11;
            MessageFieldsIndex.TimeSource = 15;
            MessageFieldsIndex.GPSYear = 16;
            MessageFieldsIndex.GPSMonth = 18;
            MessageFieldsIndex.GPSDay = 19;
            MessageFieldsIndex.GPSHour = 20;
            MessageFieldsIndex.GPSMinute = 21;
            MessageFieldsIndex.GPSSecond = 22;
            MessageFieldsIndex.GPSMiliSec = 23;
            MessageFieldsIndex.BaroHeight = 25;
            MessageFieldsIndex.Pressure = 27;
            MessageFieldsIndex.AccX = 29;
            MessageFieldsIndex.AccY = 31;
            MessageFieldsIndex.AccZ = 33;
            MessageFieldsIndex.MagX = 35;
            MessageFieldsIndex.MagY = 37;
            MessageFieldsIndex.MagZ = 39;
            MessageFieldsIndex.GyroX = 41;
            MessageFieldsIndex.GyroY = 43;
            MessageFieldsIndex.GyroZ = 45;
            MessageFieldsIndex.Heading = 47;
            MessageFieldsIndex.Roll = 49;
            MessageFieldsIndex.Pitch = 51;
            MessageFieldsIndex.OrientationX = 52;
            MessageFieldsIndex.OrientationY = 55;
            MessageFieldsIndex.OrientationZ = 57;
            MessageFieldsIndex.OrientationW = 59;
            MessageFieldsIndex.LinearAccX = 61;
            MessageFieldsIndex.LinearAccY = 63;
            MessageFieldsIndex.LinearAccZ = 65;
            MessageFieldsIndex.GravX = 67;
            MessageFieldsIndex.GravY = 69;
            MessageFieldsIndex.GravZ = 71;
        }

        public static void InitMessageFieldSizeInitializer(out InitializtionMessage MessageFieldsSize)
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
            MessageFieldsSize.SWVersionID = 2;
            MessageFieldsSize.HWVersionID = 2;
            MessageFieldsSize.ArmHeight = 2;
            MessageFieldsSize.DisarmHeight = 2;
            MessageFieldsSize.VibrationsValue = 1;
            MessageFieldsSize.NoVibrationTime = 2;
            MessageFieldsSize.VibrationFrequency = 2;
            MessageFieldsSize.RollCalibration = 1;
            MessageFieldsSize.PitchCalibration = 1;
            MessageFieldsSize.RollInitMargin = 1;
            MessageFieldsSize.PitchInitMargin = 1;
            MessageFieldsSize.IMUConfiguration = 1;
            MessageFieldsSize.RCConfiguration = 1;
            MessageFieldsSize.BatteryCells = 1;
            MessageFieldsSize.MotorDelay = 2;
            MessageFieldsSize.RollAttitudeLimit = 1;
            MessageFieldsSize.PitchAttitudeLimit = 1;
            MessageFieldsSize.FreefallDuration = 2;
            MessageFieldsSize.FreefallLimit = 2;
            MessageFieldsSize.AngularSpeedRateLimit = 2;
            MessageFieldsSize.AngularSpeedLimit = 1;
            MessageFieldsSize.YawRateLimit = 2;
            MessageFieldsSize.ActiveHeightSource = 1;
            MessageFieldsSize.MaximumHeight = 2;
            MessageFieldsSize.LandingGear = 1;
            MessageFieldsSize.ArmMode = 1;
            MessageFieldsSize.PyroSensorCalib = 1;
            MessageFieldsSize.PyroSensorMeasurement = 1;
            MessageFieldsSize.PyroTestRate = 2;
            MessageFieldsSize.EmergencyBattery = 1;
            MessageFieldsSize.Destination = 2;
            MessageFieldsSize.SDCard = 1;
            MessageFieldsSize.TriggeringMode = 1;
            MessageFieldsSize.FiveVoltIndication = 1;
            MessageFieldsSize.EmergencyBatteryVoltageIndication = 1;
            MessageFieldsSize.TwelveVoltageIndication = 1;
            MessageFieldsSize.CapacitorVoltageIndication = 1;
            //return MessageFieldsSize;
        }
        public static void InitMessageFieldIndexInitializer(out InitializtionMessage MessageFieldsIndex)
        {
            MessageFieldsIndex.OpCode                   = 0;
            MessageFieldsIndex.MessageCounter           = 1;
            MessageFieldsIndex.IDPart1                  = 3;
            MessageFieldsIndex.IDPart2                  = 7;
            MessageFieldsIndex.IDPart3                  = 11;
            MessageFieldsIndex.TimeSource               = 15;
            MessageFieldsIndex.GPSYear                  = 16;
            MessageFieldsIndex.GPSMonth                 = 18;
            MessageFieldsIndex.GPSDay                   = 19;
            MessageFieldsIndex.GPSHour                  = 20;
            MessageFieldsIndex.GPSMinute                = 21;
            MessageFieldsIndex.GPSSecond                = 22;
            MessageFieldsIndex.GPSMiliSec               = 23;
            MessageFieldsIndex.SWVersionID              = 25;
            MessageFieldsIndex.HWVersionID              = 27;
            MessageFieldsIndex.ArmHeight                = 29;
            MessageFieldsIndex.DisarmHeight             = 31;
            MessageFieldsIndex.VibrationsValue          = 32;
            MessageFieldsIndex.NoVibrationTime          = 34;
            MessageFieldsIndex.VibrationFrequency       = 36;
            MessageFieldsIndex.RollCalibration          = 37;
            MessageFieldsIndex.PitchCalibration         = 38;
            MessageFieldsIndex.RollInitMargin           = 39;
            MessageFieldsIndex.PitchInitMargin          = 40;
            MessageFieldsIndex.IMUConfiguration         = 41;
            MessageFieldsIndex.RCConfiguration          = 42;
            MessageFieldsIndex.BatteryCells             = 43;
            MessageFieldsIndex.MotorDelay               = 45;
            MessageFieldsIndex.RollAttitudeLimit        = 46;
            MessageFieldsIndex.PitchAttitudeLimit       = 47;
            MessageFieldsIndex.FreefallDuration         = 49;
            MessageFieldsIndex.FreefallLimit            = 51;
            MessageFieldsIndex.AngularSpeedRateLimit    = 53;
            MessageFieldsIndex.AngularSpeedLimit        = 54;
            MessageFieldsIndex.YawRateLimit             = 56;
            MessageFieldsIndex.ActiveHeightSource       = 57;
            MessageFieldsIndex.MaximumHeight            = 59;
            MessageFieldsIndex.LandingGear              = 60;
            MessageFieldsIndex.ArmMode                  = 61;
            MessageFieldsIndex.PyroSensorCalib          = 62;
            MessageFieldsIndex.PyroSensorMeasurement    = 63;
            MessageFieldsIndex.PyroTestRate             = 65;
            MessageFieldsIndex.EmergencyBattery         = 66;
            MessageFieldsIndex.Destination              = 68;
            MessageFieldsIndex.SDCard                   = 69;
            MessageFieldsIndex.TriggeringMode           = 70;
            MessageFieldsIndex.FiveVoltIndication       = 71;
            MessageFieldsIndex.EmergencyBatteryVoltageIndication = 72;
            MessageFieldsIndex.TwelveVoltageIndication  = 73;
            MessageFieldsIndex.CapacitorVoltageIndication = 74;
        }
    }
}                            
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
                             
