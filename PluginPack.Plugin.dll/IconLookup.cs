using System;
using System.Collections.Generic;
using System.Text;

namespace CoBPack.Plugin
{
    internal static class IconLookup
    {
        static Dictionary<string, string> iconLookup;
        public static string GetIcon(string medalName)
        {
            if (iconLookup == null)
                createDictionary();

            return iconLookup[medalName];
        }

        private static void createDictionary()
        {
            iconLookup = new Dictionary<string, string>(22);
            iconLookup.Add("Double Kill", "multiple_kill_2.gif");
            iconLookup.Add("Triple Kill", "multiple_kill_3.gif");
            iconLookup.Add("Killtacular", "multiple_kill_4.gif");
            iconLookup.Add("Kill Frenzy", "multiple_kill_5.gif");
            iconLookup.Add("Killtrocity", "multiple_kill_6.gif");
            iconLookup.Add("Killing Spree", "kills_in_a_row_5.gif");
            iconLookup.Add("Running Riot", "kills_in_a_row_10.gif");
            iconLookup.Add("Rampage", "kills_in_a_row_15.gif");
            iconLookup.Add("Berserker", "kills_in_a_row_20.gif");
            iconLookup.Add("Overkill", "kills_in_a_row_25.gif");
            iconLookup.Add("Bonecracker", "bash_kill.gif");
            iconLookup.Add("Assassin", "stealth_kill.gif");
            iconLookup.Add("Sniper Kill", "sniper_kill.gif");
            iconLookup.Add("Carjacking", "boarded_vehicle.gif");
            iconLookup.Add("Stick It", "grenade_stick.gif");
            iconLookup.Add("Roadkill", "collision_kill.gif");
            iconLookup.Add("Bomb Carrier Kill", "ctf_bomb_carrier_kill.gif");
            iconLookup.Add("Bomb Planted", "ctf_bomb_planted.gif");
            iconLookup.Add("Flag Carrier Kill", "ctf_flag_carrier_kill.gif");
            iconLookup.Add("Flag Returned", "ctf_flag_returned.gif");
            iconLookup.Add("Flag Taken", "ctf_flag_grab.gif");
            iconLookup.Add("Killimanjaro", "multiple_kill_7_or_more.gif");
        }

        public static void Dispose()
        {
            if (iconLookup != null)
            {
                iconLookup.Clear();
                iconLookup = null;
            }
        }

    }
}
