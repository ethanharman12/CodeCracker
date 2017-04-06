using System;

namespace Code2
{
    public class GameTimer
    {
        public double SecondsElapsed { get; set; }
        public DateTime? StartTime { get; set; }
        
        public double GetCurrentSecondsElapsed()
        {
            if (StartTime != null)
            {
                var span = DateTime.Now.Subtract(StartTime.Value);

                return SecondsElapsed + span.TotalSeconds;
            }

            return SecondsElapsed;
        }

        public void Pause()
        {
            if (StartTime != null)
            {
                var span = DateTime.Now.Subtract(StartTime.Value);
                SecondsElapsed += span.TotalSeconds;
                StartTime = null;
            }
        }

        public void Start()
        {
            StartTime = DateTime.Now;
        }
    }
}
