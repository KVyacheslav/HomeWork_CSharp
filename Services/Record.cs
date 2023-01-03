using System;
using HomeWork_CSharp.Job;

namespace HomeWork_CSharp.Services
{
    /// <summary>
    /// Класс, описывающий запись сотрудника.
    /// </summary>
    public class Record
    {
        #region Поля
        
        private byte _id;
        private DateTime _created;
        private Employee _emp;

        #endregion


        #region Свойства

        /// <summary>
        /// Id записи.
        /// </summary>
        public byte Id { get => _id; }
        /// <summary>
        /// Дата создания записи.
        /// </summary>
        public DateTime Created { get => _created; }
        /// <summary>
        /// Сотрудник.
        /// </summary>\
        public Employee Employee { get => _emp; }
            
        #endregion
    
        
        #region Конструкторы

        public Record(byte id, Employee employee)
        {
            _id = id;
            _created = DateTime.Now;
            _emp = employee;
        }

        public Record(byte id, DateTime created, Employee employee)
        {
            _id = id;
            _created = created;
            _emp = employee;
        }

        #endregion


        #region Методы

        public override string ToString()
        {
            return $"{_id}#{_created.ToString("dd.MM.yyyy HH:mm")}#{_emp.FullName}#" +
                $"{_emp.Age}#{_emp.Height}#{_emp.BirthDate.ToShortDateString()}#{_emp.BirthPlace}";
        }


        #endregion
    }
}