using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    /// <summary>
    /// Абстрактная фабрика
    /// </summary>
    interface AbstractFactory
    {
        /// <summary>
        /// Создать тачку
        /// </summary>
        /// <returns></returns>
        AbstractCar CreateCar();
        /// <summary>
        /// Создать вэлик
        /// </summary>
        /// <returns></returns>
        AbstractVehicle CreateVehicle();
    }

    /// <summary>
    /// Японская фабрика автомобилей и великофф
    /// </summary>
    class JapanFactory : AbstractFactory
    {
        /// <summary>
        /// Заказываем японскую тачку
        /// </summary>
        /// <returns></returns>
        public AbstractCar CreateCar()
        {
            return new JapanCar();
        }

        /// <summary>
        /// Заказываем японский велик
        /// </summary>
        /// <returns></returns>
        public AbstractVehicle CreateVehicle()
        {
            return new JapanVehicle();
        }
    }

    /// <summary>
    /// Амэрыканская фабрика автомобилей и великофф
    /// </summary>
    class UsaFactory : AbstractFactory
    {
        public AbstractCar CreateCar()
        {
            return new UsaCar();
        }

        public AbstractVehicle CreateVehicle()
        {
            return new UsaVehicle();
        }
    }

    public interface Transport
    {

    }

    /// <summary>
    /// Интерфейс машины
    /// </summary>
    interface AbstractCar
    { }

    interface AbstractVehicle
    { }

    class JapanCar : AbstractCar, Transport
    { }

    class JapanVehicle : AbstractVehicle, Transport
    { }

    /// <summary>
    /// Амэрыканская тачка
    /// </summary>
    class UsaCar : AbstractCar, Transport
    { }

    /// <summary>
    /// Амэрыканский вэлик
    /// </summary>
    class UsaVehicle : AbstractVehicle, Transport
    { }
}
