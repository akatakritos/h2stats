using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using H2Stats.Data;

namespace CoBPack.Plugin
{
    public class WikiTotalsExporter : H2Stats.Data.ITotalsExport
    {
        #region ITotalsExport Members 

        public bool Export(string gamertag, H2Stats.Data.AggregateDataSet totals, IHaloInfoSupplier haloInfoSupplier)
        {
            bool error = false;
            WikiExportSetupForm f = new WikiExportSetupForm();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                error = performExport(f.CopyToClipboard, f.FileName, gamertag, totals, haloInfoSupplier.MedalInfo);
            f.Dispose();
            return error;
        }

        public string Name
        {
            get { return "Wiki Code 1.0"; }
        }

        public string Description
        {
            get { return "By Matt Burke (CoB Leviathan): Exports totals to wiki code for display in wiki user pages"; }
        }

        #endregion

        private bool performExport(bool copyToClipboard, string filename, string gamertag, AggregateDataSet dset,HaloDataSet.MedalInfoDataTable mdlInfo)
        {
            string s = File.ReadAllText(Application.StartupPath + "\\StatsTotalsWiki.txt");
            StringBuilder wikiCode = new StringBuilder(s);
            wikiCode.Replace("#Date#", DateTime.Today.ToShortDateString());
            wikiCode.Replace("#Gamertag#", gamertag);

            #region Table 1 
            wikiCode.Replace("#Kills#", dset.Kills_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#ShotsHit#", dset.Shots_Hit_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#Deaths#", dset.Deaths_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#ShotsFired#", dset.Shots_Fired_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#Assists#", dset.Assists_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#Accuracy#", dset.Accuracy_Aggregate[0].Avg.ToString());
            wikiCode.Replace("#Suicides#", dset.Suicides_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#Headshots#", dset.Headshots_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#Betrayals#", dset.Betrayals_Aggregate[0].Sum.ToString());
            wikiCode.Replace("#Games#", dset.Game_Count_Aggregate[0].Count.ToString());
            wikiCode.Replace("#Time#", GameLength.ToTimeString((int)dset.Game_Length_Aggregate[0].Sum));
            wikiCode.Replace("#KillsPerMin#", dset.Game_Length_Aggregate[0].Sum.ToString());

            if (dset.Kills_Aggregate[0].Sum > 0)
                wikiCode.Replace("#ShotsPerKill#", Math.Round(dset.Shots_Fired_Aggregate[0].Sum / dset.Kills_Aggregate[0].Sum, 3).ToString());
            else
                wikiCode.Replace("#ShotsPerKill#", "NA");

            if (dset.Deaths_Aggregate[0].Sum > 0)
            {
                wikiCode.Replace("#KpD#", Math.Round(dset.Kills_Aggregate[0].Sum / dset.Deaths_Aggregate[0].Sum, 3).ToString());
                wikiCode.Replace("#KApD#", Math.Round((dset.Kills_Aggregate[0].Sum + dset.Assists_Aggregate[0].Sum) / dset.Deaths_Aggregate[0].Sum, 3).ToString());
            }
            else
            {
                wikiCode.Replace("#KpD#", "NA");
                wikiCode.Replace("#KApD#", "NA");
            }
            #endregion

            #region Medals Table 

            Dictionary<string, string> dataBaseToFileLookup = new Dictionary<string,string>(21);
            dataBaseToFileLookup.Add("Double Kill", "#DoubleKills#");
            dataBaseToFileLookup.Add("Triple Kill", "#TripleKills#");
            dataBaseToFileLookup.Add("Killtacular", "#Killtaculars#");
            dataBaseToFileLookup.Add("Kill Frenzy", "#KillFrenzies#");
            dataBaseToFileLookup.Add("Killtrocity", "#Killtrocities#");
            dataBaseToFileLookup.Add("Killing Spree", "#KillingSprees#");
            dataBaseToFileLookup.Add("Running Riot", "#RunningRiots#");
            dataBaseToFileLookup.Add("Rampage", "#Rampages#");
            dataBaseToFileLookup.Add("Berserker", "#Berserkers#");
            dataBaseToFileLookup.Add("Overkill", "#Overkills#");
            dataBaseToFileLookup.Add("Bonecracker", "#Beatdowns#");
            dataBaseToFileLookup.Add("Assassin", "#Assassinations#");
            dataBaseToFileLookup.Add("Sniper Kill", "#Snipes#");
            dataBaseToFileLookup.Add("Carjacking", "#BoardedVehicles#");
            dataBaseToFileLookup.Add("Stick It", "#Sticks#");
            dataBaseToFileLookup.Add("Roadkill", "#Splatters#");
            dataBaseToFileLookup.Add("Bomb Carrier Kill", "#BombKills#");
            dataBaseToFileLookup.Add("Bomb Planted", "#BombsPlanted#");
            dataBaseToFileLookup.Add("Flag Carrier Kill", "#FlagKills#");
            dataBaseToFileLookup.Add("Flag Returned", "#FlagReturns#");
            dataBaseToFileLookup.Add("Flag Taken", "#FlagsTaken#");
            dataBaseToFileLookup.Add("Killimanjaro", "THIS HAD BETTER NOT APPEAR");

            foreach (AggregateDataSet.Medals_AggregateRow medalRow in dset.Medals_Aggregate)
            {
                wikiCode.Replace(dataBaseToFileLookup[medalRow.MedalName], medalRow.Sum.ToString());
            }

            foreach (string leftover in dataBaseToFileLookup.Values)
                wikiCode.Replace(leftover, "0");

            #endregion

            #region Gametype Specifics
            int slayerGames = 0;
            int slayerWins = 0;
            int slayerAvgLife = 0;
            int oddBallGames = 0;
            int oddBallWins = 0;
            int kothGames = 0;
            int kothWins = 0;
            int terrGames = 0;
            int terrWins = 0;
            int ctfGames = 0;
            int ctfWins = 0;
            int assualtGames = 0;
            int assualtWins = 0;

            foreach (AggregateDataSet.GametypeDetailsRow row in dset.GametypeDetails)
            {
                if (row.Gametype.Contains("Slayer"))
                    slayerGames += row.Count_Of_Game;
                else if (row.Gametype.Contains("Oddball"))
                    oddBallGames += row.Count_Of_Game;
                else if (row.Gametype.Contains("KOTH"))
                    kothGames += row.Count_Of_Game;
                else if (row.Gametype.Contains("Territories"))
                    terrGames += row.Count_Of_Game;
                else if (row.Gametype == "CTF")
                {
                    ctfGames = row.Count_Of_Game;
                    wikiCode.Replace("#CTFGames#", row.Count_Of_Game.ToString());
                }
                else if (row.Gametype == "Assault")
                {
                    assualtGames = row.Count_Of_Game;
                    wikiCode.Replace("#AssaultGames#", row.Count_Of_Game.ToString());
                }
            }

            wikiCode.Replace("#SlayerGames#", slayerGames.ToString());
            wikiCode.Replace("#OddballGames#", oddBallGames.ToString());
            wikiCode.Replace("#KOTHGames#", kothGames.ToString());
            wikiCode.Replace("#TerrGames#", terrGames.ToString());

            foreach (AggregateDataSet.WinsByGametypeRow row in dset.WinsByGametype)
            {
                if (row.Gametype.Contains("Slayer"))
                    slayerWins += row.Wins;
                else if (row.Gametype.Contains("Oddball"))
                    oddBallWins += row.Wins;
                else if (row.Gametype.Contains("KOTH"))
                    kothWins += row.Wins;
                else if (row.Gametype.Contains("Territories"))
                    terrWins += row.Wins;
                else if (row.Gametype == "CTF")
                {
                    ctfWins = row.Wins;
                    wikiCode.Replace("#CTFWins#", row.Wins.ToString());
                }
                else if (row.Gametype == "Assault")
                {
                    assualtWins = row.Wins;
                    wikiCode.Replace("#AssaultWins#", row.Wins.ToString());
                }
            }

            wikiCode.Replace("#SlayerWins#", slayerWins.ToString());
            wikiCode.Replace("#OddballWins#", oddBallWins.ToString());
            wikiCode.Replace("#KOTHWins#", kothWins.ToString());
            wikiCode.Replace("#TerrWins#", terrWins.ToString());

            if (slayerGames != 0)
                wikiCode.Replace("#SlayerWinPercent#", (Math.Round(slayerWins / (double)slayerGames, 3) * 100).ToString());
            else
                wikiCode.Replace("#SlayerWinPercent#", "NA");

            if (oddBallWins != 0)
                wikiCode.Replace("#OddballWinPercent#", (Math.Round(oddBallWins / (double)oddBallGames, 3) * 100).ToString());
            else
                wikiCode.Replace("#OddballWinPercent#", "NA");

            if (kothGames != 0)
                wikiCode.Replace("#KOTHWinPercent#", (Math.Round(kothWins / (double)kothGames, 3) * 100).ToString());
            else
                wikiCode.Replace("#KOTHWinPercent#", "NA");

            if (terrGames != 0)
                wikiCode.Replace("#TerrWinPercent#", (Math.Round(terrWins / (double)terrGames, 3) * 100).ToString());
            else
                wikiCode.Replace("#TerrWinPercent#", "NA");

            if (ctfWins != 0)
                wikiCode.Replace("#CTFWinPercent#", (Math.Round(ctfWins / (double)(ctfGames), 3) * 100).ToString());
            else
                wikiCode.Replace("#CTFWinPercent#", "NA");

            if (assualtWins != 0)
                wikiCode.Replace("#AssaultWinPercent#", (Math.Round(assualtWins / (double)(assualtGames), 3) * 100).ToString());
            else
                wikiCode.Replace("#AssaultWinPercent#", "NA");

            setStat1Values(wikiCode, dset);
            setStat2Values(wikiCode, dset);
            setScoreValues(wikiCode, dset);
            #endregion

            wikiCode.Replace("<Statistics Overview Table>", buildStatTable(dset));

            wikiCode.Replace("<Medals Overview Table>", buildMedalTable(dset));

            wikiCode.Replace("<KillType Chart>", buildKillTypeChart(dset, mdlInfo));

            string finalProduct = wikiCode.ToString();
            File.WriteAllText(Application.StartupPath + "\\temp.txt", finalProduct);
            if (filename != "")
                File.WriteAllText(filename, finalProduct);
            if (copyToClipboard)
                Clipboard.SetText(finalProduct);
            return true;

        }

        private string buildKillTypeChart(AggregateDataSet dataSet, HaloDataSet.MedalInfoDataTable medalInfo)
        {
            string fmt  = "| bgcolor=\"#E0E0E0\" | {0} || bgcolor=\"#E0E0E0\" | {1} || bgcolor=\"#E0E0E0\" | {2}";
            string fmt2 = "| bgcolor=\"#F2F2F2\" | {0} || bgcolor=\"#F2F2F2\" | {1} || bgcolor=\"#F2F2F2\" | {2}";
            string[] fmts = new string[]{fmt, fmt2};
            int i = 0;
            string rowLine = "|- bgcolor='white' align=left";
            StringBuilder sBuilder = new StringBuilder(900);
            
            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine(rowLine);
            sBuilder.AppendLine("! Kill Type !! Count !! Percent");
            sBuilder.AppendLine(rowLine);

            double totalKills;
            double stdKills = totalKills = dataSet.Kills_Aggregate[0].Sum;

            AggregateDataSet.Stat2_AggregateRow ballKills = dataSet.Stat2_Aggregate.FindByStat2Name("Ball Kills");
            if ((ballKills != null) && (ballKills.Sum > 0))
            {
                sBuilder.AppendLine(string.Format(fmts[i % 2], "Oddball Kills", (int)ballKills.Sum, Math.Round(ballKills.Sum / (double)totalKills * 100, 3)));
                sBuilder.AppendLine(rowLine);
                i++;
                stdKills -= ballKills.Sum;
            }

            foreach (AggregateDataSet.Medals_AggregateRow medal in dataSet.Medals_Aggregate)
            {
                HaloDataSet.MedalInfoRow row = medalInfo.FindByName(medal.MedalName);
                if ((row != null) && (row.IsKillType))
                {
                    sBuilder.AppendLine(string.Format(fmts[i % 2], medal.MedalName, (int)medal.Sum, Math.Round(medal.Sum / (double)totalKills * 100, 3)));
                    sBuilder.AppendLine(rowLine);
                    stdKills -= medal.Sum;
                    i++;
                }                
            }

            sBuilder.AppendLine(string.Format(fmts[i % 2], "Std Kills", (int)stdKills, Math.Round(stdKills / (double)totalKills * 100, 3)));
            sBuilder.AppendLine(rowLine);
            sBuilder.AppendLine("|}");
            return sBuilder.ToString();
        }

        private string buildMedalTable(AggregateDataSet dataSet)
        {
            string fmt =  "| bgcolor=\"#E0E0E0\" | {0} || bgcolor=\"#E0E0E0\" | {1} || bgcolor=\"#E0E0E0\" | {2} || bgcolor=\"#E0E0E0\" | {3} || bgcolor=\"#E0E0E0\" | {4} || bgcolor=\"#E0E0E0\" | {5} || bgcolor=\"#E0E0E0\" | {6}";
            string fmt2 = "| bgcolor=\"#F2F2F2\" | {0} || bgcolor=\"#F2F2F2\" | {1} || bgcolor=\"#F2F2F2\" | {2} || bgcolor=\"#F2F2F2\" | {3} || bgcolor=\"#F2F2F2\" | {4} || bgcolor=\"#F2F2F2\" | {5} || bgcolor=\"#F2F2F2\" | {6}";
            string[] fmts = new string[]{fmt, fmt2};
            int i = 0;
            string rowLine = "|- bgcolor='white' align=left";
            StringBuilder sBuilder = new StringBuilder(5000);


            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine(rowLine);
            sBuilder.AppendLine("! Icon !! Medal Name !! Count / Sum !! Average !! Minimum !! Maximum !! Std Deviation");
            sBuilder.AppendLine(rowLine);

            foreach (AggregateDataSet.Medals_AggregateRow row in dataSet.Medals_Aggregate)
            {
                if(row.IsStdDevNull())
                    sBuilder.AppendLine(string.Format(fmts[i%2], "<site-image>" + IconLookup.GetIcon(row.MedalName) + "</site-image>", row.MedalName, row.Sum, Math.Round(row.Avg, 3), row.Min, row.MAX, "NA"));
                else
                    sBuilder.AppendLine(string.Format(fmts[i % 2], "<site-image>" + IconLookup.GetIcon(row.MedalName) + "</site-image>", row.MedalName, row.Sum, Math.Round(row.Avg, 3), row.Min, row.MAX, Math.Round(row.StdDev, 3)));
                sBuilder.AppendLine(rowLine);
                i++;
            }
            sBuilder.AppendLine("|}");
            IconLookup.Dispose();
            return sBuilder.ToString();
        }

        private string buildStatTable(AggregateDataSet dataSet)
        {
            string fmt =  "| bgcolor=\"#E0E0E0\" | {0} || bgcolor=\"#E0E0E0\" | {1} || bgcolor=\"#E0E0E0\" | {2} || bgcolor=\"#E0E0E0\" | {3} || bgcolor=\"#E0E0E0\" | {4} || bgcolor=\"#E0E0E0\" | {5}";
            string fmt2 = "| bgcolor=\"#F2F2F2\" | {0} || bgcolor=\"#F2F2F2\" | {1} || bgcolor=\"#F2F2F2\" | {2} || bgcolor=\"#F2F2F2\" | {3} || bgcolor=\"#F2F2F2\" | {4} || bgcolor=\"#F2F2F2\" | {5}";
            string[] fmts = new string[]{fmt, fmt2};
            int i = 0;
            string rowLine = "|- bgcolor='white' align=left";


            StringBuilder sBuilder = new StringBuilder(4675);
            sBuilder.AppendLine("{| cellpadding=3 cellspacing=3 border=0 bgcolor=white");
            sBuilder.AppendLine("|- bgcolor='white' align=left");
            sBuilder.AppendLine("! Statistic !! Count/Sum !! Average !! Minimum !! Maximum !! Std. Deviation");
            sBuilder.AppendLine("|-");

            AggregateDataSet.Kills_AggregateRow kills = dataSet.Kills_Aggregate[0];
            if (kills.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt, "Kills", kills.Sum, Math.Round(kills.Avg, 3), kills.Min, kills.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt, "Kills", kills.Sum, Math.Round(kills.Avg, 3), kills.Min, kills.Max, Math.Round(kills.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Deaths_AggregateRow deaths = dataSet.Deaths_Aggregate[0];
            if(deaths.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt2, "Deaths", deaths.Sum, Math.Round(deaths.Avg, 3), deaths.Min, deaths.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt2, "Deaths", deaths.Sum, Math.Round(deaths.Avg, 3), deaths.Min, deaths.Max, Math.Round(deaths.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Assists_AggregateRow assists = dataSet.Assists_Aggregate[0];
            if(assists.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt, "Assists", assists.Sum, Math.Round(assists.Avg, 3), assists.Min, assists.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt, "Assists", assists.Sum, Math.Round(assists.Avg, 3), assists.Min, assists.Max, Math.Round(assists.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Suicides_AggregateRow suicides = dataSet.Suicides_Aggregate[0];
            if(suicides.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt2, "Suicides", suicides.Sum, Math.Round(suicides.Avg, 3), suicides.Min, suicides.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt2, "Suicides", suicides.Sum, Math.Round(suicides.Avg, 3), suicides.Min, suicides.Max, Math.Round(suicides.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Betrayals_AggregateRow betrayals = dataSet.Betrayals_Aggregate[0];
            if(betrayals.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt, "Betrayals", betrayals.Sum, Math.Round(betrayals.Avg, 3), betrayals.Min, betrayals.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt, "Betrayals", betrayals.Sum, Math.Round(betrayals.Avg, 3), betrayals.Min, betrayals.Max, Math.Round(betrayals.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Shots_Fired_AggregateRow shotsFired = dataSet.Shots_Fired_Aggregate[0];
            if(shotsFired.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt2, "Shots Fired", shotsFired.Sum, Math.Round(shotsFired.Avg, 3), shotsFired.Min, shotsFired.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt2, "Shots Fired", shotsFired.Sum, Math.Round(shotsFired.Avg, 3), shotsFired.Min, shotsFired.Max, Math.Round(shotsFired.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Shots_Hit_AggregateRow shotsHit = dataSet.Shots_Hit_Aggregate[0];
            if(shotsHit.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt, "Shots Hit", shotsHit.Sum, Math.Round(shotsHit.Avg, 3), shotsHit.Min, shotsHit.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt, "Shots Hit", shotsHit.Sum, Math.Round(shotsHit.Avg, 3), shotsHit.Min, shotsHit.Max, Math.Round(shotsHit.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Headshots_AggregateRow headshots = dataSet.Headshots_Aggregate[0];
            if(headshots.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt2, "Headshots", headshots.Sum, Math.Round(headshots.Avg, 3), headshots.Min, headshots.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt2, "Headshots", headshots.Sum, Math.Round(headshots.Avg, 3), headshots.Min, headshots.Max, Math.Round(headshots.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Accuracy_AggregateRow accuracy = dataSet.Accuracy_Aggregate[0];
            if(accuracy.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt, "Accuracy", "NA", Math.Round(accuracy.Avg, 3), accuracy.Min, accuracy.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt, "Accuracy", "NA", Math.Round(accuracy.Avg, 3), accuracy.Min, accuracy.Max, Math.Round(accuracy.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            AggregateDataSet.Total_Medals_AggregateRow totalMedals = dataSet.Total_Medals_Aggregate[0];
            if(totalMedals.IsStdDevNull())
                sBuilder.AppendLine(string.Format(fmt2, "Total Medals", totalMedals.Sum, Math.Round(totalMedals.Avg, 3), totalMedals.Min, totalMedals.Max, "NA"));
            else
                sBuilder.AppendLine(string.Format(fmt2, "Total Medals", totalMedals.Sum, Math.Round(totalMedals.Avg, 3), totalMedals.Min, totalMedals.Max, Math.Round(totalMedals.StdDev, 3)));
            sBuilder.AppendLine(rowLine);

            foreach (AggregateDataSet.Stat1_AggregateRow row in dataSet.Stat1_Aggregate)
            {
                if (row.IsStdDevNull())
                {
                    if (row.Stat1IsTime)
                    {
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat1Name, GameLength.ToTimeString((int)row.Sum), GameLength.ToTimeString((int)(row.Avg + .5)),
                            GameLength.ToTimeString((int)row.Min), GameLength.ToTimeString((int)row.Max), "N/A"));
                    }
                    else
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat1Name, row.Sum, Math.Round(row.Avg, 3), row.Min, row.Max, "N/A"));
                }
                else
                {
                    if (row.Stat1IsTime)
                    {
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat1Name, GameLength.ToTimeString((int)row.Sum), GameLength.ToTimeString((int)(row.Avg + .5)),
                            GameLength.ToTimeString((int)row.Min), GameLength.ToTimeString((int)row.Max), GameLength.ToTimeString((int)row.StdDev)));
                    }
                    else
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat1Name, row.Sum, Math.Round(row.Avg, 3), row.Min, row.Max, Math.Round(row.StdDev, 3)));
                }
                sBuilder.AppendLine(rowLine);
                i++;
            }

            foreach (AggregateDataSet.Stat2_AggregateRow row in dataSet.Stat2_Aggregate)
            {
                if (row.IsStdDevNull())
                {
                    if (row.Stat2IsTime)
                    {
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat2Name, GameLength.ToTimeString((int)row.Sum), GameLength.ToTimeString((int)(row.Avg + .5)),
                            GameLength.ToTimeString((int)row.Min), GameLength.ToTimeString((int)row.Max), "N/A"));
                    }
                    else
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat2Name, row.Sum, Math.Round(row.Avg, 3), row.Min, row.Max, "N/A"));
                }
                else
                {
                    if (row.Stat2IsTime)
                    {
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat2Name, GameLength.ToTimeString((int)row.Sum), GameLength.ToTimeString((int)(row.Avg + .5)),
                            GameLength.ToTimeString((int)row.Min), GameLength.ToTimeString((int)row.Max), GameLength.ToTimeString((int)row.StdDev)));
                    }
                    else
                        sBuilder.AppendLine(string.Format(fmts[i%2], row.Stat2Name, row.Sum, Math.Round(row.Avg, 3), row.Min, row.Max, Math.Round(row.StdDev, 3)));
                }
                sBuilder.AppendLine(rowLine);
                i++;
            }

            sBuilder.AppendLine("|}");
            return sBuilder.ToString();
        }

        private void setScoreValues(StringBuilder wikiCode, AggregateDataSet dataSet)
        {
            int slayerScore = 0;
            int terrTime = 0;
            int oddballTime = 0;
            int kothTime = 0;
            foreach (AggregateDataSet.Score_AggregateRow row in dataSet.Score_Aggregate)
            {
                if (row.Gametype.Contains("Slayer"))
                    slayerScore += (int)row.Sum;
                else if (row.Gametype.Contains("Oddball"))
                    oddballTime += (int)row.Sum;
                else if (row.Gametype.Contains("KOTH"))
                    kothTime += (int)row.Sum;
                else if (row.Gametype.Contains("Territories"))
                    terrTime += (int)row.Sum;
                else if (row.Gametype == "CTF")
                    wikiCode.Replace("#CTFFlagsCaptured#", ((int)row.Sum).ToString());
                else if (row.Gametype == "Assault")
                    wikiCode.Replace("#AssaultBombsPlanted#", ((int)row.Sum).ToString());
            }

            wikiCode.Replace("#TerrTime#",GameLength.ToTimeString(terrTime));
            wikiCode.Replace("#OddballTime#",GameLength.ToTimeString(oddballTime));
            wikiCode.Replace("#KOTHTime#", GameLength.ToTimeString(kothTime));
            wikiCode.Replace("#SlayerScore#", slayerScore.ToString());
        }

        private void setStat2Values(StringBuilder wikiCode, AggregateDataSet dataSet)
        {
            AggregateDataSet.Stat2_AggregateRow stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Territories Lost");
            if (stat2Row != null)
                wikiCode.Replace("#TerrLost#", ((int)stat2Row.Sum).ToString());
            else
                wikiCode.Replace("#TerrLost#", "0");

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Best Spree");
            if (stat2Row != null)
                wikiCode.Replace("#SlayerBestSpree#", ((int)stat2Row.Max).ToString());
            else
                wikiCode.Replace("#SlayerBestSpree#", "0");

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Kills From");
            if (stat2Row != null)
                wikiCode.Replace("#KOTHKillsFrom#", ((int)stat2Row.Sum).ToString());
            else
                wikiCode.Replace("#KOTHKillsFrom#", "0");

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Ball Kills");
            if (stat2Row != null)
                wikiCode.Replace("#OddballBallKills#", ((int)stat2Row.Sum).ToString());
            else
                wikiCode.Replace("#OddballBallKills#", "0");

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Bombs Killed");
            if (stat2Row != null)
                wikiCode.Replace("#AssaultBombersKilled#", ((int)stat2Row.Sum).ToString());
            else
                wikiCode.Replace("#AssaultBombersKilled#", "0");

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Flags Taken");
            if (stat2Row != null)
                wikiCode.Replace("#CTFFlagsTaken#", ((int)stat2Row.Sum).ToString());
            else
                wikiCode.Replace("#CTFFlagsTaken#", "0");
        }

        private void setStat1Values(StringBuilder wikiCode, AggregateDataSet dataSet)
        {
            AggregateDataSet.Stat1_AggregateRow stat1Row;

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Avg. Life");
            if (stat1Row != null)
                wikiCode.Replace("#AverageLife#", GameLength.ToTimeString((int)stat1Row.Avg));
            else
                wikiCode.Replace("#AverageLife#", "0");

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Bomb Grabs");
            if (stat1Row != null)
                wikiCode.Replace("#AssaultBombsTaken#", ((int)stat1Row.Sum).ToString());
            else
                wikiCode.Replace("#AssaultBombsTaken#", "0");

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Territories Taken");
            if (stat1Row != null)
                wikiCode.Replace("#TerrTaken#", ((int)stat1Row.Sum).ToString());
            else
                wikiCode.Replace("#TerrTaken#", "0");

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Kings Killed");
            if (stat1Row != null)
                wikiCode.Replace("#KOTHKingsKilled#", ((int)stat1Row.Sum).ToString());
            else
                wikiCode.Replace("#KOTHKingsKilled#", "0");

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Carrier Kills");
            if (stat1Row != null)
                wikiCode.Replace("#OddballCarrierKills#", ((int)stat1Row.Sum).ToString());
            else
                wikiCode.Replace("#OddballCarrierKills#", "0");

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Flags Saved");
            if (stat1Row != null)
                wikiCode.Replace("#CTFFlagsSaved#", ((int)stat1Row.Sum).ToString());
            else
                wikiCode.Replace("#CTFFlagsSaved#", "0");
        }
    }
}
