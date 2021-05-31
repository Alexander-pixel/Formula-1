using System;
using System.Security.AccessControl;

namespace Formula_1
{
    public class Season
    {
        private int _year;
        private Team[] _teams = new Team[10];
        private int _raceNumber = 0;

        public Season()
        {
            _year = 0;
            _raceNumber = 0;
        }

        public Season(int year, Team[] teams, int raceNumber)
        {
            _year = year;
            _teams = teams;
            _raceNumber = raceNumber;
        }

        public int GetYear() => _year;
        public void SetYear(int year)
        {
            try
            {
                if (year <= 0)
                {
                    year = 0;
                    throw new ArgumentOutOfRangeException("Wrong year input");
                }
                else
                {
                    _year = year;
                }
            }
            catch (Exception e) when (year != 0)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetRaceNumber() => _raceNumber;

        public void Race()
        {
            int[] points = new int[10]{1, 2, 4, 6, 8, 10, 12, 15, 18, 25};
            Random rand = new Random();
            int pos_team = 0;
            
            for (int i = 0; i < _raceNumber; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (rand.Next() % 2 == 0)
                    {
                        pos_team = rand.Next(0, 10);
                        if (_teams[pos_team].GetPilot1().GetPoint(i) != 0)
                        {
                            while (_teams[pos_team].GetPilot1().GetPoint(i) != 0)
                            {
                                pos_team = rand.Next(0, 10);
                            }
                        }
                        _teams[pos_team].GetPilot1().AddPoint(points[j], i);
                    }
                    else
                    {
                        pos_team = rand.Next(0, 10);
                        if (_teams[pos_team].GetPilot2().GetPoint(i) != 0)
                        {
                            while (_teams[pos_team].GetPilot2().GetPoint(i) != 0)
                            {
                                pos_team = rand.Next(0, 10);
                            }
                        }
                        _teams[pos_team].GetPilot2().AddPoint(points[j], i);
                    }
                }
            }
        }
        public Pilot GetPilot(int pos)
        {
            try
            {
                Pilot[] buf = new Pilot[20];
                int counter = 0;
                for (int i = 0; i < buf.Length; i += 2)
                {
                    buf[i] = _teams[counter].GetPilot1();
                    buf[i + 1] = _teams[counter++].GetPilot2();
                }

                bool swapped = false;
                do
                {
                    swapped = false;
                    for (int i = 1; i < buf.Length; i++)
                    {
                        if (buf[i - 1].GetPointsSum() < buf[i].GetPointsSum())
                        {
                            (buf[i - 1], buf[i]) = (buf[i], buf[i - 1]);
                            swapped = true;
                        }
                    }
                } while (swapped != false);

                return buf[pos];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public Pilot Leader()
        {
            Pilot leader = _teams[0].GetPilot1();
            for (int i = 0; i < _teams.Length; i++)
            {
                if (leader.GetPointsSum() < _teams[i].GetTeamLeader().GetPointsSum())
                {
                    leader = _teams[i].GetTeamLeader();
                }
            }

            return leader;
            //return GetPilot(0);
        }

        public int GetPoints(Pilot obj)
        {
            return obj.GetPointsSum();
        }

        public double GetAvgPoints(Pilot obj)
        {
            try
            {
                return obj.GetPointsSum() / _raceNumber;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            return -1;
        }
        
    }
}