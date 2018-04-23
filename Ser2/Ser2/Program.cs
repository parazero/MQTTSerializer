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
using Ser2.Player;

namespace Ser2
{
    class Program
    {
        const string fileName = "AppSettings.dat";


        static void Main(string[] args)
        {
            /*Some Hack to Make MQTT messaging Work, Otherwise next messages are not sent*/
            //Publ publisher = new Publ();
            //publisher.Publish();
            const string IotEndpoint = "a28g8imipibhcw.iot.us-east-1.amazonaws.com";
            const int BrokerPort = 8883;
            const string DeviceStatusTopic = "DeviceStatus";
            const string PhysicalDataTopic = "PhysicalData";
            const string KinematicDataTopic = "KinematicData";
            const string InitializationDataTopic = "InitData";
            X509Certificate2 clientCert = new X509Certificate2("YOURPFXFILE.pfx", "1");
            X509Certificate caCert = X509Certificate.CreateFromSignedFile("rootCA.pem");

            // create the client
            MqttClient client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);

            //message to publish - could be anything
            //client naming has to be unique if there was more than one publisher
            client.Connect("clientid1");

            //publish to the topic
            Byte[] A = { 2 };
            client.Publish("hello", A, 0, false);

            //string Message = "";
            Console.WriteLine("Hello World!");

            //For Future use when Export form DB will have millisecond
           /* StreamReader reader = new StreamReader(@"/Users/nadavguy/Downloads/physical-data-messages-2018-04-08.csv");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Convert.ToDateTime(values[6].Substring(0,19))
            }*/

            //Play old data capured from IoT (not DB export)
            //DataPlayer.playerFromIoTCapture(@"/Users/nadavguy/Downloads/subscription2.csv", client);

//Initialize messages
    //Status message
            StatusMessage StatusMessageFieldsSize = new StatusMessage();
            MessageInitializers.StatusMessageFieldSizeInitializer(out StatusMessageFieldsSize);

            StatusMessage StatusMessageFieldsIndex = new StatusMessage();
            MessageInitializers.StatusMessageFieldIndexInitializer(out StatusMessageFieldsIndex);

    //Physical message
            PhysicalMessage PhysicalMessageFieldsSize = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldSizeInitializer(out PhysicalMessageFieldsSize);

            PhysicalMessage PhysicalMessageFieldsIndex = new PhysicalMessage();
            MessageInitializers.PhysicalMessageFieldIndexInitializer(out PhysicalMessageFieldsIndex);

    //Kinematic message
            KinematicMessage KinematicMessageFieldsSize = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldSizeInitializer(out KinematicMessageFieldsSize);

            KinematicMessage KinematicMessageFieldsIndex = new KinematicMessage();
            MessageInitializers.KinematicMessageFieldIndexInitializer(out KinematicMessageFieldsIndex);

    //Initialization message
            InitializtionMessage InitMessageFieldsSize = new InitializtionMessage();
            MessageInitializers.InitMessageFieldSizeInitializer(out InitMessageFieldsSize);

            InitializtionMessage InitMessageFieldsIndex = new InitializtionMessage();
            MessageInitializers.InitMessageFieldIndexInitializer (out InitMessageFieldsIndex);
    //Start Application part 

            WriteDefaultValues(fileName);
            //Parse old string message form IoT Core export to actual vlaues
            //will be used later for testing I guess
            /*
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
            */

