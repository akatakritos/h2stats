using System;
using System.Collections.Generic;
using System.Text;

namespace H2Stats.Data
{
    /// <summary>
    /// Converts between a number of seconds and a formatted time string
    /// </summary>
    public struct GameLength
    {
        private int seconds;
        
        /// <summary>
        /// Creates a new GameLength from a specified number of seconds
        /// </summary>
        /// <param name="seconds"></param>
        public GameLength(int seconds)
        {
            this.seconds = seconds;
        }

        /// <summary>
        /// Gets the seconds
        /// </summary>
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        /// <summary>
        /// Generates a formatted string in "H:m:s" format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToTimeString(seconds);
        }

        /// <summary>
        /// Cast GameLength to int
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static explicit operator int(GameLength g)
        {
            return g.seconds;
        }

        /// <summary>
        /// Cast int to GameLength
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static explicit operator GameLength(int seconds)
        {
            return new GameLength(seconds);
        }

        /// <summary>
        /// Converts a number of seconds to a "h:m:s" formatted string
        /// </summary>
        /// <param name="seconds">number of seconds</param>
        /// <returns></returns>
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
