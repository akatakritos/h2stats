using System;
using System.Collections.Generic;
using System.Text;
using H2Stats.Data.HaloDataSetTableAdapters;
using H2Stats.Downloader;
using H2Stats.Data;
using System.Text.RegularExpressions;
using H2Stats.Downloader.Properties;
using System.Globalization;

namespace H2Stats.Downloader
{
    public class Parse
    {
        private static string parseText(string htmlline)
        {
            Match m = Regex.Match(htmlline, ">([^<]+)<");
            return m.Groups[1].Value.Trim();
        }

        private static bool fillPage1Stats(HaloDataSet.GamePlayerRow gamePlayer, string html)
        {
            string s = parseText(html);
            return false;
        }

        private static short parseTime(string s)
        {
            DateTime t = DateTime.ParseExact(s, Settings.Default.TimeFormat, DateTimeFormatInfo.CurrentInfo);
            return (short)((t.Hour * 3600) + (t.Minute * 60) + t.Second);
        }

        public static bool CreateAndFillGamePlayerTable(HaloDataSet.GameRow game, HaloDataSet.GamePlayerDataTable gamePlayers, string page1html)
        {
            GuestHandler.Reset();
            MatchCollection gamerList = Regex.Matches(page1html, Settings.Default.FindGamertagsRegex);
            for (int i = 0; i < gamerList.Count; i++)
            {
                HaloDataSet.GamePlayerRow gamePlayer = gamePlayers.NewGamePlayerRow();
                gamePlayer.GameID = game.GameID;
                gamePlayer.Gamertag = GuestHandler.GetNextGuestNumber(gamerList[i].Groups[1].Value);

                int webIndex = i + 1;

                gamePlayer.Stat1Name = Regex.Match(page1html, Settings.Default.FindStat1NameRegex).Groups[1].Value;
                gamePlayer.Stat2Name = Regex.Match(page1html, Settings.Default.FindStat2NameRegex).Groups[1].Value;

                string temp;

                if (game.Gametype.Contains("Slayer"))
                {
                    gamePlayer.Stat1IsTime = true;
                    gamePlayer.Stat2IsTime = false;
                    gamePlayer.ScoreIsTime = false;
                }
                else if (game.Gametype.Contains("KOTH"))
                {
                    gamePlayer.Stat1IsTime = false;
                    gamePlayer.Stat2IsTime = false;
                    gamePlayer.ScoreIsTime = true;
                }
                else if (game.Gametype.Contains("Oddball"))
                {
                    gamePlayer.Stat1IsTime = false;
                    gamePlayer.Stat2IsTime = false;
                    gamePlayer.ScoreIsTime = true;
                }
                else if (game.Gametype.Contains("Territories"))
                {
                    gamePlayer.Stat1IsTime = false;
                    gamePlayer.Stat2IsTime = false;
                    gamePlayer.ScoreIsTime = true;
                }
                else
                {
                    gamePlayer.Stat1IsTime = false;
                    gamePlayer.Stat2IsTime = false;
                    gamePlayer.ScoreIsTime = false;
                }

                temp = Regex.Match(page1html, String.Format(Settings.Default.FindStat1ValueRegex, webIndex)).Groups[1].Value;

                if (gamePlayer.Stat1IsTime)
                    gamePlayer.Stat1Value = parseTime(temp);
                else
                    gamePlayer.Stat1Value = short.Parse(temp);

                temp = Regex.Match(page1html, String.Format(Settings.Default.FindStat2ValueRegex, webIndex)).Groups[1].Value;
                if (gamePlayer.Stat2IsTime)
                    gamePlayer.Stat2Value = parseTime(temp);
                else
                    gamePlayer.Stat2Value = short.Parse(temp);

                temp = Regex.Match(page1html, String.Format(Settings.Default.FindScoreValueRegex, webIndex)).Groups[1].Value;
                if (gamePlayer.ScoreIsTime)
                    gamePlayer.Score = parseTime(temp);
                else
                    gamePlayer.Score = short.Parse(temp);

                gamePlayer.ColorHex = Regex.Match(page1html, String.Format(Settings.Default.FindColorRegex, webIndex)).Groups[1].Value;
                gamePlayers.AddGamePlayerRow(gamePlayer);
                //CHECK THIS!!!!!
                gamePlayer.Place = int.Parse(Regex.Match(page1html, String.Format(Settings.Default.FindPlaceRegex, webIndex)).Groups[1].Value);
            }

            fillKdasStats(gamePlayers, game.GameID, page1html);
            fillHitsStats(gamePlayers, game.GameID, page1html);
            fillPvPStats(gamePlayers, game.GameID, page1html);

            return true;

        }

