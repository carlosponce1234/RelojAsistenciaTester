using RelojAsistenciaTester.DeviceManager;

namespace RelojAsistenciaTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Reloj de Asistencia Tester");
            Console.WriteLine("==========================================");

            Console.WriteLine("Ingrese el nombre del dispositivo:");
            Console.Write("> ");
            var name = Console.ReadLine();
            Console.WriteLine("Ingrese la ubicación del dispositivo:");
            var ubicacion = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección IP del dispositivo:");
            var ipAdress = Console.ReadLine();
            Console.WriteLine("Ingrese el puerto del dispositivo:");
            var portInput = Console.ReadLine();
            int port = int.TryParse(portInput, out int parsedPort) ? parsedPort : 0;
            Console.WriteLine("¿Usar TCP? (s/n):");
            var useTcpInput = Console.ReadLine();
            bool useTcp = useTcpInput?.ToLower() == "s";
            var clockDevice = NewDevice(name, ubicacion, ipAdress, port, useTcp);
            clockDevice.DisplayInfo();
            clockDevice.ConectDivice();
            Console.WriteLine("Presione cualquier tecla para desconectar el dispositivo...");
            Console.ReadKey();
            clockDevice.DisconnectDevice();

        }


        static ClockDevice NewDevice(string name, string ubicacion, string ipAdress, int port, bool useTcp)
        {
            return new ClockDevice(name, ubicacion, ipAdress, port, useTcp);
        }


    }
}
