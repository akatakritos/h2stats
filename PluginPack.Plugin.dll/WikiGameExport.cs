using System;
using System.Collections.Generic;
using System.Text;
using H2Stats.Data;
using System.IO;

namespace CoBPack.Plugin
{
    public class WikiGameExport : H2Stats.Data.IGameExport
    {
        #region IGameEport Members

        public bool Export(HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier)
        {            
            bool error = false;
            WikiExportSetupForm f = new WikiExportSetupForm();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                error = performExport(f.CopyToClipboard, f.FileName, gameRow, haloInfoSupplier);
            f.Dispose();
            return error;
        }        

        public string Name
        {
            get { return "Wiki Game Export 1.0"; }
        }

        public string Description
        {
            get { return "By Matt Burke (CoB Leviathan): Exports single game data to wiki code for display in wiki user pages"; }
        }

        #endregion

        private bool performExport(bool copyClipboard, string file, HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier)
        {
            StringBuilder sBuilder = new StringBuilder(3000);

            #region Header 

            DateTime dt = DateTime.ParseExact(gameRow.Time, "HH:mm:ss", System.Globalization.DateTimeFormatInfo.CurrentInfo);
            string time = dt.ToString("h:m tt");


            //== Team ActionSack - Neutral Snipers - Foundation - 02/11/2006 11:38 PM ==
            sBuilder.AppendLine(string.Format("== {0} - {1} - {2} - {3} {4} ==", gameRow.Playlist, 
                gameRow.Matchtype, gameRow.Map, gameRow.Date, time));

            //{|
            //|- valign=top
            //|[[Image:Index Foundation.jpg]]
            //|'''[http://www.bungie.net/Stats/GameStats.aspx?gameID=419056208 Neutral Snipers game played at 02/11/2006 11:38 PM]'''
            //* Playlist: [[Team ActionSack]]
            //* [[Neutral Snipers]] on [[Foundation]] - [[Foundation/Neutral Snipers]] - [[Foundation/Carney Holes]]
            //* Game length: 00:19:58
            //|}

            sBuilder.AppendLine("{|");
            sBuilder.AppendLine("|- valign=top");
            sBuilder.AppendLine(string.Format("[[Image:Index {0}.jpg]]", gameRow.Map));
            sBuilder.AppendLine(string.Format("|'''[http://www.bungie.net/Stats/GameStats.aspx?gameID={0} {1} game played at {2} {3}]'''",
                gameRow.GameID, gameRow.Matchtype, gameRow.Date, time));
            sBuilder.AppendLine(string.Format("* Playlist: [[{0}]]", gameRow.Playlist));
            sBuilder.AppendLine(string.Format("* [[{0}]] on [[{1}]] - [[{1}/{0}]] - [[{1}/Carney Holes]]", gameRow.Matchtype, gameRow.Map));
            sBuilder.AppendLine("* Game length: " + GameLength.ToTimeString(gameRow.Length));
            sBuilder.AppendLine("|}");
            sBuilder.AppendLine();
            #endregion

            #region Team Table 
            bool scoreIsTime = gameRow.GetGamePlayerRows()[0].ScoreIsTime;
            if (gameRow.TeamGame)
            {
                Dictionary<string, int> teamScores = calculateTeamScores(gameRow);
                sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
                sBuilder.AppendLine("|- bgcolor='white' align=left");
                sBuilder.AppendLine("! !! !! width=200px | Team !! Score");
                int i = 0;
                foreach (string key in teamScores.Keys)
                {
                    sBuilder.AppendLine("|- bgcolor='white'");
                    if (i % 2 == 0)
                    {
                        if (scoreIsTime)
                        {
                            sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=\"#F2F2F2\" | {2} || bgcolor=\"#F2F2F2\" align=center | {3}",
                                key, i + 1, haloInfoSupplier.ColorInfo.FindByColorHex(key).Description, GameLength.ToTimeString(teamScores[key])));
                        }
                        else
                        {
                            sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=\"#F2F2F2\" | {2} || bgcolor=\"#F2F2F2\" align=center | {3}",
                                key, i + 1, haloInfoSupplier.ColorInfo.FindByColorHex(key).Description, teamScores[key]));
                        }
                    }
                    else
                    {
                        if (scoreIsTime)
                        {
                            sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=\"#E0E0E0\" | {2} || bgcolor=\"#E0E0E0\" align=center | {3}",
                                key, i + 1, haloInfoSupplier.ColorInfo.FindByColorHex(key).Description, GameLength.ToTimeString(teamScores[key])));
                        }
                        else
                        {
                            sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=\"#E0E0E0\" | {2} || bgcolor=\"#E0E0E0\" align=center | {3}",
                                key, i + 1, haloInfoSupplier.ColorInfo.FindByColorHex(key).Description, teamScores[key]));
                        }
                    }

                    i++;
                }
                sBuilder.AppendLine("|}");
                sBuilder.AppendLine();
                sBuilder.AppendLine();
            }
            #endregion

            createStatsTable(sBuilder, gameRow, haloInfoSupplier);
            createKillsTable(sBuilder, gameRow, haloInfoSupplier);
            createPvPTable(sBuilder, gameRow, haloInfoSupplier);
            createMedalsTable(sBuilder, gameRow, haloInfoSupplier);
            createHitsTable(sBuilder, gameRow, haloInfoSupplier);

            sBuilder.AppendLine();
            sBuilder.AppendLine();
            sBuilder.AppendFormat("Generated {0} by [[User:Leviathan 0x157|CoB Leviathan's]] unnamed Halo 2 stats tracker", DateTime.Now.ToShortDateString());

            string s = sBuilder.ToString();

            if (copyClipboard)
                System.Windows.Forms.Clipboard.SetText(s);
            if (file != "")
                File.WriteAllText(file, s);

            IconLookup.Dispose();

            return true;
        }

        private void createHitsTable(StringBuilder sBuilder, HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier)
        {
            sBuilder.AppendLine("'''Hits'''");
            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine("|- bgcolor='white'");
            sBuilder.AppendLine("! !! !! width=200px align=left | Gamertag !! Shots Hit !! Shots Fired !! Hit % !! Head Shots");

            int i = 0;
            foreach (HaloDataSet.GamePlayerRow p in gameRow.GetGamePlayerRows())
            {
                sBuilder.AppendLine("|- bgcolor='white'");
                if (i % 2 == 0)
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#F2F2F2 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#F2F2F2  align=center | {4} || bgcolor=#F2F2F2  align=center | {5} || bgcolor=#F2F2F2  align=center | {6} || bgcolor=#F2F2F2  align=center | {7}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, p.ShotsHit, p.ShotsFired, p.Accuracy, p.Headshots));
                }
                else
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#E0E0E0 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#E0E0E0  align=center | {4} || bgcolor=#E0E0E0  align=center | {5} || bgcolor=#E0E0E0  align=center | {6} || bgcolor=#E0E0E0  align=center | {7}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, p.ShotsHit, p.ShotsFired, p.Accuracy, p.Headshots));
                }
                i++;
            }
            sBuilder.AppendLine("|}");
            sBuilder.AppendLine();
        }

        private void createMedalsTable(StringBuilder sBuilder, HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier)
        {
            sBuilder.AppendLine("'''Medals'''");
            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine("|- bgcolor='white'");
            sBuilder.AppendLine("! !! !! width=200px align=left | Gamertag !! Medal Total !! Medals");
            int i = 0;
            foreach (HaloDataSet.GamePlayerRow p in gameRow.GetGamePlayerRows())
            {
                sBuilder.AppendLine("|- bgcolor='white'");

                if (i % 2 == 0)
                {
                    sBuilder.Append(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#F2F2F2 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#F2F2F2  align=center | {4} || bgcolor=#F2F2F2  align=center | ",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, p.TotalMedals));
                    writeMedals(sBuilder, p.GetGamePlayerMedalRows());
                }
                else
                {
                    sBuilder.Append(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#E0E0E0 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#E0E0E0  align=center | {4} || bgcolor=#E0E0E0  align=center | ",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, p.TotalMedals));
                    writeMedals(sBuilder, p.GetGamePlayerMedalRows());
                }
                i++;   
            }

            sBuilder.AppendLine("|}");
            sBuilder.AppendLine();
            sBuilder.AppendLine();
        }

        private void writeMedals(StringBuilder sBuilder, HaloDataSet.GamePlayerMedalRow[] gamePlayerMedalRows)
        {
            for (int i = 0; i < gamePlayerMedalRows.Length; i++)
            {
                HaloDataSet.GamePlayerMedalRow medal = gamePlayerMedalRows[i];
                sBuilder.Append(string.Format("{0} <site-image>{1}</site-image>", medal.Count, IconLookup.GetIcon(medal.MedalName)));
                if (i < gamePlayerMedalRows.Length - 1)
                    sBuilder.Append(" + ");
                
            }
            sBuilder.AppendLine();
        }

        private void createPvPTable(StringBuilder sBuilder, HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier)
        {
            sBuilder.AppendLine("'''P. v. P.'''");
            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine("|- bgcolor='white'");
            sBuilder.AppendLine("! !! !! width=200px align=left | Gamertag !! Most Killed By !! Most Killed !! <br>");
            int i = 0;
            foreach (HaloDataSet.GamePlayerRow p in gameRow.GetGamePlayerRows())
            {
                sBuilder.AppendLine("|- bgcolor='white'");

                if (i % 2 == 0)
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#F2F2F2 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#F2F2F2  align=center | {4} || bgcolor=#F2F2F2  align=center | {5}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag,  p.MostKilledBy, p.MostKilled));
                }
                else
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#E0E0E0 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#E0E0E0  align=center | {4} || bgcolor=#E0E0E0  align=center | {5}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, p.MostKilledBy, p.MostKilled));
                }

                i++;
            }
            sBuilder.AppendLine("|}");
            sBuilder.AppendLine();
            sBuilder.AppendLine();
        }

        private void createKillsTable(StringBuilder sBuilder, HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier)
        {
            sBuilder.AppendLine("'''Kills'''");
            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine("|- bgcolor='white'");
            sBuilder.AppendLine("! !! !! width=200px align=left | Gamertag !! Kills !! Assists !! Deaths !! Suicides");
            int i = 0;
            foreach (HaloDataSet.GamePlayerRow p in gameRow.GetGamePlayerRows())
            {
                sBuilder.AppendLine("|- bgcolor='white'");

                if (i % 2 == 0)
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#F2F2F2 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#F2F2F2  align=center | {4} || bgcolor=#F2F2F2  align=center | {5} || bgcolor=#F2F2F2  align=center | {6} || bgcolor=#F2F2F2  align=center | {7}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, p.Kills, p.Assists, p.Deaths, p.Suicides));
                }
                else
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#E0E0E0 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#E0E0E0  align=center | {4} || bgcolor=#E0E0E0  align=center | {5} || bgcolor=#E0E0E0  align=center | {6} || bgcolor=#E0E0E0  align=center | {7}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, p.Kills, p.Assists, p.Deaths, p.Suicides));
                }
                i++;
            }
            sBuilder.AppendLine("|}");
            sBuilder.AppendLine();
            sBuilder.AppendLine();
        }

        private void createStatsTable(StringBuilder sBuilder, HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier)
        {
            HaloDataSet.GamePlayerRow[] gamePlayers = gameRow.GetGamePlayerRows();
            
            sBuilder.AppendLine("'''Stats'''");
            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine("|- bgcolor='white'");
            sBuilder.AppendLine(string.Format("! !!  !!  !! width=200px align=left | Gamertag !! {0} !! {1} !! Score",
                gamePlayers[0].Stat1Name, gamePlayers[0].Stat2Name));
            sBuilder.AppendLine("|- bgcolor='white'");
            
            int i = 0;
            foreach (HaloDataSet.GamePlayerRow p in gamePlayers)
            {
                string stat1, stat2, score;
                if (p.Stat1IsTime)
                    stat1 = GameLength.ToTimeString(p.Stat1Value);
                else
                    stat1 = p.Stat1Value.ToString();

                if (p.Stat2IsTime)
                    stat2 = GameLength.ToTimeString(p.Stat2Value);
                else
                    stat2 = p.Stat2Value.ToString();

                if (p.ScoreIsTime)
                    score = GameLength.ToTimeString(p.Score);
                else
                    score = p.Score.ToString();

                if (i % 2 == 0)
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#F2F2F2 align=right  | || bgcolor=#F2F2F2 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#F2F2F2  align=center | {4} || bgcolor=#F2F2F2  align=center | {5} || bgcolor=#F2F2F2  align=center | {6}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, stat1, stat2, score));
                }
                else
                {
                    sBuilder.AppendLine(string.Format("| bgcolor=#{0} | || {1} || bgcolor=#E0E0E0 align=right |  || bgcolor=#E0E0E0 | [http://www.bungie.net/Stats/PlayerStats.aspx?player={2} {3}] || bgcolor=#E0E0E0  align=center | {4} || bgcolor=#E0E0E0  align=center | {5} || bgcolor=#E0E0E0  align=center | {6}",
                        p.ColorHex, p.Place, encodeForUrl(p.Gamertag), p.Gamertag, stat1, stat2, score));
                }
                sBuilder.AppendLine("|- bgcolor='white'");
                i++;
                
            }
            sBuilder.AppendLine("|}");
            sBuilder.AppendLine();
            sBuilder.AppendLine();
        }

        private Dictionary<string,int> calculateTeamScores(HaloDataSet.GameRow gameRow)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (HaloDataSet.GamePlayerRow p in gameRow.GetGamePlayerRows())
            {
                if (dict.ContainsKey(p.ColorHex))
                    dict[p.ColorHex] += p.Score;
                else
                    dict.Add(p.ColorHex, p.Score);
            }
            return dict;
        }

        string encodeForUrl(string s)
        {
            return s.Replace(" ", "%20");
        }
    }
}
