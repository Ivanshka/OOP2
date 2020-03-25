using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    public sealed class Client
    {
        static Client _instance;
        static Client() => _instance = new Client();
        private Client() { }
        public static Client GetClient() => _instance;
        public Transport[] Query(string factory, string type, int count)
        {
            Transport[] arr = new Transport[count];
            AbstractFactory af;
            if (factory.ToUpper() == "USA")
            {
                af = new UsaFactory();
                if (type.ToUpper() == "CAR")
                    for (int i = 0; i < count - 1; i++)
                        arr[i] = new UsaCar();
                else
                    for (int i = 0; i < count - 1; i++)
                        arr[i] = new UsaVehicle();
            }
            else
            {
                af = new JapanFactory();
                if (type.ToUpper() == "CAR")
                    for (int i = 0; i < count - 1; i++)
                        arr[i] = new JapanCar();
                else
                    for (int i = 0; i < count - 1; i++)
                        arr[i] = new JapanVehicle();
            }
            return arr;
        }
    }
}
