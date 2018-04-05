using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Collections.Generic;
namespace Ser2.Serializer
{
    public class ManualSerializer
    {

        const string fileName = "AppSettings.dat";

        public ManualSerializer()
        {
        }
        //Reads string saved to file (const at constructor), it returns the value of Byte in Hex
        public static SByte ReturnSByteValue(int StartIndexInBytes, int VarSizeInBytes)
        {
            SByte temp = 0;
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    int position = 0;

                    int nBytes = (int)reader.BaseStream.Length;
                    byte[] ByteArray = new byte[nBytes];
                    reader.Read(ByteArray, 0, nBytes);
                    position = StartIndexInBytes * 2;
                    for (int i = 0; i < VarSizeInBytes * 2; i++)
                    {
                        temp = ((sbyte)(temp << 4));
                        temp = ((sbyte)(temp | Convert.ToSByte(Convert.ToChar(ByteArray[position]).ToString(), 16)));
                        position++;

                    }
                }
            }
            return temp;
        }

        //Reads string saved to file (const at constructor), it returns the value of short in Hex as string
        //Big Endianess does not work. 0d9417 --> 0xc924
        public static short ReturnInt16Value(int StartIndexInBytes, int VarSizeInBytes, bool BigEndianess)
        {
            short temp = 0;
            short tempread = 0;
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    int position = 0;

                    int nBytes = (int)reader.BaseStream.Length;
                    byte[] ByteArray = new byte[nBytes];
                    reader.Read(ByteArray, 0, nBytes);
                    if (BigEndianess)
                    {
                        position = StartIndexInBytes * 2;
                        for (int i = 0; i < VarSizeInBytes * 2; i++)
                        {
                            temp = (short)(temp << 4);
                            temp = ((short)(temp | (short)Convert.ToByte(Convert.ToChar(ByteArray[position]).ToString(), 16)));
                            position++;
                        }
                    }
                    if (!BigEndianess)
                    {
                        position = StartIndexInBytes * 2 + VarSizeInBytes * 2 - 1;
                        for (int i = 0; i < VarSizeInBytes; i++)
                        {
                            temp = (short)(temp << 4);
                            tempread = (short)Convert.ToByte(Convert.ToChar(ByteArray[position - 1]).ToString(), 16);
                            temp = ((short)(temp | tempread));
                            temp = (short)(temp << 4);
                            tempread = (short)Convert.ToByte(Convert.ToChar(ByteArray[position]).ToString(), 16);
                            temp = ((short)(temp | tempread));
                            position = position - 2;
                        }
                    }
                }

            }
            return temp;
        }

        //Reads string saved to file (const at constructor), it returns the value of integer in Hex as string
        //Big Endianess does not work.
        public static UInt32 ReturnUint32Value(int StartIndexInBytes, int VarSizeInBytes, bool BigEndianess)
        {
            UInt32 temp = 0;
            UInt32 tempread = 0;
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    int position = 0;

                    int nBytes = (int)reader.BaseStream.Length;
                    byte[] ByteArray = new byte[nBytes];
                    reader.Read(ByteArray, 0, nBytes);
                    if (BigEndianess)
                    {
                        position = StartIndexInBytes * 2;
                        for (int i = 0; i < VarSizeInBytes * 2; i++)
                        {
                            temp = (uint)(temp << 4);
                            temp = ((uint)(temp | (uint)Convert.ToByte(Convert.ToChar(ByteArray[position]).ToString(), 16)));
                            position++;
                        }
                    }
                    if (!BigEndianess)
                    {
                        position = StartIndexInBytes * 2 + VarSizeInBytes * 2 - 1;
                        for (int i = 0; i < VarSizeInBytes; i++)
                        {
                            temp = (uint)(temp << 4);
                            tempread = (uint)Convert.ToByte(Convert.ToChar(ByteArray[position - 1]).ToString(), 16);
                            temp = ((uint)(temp | tempread));
                            temp = (uint)(temp << 4);
                            tempread = (uint)Convert.ToByte(Convert.ToChar(ByteArray[position]).ToString(), 16);
                            temp = ((uint)(temp | tempread));
                            position = position - 2;
                        }
                    }
                }

            }
            return temp;
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

        //Converts Byte /short / int to string of singular bytes seperate by Comma
        //0d2000 --> Byte1 = 0d208, Byte2 = 0d7 
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
                TmpStr = byte1.ToString() + "," + byte2.ToString();
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

        //Dynamicly add values to list (easiier than to array). 
        //later on it transformed for array to send in MQTTchannel
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
    }
}
