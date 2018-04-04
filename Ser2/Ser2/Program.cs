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
using Ser2.Parser;

namespace Ser2
{
    class Program
    {
        const string fileName = "AppSettings.dat";
        static void Main(string[] args)
        {
            string Message = "";

            Console.WriteLine("Hello World!");

            StatusMessage StatusMessageFieldsSize = new StatusMessage();
            MessageInitializers.StatusMessageFieldSizeInitializer(out StatusMessageFieldsSize);

            StatusMessage StatusMessageFieldsIndex = new StatusMessage();
            MessageInitializers.StatusMessageFieldIndexInitializer(out StatusMessageFieldsIndex);
            //
            WriteDefaultValues(fileName);

            SByte OpCode = ManualSerializer.ReturnSByteValue(0, 1);
            Int16 MessageCounter = ManualSerializer.ReturnInt16Value(1, 2, false);
            UInt32 IDPart1 = ManualSerializer.ReturnUint32Value(3, 4, false);
            UInt32 IDPart2 = ManualSerializer.ReturnUint32Value(7, 4, false);
            UInt32 IDPart3 = ManualSerializer.ReturnUint32Value(11, 4, false);
            SByte TimeSource = ManualSerializer.ReturnSByteValue(15, 1);
            Int16 GPSYear = ManualSerializer.ReturnInt16Value(16, 2,false);
            SByte GPSMonth = ManualSerializer.ReturnSByteValue(18, 1);
            SByte GPSDay = ManualSerializer.ReturnSByteValue(19, 1);
            SByte GPSHour = ManualSerializer.ReturnSByteValue(20, 1);
            SByte GPSMinute = ManualSerializer.ReturnSByteValue(21, 1);
            SByte GPSSecond = ManualSerializer.ReturnSByteValue(22, 1);
            Int16 GPSMiliSecond = ManualSerializer.ReturnInt16Value(23, 2, false);
            SByte Mode = ManualSerializer.ReturnSByteValue(25, 1);
            SByte RTA = ManualSerializer.ReturnSByteValue(26, 1);
            Int16 BCS = ManualSerializer.ReturnInt16Value(27, 2, false);
            SByte IMUStatus = ManualSerializer.ReturnSByteValue(29, 1);
            SByte FDS = ManualSerializer.ReturnSByteValue(30, 1);
            SByte RCChannels = ManualSerializer.ReturnSByteValue(31, 1);

            StatusMessage ParsedStatusMessage = new StatusMessage();
            MessageParser.StatusMessageParser(out ParsedStatusMessage, StatusMessageFieldsIndex, StatusMessageFieldsSize);

            /*
            Message += EncodeValues(1, (uint)OpCode);
            Message += EncodeValues(2, (uint)MessageCounter);
            Message += EncodeValues(4, IDPart1);
            Message += EncodeValues(4, IDPart2);
            Message += EncodeValues(4, IDPart3);
            Message += EncodeValues(1, (uint)TimeSource);
            Message += EncodeValues(2, (uint)GPSYear);
            Message += EncodeValues(1, (uint)GPSMonth);
            Message += EncodeValues(1, (uint)GPSDay);
            Message += EncodeValues(1, (uint)GPSHour);
            Message += EncodeValues(1, (uint)GPSMinute);
            Message += EncodeValues(1, (uint)GPSSecond);
            Message += EncodeValues(2, (uint)GPSMiliSecond);
            Message += EncodeValues(1, (uint)Mode);
            Message += EncodeValues(1, (uint)RTA);
            Message += EncodeValues(2, (uint)BCS);
            Message += EncodeValues(1, (uint)IMUStatus);
            Message += EncodeValues(1, (uint)FDS);
            Message += EncodeValues(1, (uint)RCChannels);*/

            StatusMessage NewMessage = new StatusMessage();
            NewMessage.OpCode = OpCode;
            NewMessage.MessageCounter = MessageCounter;
            NewMessage.IDPart1 = IDPart1;
            NewMessage.IDPart2 = IDPart2;
            NewMessage.IDPart3 = IDPart3;
            NewMessage.TimeSource = TimeSource;
            NewMessage.GPSYear = GPSYear;
            NewMessage.GPSMonth = GPSMonth;
            NewMessage.GPSDay = GPSDay;
            NewMessage.GPSHour = GPSHour;
            NewMessage.GPSMinute = GPSMinute;
            NewMessage.GPSSecond = GPSSecond;
            NewMessage.GPSMiliSec = GPSMiliSecond;
            NewMessage.Mode = Mode;
            NewMessage.RTA = RTA;
            NewMessage.BCS = BCS;
            NewMessage.IMUStatus = IMUStatus;
            NewMessage.FDS = FDS;
            NewMessage.RCChannels = RCChannels;

            string Message2 = Encoders.MessageEncoder.StatusMessageEncoder(NewMessage, StatusMessageFieldsSize);
        }
        public static void WriteDefaultValues(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                // convert string to stream
                byte[] byteArray = Encoding.UTF8.GetBytes("02c92447002000175135323536363302e20704030e180948000602a100020000");
                MemoryStream stream = new MemoryStream(byteArray);
                writer.Write(byteArray);
            }
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