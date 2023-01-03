using System;
using System.IO;
using System.Collections.Generic;
using HomeWork_CSharp.Job;

namespace HomeWork_CSharp.Services
{
    /// <summary>
    /// Записи сотрудников.
    /// </summary>
    public static class EmployeeRecords
    {
        #region Поля

        private static byte _count;
        private static List<Record> _records;
        private readonly static string _filename = "employees.txt";

        #endregion
    

        #region Конструкторы

        static EmployeeRecords()
        {
            ToReadRecords();
        }
            
        #endregion
    
    
        #region Методы

        /// <summary>
        /// Считать данные о сотрудниках.
        /// </summary>
        private static void ToReadRecords()
        {
            _records = new List<Record>();

            if (!File.Exists(_filename))
            {    
                _count = 0;
                File.Create(_filename).Close();
                return;
            }

            var data = File.ReadAllLines(_filename);

            ToParseToRecord(data);
        }

        /// <summary>
        /// Преобразование данных в записи о сотрудниках.
        /// </summary>
        /// <param name="data"></param>
        private static void ToParseToRecord(string[] data)
        {
            foreach (var line in data)
            {
                var dataLine = line.Split('#');

                var id = byte.Parse(dataLine[0]);
                var created = DateTime.Parse(dataLine[1]);

                var fullName = dataLine[2];
                var height = byte.Parse(dataLine[4]);
                var birthDate = DateTime.Parse(dataLine[5]);
                var birthPlace = dataLine[6];

                var employee = new Employee(fullName, height, birthDate, birthPlace);
                var record = new Record(id, created, employee);

                _records.Add(record);
                _count = id;
            }
        }

        /// <summary>
        /// Вывести записи о пользователяъх.
        /// </summary>
        public static void PrintInfoOfEmployees()
        {
            Console.WriteLine("\n***** Список данных сотрудников *****\n");
            _records.ForEach(Console.WriteLine);
            Console.WriteLine("\n=====================================\n");
        }

        /// <summary>
        /// Добавить запись о сотруднике.
        /// </summary>
        public static void ToCreateRecordOfEmployee() 
        {
            Console.WriteLine("\n***** Добавление новой записи о сотруднике *****\n");
            Console.Write("Введите ФИО сотрудника: ");
            var fullName = Console.ReadLine();
            Console.Write("Введите рост сотрудника: ");
            var height = byte.Parse(Console.ReadLine());            
            Console.Write("Введите дату рождения сотрудника: ");
            var birthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите место рождения сотрудника: ");
            var birthPlace = Console.ReadLine();

            var emp = new Employee(fullName, height, birthDate, birthPlace);
            var record = new Record(++_count, DateTime.Now, emp);

            _records.Add(record);
            File.AppendAllText(_filename, record.ToString() + "\n");

            Console.WriteLine("\n================================================\n");
        }

        #endregion
    }
}