using System;
using System.Collections.Generic;
using System.Threading;
//Цель:
//В этом ДЗ вы научитесь явному вызову интерфейсов, их наследованию и реализации методов по умолчанию.

//Описание/Пошаговая инструкция выполнения домашнего задания:
//Создать интерфейс IRobot с публичным методами string GetInfo() и List GetComponents(), а также string GetRobotType() с дефолтной реализацией, возвращающей значение "I am a simple robot.".
//Создать интерфейс IChargeable с методами void Charge() и string GetInfo().
//Создать интерфейс IFlyingRobot как наследник IRobot с дефолтной реализацией GetRobotType(), возвращающей строку "I am a flying robot.".
//Создать класс Quadcopter, наследующий IFlyingRobot и IChargeable. В нём создать список компонентов List _components = new List { "rotor1", "rotor2", "rotor3", "rotor4" } и возвращать его из метода GetComponents().
//Реализовать метод Charge() должен писать в консоль "Charging..." и через 3 секунды "Charged!". Ожидание в 3 секунды реализовать через Thread.Sleep(3000).
//Реализовать все методы интерфейсов в классах. До этого пункта достаточно "throw new NotImplementedException();" В чат напишите также время, которое вам потребовалось для реализации домашнего задания.

namespace ДЗ_5_интерфейс
{
    class Program
    {
        static void Main(string[] args)
        {

            Quadcopter myQuadcopter = new ();

            myQuadcopter.GetInfo();

            List<string> list = myQuadcopter.GetComponents();
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            myQuadcopter.Charge();

            ExecuteIFlyingRobot(myQuadcopter);
        }

        static void ExecuteIFlyingRobot(IFlyingRobot printTxt)
        {
            Console.WriteLine(printTxt.GetRobotType());
        }
    }

    interface IRobot
    {
        string GetInfo();
        List<string> GetComponents();
        string GetRobotType() => "I am a simple robot.";
    }

    interface IChargeable
    {
        void Charge();
        string GetInfo();
    }

    interface IFlyingRobot : IRobot
    {
        // string GetRobotType() => "I am a flying robot.";
        string IRobot.GetRobotType() => "I am a flying robot."; 
    }

    class Quadcopter : IFlyingRobot, IChargeable
    {
        private readonly List<string> _components = new() { "rotor1", "rotor2", "rotor3", "rotor4" };

        public void Charge()
        {
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");
        }

        public List<string> GetComponents()
        {
            return _components;
        }

        public string GetInfo()
        {
            var str = "Quadcopter:";
            Console.WriteLine(str);
            if (str == "")
            {
                throw new NotImplementedException();
            }

            return str;
        }
    }


}