            /*
            StatusMessage ParsedStatusMessage = new StatusMessage();
            MessageParser.StatusMessageParser(out ParsedStatusMessage, StatusMessageFieldsIndex, StatusMessageFieldsSize);
            */
            /* Part of the try to create a Byte array manuall and sending it using external MQTT applicaiton
             * it did not work. apperantly MQTT does so weird stuff to the payload.
             * added MQTT library.
             * Code is obsolete
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)2) + ",";
            Message += ManualSerializer.EncodeValuesAsBytes(2, (uint)0) + ",";
            Message += ManualSerializer.EncodeValuesAsBytes(4, 300) + ",";
            Message += ManualSerializer.EncodeValuesAsBytes(4, 400) + ",";
            Message += ManualSerializer.EncodeValuesAsBytes(4, 500) + ",";
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)2) + ",";//Accurate
            Message += ManualSerializer.EncodeValuesAsBytes(2, (uint)0) + ",";//Year
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)0) + ",";//Month
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)0) + ",";//Day
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)0) + ",";//Hour
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)0) + ",";//Min
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)0) + ",";//Sec
            Message += ManualSerializer.EncodeValuesAsBytes(2, (uint)0) + ",";//Mili
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)6) + ",";//Mode
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)1) + ",";//Ready To Arm
            Message += ManualSerializer.EncodeValuesAsBytes(2, (uint)10) + ",";//Battery LSB=0.1
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)1) + ",";//IMU
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)3) + ",";//Flash
            Message += ManualSerializer.EncodeValuesAsBytes(1, (uint)1);//RC*/

            //Encode Byte Array using list.
            List<Byte> termsList = new List<Byte>();
            //termsList = EncodeValuesAsBytesInList(4, 400, termsList);

