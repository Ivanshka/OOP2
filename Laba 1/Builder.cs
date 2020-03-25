using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    /// <summary>
    /// Директор. Ему все управление и поручим.
    /// </summary>
    class Director
    {
        //Builder _builder;
        /// <summary>
        /// Строить домину
        /// </summary>
        /// <param name="builder"></param>
        public void Build(Builder builder)
        {
            //_builder = builder;
            if (builder.GetType() == typeof(CaveBuilder))
            {
                builder.Reset();
                builder.BuildDoor();
                builder.BuildWindows();
            }
            if (builder.GetType() == typeof(IndustrialBuilder))
            {
                builder.Reset();
                builder.BuildFoundation();
                builder.BuildWalls();
                builder.BuildRoof();
                builder.BuildWindows();
                builder.BuildDoor();
            }
        }
    }

    /// <summary>
    /// Требования к умениям строителей
    /// </summary>
    interface Builder
    {
        /// <summary>
        /// Подрываем к чертям строящийся объект)
        /// </summary>
        void Reset();
        /// <summary>
        /// Строим фундамент
        /// </summary>
        void BuildFoundation();
        /// <summary>
        /// Строим стены
        /// </summary>
        void BuildWalls();
        /// <summary>
        /// Строим дверь
        /// </summary>
        void BuildDoor();
        /// <summary>
        /// Строим крышу
        /// </summary>
        void BuildRoof();
        /// <summary>
        /// Строим окна
        /// </summary>
        void BuildWindows();
    }

    /// <summary>
    /// Строитель, который выдалбливает дом в горе.
    /// </summary>
    class CaveBuilder : Builder
    {
        private CaveHouse Result;

        public void BuildDoor() => Result.Door = "бальшОООООООй каменище";
        public void BuildFoundation() { }
        public void BuildRoof() { }
        public void BuildWalls() { }
        public void BuildWindows() => Result.Windows = "Па факту проста ДыраЧКи в стенах)";
        public void Reset() => Result = new CaveHouse();
        public CaveHouse GetHouse() => Result;
    }

    /// <summary>
    /// Строитель, который строит современную домину.
    /// </summary>
    class IndustrialBuilder : Builder
    {
        private IndustrialHouse Result;

        public void BuildDoor() => Result.Door = "Крепкая и крутым замком";
        public void BuildFoundation() => Result.Foundation = "Такой, что здание простоит 1кк лет";
        public void BuildRoof() => Result.Roof = "Жоская, крутая, нифига не протекает";
        public void BuildWalls() => Result.Walls = "Высокие и мощные, такие, что выдержат землятрясение в 10 баллов";
        public void BuildWindows() => Result.Windows = "Пулей фиг пробьешь";
        public void Reset() => Result = new IndustrialHouse();
        public IndustrialHouse GetHouse() => Result;
    }

    class CaveHouse { public string Windows, Door; }

    class IndustrialHouse { public string Roof, Walls, Foundation, Windows, Door; }
}
