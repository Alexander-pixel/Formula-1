using System;
using System.CodeDom.Compiler;

namespace Formula_1
{
    public class Team
    {
        private string _title;
        private Pilot _pilot1;
        private Pilot _pilot2;

        public Team()
        {
            _title = String.Empty;
            _pilot1 = new Pilot();
            _pilot2 = new Pilot();
        }

        public Team(string title, Pilot pilot1, Pilot pilot2)
        {
            _title = title;
            _pilot1 = pilot1;
            _pilot2 = pilot2;
        }

        public void SetPilot1(Pilot pilot1)
        {
            _pilot1 = pilot1;
        }
        public void SetPilot2(Pilot pilot2)
        {
            _pilot2 = pilot2;
        }

        public Pilot GetPilot1() => _pilot1;
        public Pilot GetPilot2() => _pilot2;

        public string GetTitle() => _title;
        public void SetTitle(string title) => _title = title;

        public Pilot GetTeamLeader()
        {
            return _pilot1.GetPointsSum() > _pilot2.GetPointsSum() ? _pilot1 : _pilot2;
        }

        

    }
}