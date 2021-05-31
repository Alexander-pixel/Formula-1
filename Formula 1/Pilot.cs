using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace Formula_1
{
    public class Pilot
    {
        private string _name;
        private int _age;
        private string _team;
        private int [] _arr = new int[20];
        
        public Pilot()
        {
            _name = String.Empty;
            _age = 0;
            _team = string.Empty;
        }

        public int GetPointsSum()
        {
            /*int sum = 0;
            for (int i = 0; i < _arr.Length; i++)
            {
                sum += _arr[i];
            }*/
            
            return _arr.Sum();
        }

        public Pilot(string name, string team, int age)
        {
            _name = name;
            _team = team;
            
            try
            {
                if (age <= 0)
                {
                    age = 0;
                    throw new Exception("Wrong age input.");
                }
                else
                {
                    _age = age;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddPoint(int point, int pos)
        {
            _arr[pos] = point;
        }

        public int GetPoint(int pos)
        {
            return _arr[pos];
        }
        

        public string GetName() => _name;
        public void SetName(string name) => _name = name;

        public int GetAge() => _age;
        public void SetAge(int age)
        {
            try
            {
                if (age <= 0)
                {
                    age = 0;
                    throw new Exception("Wrong age input.");
                }
                else
                {
                    _age = age;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetTeam() => _team;
        public void SetTeam(string team) => _team = team;

        public override string ToString()
        {
            return $"Name: {_name}\n" +
                   $"Age: {_age}\n" +
                   $"Team: {_team}";
        }
    }
}