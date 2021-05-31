using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Formula_1
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Pilot pilot1 = new Pilot(name: "Льюис Хэмилтон", team: "Mercedes", 36); // ok
            Pilot pilot2 = new Pilot("Валттери Боттас", "Mercedes", 31); // ok
            
            Pilot pilot3 = new Pilot(name: "Карлос Сайнс", team: "Ferrari", 26); // ok
            Pilot pilot4 = new Pilot("Шарль Леклер", "Ferrari", 23); // ok
            
            Pilot pilot5 = new Pilot(name: "Лэнс Стролл", team: "ASTON MARTIN", 22); // ok
            Pilot pilot6 = new Pilot("Себастьян Феттель", "ASTON MARTIN", 33); // ok
            
            Pilot pilot7 = new Pilot(name: "Даниэль Риккардо", team: "MCLAREN", 31); // ok
            Pilot pilot8 = new Pilot("Ландо Норрис", "MCLAREN", 21); // ok
            
            Pilot pilot9 = new Pilot(name: "Фернандо Алонсо", team: "RENAULT / ALPINE", 39); // ok
            Pilot pilot10 = new Pilot("Эстебан Окон", "RENAULT / ALPINE", 24); // ok
            
            Pilot pilot11 = new Pilot(name: "Пьер Гасли", team: "ALPHATAURI", 25); // ok
            Pilot pilot12 = new Pilot("Юки Цунода", "ALPHATAURI", 20); // ok
            
            Pilot pilot13 = new Pilot(name: "Серхио Перес", team: "RED BULL RACING", 31);
            Pilot pilot14 = new Pilot("Макс Ферстаппен", "RED BULL RACING", 23);
            
            Pilot pilot15 = new Pilot(name: "Кими Райкконен", team: "ALFA ROMEO", 41); // ok
            Pilot pilot16 = new Pilot("Антонио Джовинацци", "ALFA ROMEO", 27); // ok
            
            Pilot pilot17 = new Pilot(name: "Никита Мазепин", team: "HAAS", 22); // ok
            Pilot pilot18 = new Pilot("Мик Шумахер", "HAAS", 22); // ok
            
            Pilot pilot19 = new Pilot(name: "Джордж Расселл", team: "WILLIAMS", 23); // ok
            Pilot pilot20 = new Pilot("Николас Латифи", "WILLIAMS", 25); // ok

            Team[] teams =
            {
                new Team("Mercedes", pilot1, pilot2), new Team("Ferrari", pilot3, pilot4),
                new Team("Aston Martin", pilot5, pilot6), new Team("Mclaren", pilot7, pilot8),
                new Team("RENAULT / ALPINE", pilot9, pilot10), new Team("ALPHATAURI", pilot11, pilot12),
                new Team("RED BULL RACING", pilot13, pilot14), new Team("Alfa Romeo", pilot15, pilot16),
                new Team("HAAS", pilot17, pilot18), new Team("Williams", pilot19, pilot20)
            };
            
            
            Season season1 = new Season(2021, teams, 10);
            season1.Race();
            for (int i = 0; i < teams.Length; i++)
            {
                Console.WriteLine("Race " + i+" :");
                Console.WriteLine($"Team: {teams[i].GetTitle()}");
                Console.WriteLine($"Pilot_1 name: {teams[i].GetPilot1().GetName()} - points: {season1.GetPoints(teams[i].GetPilot1())}");
                Console.WriteLine($"Pilot_2 name: {teams[i].GetPilot2().GetName()} - points: {season1.GetPoints(teams[i].GetPilot2())}");
                Console.WriteLine();
            }
            Console.WriteLine($"Leader name: {season1.GetPilot(0).GetName()}");
            Console.WriteLine($"Leader points: {season1.GetPilot(0).GetPointsSum()}");

            
        }
    }
}