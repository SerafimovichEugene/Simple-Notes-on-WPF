using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Find_SDF_On_Usb
{
    class Program
    {
        static void Main(string[] args)
        {
            var UsbDivices = GetUSBDevices();
            foreach (var usbDevice in UsbDivices)
            {
                Console.WriteLine("Device ID: {0}\nPNP Device ID: {1}\nDescription: {2}\n",
                    usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
                Console.WriteLine("-----------------------------------------");
            }

            Console.Read();
        }
        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")                
                ));
            }

            collection.Dispose();
            return devices;
        }
    }
    public class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            DeviceID = deviceID;
            PnpDeviceID = pnpDeviceID;
            Description = description;
            
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
    }
}
