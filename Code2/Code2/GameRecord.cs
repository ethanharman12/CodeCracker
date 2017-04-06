using System.Collections.Generic;
using System.Linq;

namespace Code2
{
    public class GameRecord
    {
        public double Slowest
        {
            get { return Times.Max(); }
        }

        public double Fastest
        {
            get { return Times.Min(); }
        }

        public int TimesPlayed
        {
            get { return Times.Count; }
        }

        private List<double> times;

        public List<double> Times
        {
            get { return times; }
            set { times = value; }
        }

        public void AddTime(double time)
        {
            Times.Add(time);
        }

        public GameRecord(List<double> times)
        {
            Times = times;
        }        
    }
}
