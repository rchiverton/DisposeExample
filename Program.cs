using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DisposeExample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class BinarySerialization
    {
        public static byte[] Serialize(object o, bool useCompression)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                new BinaryFormatter().Serialize((Stream)ms, o);
                return useCompression ? BinarySerialization.Compress(ms) : ms.GetBuffer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
               // ms?.Close();
            }
        }

        public static object Deserialize(byte[] data, bool useCompression)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                if (useCompression)
                {
                    data = (byte[])(BinarySerialization.Decompress(data));
                }
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                ms.Write(data, 0, data.Length);
                ms.Position = 0L;
                return binaryFormatter.Deserialize((Stream)ms);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                ms?.Close();
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            throw new NotImplementedException();
        }

        public static byte[] Compress(MemoryStream ms)
        {
            throw new NotImplementedException();
        }
    }


    public class OhNo
    {
        public void ReadDataAtBytePosition(long bytePosition)
        {
            using (FileStream stream = new FileStream("test.txt", FileMode.Open) {Position = bytePosition})
            {
                int byteValue = stream.ReadByte();
            }
        }

    }
}
