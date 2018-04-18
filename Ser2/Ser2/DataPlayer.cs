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
using System.Threading;
using System.Diagnostics;

namespace Ser2.Player
{
    public class DataPlayer
    {
        const string DeviceStatusTopic = "DeviceStatus";
        const string PhysicalDataTopic = "PhysicalData";
        const string KinematicDataTopic = "KinematicData";
        const string InitializationDataTopic = "InitData";
       

        public DataPlayer()
        {
        }

        static public void player(string fileToPlay, MqttClient client)
        {
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan startTime = new TimeSpan();
            TimeSpan currentTime = new TimeSpan();

            //StreamReader reader = new StreamReader(@"/Users/nadavguy/Downloads/subscription.csv");
            StreamReader reader = new StreamReader(fileToPlay);

            StatusMessage statusMessagetoParse = new StatusMessage();

            KinematicMessage kinematicMessagetoParse = new KinematicMessage();

            StatusMessage StatusMessageFieldsSize = new StatusMessage();
            MessageInitializers.StatusMessageFieldSizeInitializer(out StatusMessageFieldsSize);

            StatusMessage StatusMessageFieldsIndex = new StatusMessage();
            MessageInitializers.StatusMessageFieldIndexInitializer(out StatusMessageFieldsIndex);

            //Kinematic message
            KinematicMessage KinematicMessageFieldsSize = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldSizeInitializer(out KinematicMessageFieldsSize);

            KinematicMessage KinematicMessageFieldsIndex = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldIndexInitializer(out KinematicMessageFieldsIndex);

            List<string> listHex = new List<string>();
            List<string> listPayload = new List<string>();
            List<string> listQoS = new List<string>();
            List<string> listTimestamp = new List<string>();
            List<string> listTopic = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listHex.Add(values[0]);
                listPayload.Add(values[1]);
                listQoS.Add(values[2]);
                listTimestamp.Add(values[3]);
                listTopic.Add(values[4]);
                /*Thread.Sleep(1);
                if (values[4].Equals("DeviceStatus"))
                {
                    byte[] statusbyteArray = Encoding.UTF8.GetBytes(values[1]);
                    MessageParser.StatusMessageParserFromByteArray(out statusMessagetoParse, StatusMessageFieldsIndex, StatusMessageFieldsSize, statusbyteArray);

                    List<Byte> termsList = new List<Byte>();

                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.OpCode, (uint)2, termsList);
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.MessageCounter, (uint)0, termsList);
                    termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart1, 600, termsList);
                    termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart2, 700, termsList);
                    termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart3, 800, termsList);
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.TimeSource, (uint)statusMessagetoParse.TimeSource, termsList);//Accurate
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSYear, (uint)0, termsList);//Year
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMonth, (uint)0, termsList);//Month
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSDay, (uint)0, termsList);//Day
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSHour, (uint)0, termsList);//Hour
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMinute, (uint)0, termsList);//Min
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSSecond, (uint)0, termsList);//Sec
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMiliSec, (uint)0, termsList);//Mili
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.Mode, (uint)statusMessagetoParse.Mode, termsList);//Mode
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RTA, (uint)statusMessagetoParse.RTA, termsList);//Ready To Arm
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.BCS, (uint)statusMessagetoParse.BCS, termsList);//Battery LSB=0.1
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.IMUStatus, (uint)statusMessagetoParse.IMUStatus, termsList);//IMU
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.FDS, (uint)statusMessagetoParse.FDS, termsList);//Flash
                    termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RCChannels, (uint)statusMessagetoParse.RCChannels, termsList);//RC
                    Byte[] terms = termsList.ToArray();
                    //client.Connect("clientid1");
                    //Publish message
                    //client.Publish(DeviceStatusTopic, terms, 0, false);
                }*/

            }
            double baseTimestamp = Convert.ToDouble(listTimestamp[0]);
            startTime = DateTime.Now.TimeOfDay;
            //stopWatch.Start();
            int i = 0; 
            while (i < listHex.Count)
            {
                currentTime = DateTime.Now.TimeOfDay;
                //stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                //ts = stopWatch.Elapsed;
                for (int j = i; j < listHex.Count; j++)
                {
                    if ((double)(currentTime - startTime).TotalMilliseconds > (Convert.ToDouble(listTimestamp[j]) - baseTimestamp))
                    {
                        i++;
                        if (listTopic[j].Equals(DeviceStatusTopic))
                        {
                            byte[] statusbyteArray = Encoding.UTF8.GetBytes(listPayload[j]);
                            MessageParser.StatusMessageParserFromByteArray(out statusMessagetoParse, StatusMessageFieldsIndex, StatusMessageFieldsSize, statusbyteArray);

                            List<Byte> termsList = new List<Byte>();

                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.OpCode, (uint)2, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.MessageCounter, (uint)0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart1, 600, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart2, 700, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart3, 800, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.TimeSource, (uint)statusMessagetoParse.TimeSource, termsList);//Accurate
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSYear, (uint)0, termsList);//Year
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMonth, (uint)0, termsList);//Month
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSDay, (uint)0, termsList);//Day
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSHour, (uint)0, termsList);//Hour
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMinute, (uint)0, termsList);//Min
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSSecond, (uint)0, termsList);//Sec
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMiliSec, (uint)0, termsList);//Mili
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.Mode, (uint)statusMessagetoParse.Mode, termsList);//Mode
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RTA, (uint)statusMessagetoParse.RTA, termsList);//Ready To Arm
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.BCS, (uint)statusMessagetoParse.BCS, termsList);//Battery LSB=0.1
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.IMUStatus, (uint)statusMessagetoParse.IMUStatus, termsList);//IMU
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.FDS, (uint)statusMessagetoParse.FDS, termsList);//Flash
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RCChannels, (uint)statusMessagetoParse.RCChannels, termsList);//RC
                            Byte[] terms = termsList.ToArray();
                            client.Publish(DeviceStatusTopic, terms, 0, false);
                        }
                        if (listTopic[j].Equals(KinematicDataTopic))
                        {
                            byte[] statusbyteArray = Encoding.UTF8.GetBytes(listPayload[j]);
                            MessageParser.KinematicMessageParserFromByteArray(out kinematicMessagetoParse, KinematicMessageFieldsIndex, KinematicMessageFieldsSize, statusbyteArray);

                            List<Byte> termsList = new List<Byte>();

                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.OpCode, (uint)4, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.MessageCounter, (uint)1, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart1, 600, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart2, 700, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart3, 800, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.TimeSource, (uint)statusMessagetoParse.TimeSource, termsList);//Accurate
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSYear, (uint)0, termsList);//Year
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMonth, (uint)0, termsList);//Month
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSDay, (uint)0, termsList);//Day
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSHour, (uint)0, termsList);//Hour
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMinute, (uint)0, termsList);//Min
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSSecond, (uint)0, termsList);//Sec
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMiliSec, (uint)0, termsList);//Mili
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.BaroHeight, (uint)kinematicMessagetoParse.BaroHeight, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Pressure, (uint)kinematicMessagetoParse.Pressure, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.AccX, 3500, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.AccY, 3000, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.AccZ, 3, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MagX, 5, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MagY, 15, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MagZ, 32, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GyroX, 3000, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GyroY, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GyroZ, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Heading, 10, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Roll, 20, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Pitch, 40, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationX, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationY, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationZ, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationW, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.LinearAccX, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.LinearAccY, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.LinearAccZ, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GravX, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GravY, 0, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GravZ, 0, termsList);
                            Byte[] terms = termsList.ToArray();
                            client.Publish(KinematicDataTopic, terms, 0, false);
                        }
                    }

                }
            }
        }
    }
}

