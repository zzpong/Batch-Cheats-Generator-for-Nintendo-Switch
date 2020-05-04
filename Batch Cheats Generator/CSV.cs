using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Cheats_Generator
{
    internal static class CSV
    {
        public class CSV_Header
        {
            public string[] Data;
            public string Type;
            public string EndMark;

            public CSV_Header(byte[] data)
            {
                // Data = System.Text.Encoding.GetEncoding("GBK").GetString(data);
                // Type = Data.Substring(0, 2);
                // EndMark = Data.Substring(3, 4);
                Data = BytesToHexString(data);
                //string DataString = new string(Data);
                string DataString = string.Join("", Data);
                Type = DataString.Substring(0, 6);
                EndMark = DataString.Remove(0, 6);
            }
        }
        public static String[] BytesToHexString(byte[] bData)
        {
            string[] Data = new string[bData.Length];
            for (int i = 0; i < bData.Length; i++)
            {
                Data[i] = Convert.ToString(bData[i], 16).PadLeft(2, '0').ToUpper();
            }
            return Data;
        }

        public static CSV_Header[] CSV_Headers = new CSV_Header[1];
    }
}