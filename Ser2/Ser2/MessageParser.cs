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

namespace Ser2.Parser
{
    public class MessageParser
    {
        /*Read values from (const) file, than parse them to and return as message accordingto truct
        */
        public static void StatusMessageParser(out StatusMessage messageToParse, StatusMessage statusMessageIndex, StatusMessage statusMessageSize)
        {
            messageToParse.OpCode = ManualSerializer.ReturnSByteValue(statusMessageIndex.OpCode,
                                                                      statusMessageSize.OpCode);
            messageToParse.MessageCounter = ManualSerializer.ReturnInt16Value(statusMessageIndex.MessageCounter,
                                                                              statusMessageSize.MessageCounter, false);
            messageToParse.IDPart1 = ManualSerializer.ReturnUint32Value((int)statusMessageIndex.IDPart1,
                                                                        (int)statusMessageSize.IDPart1, false);
            messageToParse.IDPart2 = ManualSerializer.ReturnUint32Value((int)statusMessageIndex.IDPart2,
                                                                        (int)statusMessageSize.IDPart2, false);
            messageToParse.IDPart3 = ManualSerializer.ReturnUint32Value((int)statusMessageIndex.IDPart3,
                                                                        (int)statusMessageSize.IDPart3, false);
            messageToParse.TimeSource = ManualSerializer.ReturnSByteValue(statusMessageIndex.TimeSource,
                                                                          statusMessageSize.TimeSource);
            messageToParse.GPSYear = ManualSerializer.ReturnInt16Value(statusMessageIndex.GPSYear,
                                                                       statusMessageSize.GPSYear, false);
            messageToParse.GPSMonth = ManualSerializer.ReturnSByteValue(statusMessageIndex.GPSMonth,
                                                                        statusMessageSize.GPSMonth);
            messageToParse.GPSDay = ManualSerializer.ReturnSByteValue(statusMessageIndex.GPSDay,
                                                                      statusMessageSize.GPSDay);
            messageToParse.GPSHour = ManualSerializer.ReturnSByteValue(statusMessageIndex.GPSHour,
                                                                       statusMessageSize.GPSHour);
            messageToParse.GPSMinute = ManualSerializer.ReturnSByteValue(statusMessageIndex.GPSMinute,
                                                                         statusMessageSize.GPSMinute);
            messageToParse.GPSSecond = ManualSerializer.ReturnSByteValue(statusMessageIndex.GPSSecond,
                                                                         statusMessageSize.GPSSecond);
            messageToParse.GPSMiliSec = ManualSerializer.ReturnInt16Value(statusMessageIndex.GPSMiliSec,
                                                                          statusMessageSize.GPSMiliSec, false);
            messageToParse.Mode = ManualSerializer.ReturnSByteValue(statusMessageIndex.Mode,
                                                                    statusMessageSize.Mode);
            messageToParse.RTA = ManualSerializer.ReturnSByteValue(statusMessageIndex.RTA,
                                                                   statusMessageSize.RTA);
            messageToParse.BCS = ManualSerializer.ReturnInt16Value(statusMessageIndex.BCS,
                                                                   statusMessageSize.BCS, false);
            messageToParse.IMUStatus = ManualSerializer.ReturnSByteValue(statusMessageIndex.IMUStatus,
                                                                         statusMessageSize.IMUStatus);
            messageToParse.FDS = ManualSerializer.ReturnSByteValue(statusMessageIndex.FDS,
                                                                   statusMessageSize.FDS);
            messageToParse.RCChannels = ManualSerializer.ReturnSByteValue(statusMessageIndex.RCChannels,
                                                                          statusMessageSize.RCChannels);
        }