        public static bool FillGameStats(HaloDataSet.GameRow game, string html)
        {
            Match m = Regex.Match(html, Settings.Default.FindMapRegex);
            game.Map = m.Groups[1].Value;

            m = Regex.Match(html, Settings.Default.FindMatchTypeRegex);
            game.Matchtype = m.Groups[1].Value.Trim();

            MatchCollection c = Regex.Matches(html, Settings.Default.FindPlaylistDateLength);
            game.Playlist = c[0].Groups[1].Value;

            DateTime dt = DateTime.ParseExact(c[1].Groups[1].Value, Settings.Default.DateTimeFormat, System.Globalization.DateTimeFormatInfo.CurrentInfo);
            dt = dt.Add(Settings.Default.BungieTimeOffset);
            dt = dt.ToLocalTime();

            game.Date = dt.Date.ToString("M/d/yyyy");
            game.Time = dt.TimeOfDay.ToString();

            game.Length = parseTime(c[2].Groups[1].Value.Substring(Settings.Default.GameLengthBeginningIndex));

            m = Regex.Match(html, Settings.Default.FindStat1NameRegex);
            string stat1name = m.Groups[1].Value;

            if (stat1name.Contains("Flag"))
            {
                game.Gametype = "CTF";
                game.BaseGametype = "CTF";
                game.TeamGame = true;
            }
            else if (stat1name.Contains("Bomb"))
            {
                game.Gametype = "Assault";
                game.BaseGametype = "Assault";
                game.TeamGame = true;
            }
            else if (stat1name.Contains("Carrier"))
            {
                game.BaseGametype = "Oddball";
                if (html.Contains(Settings.Default.TeamScoreHeaderCode))
                {
                    game.TeamGame = true;
                    game.Gametype = "Team Oddball";
                }
                else
                {
                    game.TeamGame = false;
                    game.Gametype = "Oddball";
                }
            }
            else if (stat1name.Contains("Avg."))
            {
                game.BaseGametype = "Slayer";
                if (html.Contains(Settings.Default.TeamScoreHeaderCode))
                {
                    game.TeamGame = true;
                    game.Gametype = "Team Slayer";
                }
                else
                {
                    game.TeamGame = false;
                    game.Gametype = "Slayer";
                }
            }
            else if (stat1name.Contains("Territories"))
            {
                game.BaseGametype = "Territories";
                if (html.Contains(Settings.Default.TeamScoreHeaderCode))
                {
                    game.TeamGame = true;
                    game.Gametype = "Team Territories";
                }
                else
                {
                    game.TeamGame = false;
                    game.Gametype = "Territories";
                }
            }
            else if (stat1name.Contains("Kings"))
            {
                game.BaseGametype = "KOTH";
                if (html.Contains(Settings.Default.TeamScoreHeaderCode))
                {
                    game.TeamGame = true;
                    game.Gametype = "Team KOTH";
                }
                else
                {
                    game.TeamGame = false;
                    game.Gametype = "KOTH";
                }
            }
            else
            {
                //Fucking juggernaut!
                game.BaseGametype = "JUGGERNAUT";
            }
            return true;
        }

