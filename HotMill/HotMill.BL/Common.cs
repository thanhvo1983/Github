using System;
using System.Text;

namespace Kvics.HotMill.BL
{
    public class Common
    {
        /*
        public static void CopyBytes(Byte[] source, int sourceStart, Byte[] des, int desStart, int count)
        {
            Buffer.BlockCopy(source, sourceStart, des, desStart, count); 
        }
        */
        public static Byte[] GetBytes(Int16 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] GetBytes(Int32 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] GetBytes(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        public static Int16 ToInt16(Byte[] data, int startIndex)
        {
            return BitConverter.ToInt16(data, startIndex);
        }

        public static Int32 ToInt32(Byte[] data, int startIndex)
        {
            return BitConverter.ToInt32(data, startIndex);
        }

        public static string GetString(Byte[] data)
        {
            return Encoding.ASCII.GetString(data);
        }

        public static string GetString(Byte[] data, int index, int count)
        {
            return Encoding.ASCII.GetString(data, index, count);
        }
        public static string GetString(string data, int index, int count, char pattern, int beginEndAdd)
        {
            if (data == null)
            {
                return null;
            }
            string strReturn = data.Substring(index, ((data.Length - index) > count ? count : (data.Length - index)));

            while (strReturn.Length < count)
            {
                strReturn = (beginEndAdd == 1 ? (pattern + strReturn) : (strReturn + pattern));
            }

            return strReturn;
        }
    }

    public enum DataPackages
    {
        Preset,
        FinalSet,
        Finished,
        Result
    }
}
