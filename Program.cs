using RelojAsistenciaTester.DeviceManager;
using zkteco_attendance_api;

namespace RelojAsistenciaTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("\nCerrando aplicación...");
            };

            DeviceManager.DeviceManager deviceManager = new DeviceManager.DeviceManager();

            while (true)
            {
                Console.Clear();
                AplicationTitle();
                ShowMenu();

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewDevice(deviceManager);
                        break;
                    case "2":
                        ListDevices(deviceManager);
                        break;
                    case "3":
                        ConnectToDevice(deviceManager);
                        break;
                    case "4":
                        DisconnectFromDevice(deviceManager);
                        break;
                    case "5":
                        GetDeviceInfo(deviceManager);
                        break;
                    case "6":
                        AddUserToDevice(deviceManager);
                        break;
                    case "7":
                        ListUsersInDevice(deviceManager);
                        break;
                    case "8":
                        Console.WriteLine("La aplicación solo se cierra con Ctrl + C.");
                        Pause();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente nuevamente.");
                        Pause();
                        break;
                }
            }
        }

        static void AplicationTitle()
        {
            Console.WriteLine("Reloj de Asistencia Tester");
            Console.WriteLine("==========================");
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Agregar dispositivo");
            Console.WriteLine("2. Listar dispositivos");
            Console.WriteLine("3. Conectar a un dispositivo");
            Console.WriteLine("4. Desconectar de un dispositivo");
            Console.WriteLine("5. Obtener información del dispositivo");
            Console.WriteLine("6. Agregar Usuario Dispositivo");
            Console.WriteLine("7. Listar Usuarios Dispositivo");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void Pause()
        {
            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }

        public static void AddNewDevice(DeviceManager.DeviceManager deviceManager)
        {
            Console.Clear();
            Console.WriteLine("Agregar nuevo dispositivo");

            Console.Write("Ingrese el nombre del dispositivo: ");
            string name = Console.ReadLine();

            Console.Write("Ingrese la ubicación del dispositivo: ");
            string ubicacion = Console.ReadLine();

            Console.Write("Ingrese la dirección IP del dispositivo: ");
            string ipAdress = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(ubicacion) ||
                string.IsNullOrWhiteSpace(ipAdress))
            {
                Console.WriteLine("Todos los campos son obligatorios. Por favor, intente nuevamente.");
                Pause();
                return;
            }

            var device = NewDevice(name, ubicacion, ipAdress, 4370, true);
            deviceManager.AddDevice(device);

            Console.WriteLine("Dispositivo agregado exitosamente.");
            Pause();
        }

        static void ListDevices(DeviceManager.DeviceManager deviceManager)
        {
            Console.Clear();
            Console.WriteLine("Dispositivos registrados:");

            if (deviceManager.Devices.Count == 0)
            {
                Console.WriteLine("No hay dispositivos registrados.");
            }
            else
            {
                deviceManager.ListDevices();
            }

            Console.WriteLine("===========================");
            Pause();
        }

        static void ConnectToDevice(DeviceManager.DeviceManager deviceManager)
        {
            Console.Clear();
            Console.WriteLine("Conectar a un dispositivo");

            Console.Write("Ingrese el nombre del dispositivo: ");
            string name = Console.ReadLine();

            var device = deviceManager.GetDeviceByName(name);

            if (device != null)
            {
                device.ConectDivice();
            }
            else
            {
                Console.WriteLine("Dispositivo no encontrado.");
            }

            Pause();
        }

        static void DisconnectFromDevice(DeviceManager.DeviceManager deviceManager)
        {
            Console.Clear();
            Console.WriteLine("Desconectar de un dispositivo");

            Console.Write("Ingrese el nombre del dispositivo: ");
            string name = Console.ReadLine();

            var device = deviceManager.GetDeviceByName(name);

            if (device != null)
            {
                device.DisconnectDevice();
            }
            else
            {
                Console.WriteLine("Dispositivo no encontrado.");
            }

            Pause();
        }

        static void GetDeviceInfo(DeviceManager.DeviceManager deviceManager)
        {
            Console.Clear();
            Console.WriteLine("Obtener información del dispositivo");

            Console.Write("Ingrese el nombre del dispositivo: ");
            string name = Console.ReadLine();

            var device = deviceManager.GetDeviceByName(name);

            if (device != null)
            {
                device.GetDeviceInfo();
            }
            else
            {
                Console.WriteLine("Dispositivo no encontrado.");
            }

            Pause();
        }

        static void AddUserToDevice(DeviceManager.DeviceManager deviceManager)
        {
            Console.Clear();
            Console.WriteLine("Agregar usuario a un dispositivo");

            Console.Write("Ingrese el nombre del dispositivo: ");
            string name = Console.ReadLine();

            var device = deviceManager.GetDeviceByName(name);

            if (device != null)
            {
                Console.Write("Ingrese el nombre del usuario: ");
                string userName = Console.ReadLine();

                Console.Write("Ingrese el ID del usuario: ");
                string id = Console.ReadLine();

                Console.Write("Ingrese la contraseña del usuario: ");
                string password = Console.ReadLine();

                Console.WriteLine("Asigne el Rol del Usuario");
                deviceManager.ShowRolsAbeilableInDevice(device);

                Console.Write("Ingrese el rol del usuario: ");
                string rolInput = Console.ReadLine();

                if (Enum.TryParse(rolInput, true, out Privilege privilege))
                {
                    deviceManager.AddUserToDevice(device, id, userName, password, privilege);
                }
                else
                {
                    Console.WriteLine("Rol inválido.");
                }
            }
            else
            {
                Console.WriteLine("Dispositivo no encontrado.");
            }

            Pause();
        }

        static void ListUsersInDevice(DeviceManager.DeviceManager deviceManager)
        {
            Console.Clear();
            Console.WriteLine("Listar usuarios en un dispositivo");

            Console.Write("Ingrese el nombre del dispositivo: ");
            string name = Console.ReadLine();

            var device = deviceManager.GetDeviceByName(name);

            if (device != null)
            {
                deviceManager.ListUsersInDevice(device);
            }
            else
            {
                Console.WriteLine("Dispositivo no encontrado.");
            }

            Pause();
        }

        static ClockDevice NewDevice(string name, string ubicacion, string ipAdress, int port, bool useTcp)
        {
            return new ClockDevice(name, ubicacion, ipAdress, port, useTcp);
        }
    }
}