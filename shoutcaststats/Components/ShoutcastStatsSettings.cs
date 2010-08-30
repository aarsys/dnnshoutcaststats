// 
// Aarsys® M. Schlomann - http://www.aarsys.de 
// Copyright (c) 2010 
// by Aarsys M. Schlomann 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software. 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE. 
// 

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Security;

namespace Aarsys.ShoutcastStats.Components
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The Settings class manages Module Settings 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    class ShoutCastSettings : ModuleSettingsBase
    {

        #region "Public Members"

        // Shared Settings
        public string ModuleID { get; set; }

        public string SC_IP { get; set; }

        public string SC_Port { get; set; }

        public string SC_Password { get; set; }

        // Features Settings
        public bool SC_AIM { get; set; }

        public bool SC_AOL { get; set; }

        public bool SC_ICQ { get; set; }
        
        public bool SC_MSN { get; set; }

        public bool SC_Yahoo { get; set; }

        public bool SC_AIMChat { get; set; }
        
        public bool SC_AOLChat { get; set; }

        public bool SC_ICQChat { get; set; }

        public bool SC_YahooChat { get; set; }

        public bool SC_Station { get; set; }
        public bool SC_CurrentListeners { get; set; }
        public bool SC_MaxListeners { get; set; }
        public bool SC_PeakListeners { get; set; }
        public bool SC_Song { get; set; }
        public bool SC_DJ { get; set; }
        public bool SC_Bitrate { get; set; }
        public bool SC_Content { get; set; }
        public bool SC_genre { get; set; }
        public bool SC_Winamp { get; set; }
        public bool SC_MediaPlayer { get; set; }
        public bool SC_RealPlayer { get; set; }
        public bool SC_iTunes { get; set; }
        public bool SC_Player { get; set; }
        

        //Features StatsSettings
        public bool SC_XMLFileCount { get; set; }

        public bool SC_ListenerList { get; set; }

        public bool SC_LastPlayed { get; set; }

        #endregion


        #region "Base Method Implementations"

        private const string SC_SettingsPrefix = "Aarsys_ShoutcastStats_SC_";

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// StatsLoadSettings loads the settings from the Database and displays them 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 

        
        public void StatsLoadSettings(PortalModuleBase sd)
        {
            try
            {
                if ((string)sd.Settings[SC_SettingsPrefix + "IP"] != "")
                {
                    SC_IP = (string)sd.Settings[SC_SettingsPrefix + "IP"];
                }
                else
                {
                    SC_IP = "";
                }
            }
            catch (Exception exc)
            {

                //Module failed to load
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
            try
            {
                if ((string)sd.Settings[SC_SettingsPrefix + "Port"] != "")
                {
                    SC_Port = (string)sd.Settings[SC_SettingsPrefix + "Port"];
                }
                else
                {
                    SC_Port = "";
                }
            }
            catch (Exception exc)
            {

                //Module failed to load
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
            try
            {
                if ((string)sd.Settings[SC_SettingsPrefix + "Password"] != "")
                {
                    SC_Password = (string)sd.Settings[SC_SettingsPrefix + "Password"];
                }
                else
                {
                    SC_Password = "";
                }
            }
            catch (Exception exc)
            {

                //Module failed to load
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
            try
            {
                if ((string)sd.Settings[SC_SettingsPrefix + "XMLFileCount"] != "")
                {
                    Boolean sc_xmlFileCount;
                    if (!Boolean.TryParse((string)sd.Settings[SC_SettingsPrefix + "XMLFileCount"], out sc_xmlFileCount)) SC_XMLFileCount = false;
                    SC_XMLFileCount = sc_xmlFileCount;
                }
                else
                {
                    SC_XMLFileCount = false;
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(sd, exc);
            }

            try
            {
                if ((string)sd.Settings[SC_SettingsPrefix + "ListenerList"] != "")
                {
                    Boolean sc_listenerlist;
                    if (!Boolean.TryParse((string)sd.Settings[SC_SettingsPrefix + "ListenerList"], out sc_listenerlist)) SC_ListenerList = false;
                    SC_ListenerList = sc_listenerlist;
                }
                else
                {
                    SC_ListenerList = false;
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
            try
            {
                if ((string)sd.Settings[SC_SettingsPrefix + "LastPlayed"] != "")
                {
                    Boolean sc_lastplayed;
                    if (!Boolean.TryParse((string)sd.Settings[SC_SettingsPrefix + "LastPlayed"], out sc_lastplayed)) SC_LastPlayed = false;
                    SC_LastPlayed = sc_lastplayed;
                }
                else
                {
                    SC_LastPlayed = false;
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// LoadSettings loads the settings from the Database and displays them 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 

        public void LoadSettings(PortalModuleBase md)
        {
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "IP"] != "")
                {
                    SC_IP = (string)md.Settings[SC_SettingsPrefix + "IP"];
                }
                else
                {
                    SC_IP = "";
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "Port"] != "")
                {
                    SC_Port = (string)md.Settings[SC_SettingsPrefix + "Port"];
                }
                else
                {
                    SC_Port = "";
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "Password"] != "")
                {
                    SC_Password = (string)md.Settings[SC_SettingsPrefix + "Password"];
                }
                else
                {
                    SC_Password = "";
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "AIM"] != "")
                {

                    Boolean sc_aim;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "AIM"], out sc_aim)) sc_aim = false;
                    SC_AIM = sc_aim;

                }
                else
                {
                    SC_AIM = false;
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "AOL"] != "")
                {
                    Boolean sc_aol;
                    if (!Boolean.TryParse ((string)md.Settings[SC_SettingsPrefix + "AOL"], out sc_aol)) sc_aol = false;
                    SC_AOL = sc_aol;
                }
                else
                {
                    SC_AOL = false;
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "AIM"] != "")
                {

                    Boolean sc_icq;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "ICQ"], out sc_icq)) sc_icq = false;
                    SC_ICQ = sc_icq;

                }
                else
                {
                    SC_ICQ = checked(false);
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "MSN"] != "")
                {
                    Boolean sc_msn;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "MSN"], out sc_msn)) sc_msn =false;
                    SC_MSN = sc_msn;
                }
                else
                {
                    SC_MSN = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "Yahoo"] != "")
                {
                    Boolean sc_yahoo;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "Yahoo"], out sc_yahoo)) sc_yahoo =false;
                    SC_Yahoo = sc_yahoo;
                }
                else
                {
                    SC_Yahoo = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "AIM-Chat"] != "")
                {
                    Boolean sc_aimchat;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "AIM-Chat"], out sc_aimchat)) sc_aimchat = false;
                    SC_AIMChat = sc_aimchat;
                }
                else
                {
                    SC_AIMChat = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "StationName"] != "")
                {
                    Boolean sc_stationname;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "StationName"], out sc_stationname)) sc_stationname = false;
                    SC_Station = sc_stationname;
                }
                else
                {
                    SC_Station = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "CurrentListeners"] != "")
                {
                    Boolean sc_currentlisteners;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "CurrentListeners"], out sc_currentlisteners)) sc_currentlisteners = false;
                    SC_CurrentListeners = sc_currentlisteners;
                }
                else
                {
                    SC_CurrentListeners = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "ListenerPeak"] != "")
                {
                    Boolean sc_peaklistener;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "ListenerPeak"], out sc_peaklistener)) sc_peaklistener = false;
                  
                    SC_PeakListeners = sc_peaklistener;
                }
                else
                {
                    SC_PeakListeners = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "MaxListeners"] != "")
                {
                    Boolean sc_maxlisteners;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "MaxListeners"], out sc_maxlisteners)) sc_maxlisteners = false;
                    SC_MaxListeners = sc_maxlisteners;
                }
                else
                {
                    SC_MaxListeners = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "Genre"] != "")
                {
                    Boolean sc_Genre;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "Genre"], out sc_Genre)) sc_Genre = false;
                    SC_genre = sc_Genre;
                }
                else
                {
                    SC_genre = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "CurrentTitle"] != "")
                {
                    Boolean sc_title;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "CurrentTitle"], out sc_title)) sc_title = false;
                    SC_Song = sc_title;
                }
                else
                {
                    SC_Song = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "DJname"] != "")
                {
                    Boolean sc_djname;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "DJname"], out sc_djname)) sc_djname = false;
                    SC_DJ = sc_djname;
                }
                else
                {
                    SC_DJ = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "Bitrate"] != "")
                {
                    Boolean sc_bitrate;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "Bitrate"], out sc_bitrate)) sc_bitrate = false;
                    SC_Bitrate = sc_bitrate;
                }
                else
                {
                    SC_Bitrate = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "ContentType"] != "")
                {
                    Boolean sc_contenttyp;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "ContentType"], out sc_contenttyp)) sc_contenttyp = false;
                    SC_Content = sc_contenttyp;
                }
                else
                {
                    SC_Content = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "Winamp"] != "")
                {
                    Boolean sc_winamp;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "Winamp"], out sc_winamp)) sc_winamp = false;
                    SC_Winamp = sc_winamp;
                }
                else
                {
                    SC_Winamp = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "MediaPlayer"] != "")
                {
                    Boolean sc_mediaplayer;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "MediaPlayer"], out sc_mediaplayer)) sc_mediaplayer = false;
                    SC_MediaPlayer = sc_mediaplayer;
                }
                else
                {
                    SC_MediaPlayer = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "RealPlayer"] != "")
                {
                    Boolean sc_realplayer;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "RealPlayer"], out sc_realplayer)) sc_realplayer = false;
                    SC_RealPlayer = sc_realplayer;
                }
                else
                {
                    SC_RealPlayer = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "iTunes"] != "")
                {
                    Boolean sc_itunes;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "iTunes"], out sc_itunes)) sc_itunes = false;
                    SC_iTunes = sc_itunes;
                }
                else
                {
                    SC_iTunes = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                if ((string)md.Settings[SC_SettingsPrefix + "PlayerLabel"] != "")
                {
                    Boolean sc_player;
                    if (!Boolean.TryParse((string)md.Settings[SC_SettingsPrefix + "PlayerLabel"], out sc_player)) sc_player = false;
                    SC_Player = sc_player;
                }
                else
                {
                    SC_Player = checked(false);
                }
            }
            catch (Exception exc)
            {
                // Module faild to Load
                Exceptions.ProcessModuleLoadException(md, exc);
            }





        }



        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// StatsUpdateSettings saves the modified settings to the Database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 

        public void StatsUpdateSettings(PortalModuleBase sd)
        {
            try
            {
                var objModules = new ModuleController();
                objModules.UpdateModuleSetting(sd.ModuleId, SC_SettingsPrefix + "IP", SC_IP);
            }

            catch (Exception exc)
            {
                //Module faild to load
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
            try
            {
                var objModules = new ModuleController();
                objModules.UpdateModuleSetting(sd.ModuleId, SC_SettingsPrefix + "Port", SC_Port);
            }

            catch (Exception exc)
            {
                //Module faild to load
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
        try
            {
                var objModules = new ModuleController();
                objModules.UpdateModuleSetting(sd.ModuleId, SC_SettingsPrefix + "Password", SC_Password);
            }

            catch (Exception exc)
            {
                //Module faild to load
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(sd.ModuleId, SC_SettingsPrefix + "XMLFileCount", SC_XMLFileCount.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(sd, exc);
            }

            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(sd.ModuleId, SC_SettingsPrefix + "ListenerList", SC_ListenerList.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(sd, exc);
            }

            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(sd.ModuleId, SC_SettingsPrefix + "LastPlayed", SC_LastPlayed.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(sd, exc);
            }
        
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// UpdateSettings saves the modified settings to the Database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void UpdateSettings(PortalModuleBase md)
        {
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "IP", SC_IP);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Port", SC_Port);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Password", SC_Password);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "AIM", SC_AIM.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "AOL", SC_AOL.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "ICQ", SC_ICQ.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "MSN", SC_MSN.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Yahoo", SC_Yahoo.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "StationName", SC_Station.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "CurrentListeners", SC_CurrentListeners.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "ListenerPeak", SC_PeakListeners.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "MaxListeners", SC_MaxListeners.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Genre", SC_genre.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "CurrentTitle", SC_Song.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "DJname", SC_DJ.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Bitrate", SC_Bitrate.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "ContentType", SC_Content.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Winamp", SC_Winamp.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "MediaPlayer", SC_MediaPlayer.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "RealPlayer", SC_RealPlayer.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "iTunes", SC_iTunes.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                var objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "PlayerLabel", SC_Player.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


       

        #endregion

    }

}
