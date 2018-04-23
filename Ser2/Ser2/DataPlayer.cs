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

        static public void playerFromIoTCapture(string fileToPlay, MqttClient client)
        {
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan startTime = new TimeSpan();
            TimeSpan currentTime = new TimeSpan();

            //StreamReader reader = new StreamReader(@"/Users/nadavguy/Downloads/subscription.csv");
            StreamReader reader = new StreamReader(fileToPlay);

            StatusMessage statusMessagetoParse = new StatusMessage();

            KinematicMessage kinematicMessagetoParse = new KinematicMessage();

            PhysicalMessage physicalMessagetoParse = new PhysicalMessage();

            StatusMessage StatusMessageFieldsSize = new StatusMessage();
            MessageInitializers.StatusMessageFieldSizeInitializer(out StatusMessageFieldsSize);

            StatusMessage StatusMessageFieldsIndex = new StatusMessage();
            MessageInitializers.StatusMessageFieldIndexInitializer(out StatusMessageFieldsIndex);

            //Kinematic message
            KinematicMessage KinematicMessageFieldsSize = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldSizeInitializer(out KinematicMessageFieldsSize);

            KinematicMessage KinematicMessageFieldsIndex = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldIndexInitializer(out KinematicMessageFieldsIndex);

            //Physical message
            PhysicalMessage PhysicalMessageFieldsSize = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldSizeInitializer(out PhysicalMessageFieldsSize);

            PhysicalMessage PhysicalMessageFieldsIndex = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldIndexInitializer(out PhysicalMessageFieldsIndex);

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
                // Using ID 600-700-800 for the data playerso it hard coded
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

                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.OpCode, (uint)statusMessagetoParse.OpCode, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.MessageCounter, (uint)statusMessagetoParse.MessageCounter, termsList);
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

                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OpCode, (uint)kinematicMessagetoParse.OpCode, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MessageCounter, (uint)kinematicMessagetoParse.MessageCounter, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart1, 600, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart2, 700, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart3, 800, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.TimeSource, (uint)statusMessagetoParse.TimeSource, termsList);//Accurate
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSYear, (uint)0, termsList);//Year
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMonth, (uint)0, termsList);//Month
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSDay, (uint)0, termsList);//Day
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSHour, (uint)0, termsList);//Hour
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMinute, (uint)0, termsList);//Min
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSSecond, (uint)0, termsList);//Sec
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMiliSec, (uint)0, termsList);//Mili
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.BaroHeight, (uint)kinematicMessagetoParse.BaroHeight, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Pressure, (uint)kinematicMessagetoParse.Pressure, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.AccX, (uint)kinematicMessagetoParse.AccX, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.AccY, (uint)kinematicMessagetoParse.AccY, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.AccZ, (uint)kinematicMessagetoParse.AccZ, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MagX, (uint)kinematicMessagetoParse.MagX, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MagY, (uint)kinematicMessagetoParse.MagY, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MagZ, (uint)kinematicMessagetoParse.MagZ, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GyroX, (uint)kinematicMessagetoParse.GyroX, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GyroY, (uint)kinematicMessagetoParse.GyroY, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GyroZ, (uint)kinematicMessagetoParse.GyroZ, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Heading, (uint)kinematicMessagetoParse.Heading, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Roll, (uint)kinematicMessagetoParse.Roll, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Pitch, (uint)kinematicMessagetoParse.Pitch, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationX, (uint)kinematicMessagetoParse.OrientationX, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationY, (uint)kinematicMessagetoParse.OrientationY, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationZ, (uint)kinematicMessagetoParse.OrientationZ, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OrientationW, (uint)kinematicMessagetoParse.OrientationW, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.LinearAccX, (uint)kinematicMessagetoParse.LinearAccX, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.LinearAccY, (uint)kinematicMessagetoParse.LinearAccY, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.LinearAccZ, (uint)kinematicMessagetoParse.LinearAccZ, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GravX, (uint)kinematicMessagetoParse.GravX, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GravY, (uint)kinematicMessagetoParse.GravY, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GravZ, (uint)kinematicMessagetoParse.GravZ, termsList);
                            Byte[] terms = termsList.ToArray();
                            client.Publish(KinematicDataTopic, terms, 0, false);
                        }

                        if (listTopic[j].Equals(PhysicalDataTopic))
                        {
                            byte[] statusbyteArray = Encoding.UTF8.GetBytes(listPayload[j]);
                            MessageParser.PhysicalMessageParserFromByteArray(out physicalMessagetoParse, PhysicalMessageFieldsIndex, PhysicalMessageFieldsSize, statusbyteArray);

                            List<Byte> termsList = new List<Byte>();

                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.OpCode, (uint)physicalMessagetoParse.OpCode, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.MessageCounter, (uint)physicalMessagetoParse.MessageCounter, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart1, 600, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart2, 700, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart3, 800, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.TimeSource, (uint)physicalMessagetoParse.TimeSource, termsList);//Accurate
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSYear, (uint)0, termsList);//Year
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMonth, (uint)0, termsList);//Month
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSDay, (uint)0, termsList);//Day
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSHour, (uint)0, termsList);//Hour
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMinute, (uint)0, termsList);//Min
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSSecond, (uint)0, termsList);//Sec
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMiliSec, (uint)0, termsList);//Mili
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.NumberOfSatellites, (uint)physicalMessagetoParse.NumberOfSatellites, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Latitude, (uint)physicalMessagetoParse.Latitude, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Longitude, (uint)physicalMessagetoParse.Longitude, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSAltitude, (uint)physicalMessagetoParse.GPSAltitude, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSVelocity, (uint)physicalMessagetoParse.GPSVelocity, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSAngle, (uint)physicalMessagetoParse.GPSAngle, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSGroundSpeed, (uint)physicalMessagetoParse.GPSGroundSpeed, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Temperature, (uint)physicalMessagetoParse.Temperature, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Humidity, (uint)physicalMessagetoParse.Humidity, termsList);
                            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.UVAUVB, (uint)physicalMessagetoParse.UVAUVB, termsList);
                            Byte[] terms = termsList.ToArray();
                            client.Publish(PhysicalDataTopic, terms, 0, false);
                        }
                    }

                }
            }
        }
    }
}

