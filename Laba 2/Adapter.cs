using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    /// <summary>
    /// Класс пользователя. Задача - передвинуть самолет, а затем машину одним и тем же способом, т.е. методом Move()
    /// </summary>
    class User
    {
        public void Move(IMovable transport) { transport.Move(3, 3, 3); }
    }

    interface IMovable
    {
        void Move(int dx, int dy, int dz);
    }

    // Адаптер от самолета к машине
    class PlaneToCarAdapter : IMovable
    {
        private Car adaptee = new Car();
        public void Move(int dx, int dy, int dz) { adaptee.X += dx; adaptee.Y += dy; }
        public override string ToString() => adaptee.ToString();
    }

    /// <summary>
    /// Адаптируемый класс самолета
    /// </summary>
    class Plane : IMovable
    {
        public Plane() { X = Y = Z = 0; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public void Move(int dx, int dy, int dz) { X += dx; Y += dy; Z += dz; }
        public override string ToString() => $"X: {X}, Y: {Y}, Z: {Z}";
    }

    /// <summary>
    /// Адаптируем самолет к машине
    /// </summary>
    class Car
    {
        public Car() { X = Y = 0; }
        public int X { get; set; }
        public int Y { get; set; }
        void Move(int dx, int dy, int dz) { X += dx; Y += dy; }
        public override string ToString() => $"X: {X}, Y: {Y}";
    }
}
