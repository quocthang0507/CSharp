using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProductID
{
    public class HardwareInfo
    {
        public static string AppName
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        public static string CpuId
        {
            get
            {
                string id = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select Processorid from Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    id = obj["ProcessorId"].ToString();
                    break;
                }
                return id;
            }
        }

        public static string HddSerialNumber
        {
            get
            {
                List<string> list = new List<string>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select SerialNumber from Win32_DiskDrive");
                foreach (ManagementObject obj in searcher.Get())
                {
                    string serial = obj["SerialNumber"].ToString();
                    list.Add(serial);
                }
                return string.Join("_", list.ToArray());
            }
        }

        public static string BiosVersion
        {
            get
            {
                string biosVersion = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_BIOS");
                foreach (ManagementObject obj in searcher.Get())
                {
                    biosVersion = obj["Version"].ToString();
                    break;
                }
                return biosVersion;
            }
        }

        public static string MachineId
        {
            get
            {
                string app = AppName,
                    cpuId = CpuId,
                    driveSerial = HddSerialNumber,
                    biosVersion = BiosVersion;
                string combined = $"{app}-{cpuId}-{driveSerial}-{biosVersion}";
                string digest = CalculateMD5Hash(combined);
                string formatted = FormatProductID(digest);
                return formatted;
            }
        }

        private static string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private static string FormatProductID(string input)
        {
            string formatted = input.Substring(0, 5) + "-" + input.Substring(5, 5) + "-" + input.Substring(10, 5) + "-" + input.Substring(15, 5) + "-" + input.Substring(20, 5);
            return formatted.ToUpper();
        }
    }
}
