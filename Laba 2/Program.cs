using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADAPTER
            User cl = new User();
            Plane plane = new Plane();
            Console.WriteLine($"Координаты самолета: {plane}\nПеремещаем самолет");
            // перемещаем самолет
            cl.Move(plane);
            Console.WriteLine($"Теперь координаты самолета: {plane}");

            // создаем адаптер, чтобы можно было переместить машину 
            PlaneToCarAdapter adapter = new PlaneToCarAdapter();
            Console.WriteLine($"Координаты машины: {adapter}\nПеремещаем машину с помощью адаптера");
            // перемещаем самолет
            cl.Move(adapter);
            Console.WriteLine($"Теперь координаты машины: {adapter}");

            //DECORATOR
            Console.WriteLine("\n\n(Ракета с принтом:)");
            RocketDecorator rocket = new RocketWithPrint();
            rocket.Operation();

            Console.WriteLine("\n(Ракета с принтом и компонентом: необычный доп движок:)");
            rocket.SetComponent(new UnusualEngineComponent());
            rocket.Operation();

            Console.WriteLine("\n(Ракета2 с доп движком и компонентом: прошлая ракета:)");
            RocketDecorator rocket2 = new RocketWithAdditionalEngine();
            rocket2.SetComponent(rocket);
            rocket2.Operation();

            Console.WriteLine("\n(Ракета3 с принтом и компонентом: очень мощный доп движок:)");
            RocketDecorator rocket3 = new RocketWithPrint("зеленый");
            rocket3.SetComponent(new PowerfullUnusualEngineComponent());
            rocket3.Operation();

            // COMPOSITE
            Console.WriteLine("\n");
            Map villages = new Map();
            villages.AddComponent(new Village("Орешники"));
            villages.AddComponent(new Village("Гончаровка"));
            villages.AddComponent(new Village("Дубровка"));

            Map cAm = new Map();
            cAm.AddComponent(new City("Смолевичи"));
            cAm.AddComponent(new Microdistrict("Сокол"));

            Map map = new Map();
            map.AddComponent(new City("Минск"));
            map.AddComponent(villages);
            map.AddComponent(cAm);

            var output = map.Find("Деревня Гончаровка");

            if (output == null)
                Console.WriteLine("Объект не найден!");
            else
                Console.WriteLine("Найдено:\n" + output.Title);
        }
    }
}
