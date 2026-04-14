using System;
using System.Collections.Generic;
using System.Text;
using zkteco_attendance_api;

namespace RelojAsistenciaTester.DeviceManager
{
    internal class DeviceManager
    {
        public List<ClockDevice> Devices { get; set; }

        public DeviceManager()
        {
            Devices = new List<ClockDevice>();
        }

        public void AddDevice(ClockDevice device)
        {
            Devices.Add(device);
        }

        public void RemoveDevice(ClockDevice device)
        {
            Devices.Remove(device);
        }

        public void Clear()
        {
            Devices.Clear();
        }

        public bool Contains(ClockDevice device)
        {
            return Devices.Contains(device);
        }

        public void ListDevices()
        {
            if (Devices.Count == 0)
            {
                Console.WriteLine("No devices found.");
                return;
            }
            Console.WriteLine("Devices:");
            foreach (var device in Devices)
            {
                Console.WriteLine($"- {device.Name} ({device.IpAdress}:{device.Port})");
            }
        }

        public ClockDevice GetDeviceByName(string name)
        {
            return Devices.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public ClockDevice GetDeviceByIp(string ipAdress)
        {
            return Devices.Find(d => d.IpAdress.Equals(ipAdress, StringComparison.OrdinalIgnoreCase));
        }

        public bool ConnectToDevice(ClockDevice device)
        {
            if (device != null)
            {
                device.ConectDivice();
                Console.WriteLine("Device connected.");
                return true;
            }
            Console.WriteLine("Device not found.");
            return false;
        }

        public bool DisconnectFromDevice(ClockDevice device)
        {
            if (device != null)
            {
                device.DisconnectDevice();
                Console.WriteLine("Device disconnected.");
                return true;
            }
            Console.WriteLine("Device not found.");
            return false;
        }

        public void GetDeviceInfo(ClockDevice device)
        {
            if (device != null)
            {
                device.ConectDivice();
                device.GetDeviceInfo();
                device.DisconnectDevice();
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        public void DisconectAllDevices()
        {
            foreach (var device in Devices)
            {
                Console.WriteLine("Disconnecting device: " + device.Name);
                device.DisconnectDevice();
            }
        }

        public void DisplayAllDevicesInfo()
        {
            foreach (var device in Devices)
            {
                Console.WriteLine("Device: " + device.Name);
                device.DisplayInfo();
                Console.WriteLine();
            }

        }


        public void ConnectAllDevices()
        {
            foreach (var device in Devices)
            {
                Console.WriteLine("Connecting to device: " + device.Name);
                device.ConectDivice();
            }
        }

        public void AddUserToDevice(ClockDevice device, string userId, string name)
        {
            if (device != null )
            {
                device.AddUserToDevice(userId, name, "123456", Privilege.Default);
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        public void AddUserToDevice(ClockDevice device, string userId, string name , string password, Privilege privilege)
        {
            if (device != null)
            {
                device.AddUserToDevice(userId, name, password, privilege);
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        public void ShowRolsAbeilableInDevice(ClockDevice device)
        {
            if (device != null)
            {
                foreach (var role in Enum.GetValues(typeof(Privilege)))
                {
                    Console.WriteLine($"- {role}");
                }
            }
        }

            public void ListUsersInDevice(ClockDevice device)
            {
                if (device != null)
                {
                    device.ListUsers();
                }
                else
                {
                    Console.WriteLine("Device not found.");
                }
        }
    }
}
