using System;

namespace HomeWork_CSharp.Job
{
    /// <summary>
    /// Класс, описывающий работника.
    /// </summary>
    public class Employee
    {
        #region Поля

        private string _fullName;
        private byte _height;
        private DateTime _birthDate;
        private string _birthPlace;

        #endregion
        

        #region Свойства
        
        /// <summary>
        /// Фамилия, имя и отчество сотрудника.
        /// </summary>
        public string FullName { get => _fullName; }
        /// <summary>
        /// Возраст сотрудника.
        /// </summary>
        public byte Age { get => (byte)(DateTime.Now.Year - _birthDate.Year); }
        /// <summary>
        /// Рост сотрудника.
        /// </summary>
        public byte Height { get => _height; }
        /// <summary>
        /// Дата рождения сотрудника.
        /// </summary>
        public DateTime BirthDate { get => _birthDate; }
        /// <summary>
        /// Место рождения сотрудника.
        /// </summary>
        public string BirthPlace { get => _birthPlace; }

        #endregion
    
    
        #region Конструкторы
            
        /// <summary>
        /// Создание нового сотрудника.
        /// </summary>
        /// <param name="fullName">Полное ФИО сотрудника.</param>
        /// <param name="height">Рост сотрудника в см.</param>
        /// <param name="birthDate">Дата рождения сотрудника.</param>
        /// <param name="birthPlace">Место рождения сотрудника.</param>
        public Employee(string fullName, byte height, DateTime birthDate, string birthPlace)
        {
            _fullName = fullName;
            _height = height;
            _birthDate = birthDate;
            _birthPlace = birthPlace;
        }

        #endregion
    }
}