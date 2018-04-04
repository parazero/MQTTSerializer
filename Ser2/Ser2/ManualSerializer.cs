using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
namespace Ser2.Serializer
{
    public class ManualSerializer
    {

        const string fileName = "AppSettings.dat";

        public ManualSerializer()
        {
        }
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
    }
}
