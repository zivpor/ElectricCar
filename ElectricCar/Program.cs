using System.Net.Sockets;

namespace ElectricCar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElectricCar c=new ElectricCar(1);
            c.StartEngine();
            Console.WriteLine("Hello, World!");
        }
    }
}