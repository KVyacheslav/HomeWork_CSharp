using System;
using HomeWork_CSharp.Data;

namespace HomeWork_CSharp
{
    class Program
    {
        private static Repository _rep;

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            _rep = new Repository();

            while(true)
            {
                Console.WriteLine("\n***** Главное меню *****\n");
                Console.WriteLine("1) Показать список всех сотрудников.");
                Console.WriteLine("2) Добавить новую запись о сотруднике.");
                Console.WriteLine("\n========================\n");
                Console.Write("Введите номер пункта: ");
                UserInput();
            }
        }

        private static void UserInput()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    _rep.PrintAllWorkers();
                    break;
                case "2":
                    AddWorkerInRepository();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            
        }

        private static void AddWorkerInRepository()
        {
            Console.Write("Введите ФИО сотрудника: ");
            var fullName = Console.ReadLine();
            Console.Write("Введите рост сотрудника: ");
            var height = byte.Parse(Console.ReadLine());
            Console.Write("Введите дату рождения сотрудника: ");
            var birthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите место рождения сотрудника: ");
            var birthPlace = Console.ReadLine();
            _rep.AddWorker(fullName, height, birthDate, birthPlace);
        }
    }
}