            //Generate Status message
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.OpCode, (uint)2,
                                                                   termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.MessageCounter,
                                                                   (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart1,
                                                                   600, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart2,
                                                                   700, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart3,
                                                                   800, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.TimeSource,
                                                                   (uint)2, termsList);//Accurate
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSYear,
                                                                   (uint)0, termsList);//Year
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMonth,
                                                                   (uint)0, termsList);//Month
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSDay,
                                                                   (uint)0, termsList);//Day
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSHour,
                                                                   (uint)0, termsList);//Hour
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMinute,
                                                                   (uint)0, termsList);//Min
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSSecond,
                                                                   (uint)0, termsList);//Sec
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMiliSec,
                                                                   (uint)0, termsList);//Mili
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.Mode,
                                                                   (uint)2, termsList);//Mode
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RTA,
                                                                   (uint)2, termsList);//Ready To Arm
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.BCS,
                                                                   (uint)160, termsList);//Battery LSB=0.1
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.IMUStatus,
                                                                   (uint)2, termsList);//IMU
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.FDS,
                                                                   (uint)3, termsList);//Flash
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RCChannels,
                                                                   (uint)0, termsList);//RC
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,0  ,0    ,0    ,0   ,0  ,0   ,0  ,0  ,0    ,0    ,0   ,0  ,255 ,0   ,1  ,1  ,3 
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,Acc,YearL,YearH,Mnth,Day,Hour,Min,Sec,MiliL,MiliH,Mode,RTA,BCSL,BCSH,IMU,FSD,RC
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,1  ,0    ,0    ,0   ,0  ,0   ,0  ,0  ,0    ,0    ,6   ,1  ,10  ,0   ,1  ,3  ,1
            //Convert list to Array
            Byte[] terms = termsList.ToArray();
            //client.Connect("clientid1");
            //Publish message
            client.Publish(DeviceStatusTopic, terms, 0, false);

            termsList.Clear();
            //Generate Physical data message
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.OpCode, 3, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.MessageCounter, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart1, 600, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart2, 700, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart3, 800, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.TimeSource, 2, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSYear, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMonth, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSDay, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSHour, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMinute, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSSecond, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMiliSec, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.NumberOfSatellites, 17, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Latitude, 32100000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Longitude, 35200000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSAltitude, 3000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSVelocity, 3, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSAngle, 5, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSGroundSpeed, 15, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Temperature, 32, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Humidity, 3000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.UVAUVB, 0, termsList);
            Byte[] terms2 = termsList.ToArray();
            //client.Connect("clientid1");
            client.Publish(PhysicalDataTopic, terms2, 0, false);

            //Generate Kinematic message
            termsList.Clear();
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OpCode, 4, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MessageCounter, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart1, 600, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart2, 700, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart3, 800, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.TimeSource, 2, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSYear, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMonth, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSDay, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSHour, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMinute, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSSecond, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMiliSec, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.BaroHeight, 17, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Pressure, 3200, termsList);
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

            Byte[] terms3 = termsList.ToArray();
            //client.Connect("clientid1");
            client.Publish(KinematicDataTopic, terms3, 0, false);

            //Generate Initialization message
            termsList.Clear();
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.OpCode                   , (uint)1,termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.MessageCounter           , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)InitMessageFieldsSize.IDPart1, (uint)600, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)InitMessageFieldsSize.IDPart2, (uint)700, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)InitMessageFieldsSize.IDPart3, (uint)800, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.TimeSource               , (uint)1, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.GPSYear                  , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.GPSMonth                 , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.GPSDay                   , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.GPSHour                  , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.GPSMinute                , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.GPSSecond                , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.GPSMiliSec               , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.SWVersionID              , (uint)1000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.HWVersionID              , (uint)1000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.ArmHeight                , (uint)5, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.DisarmHeight             , (uint)3, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.VibrationsValue          , (uint)2, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.NoVibrationTime          , (uint)250, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.VibrationFrequency       , (uint)5, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.RollCalibration          , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.PitchCalibration         , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.RollInitMargin           , (uint)5, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.PitchInitMargin          , (uint)5, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.IMUConfiguration         , (uint)15, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.RCConfiguration          , (uint)3, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.BatteryCells             , (uint)4, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.MotorDelay               , (uint)50, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.RollAttitudeLimit        , (uint)65, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.PitchAttitudeLimit       , (uint)65, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.FreefallDuration         , (uint)250, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.FreefallLimit            , (uint)3, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.AngularSpeedRateLimit    , (uint)150, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.AngularSpeedLimit        , (uint)65, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.YawRateLimit             , (uint)150, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.ActiveHeightSource       , (uint)1, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.MaximumHeight            , (uint)1, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.LandingGear              , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.ArmMode                  , (uint)1, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.PyroSensorCalib          , (uint)35, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.PyroSensorMeasurement    , (uint)19, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.PyroTestRate             , (uint)15, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.EmergencyBattery         , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.Destination              , (uint)1, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.SDCard                   , (uint)1, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.TriggeringMode           , (uint)1, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.FiveVoltIndication       , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.EmergencyBatteryVoltageIndication , (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.TwelveVoltageIndication   , (uint)0, termsList);  
            termsList = ManualSerializer.EncodeValuesAsBytesInList(InitMessageFieldsSize.CapacitorVoltageIndication, (uint)0, termsList);

            //Convert list to Array
            Byte[] terms7 = termsList.ToArray();
            //client.Connect("clientid1");
            //Publish message
            client.Publish(InitializationDataTopic, terms7, 0, false);


            termsList.Clear();
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.OpCode, (uint)2,
                                                                   termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.MessageCounter,
                                                                   (uint)0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart1,
                                                                   600, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart2,
                                                                   700, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)StatusMessageFieldsSize.IDPart3,
                                                                   900, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.TimeSource,
                                                                   (uint)2, termsList);//Accurate
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSYear,
                                                                   (uint)0, termsList);//Year
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMonth,
                                                                   (uint)0, termsList);//Month
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSDay,
                                                                   (uint)0, termsList);//Day
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSHour,
                                                                   (uint)0, termsList);//Hour
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMinute,
                                                                   (uint)0, termsList);//Min
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSSecond,
                                                                   (uint)0, termsList);//Sec
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.GPSMiliSec,
                                                                   (uint)0, termsList);//Mili
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.Mode,
                                                                   (uint)6, termsList);//Mode
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RTA,
                                                                   (uint)1, termsList);//Ready To Arm
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.BCS,
                                                                   (uint)160, termsList);//Battery LSB=0.1
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.IMUStatus,
                                                                   (uint)1, termsList);//IMU
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.FDS,
                                                                   (uint)3, termsList);//Flash
            termsList = ManualSerializer.EncodeValuesAsBytesInList(StatusMessageFieldsSize.RCChannels,
                                                                   (uint)0, termsList);//RC
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,0  ,0    ,0    ,0   ,0  ,0   ,0  ,0  ,0    ,0    ,0   ,0  ,255 ,0   ,1  ,1  ,3 
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,Acc,YearL,YearH,Mnth,Day,Hour,Min,Sec,MiliL,MiliH,Mode,RTA,BCSL,BCSH,IMU,FSD,RC
            //2,0,0,3,0,0,0,4,0,0,0,5,0,0,0,1  ,0    ,0    ,0   ,0  ,0   ,0  ,0  ,0    ,0    ,6   ,1  ,10  ,0   ,1  ,3  ,1
            //Convert list to Array
            Byte[] terms6 = termsList.ToArray();
            //client.Connect("clientid1");
            //Publish message
            client.Publish(DeviceStatusTopic, terms6, 0, false);

            termsList.Clear();
            //Generate Physical data message
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.OpCode, 3, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.MessageCounter, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart1, 600, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart2, 700, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)PhysicalMessageFieldsSize.IDPart3, 900, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.TimeSource, 2, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSYear, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMonth, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSDay, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSHour, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMinute, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSSecond, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSMiliSec, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.NumberOfSatellites, 17, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Latitude, 32000000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Longitude, 35000000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSAltitude, 3000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSVelocity, 3, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSAngle, 5, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.GPSGroundSpeed, 15, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Temperature, 32, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.Humidity, 3000, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(PhysicalMessageFieldsSize.UVAUVB, 0, termsList);
            Byte[] terms5 = termsList.ToArray();
            //client.Connect("clientid1");
            client.Publish(PhysicalDataTopic, terms5, 0, false);

            //Generate Kinematic message
            termsList.Clear();
            //Generate Physical data message
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.OpCode, 4, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.MessageCounter, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart1, 600, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart2, 700, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList((int)KinematicMessageFieldsSize.IDPart3, 900, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.TimeSource, 2, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSYear, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMonth, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSDay, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSHour, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMinute, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSSecond, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.GPSMiliSec, 0, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.BaroHeight, 17, termsList);
            termsList = ManualSerializer.EncodeValuesAsBytesInList(KinematicMessageFieldsSize.Pressure, 3200, termsList);
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

            Byte[] terms4 = termsList.ToArray();
            //client.Connect("clientid1");
            client.Publish(KinematicDataTopic, terms4, 0, false);


            //client.Disconnect();
            /*
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
            */
