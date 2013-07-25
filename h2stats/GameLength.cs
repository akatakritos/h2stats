using System;
using System.Collections.Generic;
using System.Text;

namespace H2Stats
{
    public struct GameLength
    {
        private int seconds;
        
        public GameLength(int seconds)
        {
            this.seconds = seconds;
        }

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        public override string ToString()
        {
            return ToTimeString(seconds);
        }

        public static explicit operator int(GameLength g)
        {
            return g.seconds;
        }

        public static explicit operator GameLength(int seconds)
        {
            return new GameLength(seconds);
        }

        public static string ToTimeString(int seconds)
        {
            int h, m, s;
            s = seconds % 60;
            seconds -= s;

            //seconds /= 60;
            m = (seconds / 60) % 60;
            seconds -= m * 60;

            h = seconds / 3600;

            string time = h.ToString() + ":";

            if (m < 10)
                time += "0";

            time += m.ToString() + ":";

            if (s < 10)
                time += "0";

            time += s.ToString();

            return time;
        }
    }
}