        private static bool fillKdasStats(HaloDataSet.GamePlayerDataTable table, string gameID, string html)
        {
            //string html = Download.GetGameHTML(StatsPanel.Kills, gameID);
            for(int i = 0; i < table.Count; i++)
            {
                HaloDataSet.GamePlayerRow player = table[i];
                int webIndex = i + 1;

                player.Kills = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindKillsRegex, webIndex)).Groups[1].Value);
                player.Assists = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindAssistsRegex, webIndex)).Groups[1].Value);
                player.Deaths = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindDeathsRegex, webIndex)).Groups[1].Value);
                player.Suicides = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindSuicidesRegex, webIndex)).Groups[1].Value);
            }

            return true;
        }

        private static bool fillPvPStats(HaloDataSet.GamePlayerDataTable gamePlayers, string gameID, string html)
        {
            //string html = Download.GetGameHTML(StatsPanel.Vs, gameID);
     
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                HaloDataSet.GamePlayerRow player = gamePlayers[i];
                int webIndex = i+1;

                player.MostKilled = Regex.Match(html, 
                    String.Format(Settings.Default.FindMostKilledRegex, webIndex)).Groups[1].Value;
                player.MostKilledBy = Regex.Match(html, 
                    String.Format(Settings.Default.FindMostKilledByRegex, webIndex)).Groups[1].Value;

                string table = Regex.Match(html,
                    String.Format(Settings.Default.FindBetrayalsTableRegex, webIndex), RegexOptions.Singleline).Groups[1].Value;

                player.Betrayals = 0;

                if (player.GameRow.TeamGame)
                {
                    MatchCollection betrayals = Regex.Matches(table,
                        String.Format(Settings.Default.FindBetrayalsRegex, /*webIndex,*/ player.ColorHex), RegexOptions.Singleline);
                    
                    foreach (Match m in betrayals)
                    {
                        player.Betrayals += short.Parse(m.Groups[1].Value);
                    }
                    player.Betrayals -= player.Suicides; //The above adds in your suicides, so we're going to take them out.
                }
            }
            return true;
        }

        private static bool fillHitsStats(HaloDataSet.GamePlayerDataTable gamePlayers, string gameID, string html)
        {
            //string html = Download.GetGameHTML(StatsPanel.Hits, gameID);

            for (int i = 0; i < gamePlayers.Count; i++)                
            {
                HaloDataSet.GamePlayerRow player = gamePlayers[i];
                int webIndex = i+1;

                player.ShotsHit = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindShotsHitRegex, webIndex)).Groups[1].Value);
                player.ShotsFired = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindShotsFiredRegex, webIndex)).Groups[1].Value);
                player.Accuracy = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindAccuracyRegex, webIndex)).Groups[1].Value);
                player.Headshots = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindHeadshotsRegex, webIndex)).Groups[1].Value);
            }
            return true;
        }

        public static bool FillMedalsStats(HaloDataSet.GamePlayerMedalDataTable medalTable, 
            HaloDataSet.GamePlayerDataTable gamePlayers, string gameID, string html)
        {
            //string html = Download.GetGameHTML(StatsPanel.Medals, gameID);
            int currentRow = 0;
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                HaloDataSet.GamePlayerRow gamePlayer = gamePlayers[i];
                int webIndex = i+1;

                gamePlayer.TotalMedals = short.Parse(Regex.Match(html,
                    String.Format(Settings.Default.FindMedalCountRegex, webIndex)).Groups[1].Value);

                //If he didnt get any medals, the medal table does not exist and regex captures too much.
                if (gamePlayer.TotalMedals == 0)
                    continue;

                string medalHtmlTable = Regex.Match(html,
                    String.Format(Settings.Default.FindMedalTableRegex, webIndex), RegexOptions.Singleline).Groups[1].Value;

                //Get all medal names this player earned, and create and add a row for each
                MatchCollection medalNames = Regex.Matches(medalHtmlTable, Settings.Default.FindAllMedalNamesRegex);
                foreach (Match medalName in medalNames)
                {
                    HaloDataSet.GamePlayerMedalRow row = medalTable.NewGamePlayerMedalRow();
                    row.GameID = gamePlayer.GameID;
                    row.Gamertag = gamePlayer.Gamertag;
                    row.MedalName = medalName.Groups[1].Value;
                    medalTable.AddGamePlayerMedalRow(row);
                }

                //Set the count for each medal row
              
                MatchCollection medalCounts = Regex.Matches(medalHtmlTable, Settings.Default.FindAllMedalValuesRegex);
                for (int j = 0; j < medalNames.Count; j++)
                {
                    medalTable[currentRow].Count = short.Parse(medalCounts[j].Groups[1].Value);
                    currentRow++;
                }

            }

            return true;
        }

        public static string ParseGameID(string url)
        {
            Match m = Regex.Match(url, "=[0-9]*&");
            url = m.Value.Substring(1);
            url = url.Remove(url.Length - 1);
            return url;
        }

        public static bool UpdatePlayerRanks(HaloDataSet.PlayerRankDataTable playerRanks, string html, string gamertag)
        {
            MatchCollection playlists = Regex.Matches(html, Settings.Default.FindAllPlaylistNamesRegex);
            MatchCollection ranks = Regex.Matches(html, Settings.Default.FindAllPlaylistRanksRegex);
            MatchCollection rankPercents = Regex.Matches(html, Settings.Default.FindAllRankPercentRegex);
            MatchCollection gamesAndWins = Regex.Matches(html, Settings.Default.FindAllGamesAndWinsRegex);
            MatchCollection noGames = Regex.Matches(html, "<span id=\"dlHopperRanks_ctl([0-9]*?)_lblNoLevel\">");

            int currGoodGameIndex = 0;
            int[] badIndexes = new int[noGames.Count];
            for (int i = 0; i < badIndexes.Length; i++)
                badIndexes[i] = int.Parse(noGames[i].Groups[1].Value);

            for (int i = 0; i < playlists.Count; i++)
            {
                
                string playlist = playlists[i].Groups[1].Value;
                HaloDataSet.PlayerRankRow[] rows = (HaloDataSet.PlayerRankRow[])playerRanks.Select("Playlist=\'" + playlist +"\'");
                HaloDataSet.PlayerRankRow row;
                //if...
                if (rows.Length == 0)
                {
                    row = playerRanks.NewPlayerRankRow();
                    row.Playlist = playlist;
                    row.Gamertag = gamertag;
                    row.Percent = 0;
                    row.Rank = 0;
                    row.Wins = 0;
                    row.GamesPlayed = 0;
                    playerRanks.AddPlayerRankRow(row);
                }
                else
                    row = rows[0];

                bool iIsBad = false;
                for (int j = 0; j < badIndexes.Length; j++)
                {
                    if (i+1 == badIndexes[j])
                    {
                        iIsBad = true;
                        break;
                    }
                }

                if (!iIsBad)
                {
                    row.Rank = byte.Parse(ranks[currGoodGameIndex].Groups[1].Value);
                    row.Percent = (byte)(float.Parse(rankPercents[currGoodGameIndex].Groups[1].Value) / 50.0 * 100 + .5);
                    row.GamesPlayed = int.Parse(gamesAndWins[2 * i].Groups[1].Value);
                    row.Wins = int.Parse(gamesAndWins[2 * i + 1].Groups[1].Value);
                    currGoodGameIndex++;
                }
            }

            return true;
        }

        public static bool UpdatePlayerClan(HaloDataSet.TagListRow player, string html)
        {
            player.Clan = Regex.Match(html, Settings.Default.FindClanRegex).Groups[1].Value;
            return true;
        }
    }
}
