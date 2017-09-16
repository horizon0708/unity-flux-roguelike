using System.Timers;
using UnityEngine;

namespace MyRogueLike
{
    public class PipeGenerator
    {
        public int Difficulty;
        public float Interval;
        public float Speed;

        private Timer _timer;

        public PipeGenerator(float interval)
        {
            Interval = interval;
            setTimer(Interval);
        }

        public void setTimer(double time)
        {
            _timer = new Timer(time);
            _timer.Elapsed += new ElapsedEventHandler(CreatePipes);
            _timer.Interval = Interval;
            _timer.Enabled = true;
        }

        private static void CreatePipes(object source, ElapsedEventArgs e)
        {
            Debug.Log("pipe");          
        }
    }
}