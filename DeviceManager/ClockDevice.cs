using System;
using System.Collections.Generic;
using System.Text;
using zkteco_attendance_api;

namespace RelojAsistenciaTester.DeviceManager
{
    internal class ClockDevice
    {
        public string Name { get; set; }
        public string Ubicacion { get; set; }
        public string IpAdress { get; set; }
        public int Port { get; set; }
        public bool UseTcp { get; set; }

        private ZkTeco _zkTeco;

        public ClockDevice(string name, string ubicacion, string ipAdress, int port, bool useTcp)
        {
            Name = name;
            Ubicacion = ubicacion;
            IpAdress = ipAdress;
            Port = port;
            UseTcp = useTcp;
            _zkTeco = new ZkTeco(IpAdress, Port, UseTcp);
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Ubicacion: {Ubicacion}");
            Console.WriteLine($"IP Address: {IpAdress}");
            Console.WriteLine($"Port: {Port}");
            Console.WriteLine($"Use TCP: {UseTcp}");
        }

        public void ConectDivice()
        {
            var clock = _zkTeco;
            if (clock.Connect())
            {
                Console.WriteLine("Device connected successfully.");
            }
            else
            {
                Console.WriteLine("Failed to connect to the device.");
            }
        }

        public void DisconnectDevice()
        {
            _zkTeco.Disconnect();
        }

        public void GetDeviceInfo()
        {
            var clock = _zkTeco;
            if (clock.IsConnected)
            {
                Console.WriteLine("Device connected successfully.");
                Console.WriteLine($"Device Name: {clock.GetDeviceName}");
                Console.WriteLine($"Firmware Version: {clock.GetFirmwareVersion}");
                Console.WriteLine($"Serial Number: {clock.GetDeviceSerial}");
                clock.Disconnect();
            }
            else
            {
                Console.WriteLine("Failed to connect to the device.");
            }
        }
    }
}
