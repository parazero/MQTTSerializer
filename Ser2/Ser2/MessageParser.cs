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
    }
}
