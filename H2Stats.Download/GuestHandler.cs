using System;
using System.Collections.Generic;
using System.Text;

namespace H2Stats.Downloader
{
    class GuestHandler
    {
        private static Dictionary<string, int> guestLookup = new Dictionary<string, int>();

        //public GuestHandler()
        //{
        //    gamertags = new List<string>();
        //    nextGuestNumbers = new List<int>();
        //}

        public static string GetNextGuestNumber(string gamertag)
        {
            if (gamertag.Contains("(G)"))
            {
                gamertag = gamertag.Substring(0, gamertag.IndexOf("("));
                if (guestLookup.ContainsKey(gamertag))
                {
                    guestLookup[gamertag]++;
                    gamertag += "(G" + guestLookup[gamertag] + ")";                    
                }
                else
                {
                    guestLookup.Add(gamertag, 1);
                    return gamertag + "(G1)";
                }
            }

            return gamertag;
        }

        public static void Reset()
        {
            guestLookup.Clear();
        }
    }
}
