using System;
using System.Collections.Generic;
using System.Text;
using H2Stats.Data.HaloDataSetTableAdapters;
using H2Stats.Data;
using System.Net;
using System.IO;
using H2Stats.Downloader.Properties;
using System.Text.RegularExpressions;
using System.Drawing;

namespace H2Stats.Downloader
{
    /// <summary>
    /// Represents the different pages of stats on Bungie.net
    /// </summary>
    public enum StatsPanel
    {
        Stats,
        Kills,
        Vs,
        Medals,
        Hits
    }

    public class Download
    {
        public static int BytesDownloaded = 0;

        static int calcBytes(string s)
        {
            return s.Length * 2;
        }

        /// <summary>
        /// Finds all new unpurged games.
        /// </summary>
        /// <param name="gamerTag">The gamertag to find games for.</param>
        /// <returns>A list of all valid games for downlaoad</returns>
        public static List<string> FindNewGames(string gamerTag)
        {
            string url = encode(Settings.Default.GameListBaseURL + gamerTag);
            TagListTableAdapter tagList = new TagListTableAdapter();
            HaloDataSet.TagListDataTable tb = tagList.GetData();
            List<string> list = new List<string>();

            HaloDataSet.TagListRow row = tb.FindByGamertag(gamerTag);
            GamePlayerTableAdapter gamePlayerAdapter = new GamePlayerTableAdapter();

            //string lastGameID;
            //string[] lines = getHTML(url);
            string oldestID;// = findOldestGame(gamerTag);

            try
            {
                //Dont redownload oldest game...
                oldestID = ((int)(int.Parse(row.LastGameID) + 1)).ToString();
            }
            catch (System.Data.StrongTypingException)
            {
                oldestID = findOldestGame(gamerTag);
            }

            int currPage = 1;
            string currentID = "999999999";
            int iOldest = int.Parse(oldestID);
            while (int.Parse(currentID) >= iOldest)
            {
                string html = getHtmlString(String.Format(Settings.Default.GameListPageURL,
                    gamerTag, currPage));
                MatchCollection matches = Regex.Matches(html, Settings.Default.FindValidGamesRegex);

                for (int i = 0; i < matches.Count; i++)
                {
                    currentID = Parse.ParseGameID(matches[i].Value);
                    if (int.Parse(currentID) >= iOldest)
                    {
                        //If there is no such row in the table, better download it
                        if (gamePlayerAdapter.GetData(currentID, gamerTag).Count == 0)
                            list.Add(currentID);
                    }

                    else
                        break;
                }
                currPage++;
            }

            //Want to download from oldest to newest, in case of cancellation            
            list.Reverse();

            //Check Validity: Loop through until we find the first valid game, removing any invalid ones
            for (int i = 0; i < list.Count; i++)
            {
                if (validGame(list[i]))
                    break;
                else
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            //tagList.Update(tb);
            tagList.Dispose();

            return list;

        }

        /// <summary>
        /// Gets the HTML source for a page of stats.
        /// </summary>
        /// <param name="panel">The stats panel to fetch source from</param>
        /// <param name="gameID">The gameID to download</param>
        /// <returns></returns>
        public static string GetGameHTML(StatsPanel panel, string gameID)
        {
            string url = encode(String.Format(Settings.Default.StatsPageUrls,
                panel.ToString().ToLower(), gameID));
            return getHtmlString(url);
        }

        /// <summary>
        /// Downloads the player's current avatar
        /// </summary>
        /// <param name="html">The HTML for the player main stats page</param>
        /// <returns>An <c>Image</c> of the player's avatar.</returns>
        public static Image GetPlayerIcon(string html)
        {
            StringBuilder urlEncoder = new  
                StringBuilder(@"http://www.bungie.net" + Regex.Match(html, Settings.Default.FindIconUrlRegex).Groups[1].Value);

            urlEncoder.Replace("amp;", "");
            string url = urlEncoder.ToString();

            WebClient webClient = new WebClient();
            Image image = null;
            
            try
            {                
                using (Stream imageStream = webClient.OpenRead(url))
                {
                    image = Image.FromStream(imageStream);
                }
            }
            catch(Exception e)
            {
            }

            return image;
        }

        /// <summary>
        /// Finds the oldest valid (non-purged) game.
        /// </summary>
        /// <param name="gamerTag">The player to find games for</param>
        /// <returns>The GameID of the oldest non purged game</returns>
        private static string findOldestGame(string gamerTag)
        {
            string url = encode(String.Format(Settings.Default.GameListBaseURL+gamerTag));
            //bool gameFound = false;
            string oldestGame = null;
            int currPage = 1;

            while (true)
            {
                string html = getHtmlString(String.Format(Settings.Default.GameListPageURL,
                    gamerTag, currPage));
                MatchCollection c = Regex.Matches(html, Settings.Default.FindValidGamesRegex);

                string lastGameID = c[c.Count - 1].Value;
                lastGameID = Parse.ParseGameID(lastGameID);
                

                if (!validGame(lastGameID))
                {
                    for (int i = c.Count - 1; i >= 0; i--)
                    {
                        oldestGame = Parse.ParseGameID(c[i].Value);
                        if (validGame(oldestGame))
                            return oldestGame; //stop searching
                    }
                }

                currPage++;

            }
            //return oldestGame;
        }

        private static bool validGame(string lastGameID)
        {
            string html = getHtmlString(Settings.Default.MainStatsPageURL + lastGameID);
            return !html.Contains(Settings.Default.GamePurgedMessage);
        }

        private static int findString(string[] lines, string text)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(text))
                    return i;
                    
            }

