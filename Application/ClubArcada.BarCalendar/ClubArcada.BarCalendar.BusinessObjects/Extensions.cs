using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ClubArcada.BarCalendar.BusinessObjects
{
    public static class Extensions
    {
        public static bool IsNull(this object obj)
        {
            if (obj == null)
                return true;

            if (obj.GetType() == typeof(Guid))
                return false;

            return true;
        }

        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }

        public static string GetEnumDescription<T>(this T enumerator) where T : struct, IConvertible
        {
            var fi = enumerator.GetType().GetField(enumerator.ToString());
            var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().ToArray();

            if (attributes != null && attributes.Length > 0)
                return attributes.First().Description;
            else
                return enumerator.ToString();
        }

        public static List<int> GetValuesOf<T>() where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<Enum>().Select(e => Convert.ToInt32(e)).ToList();
        }

        public static bool In<T>(this T enumerator, params T[] values) where T : struct, IConvertible
        {
            if (values.Length == 0)
                return false;

            return values.Any(v => enumerator.Equals(v));
        }

        public static byte[] ReadToEnd(this System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }


    }
}