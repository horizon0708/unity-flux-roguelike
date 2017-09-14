using System.Timers;
using UnityEngine;

namespace MyRogueLike
{
    public class PipeGenerator
    {
        public int Difficulty;

        private Timer _timer;

        public PipeGenerator()
        {
            setTimer(2);
        }

        public void setTimer(double time)
        {
            _timer = new Timer(time);
            _timer.Elapsed += new ElapsedEventHandler(CreatePipes);
            _timer.Interval = 5000;
            _timer.Enabled = true;
        }

        private static void CreatePipes(object source, ElapsedEventArgs e)
        {
            Debug.Log("hello");          
        }
    }
}