            return -1;
        }

        private static string[] getHTML(string url)
        {
            return getHtmlString(url).Split('\n');
        }

        private static string getHtmlString(string url)
        {
            HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(url);

            // execute the request
            HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();

            StreamReader r = new StreamReader(response.GetResponseStream());
            string s = r.ReadToEnd();
            r.Close();
            response.Close();
            BytesDownloaded += calcBytes(s);
            return s;
        }

        public static string GetStatsHomeHtml(string gamerTag)
        {
            return getHtmlString(encode(Settings.Default.OverviewBaseURL + gamerTag));
        }

        private static string encode(string p)
        {
            StringBuilder s = new StringBuilder(p);
            s.Replace(" ", "%20");
            return s.ToString();
        }

        public static void AddPlaylistInfoRow(string html, HaloDataSet.PlaylistInfoDataTable playlistInfo, string playlist)
        {
            HaloDataSet.PlaylistInfoRow row = playlistInfo.NewPlaylistInfoRow();
            row.Name = playlist;

            string infoTable = Regex.Match(html,
                String.Format(Settings.Default.FindPlaylistInfoRegex, playlist), RegexOptions.Singleline).Groups[1].Value;

            string ranked = Regex.Match(infoTable, Settings.Default.FindRankedRegex).Groups[1].Value;

            row.IsRanked = (ranked == "YES");
            row.IsCurrent = true;
            row.Description = Regex.Match(infoTable, Settings.Default.FindPlaylistDescriptionRegex).Groups[1].Value;

            #warning Prompt user for Abbreviation
            row.Abbreviation = "AAA";
            playlistInfo.AddPlaylistInfoRow(row);
        }

        public static void UpdatePlaylistInfoTable()
        {
            string html = Download.getHtmlString(Settings.Default.PlaylistInfoUrl);
            PlaylistInfoTableAdapter playlistAdapter = new PlaylistInfoTableAdapter();
            HaloDataSet.PlaylistInfoDataTable playlistInfo = playlistAdapter.GetData();

            MatchCollection matches = Regex.Matches(html, 
                Settings.Default.FindAllCurrentPlaylistsRegex);

            List<string> currentPlaylists = new List<string>();

            //Add or update the entry for each playlist found on Bungie.net
            foreach (Match m in matches)
            {
                currentPlaylists.Add(m.Groups[1].Value);

                if (playlistInfo.FindByName(m.Groups[1].Value) == null)
                    AddPlaylistInfoRow(html, playlistInfo, m.Groups[1].Value);
                else
                    UpdatePlaylistInfoRow(html, playlistInfo.FindByName(m.Groups[1].Value));
            }

            //If we have any playlists in the database that are not on Bungie.net,
            //then the playlist is no longer current
            foreach (HaloDataSet.PlaylistInfoRow row in playlistInfo)
            {
                if (!currentPlaylists.Contains(row.Name))
                    row.IsCurrent = false;
            }

            playlistAdapter.Update(playlistInfo);
            playlistInfo.Dispose();
            playlistAdapter.Dispose();

        }

        private static void UpdatePlaylistInfoRow(string html, HaloDataSet.PlaylistInfoRow playlistInfoRow)
        {
            string infoTable = Regex.Match(html,
                String.Format(Settings.Default.FindPlaylistInfoRegex, playlistInfoRow.Name), RegexOptions.Singleline).Groups[1].Value;

            string ranked = Regex.Match(infoTable, Settings.Default.FindRankedRegex).Groups[1].Value;

            playlistInfoRow.IsRanked = (ranked == "YES");
            playlistInfoRow.IsCurrent = true;
            playlistInfoRow.Description = Regex.Match(infoTable, Settings.Default.FindPlaylistDescriptionRegex).Groups[1].Value;

#warning Prompt user for Abbreviation?
            playlistInfoRow.Abbreviation = "AAA";
        }
    }
}
