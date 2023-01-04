using System;

namespace HomeWork_CSharp.Models
{
    public struct Worker
    {
        #region Поля

        private int _id;
        private DateTime _created;
        private string _fullName;
        private byte _height;
        private DateTime _birthDate;
        private string _birthPlace;

        #endregion
        

        #region Свойства

        /// <summary>
        /// ID сотрудника.
        /// </summary>
        public int Id { get => _id; }   
        /// <summary>
        /// Дата добавления сотрудника в базу данных.
        /// </summary>
        public DateTime Created { get => _created; }     
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
        /// <param name="id">ID сотрудника.</param>
        /// <param name="fullName">Полное ФИО сотрудника.</param>
        /// <param name="height">Рост сотрудника в см.</param>
        /// <param name="birthDate">Дата рождения сотрудника.</param>
        /// <param name="birthPlace">Место рождения сотрудника.</param>
        public Worker(int id, string fullName, byte height, DateTime birthDate, string birthPlace)
        {
            _id = id;
            _created = DateTime.Now;
            _fullName = fullName;
            _height = height;
            _birthDate = birthDate;
            _birthPlace = birthPlace;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ID сотрудника.</param>
        /// <param name="created">Дата добавления сотрудника.</param>
        /// <param name="fullName">Полное ФИО сотрудника.</param>
        /// <param name="height">Рост сотрудника в см.</param>
        /// <param name="birthDate">Дата рождения сотрудника.</param>
        /// <param name="birthPlace">Место рождения сотрудника.</param>
        public Worker(byte id, DateTime created, string fullName, byte height, DateTime birthDate, string birthPlace)
        {
            _id = id;
            _created = created;
            _fullName = fullName;
            _height = height;
            _birthDate = birthDate;
            _birthPlace = birthPlace;
        }

        #endregion


        #region Методы
            
        public override string ToString()
        {
            return $"{_id}#{_created.ToString("dd.MM.yyyy HH:mm")}#{_fullName}#" +
                $"{Age}#{_height}#{_birthDate.ToShortDateString()}#{_birthPlace}";
        }

        #endregion
    }
}