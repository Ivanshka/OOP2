using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    public interface IComponent
    {
        string Title { get; set; }
        void Draw();
        IComponent Find(string title);
    }

    /// <summary>
    /// Map (композит) - карта всех объектов
    /// </summary>
    public class Map : IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();
        
        public string Title { get; set; }
        public void Draw() { Console.WriteLine("Отрисовка компонентов:"); foreach (IComponent ic in _map) Console.WriteLine(ic.ToString()); }
        //public IComponent Find(string title) => _map.Find((ic) => { if (ic.Title == title) return true; else return false; });
        public IComponent Find(string title)
        {
            foreach (IComponent ic in _map)
            {
                if (ic.Title == title)
                    return ic;
                if (ic is Map)
                {
                    IComponent temp = ic.Find(title);
                    if (temp != null)
                        return temp;
                }
            }
            return null;
        }

        public void AddComponent(IComponent component) { _map.Add(component); }
    }

    public class City : IComponent
    {
        public City() { Title = "Город без имени."; }
        public City(string title) { Title = "Город " + title; }

        public string Title { get; set; }
        public void Draw() => throw new NotImplementedException("Недопустимая для элемента операция!");
        public IComponent Find(string title) => throw new NotImplementedException("Недопустимая для элемента операция!");
    }

    public class Village : IComponent
    {
        public Village() { Title = "Деревня без имени."; }
        public Village(string title) { Title = "Деревня " + title; }

        public string Title { get; set; }
        public void Draw() => throw new NotImplementedException("Недопустимая для элемента операция!");
        public IComponent Find(string title) => throw new NotImplementedException("Недопустимая для элемента операция!");
    }

    public class Microdistrict : IComponent
    {
        public Microdistrict() { Title = "Микрорайон без имени."; }
        public Microdistrict(string title) { Title = "Микрорайон " + title; }

        public string Title { get; set; }
        public void Draw() => throw new NotImplementedException("Недопустимая для элемента операция!");
        public IComponent Find(string title) => throw new NotImplementedException("Недопустимая для элемента операция!");
    }
}
