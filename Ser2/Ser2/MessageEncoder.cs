using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using Ser2.Serializer;
using Ser2.MessagesStructs;
using Ser2.Initializers;

namespace Ser2.Encoders
{
    public class MessageEncoder
    {
        public MessageEncoder()
        {
        }

        public static string StatusMessageEncoder(StatusMessage MessageFields, StatusMessage MessageFieldsIndex)
        {
            string Message = "";

            Message += EncodeValues(MessageFieldsIndex.OpCode,          (uint)MessageFields.OpCode);
            Message += EncodeValues(MessageFieldsIndex.MessageCounter,  (uint)MessageFields.MessageCounter);
            Message += EncodeValues((int)MessageFieldsIndex.IDPart1,    MessageFields.IDPart1);
            Message += EncodeValues((int)MessageFieldsIndex.IDPart2,    MessageFields.IDPart2);
            Message += EncodeValues((int)MessageFieldsIndex.IDPart3,    MessageFields.IDPart3);
            Message += EncodeValues(MessageFieldsIndex.TimeSource,      (uint)MessageFields.TimeSource);
            Message += EncodeValues(MessageFieldsIndex.GPSYear,         (uint)MessageFields.GPSYear);
            Message += EncodeValues(MessageFieldsIndex.GPSMonth,        (uint)MessageFields.GPSMonth);
            Message += EncodeValues(MessageFieldsIndex.GPSDay,          (uint)MessageFields.GPSDay);
            Message += EncodeValues(MessageFieldsIndex.GPSHour,         (uint)MessageFields.GPSHour);
            Message += EncodeValues(MessageFieldsIndex.GPSMinute,       (uint)MessageFields.GPSMinute);
            Message += EncodeValues(MessageFieldsIndex.GPSSecond,       (uint)MessageFields.GPSSecond);
            Message += EncodeValues(MessageFieldsIndex.GPSMiliSec,      (uint)MessageFields.GPSMiliSec);
            Message += EncodeValues(MessageFieldsIndex.Mode,            (uint)MessageFields.Mode);
            Message += EncodeValues(MessageFieldsIndex.RTA,             (uint)MessageFields.RTA);
            Message += EncodeValues(MessageFieldsIndex.BCS,             (uint)MessageFields.BCS);
            Message += EncodeValues(MessageFieldsIndex.IMUStatus,       (uint)MessageFields.IMUStatus);
            Message += EncodeValues(MessageFieldsIndex.FDS,             (uint)MessageFields.FDS);
            Message += EncodeValues(MessageFieldsIndex.RCChannels,      (uint)MessageFields.RCChannels);
            return Message;
        }

        public static string PhysicalMessageEncoder(PhysicalMessage MessageFields, PhysicalMessage MessageFieldsIndex)
        {
            string Message = "";

            Message += EncodeValues(MessageFieldsIndex.OpCode, (uint)MessageFields.OpCode);
            Message += EncodeValues(MessageFieldsIndex.MessageCounter, (uint)MessageFields.MessageCounter);
            Message += EncodeValues((int)MessageFieldsIndex.IDPart1, MessageFields.IDPart1);
            Message += EncodeValues((int)MessageFieldsIndex.IDPart2, MessageFields.IDPart2);
            Message += EncodeValues((int)MessageFieldsIndex.IDPart3, MessageFields.IDPart3);
            Message += EncodeValues(MessageFieldsIndex.TimeSource, (uint)MessageFields.TimeSource);
            Message += EncodeValues(MessageFieldsIndex.GPSYear, (uint)MessageFields.GPSYear);
            Message += EncodeValues(MessageFieldsIndex.GPSMonth, (uint)MessageFields.GPSMonth);
            Message += EncodeValues(MessageFieldsIndex.GPSDay, (uint)MessageFields.GPSDay);
            Message += EncodeValues(MessageFieldsIndex.GPSHour, (uint)MessageFields.GPSHour);
            Message += EncodeValues(MessageFieldsIndex.GPSMinute, (uint)MessageFields.GPSMinute);
            Message += EncodeValues(MessageFieldsIndex.GPSSecond, (uint)MessageFields.GPSSecond);
            Message += EncodeValues(MessageFieldsIndex.GPSMiliSec, (uint)MessageFields.GPSMiliSec);
            Message += EncodeValues(MessageFieldsIndex.NumberOfSatellites, (uint)MessageFields.NumberOfSatellites);
            Message += EncodeValues(MessageFieldsIndex.Latitude, (uint)MessageFields.Latitude);
            Message += EncodeValues(MessageFieldsIndex.Longitude, (uint)MessageFields.Longitude);
            Message += EncodeValues(MessageFieldsIndex.GPSAltitude, (uint)MessageFields.GPSAltitude);
            Message += EncodeValues(MessageFieldsIndex.GPSVelocity, (uint)MessageFields.GPSVelocity);
            Message += EncodeValues(MessageFieldsIndex.GPSAngle, (uint)MessageFields.GPSAngle);
            Message += EncodeValues(MessageFieldsIndex.GPSGroundSpeed, (uint)MessageFields.GPSGroundSpeed);
            Message += EncodeValues(MessageFieldsIndex.Temperature, (uint)MessageFields.Temperature);
            Message += EncodeValues(MessageFieldsIndex.Humidity, (uint)MessageFields.Humidity);
            Message += EncodeValues(MessageFieldsIndex.UVAUVB, (uint)MessageFields.UVAUVB);

            return Message;
        }

        public static string EncodeValues(int size, uint value)
        {
            byte byte1 = 0;
            byte byte2 = 0;
            byte byte3 = 0;
            byte byte4 = 0;
            byte byte5 = 0;
            byte byte6 = 0;
            byte byte7 = 0;
            byte byte8 = 0;
            string TmpStr = "";
            if (size == 1)
            {
                byte1 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte2 = (byte)(value & 0x0F);
                TmpStr = byte2.ToString("X") + byte1.ToString("X");
            }
            if (size == 2)
            {
                byte1 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte2 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte3 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte4 = (byte)(value & 0x0F);
                TmpStr = byte2.ToString("X") + byte1.ToString("X") + byte4.ToString("X") + byte3.ToString("X");
            }
            if (size == 4)
            {
                byte1 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte2 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte3 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte4 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte5 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte6 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte7 = (byte)(value & 0x0F);
                value = (uint)(value >> 4);
                byte8 = (byte)(value & 0x0F);
                TmpStr = byte2.ToString("X") + byte1.ToString("X")
                              + byte4.ToString("X") + byte3.ToString("X")
                              + byte6.ToString("X") + byte5.ToString("X")
                              + byte8.ToString("X") + byte7.ToString("X");
            }
            return TmpStr;
        }
    }
}
