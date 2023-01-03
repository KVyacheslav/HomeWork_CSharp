using System;
using HomeWork_CSharp.Services;

namespace HomeWork_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
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
                    EmployeeRecords.PrintInfoOfEmployees();
                    break;
                case "2":
                    EmployeeRecords.ToCreateRecordOfEmployee();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            
        }
    }
}
