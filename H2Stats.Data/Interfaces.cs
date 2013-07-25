using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace H2Stats.Data
{
    /// <summary>
    /// Classes that implement this interface are capable of showing the stats from one game
    /// </summary>
    public interface IGameViewer
    {
        /// <summary>
        /// The game row containing all the game information
        /// </summary>
        HaloDataSet.GameRow GameRow
        {
            get;
        }

        /// <summary>
        /// The game ID for that game
        /// </summary>
        string GameID
        {
            get;
        }
    }

    /// <summary>
    /// Classes that implement this provide the information rows from the database, so
    /// that there arent multiple instances of the same table
    /// </summary>
    public interface IHaloInfoSupplier
    {
        /// <summary>
        /// Gets the color information table
        /// </summary>
        HaloDataSet.ColorInfoDataTable ColorInfo
        {
            get;
        }

        /// <summary>
        /// Gets the playlist ionformation table
        /// </summary>
        HaloDataSet.PlaylistInfoDataTable PlaylistInfo
        {
            get;
        }

        /// <summary>
        /// Gets the user's gamertag list
        /// </summary>
        HaloDataSet.TagListDataTable TagList
        {
            get;
        }

        /// <summary>
        /// Gets the medal information table
        /// </summary>
        HaloDataSet.MedalInfoDataTable MedalInfo
        {
            get;
        }

        /// <summary>
        /// Gets the users favorite games
        /// </summary>
        HaloDataSet.FavoritesDataTable Favorites
        {
            get;
        }

        /// <summary>
        /// Gets common images
        /// </summary>
        IImageCache Images
        {
            get;
        }
    }

    /// <summary>
    /// Represents a list of cached images
    /// </summary>
    public interface IImageCache
    {
        /// <summary>
        /// Gets a list of cached map images
        /// </summary>
        IMapImageCache Maps
        {
            get;
        }

        /// <summary>
        /// Gets a list of cached gametype images
        /// </summary>
        IGametypeImageCache Gametypes
        {
            get;
        }

        /// <summary>
        /// gets a list of cached medal icons
        /// </summary>
        IMedalsImageCache Medals
        {
            get;
        }
    }

    /// <summary>
    /// represents a list of cached map images
    /// </summary>
    public interface IMapImageCache
    {
        /// <summary>
        /// Gets the default image for the map Ascension
        /// </summary>
        Image Ascension
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Backwash
        /// </summary>
        Image Backwash
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Beaver Creek
        /// </summary>
        Image BeaverCreek
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Burial Mounds
        /// </summary>
        Image BurialMounds
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Coagulation
        /// </summary>
        Image Coagulation
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Colossus
        /// </summary>
        Image Colossus
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Containment
        /// </summary>
        Image Containment
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Elongation
        /// </summary>
        Image Elongation
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Foundation
        /// </summary>
        Image Foundation
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Gemini
        /// </summary>
        Image Gemini
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Headlong
        /// </summary>
        Image Headlong
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Ivory Tower
        /// </summary>
        Image IvoryTower
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Lockout
        /// </summary>
        Image Lockout
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Midship
        /// </summary>
        Image Midship
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Relic
        /// </summary>
        Image Relic
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Sanctuary
        /// </summary>
        Image Sanctuary
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Terminal
        /// </summary>
        Image Terminal
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Turf
        /// </summary>
        Image Turf
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Warlock
        /// </summary>
        Image Warlock
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Waterworks
        /// </summary>
        Image Waterworks
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the map Zanzibar
        /// </summary>
        Image Zanzibar
        {
            get;
        }

        /// <summary>
        /// Gets an image of a map by name. Name is properly capitalized with necessary spaces. For example: "Ivory Tower"
        /// </summary>
        /// <param name="name">The name of the map</param>
        /// <returns></returns>
        Image GetByName(string name);
    }

    /// <summary>
    /// represents a list of cached gametype pictures
    /// </summary>
    public interface IGametypeImageCache
    {
        /// <summary>
        /// Gets the default image for the game type Slayer
        /// </summary>
        Image Slayer
        {
            get;
        }
        
        /// <summary>
        /// Gets the default image for the game type Oddball
        /// </summary>
        Image Oddball
        {
            get;
        }
        
        /// <summary>
        /// Gets the default image for the game type King of the Hill
        /// </summary>
        Image Koth
        {
            get;
        }
        
        /// <summary>
        /// Gets the default image for the game type CTF
        /// </summary>
        Image Ctf
        {
            get;
        }
        
        /// <summary>
        /// Gets the default image for the game type Assault
        /// </summary>
        Image Assault
        {
            get;
        }

        /// <summary>
        /// Gets the default image for the game type Territories
        /// </summary>
        Image Territories
        {
            get;
        }

        /// <summary>
        /// Gets the image by name. Name should be capitalized. The "Team" specifier is optional: "Slayer" or "Team Slayer"
        /// </summary>
        /// <param name="name">The name of the gametype</param>
        /// <returns></returns>
        Image GetByName(string name);
               
    }

    /// <summary>
    /// Represents a list of cached medal icons
    /// </summary>
    public interface IMedalsImageCache
    {
        /// <summary>
        /// Returns the default medal icon for a Double Kill
        /// </summary>
        Image DoubleKill
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Triple Kill
        /// </summary>
        Image TripleKill
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Killtacular
        /// </summary>
        Image Killtacular
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Kill Frenzy
        /// </summary>
        Image KillFrenzy
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Killtrocity
        /// </summary>
        Image Killtrocity
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Killing Spree
        /// </summary>
        Image KillingSpree
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Running Riot
        /// </summary>
        Image RunningRiot
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Rampage
        /// </summary>
        Image Rampage
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Berserker
        /// </summary>
        Image Berserker
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Overkill
        /// </summary>
        Image Overkill
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Bonecracker
        /// </summary>
        Image Bonecracker
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Assassin
        /// </summary>
        Image Assassin
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Sniper Kill
        /// </summary>
        Image SniperKill
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Carjacking
        /// </summary>
        Image Carjacking
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Stick It
        /// </summary>
        Image StickIt
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Roadkill (Splatter)
        /// </summary>
        Image Roadkill
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Bomb Carrier Kill
        /// </summary>
        Image BombCarrierKill
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Bomb Planted
        /// </summary>
        Image BombPlanted
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Flag Carrier Kill
        /// </summary>
        Image FlagCarrierKill
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Flag Returned
        /// </summary>
        Image FlagReturned
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Flag Taken
        /// </summary>
        Image FlagTaken
        {
            get;
        }

        /// <summary>
        /// Returns the default medal icon for a Killimanjaro
        /// </summary>
        Image Killimanjaro
        {
            get;
        }
        
        /// <summary>
        /// Gets the medal by name. Name should be capitalized with necessary spaces: "Double Kill"
        /// </summary>
        /// <param name="name">The medal name</param>
        /// <returns></returns>
        Image GetByName(string name);
    }

    /// <summary>
    /// Classes that implement this can output the aggregations to a variety of formats
    /// </summary>
    public interface ITotalsExport
    {
        /// <summary>
        /// Exports the information to a certain format
        /// </summary>
        /// <param name="gamertag">The gamertag in question</param>
        /// <param name="totals">The totals for export</param>
        /// <param name="haloInfoSupplier">A supplier of information that may be needed</param>
        /// <returns>true if successful</returns>
        bool Export(string gamertag, AggregateDataSet totals, IHaloInfoSupplier haloInfoSupplier);

        /// <summary>
        /// Gets the name of the plugin
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets a short description of the plugin
        /// </summary>
        string Description
        {
            get;
        }
    }

    /// <summary>
    /// Implementers of this interface can export stats from a single game to some other medium
    /// </summary>
    public interface IGameExport
    {
        /// <summary>
        /// Exports the stats to a certain format
        /// </summary>
        /// <param name="gameRow">The game data</param>
        /// <param name="haloInfoSupplier">A supplier of information that may be needed</param>
        /// <returns></returns>
        bool Export(HaloDataSet.GameRow gameRow, IHaloInfoSupplier haloInfoSupplier);

        /// <summary>
        /// Gets the name of the plugin
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets a short description of the plugin
        /// </summary>
        string Description
        {
            get;
        }
    }

    public interface IGameViewerLauncher
    {
        string Name
        {
            get;
        }

        void Launch(string gamertag, HaloDataSet.GameRow gameRow, IHaloInfoSupplier infoSupplier, Form mdiParent);
    }
}
