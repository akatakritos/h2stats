using System;
using System.Collections.Generic;
using System.Text;
using H2Stats.Data;
using H2Stats.Properties;

namespace H2Stats
{
    public class MasterImageCache : IImageCache
    {
        MedalsImages medals;
        MapsImages maps;
        GametypeImages gametypes;
        public MasterImageCache()
        {
            medals = new MedalsImages();
            maps = new MapsImages();
            gametypes = new GametypeImages();
        }
        #region IImageCache Members

        public IMapImageCache Maps
        {
            get { return (IMapImageCache)maps; }
        }

        public IGametypeImageCache Gametypes
        {
            get { return gametypes; }
        }

        public IMedalsImageCache Medals
        {
            get { return medals; }
        }

        #endregion
    }

    public class MedalsImages : IMedalsImageCache
    {

        #region IMedalsImageCache Members

        public System.Drawing.Image DoubleKill
        {
            get { return Resources.Double_Kill; }
        }

        public System.Drawing.Image TripleKill
        {
            get { return Resources.Triple_Kill; }
        }

        public System.Drawing.Image Killtacular
        {
            get { return Resources.Killtacular; }
        }

        public System.Drawing.Image KillFrenzy
        {
            get { return Resources.Kill_Frenzy; }
        }

        public System.Drawing.Image Killtrocity
        {
            get { return Resources.Killtrocity; }
        }

        public System.Drawing.Image KillingSpree
        {
            get { return Resources.Killing_Spree; }
        }

        public System.Drawing.Image RunningRiot
        {
            get { return Resources.Running_Riot; }
        }

        public System.Drawing.Image Rampage
        {
            get { return Resources.Rampage; }
        }

        public System.Drawing.Image Berserker
        {
            get { return Resources.Berserker; }
        }

        public System.Drawing.Image Overkill
        {
            get { return Resources.Overkill; }
        }

        public System.Drawing.Image Bonecracker
        {
            get { return Resources.Bonecracker; }
        }

        public System.Drawing.Image Assassin
        {
            get { return Resources.Assassin; }
        }

        public System.Drawing.Image SniperKill
        {
            get { return Resources.Sniper_Kill; }
        }

        public System.Drawing.Image Carjacking
        {
            get { return Resources.Carjacking; }
        }

        public System.Drawing.Image StickIt
        {
            get { return Resources.Stick_It; }
        }

        public System.Drawing.Image Roadkill
        {
            get { return Resources.Roadkill; }
        }

        public System.Drawing.Image BombCarrierKill
        {
            get { return Resources.Bomb_Carrier_Kill; }
        }

        public System.Drawing.Image BombPlanted
        {
            get { return Resources.Bomb_Planted; }
        }

        public System.Drawing.Image FlagCarrierKill
        {
            get { return Resources.Flag_Carrier_Kill; }
        }

        public System.Drawing.Image FlagReturned
        {
            get { return Resources.Flag_Returned; }
        }

        public System.Drawing.Image FlagTaken
        {
            get { return Resources.Flag_Taken; }
        }

        public System.Drawing.Image Killimanjaro
        {
            get { return Resources.Killimanjaro; }
        }

        public System.Drawing.Image GetByName(string name)
        {
            return Resources.ResourceManager.GetObject(name) as System.Drawing.Image;
        }

        #endregion
    }

    public class MapsImages : IMapImageCache
    {

        #region IMapImageCache Members

        public System.Drawing.Image Ascension
        {
            get { return Resources.Ascension; }
        }

        public System.Drawing.Image Backwash
        {
            get { return Resources.Backwash; }
        }

        public System.Drawing.Image BeaverCreek
        {
            get { return Resources.Beaver_Creek; }
        }

        public System.Drawing.Image BurialMounds
        {
            get { return Resources.Burial_Mounds; }
        }

        public System.Drawing.Image Coagulation
        {
            get { return Resources.Coagulation; }
        }

        public System.Drawing.Image Colossus
        {
            get { return Resources.Colossus; }
        }

        public System.Drawing.Image Containment
        {
            get { return Resources.Containment; }
        }

        public System.Drawing.Image Elongation
        {
            get { return Resources.Elongation; }
        }

        public System.Drawing.Image Foundation
        {
            get { return Resources.Foundation; }
        }

        public System.Drawing.Image Gemini
        {
            get { return Resources.Gemini; }
        }

        public System.Drawing.Image Headlong
        {
            get { return Resources.Headlong; }
        }

        public System.Drawing.Image IvoryTower
        {
            get { return Resources.Ivory_Tower; }
        }

        public System.Drawing.Image Lockout
        {
            get { return Resources.Lockout; }
        }

        public System.Drawing.Image Midship
        {
            get { return Resources.Midship; }
        }

        public System.Drawing.Image Relic
        {
            get { return Resources.Relic; }
        }

        public System.Drawing.Image Sanctuary
        {
            get { return Resources.Sanctuary; }
        }

        public System.Drawing.Image Terminal
        {
            get { return Resources.Terminal; }
        }

        public System.Drawing.Image Turf
        {
            get { return Resources.Turf; }
        }

        public System.Drawing.Image Warlock
        {
            get { return Resources.Warlock; }
        }

        public System.Drawing.Image Waterworks
        {
            get { return Resources.Waterworks; }
        }

        public System.Drawing.Image Zanzibar
        {
            get { return Resources.Zanzibar; }
        }

        public System.Drawing.Image GetByName(string name)
        {
            return Resources.ResourceManager.GetObject(name) as System.Drawing.Image;
        }

        #endregion
    }

    public class GametypeImages : IGametypeImageCache
    {

        #region IGametypeImageCache Members

        public System.Drawing.Image Slayer
        {
            get { return Resources.Slayer; }
        }

        public System.Drawing.Image Oddball
        {
            get { return Resources.Oddball; }
        }

        public System.Drawing.Image Koth
        {
            get { return Resources.KOTH; }
        }

        public System.Drawing.Image Ctf
        {
            get { return Resources.CTF; }
        }

        public System.Drawing.Image Assault
        {
            get { return Resources.Assault; }
        }

        public System.Drawing.Image Territories
        {
            get { return Resources.Territories; }
        }

        public System.Drawing.Image GetByName(string name)
        {
            string s = name;
            if (name.Contains("Team "))
                s = name.Remove(0, 5);
            return Resources.ResourceManager.GetObject(s) as System.Drawing.Image;
        }

        #endregion
    }
}