        public static void StatusMessageParserFromByteArray(out StatusMessage messageToParse, StatusMessage statusMessageIndex, StatusMessage statusMessageSize, Byte[] arraytoParse)
        {
            messageToParse.OpCode = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.OpCode,
                                                                                    statusMessageSize.OpCode, arraytoParse);
            messageToParse.MessageCounter = ManualSerializer.ReturnInt16ValueFromByteArray(statusMessageIndex.MessageCounter,
                                                                              statusMessageSize.MessageCounter, false, arraytoParse);
            messageToParse.IDPart1 = ManualSerializer.ReturnUint32ValueFromByteArray((int)statusMessageIndex.IDPart1,
                                                                        (int)statusMessageSize.IDPart1, false, arraytoParse);
            messageToParse.IDPart2 = ManualSerializer.ReturnUint32ValueFromByteArray((int)statusMessageIndex.IDPart2,
                                                                        (int)statusMessageSize.IDPart2, false, arraytoParse);
            messageToParse.IDPart3 = ManualSerializer.ReturnUint32ValueFromByteArray((int)statusMessageIndex.IDPart3,
                                                                        (int)statusMessageSize.IDPart3, false, arraytoParse);
            messageToParse.TimeSource = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.TimeSource,
                                                                          statusMessageSize.TimeSource, arraytoParse);
            messageToParse.GPSYear = ManualSerializer.ReturnInt16ValueFromByteArray(statusMessageIndex.GPSYear,
                                                                       statusMessageSize.GPSYear, false, arraytoParse);
            messageToParse.GPSMonth = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.GPSMonth,
                                                                        statusMessageSize.GPSMonth, arraytoParse);
            messageToParse.GPSDay = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.GPSDay,
                                                                      statusMessageSize.GPSDay, arraytoParse);
            messageToParse.GPSHour = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.GPSHour,
                                                                       statusMessageSize.GPSHour, arraytoParse);
            messageToParse.GPSMinute = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.GPSMinute,
                                                                         statusMessageSize.GPSMinute, arraytoParse);
            messageToParse.GPSSecond = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.GPSSecond,
                                                                         statusMessageSize.GPSSecond, arraytoParse);
            messageToParse.GPSMiliSec = ManualSerializer.ReturnInt16ValueFromByteArray(statusMessageIndex.GPSMiliSec,
                                                                          statusMessageSize.GPSMiliSec, false, arraytoParse);
            messageToParse.Mode = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.Mode,
                                                                    statusMessageSize.Mode, arraytoParse);
            messageToParse.RTA = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.RTA,
                                                                   statusMessageSize.RTA, arraytoParse);
            messageToParse.BCS = ManualSerializer.ReturnInt16ValueFromByteArray(statusMessageIndex.BCS,
                                                                   statusMessageSize.BCS, false, arraytoParse);
            messageToParse.IMUStatus = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.IMUStatus,
                                                                         statusMessageSize.IMUStatus, arraytoParse);
            messageToParse.FDS = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.FDS,
                                                                   statusMessageSize.FDS, arraytoParse);
            messageToParse.RCChannels = ManualSerializer.ReturnSByteValueFromByteArray(statusMessageIndex.RCChannels,
                                                                          statusMessageSize.RCChannels, arraytoParse);
        }

        public static void KinematicMessageParserFromByteArray(out KinematicMessage messageToParse, KinematicMessage MessageIndex, KinematicMessage MessageSize, Byte[] arraytoParse)
        {
            messageToParse.OpCode = ManualSerializer.ReturnSByteValueFromByteArray(MessageIndex.OpCode, MessageSize.OpCode, arraytoParse);
            messageToParse.MessageCounter = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.MessageCounter, MessageSize.MessageCounter, false, arraytoParse);
            messageToParse.IDPart1 = ManualSerializer.ReturnUint32ValueFromByteArray((int)MessageIndex.IDPart1, (int)MessageSize.IDPart1, false, arraytoParse);
            messageToParse.IDPart2 = ManualSerializer.ReturnUint32ValueFromByteArray((int)MessageIndex.IDPart2, (int)MessageSize.IDPart2, false, arraytoParse);
            messageToParse.IDPart3 = ManualSerializer.ReturnUint32ValueFromByteArray((int)MessageIndex.IDPart3, (int)MessageSize.IDPart3, false, arraytoParse);
            messageToParse.TimeSource = ManualSerializer.ReturnSByteValueFromByteArray(MessageIndex.TimeSource, MessageSize.TimeSource, arraytoParse);
            messageToParse.GPSYear = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GPSYear, MessageSize.GPSYear, false, arraytoParse);
            messageToParse.GPSMonth = ManualSerializer.ReturnSByteValueFromByteArray(MessageIndex.GPSMonth, MessageSize.GPSMonth, arraytoParse);
            messageToParse.GPSDay = ManualSerializer.ReturnSByteValueFromByteArray(MessageIndex.GPSDay, MessageSize.GPSDay, arraytoParse);
            messageToParse.GPSHour = ManualSerializer.ReturnSByteValueFromByteArray(MessageIndex.GPSHour, MessageSize.GPSHour, arraytoParse);
            messageToParse.GPSMinute = ManualSerializer.ReturnSByteValueFromByteArray(MessageIndex.GPSMinute, MessageSize.GPSMinute, arraytoParse);
            messageToParse.GPSSecond = ManualSerializer.ReturnSByteValueFromByteArray(MessageIndex.GPSSecond, MessageSize.GPSSecond, arraytoParse);
            messageToParse.GPSMiliSec = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GPSMiliSec, MessageSize.GPSMiliSec, false, arraytoParse);
            messageToParse.BaroHeight = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.BaroHeight, MessageSize.BaroHeight, false, arraytoParse);
            messageToParse.Pressure = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.Pressure, MessageSize.Pressure, false, arraytoParse);
            messageToParse.AccX = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.AccX, MessageSize.AccX, false, arraytoParse);
            messageToParse.AccY = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.AccY, MessageSize.AccY, false, arraytoParse);
            messageToParse.AccZ = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.AccZ, MessageSize.AccZ, false, arraytoParse);
            messageToParse.MagX = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.MagX, MessageSize.MagX, false, arraytoParse);
            messageToParse.MagY = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.MagY, MessageSize.MagY, false, arraytoParse);
            messageToParse.MagZ = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.MagZ, MessageSize.MagZ, false, arraytoParse);
            messageToParse.GyroX = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GyroX, MessageSize.GyroX, false, arraytoParse);
            messageToParse.GyroY = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GyroY, MessageSize.GyroY, false, arraytoParse);
            messageToParse.GyroZ = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GyroZ, MessageSize.GyroZ, false, arraytoParse);
            messageToParse.Heading = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.Heading, MessageSize.Heading, false, arraytoParse);
            messageToParse.Roll = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.Roll, MessageSize.Roll, false, arraytoParse);
            messageToParse.Pitch = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.Pitch, MessageSize.Pitch, false, arraytoParse);
            messageToParse.OrientationX = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.OrientationX, MessageSize.OrientationX, false, arraytoParse);
            messageToParse.OrientationY = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.OrientationY, MessageSize.OrientationY, false, arraytoParse);
            messageToParse.OrientationZ = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.OrientationZ, MessageSize.OrientationZ, false, arraytoParse);
            messageToParse.OrientationW = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.OrientationW, MessageSize.OrientationW, false, arraytoParse);
            messageToParse.LinearAccX = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.LinearAccX, MessageSize.LinearAccX, false, arraytoParse);
            messageToParse.LinearAccY = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.LinearAccY, MessageSize.LinearAccY, false, arraytoParse);
            messageToParse.LinearAccZ = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.LinearAccZ, MessageSize.LinearAccZ, false, arraytoParse);
            messageToParse.GravX = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GravX, MessageSize.GravX, false, arraytoParse);
            messageToParse.GravY = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GravY, MessageSize.GravY, false, arraytoParse);
            messageToParse.GravZ = ManualSerializer.ReturnInt16ValueFromByteArray(MessageIndex.GravZ, MessageSize.GravZ, false, arraytoParse);
        }
    }
}
