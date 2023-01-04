using System;
using System.IO;
using System.Linq;
using HomeWork_CSharp.Models;

namespace HomeWork_CSharp.Data
{
    public class Repository
    {
        private readonly string _path = "workers.txt";
        private int _count = -1;
        private Worker[] _workers;

        public Worker this[int index] { get => _workers[index]; }


        public Repository()
        {
            _workers = GetAllWorkers();
        }

        public Repository(params Worker[] workers)
        {
            _workers = workers;
        }

        public void PrintAllWorkers()
        {
            Console.WriteLine();
            foreach (var worker in _workers)
            {
                if(!string.IsNullOrWhiteSpace(worker.FullName))
                    Console.WriteLine(worker);
            }
        }

        public Worker[] GetAllWorkers()
        {
            if (File.Exists(_path))
            {
                var data = File.ReadAllLines(_path);
                _workers = new Worker[data.Length];
                foreach (var line in data)
                {
                    var tmp = line.Split('#');
                    var id = byte.Parse(tmp[0]);
                    var created = DateTime.Parse(tmp[1]);
                    var fullName = tmp[2];
                    var height = byte.Parse(tmp[4]);
                    var birthDate = DateTime.Parse(tmp[5]);
                    var birthPlace = tmp[6];
                    var worker = new Worker(id, fullName, height, birthDate, birthPlace);
                    ResizeRepository();
                     _workers[++_count] = worker;
                }
            }
            else
            {
                File.Create(_path).Close();
                _workers = new Worker[0];
            }

            return _workers;
        }

        private void ResizeRepository()
        {
            if (_count + 1 >= _workers.Length)
            {
                Array.Resize<Worker>(ref _workers, _workers.Length * 2);
            }
        }

        public Worker GetWorkerById(int id)
        {
            return _workers.First(w => id == w.Id);
        }

        public void DeleteWorker(int id)
        {
            if (File.Exists(_path))
            {                
                var data = File.ReadAllLines(_path);
                var strId = id.ToString();
                var tmpWorkers = new string[data.Length - 1];
                var tmpCount = 0;
                foreach (var line in data)
                {
                    var _id = line.Split('#')[0];

                    if (_id.Equals(strId))
                        continue;
                    
                    tmpWorkers[tmpCount++] = line;
                }

                File.WriteAllLines(_path, tmpWorkers);
                _workers = GetAllWorkers();
            }
        }

        public void AddWorker(string fullName, byte height, DateTime birthDate, string birthPlace)
        {
            var worker = new Worker(_count + 2, fullName, height, birthDate, birthPlace);
            ResizeRepository();
            _workers[++_count] = worker;
            File.AppendAllText(_path, worker.ToString() + "\n");
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            if (File.Exists(_path))
            {                
                var data = File.ReadAllLines(_path);
                _workers = new Worker[data.Length];
                _count = -1;
                foreach (var line in data)
                {
                    var tmp = line.Split("#");
                    var created = DateTime.Parse(tmp[1]);
                    if (dateFrom <= created && dateTo >= created )
                    {
                        var id = byte.Parse(tmp[0]);
                        var fullName = tmp[2];
                        var height = byte.Parse(tmp[4]);
                        var birthDate = DateTime.Parse(tmp[5]);
                        var birthPlace = tmp[6];
                        var worker = new Worker(id, created, fullName, height, birthDate, birthPlace);
                        _workers[++_count] = worker;
                    }
                }
                return _workers;
            }
            else 
            {
                return new Worker[0];
            }
        }
    }
}