//            client.Disconnect();
            Console.WriteLine("Its the End of the world as we know it!");
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




        /* Original Code for generating MQTT publisher
         * since multiple sends or even one not in the beginning did not wrok
         * added a hack. this code is Obsolete.
    public class Publ
    {
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
            public void Publish()
            {
                //convert to pfx using openssl - see confluence
                //you'll need to add these two files to the project and copy them to the output (not included in source control deliberately!)
                X509Certificate2 clientCert = new X509Certificate2("YOURPFXFILE.pfx", "1");
                X509Certificate caCert = X509Certificate.CreateFromSignedFile("rootCA.pem");
                // create the client
                MqttClient client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
                //message to publish - could be anything
                //string message = "02c92447002000175135323536363302e20704030e180948000602a100020000";
                //client naming has to be unique if there was more than one publisher
                client.Connect("clientid1");
                //client.Publish()
                //publish to the topic
                Byte[] A = { 2, 0, 0, 44, 1, 0, 0, 144, 1, 0, 0, 244, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 1, 200, 0, 1, 3, 1 };
                client.Publish(Topic, A, 0, false);
                //this was in for debug purposes but it's useful to see something in the console
                if (client.IsConnected)
                {
                    Console.WriteLine("SUCCESS!");
                }
                //wait so that we can see the outcome
                //Console.ReadLine();
            }
        }*/
    }
}