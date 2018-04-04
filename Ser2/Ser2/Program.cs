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
using uPLibrary.Networking.M2Mqtt;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Ser2
{
    class Program
    {
        const string fileName = "AppSettings.dat";

        /// <summary>
        /// AWS IoT endpoint - replace with your own
        /// </summary>
        private const string IotEndpoint = "a28g8imipibhcw.iot.us-east-1.amazonaws.com";
        /// <summary>
        /// TLS1.2 port used by AWS IoT
        /// </summary>
        private const int BrokerPort = 8883;
        /// <summary>
        /// this must match - partially - what the subscribed is subscribed too
        /// nicksthings = the THING i created in AWS IoT
        /// t1/t555 is just an arbitary topic that i'm publishing to. (It needs 2 parts for the rule I'm using to work)
        /// </summary>
        private const string Topic = "DeviceStatus";
        //

        static void Main(string[] args)
        {
            var publisher = new Program();
            publisher.Publish();

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

            List<Byte> termsList = new List<Byte>();
            termsList = EncodeValuesAsBytesInList(4, 400, termsList);

            Message += EncodeValuesAsBytes(1, (uint)2) + ",";
            Message += EncodeValuesAsBytes(2, (uint)0)+ ",";
            Message += EncodeValuesAsBytes(4, 300)+ ",";
            Message += EncodeValuesAsBytes(4, 400)+ ",";
            Message += EncodeValuesAsBytes(4, 500)+ ",";
            Message += EncodeValuesAsBytes(1, (uint)2)+ ",";//Accurate
            Message += EncodeValuesAsBytes(2, (uint)0)+ ",";//Year
            Message += EncodeValuesAsBytes(1, (uint)0)+ ",";//Month
            Message += EncodeValuesAsBytes(1, (uint)0)+ ",";//Day
            Message += EncodeValuesAsBytes(1, (uint)0)+ ",";//Hour
            Message += EncodeValuesAsBytes(1, (uint)0)+ ",";//Min
            Message += EncodeValuesAsBytes(1, (uint)0)+ ",";//Sec
            Message += EncodeValuesAsBytes(2, (uint)0)+ ",";//Mili
            Message += EncodeValuesAsBytes(1, (uint)6)+ ",";//Mode
            Message += EncodeValuesAsBytes(1, (uint)1)+ ",";//Ready To Arm
            Message += EncodeValuesAsBytes(2, (uint)10)+ ",";//Battery LSB=0.1
            Message += EncodeValuesAsBytes(1, (uint)1)+ ",";//IMU
            Message += EncodeValuesAsBytes(1, (uint)3)+ ",";//Flash
            Message += EncodeValuesAsBytes(1, (uint)1);//RC
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,0  ,0    ,0    ,0   ,0  ,0   ,0  ,0  ,0    ,0    ,0   ,0  ,255 ,0   ,1  ,1  ,3 
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,Acc,YearL,YearH,Mnth,Day,Hour,Min,Sec,MiliL,MiliH,Mode,RTA,BCSL,BCSH,IMU,FSD,RC
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,1  ,0    ,0    ,0   ,0  ,0   ,0  ,0  ,0    ,0    ,6   ,1  ,10  ,0   ,1  ,3  ,1
            Byte[] terms = termsList.ToArray();

            StatusMessage NewMessage = new StatusMessage();
            NewMessage.OpCode = OpCode;
            NewMessage.MessageCounter = MessageCounter;
            NewMessage.IDPart1 = IDPart1;
            NewMessage.IDPart2 = IDPart2;
            NewMessage.IDPart3 = IDPart3;
            NewMessage.TimeSource = TimeSource;
            NewMessage.GPSYear = 2018;
            NewMessage.GPSMonth = 4;
            NewMessage.GPSDay = 4;
            NewMessage.GPSHour = 14;
            NewMessage.GPSMinute = 5;
            NewMessage.GPSSecond = 0;
            NewMessage.GPSMiliSec = 0;
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

        public static string EncodeValuesAsString(int size, uint value)
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

        public static string EncodeValuesAsBytes(int size, uint value)
        {
            byte byte1 = 0;
            byte byte2 = 0;
            byte byte3 = 0;
            byte byte4 = 0;
            string TmpStr = "";
            if (size == 1)
            {
                byte1 = (byte)(value & 0xFF);

                TmpStr = byte1.ToString();
            }
            if (size == 2)
            {
                byte1 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte2 = (byte)(value & 0xFF);
                TmpStr = byte1.ToString() + ","+ byte2.ToString();
            }
            if (size == 4)
            {
                byte1 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte2 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte3 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte4 = (byte)(value & 0xFF);
                TmpStr = byte1.ToString() + "," + byte2.ToString() + ","
                              + byte3.ToString() + "," + byte4.ToString();
            }
            return TmpStr;
        }

        public static List<Byte> EncodeValuesAsBytesInList(int size, uint value, List<Byte> TempList)
        {
            byte byte1 = 0;
            byte byte2 = 0;
            byte byte3 = 0;
            byte byte4 = 0;
            //string TmpStr = "";
            if (size == 1)
            {
                byte1 = (byte)(value & 0xFF);

                TempList.Add(byte1);
            }
            if (size == 2)
            {
                byte1 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte2 = (byte)(value & 0xFF);
                TempList.Add(byte1);
                TempList.Add(byte2);
            }
            if (size == 4)
            {
                byte1 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte2 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte3 = (byte)(value & 0xFF);
                value = (uint)(value >> 8);
                byte4 = (byte)(value & 0xFF);
                TempList.Add(byte1);
                TempList.Add(byte2);
                TempList.Add(byte3);
                TempList.Add(byte4);
            }
            return TempList;
        }

        public void Publish()
        {
            //convert to pfx using openssl - see confluence
            //you'll need to add these two files to the project and copy them to the output (not included in source control deliberately!)
            var clientCert = new X509Certificate2("YOURPFXFILE.pfx", "1");
            var caCert = X509Certificate.CreateFromSignedFile("rootCA.pem");
            // create the client
            var client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
            //message to publish - could be anything
            var message = "02c92447002000175135323536363302e20704030e180948000602a100020000";
            //client naming has to be unique if there was more than one publisher
            client.Connect("clientid1");
            //publish to the topic
            Byte[] A = {2,0,0,44,1,0,0,144,1,0,0,244,1,0,0,2,0,0,0,0,0,0,0,0,0,6,1,200,0,1,3,1} ;
            client.Publish(Topic, A);
            //this was in for debug purposes but it's useful to see something in the console
            if (client.IsConnected)
            {
                Console.WriteLine("SUCCESS!");
            }
            //wait so that we can see the outcome
            //Console.ReadLine();
        }
    }
}