using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // ABSTRACT FACTORY и SINGLETON

            // вместо "главного" сделал клиента для создания запроса
            var client = Client.GetClient();
            var arr = client.Query("Japan", "car", 10);

            // BUILDER

            Director dir = new Director();
            CaveBuilder cb = new CaveBuilder();
            dir.Build(cb);
            var house = cb.GetHouse();
            Console.WriteLine($"Дверь: {house.Door}, окно: {house.Windows}.");

            // PROTOTYPE
            SuperMegaCoolString s = new SuperMegaCoolString();
            s.Text = "СУПЕР МЕГА КРУТАЯ СТРОКА!!!";

            var s2 = s.DeepCopy();
            Console.WriteLine(s2.Text);

            Console.ReadLine();
        }
    }
}
