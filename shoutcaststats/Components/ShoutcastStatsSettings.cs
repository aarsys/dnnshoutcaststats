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
using System.Web.UI;

using DotNetNuke;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace Aarsys.ShoutcastStats
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

        public string SC_IP { get; set; }

        public string SC_Port { get; set; }

        public string SC_Password { get; set; }

        public bool SC_AIM { get; set; }

        public bool SC_AOL { get; set; }

        public bool SC_ICQ { get; set; }
        
        public bool SC_MSN { get; set; }

        public bool SC_Yahoo { get; set; }

        public bool SC_AIMChat { get; set; }
        
        public bool SC_AOLChat { get; set; }

        public bool SC_ICQChat { get; set; }

        public bool SC_YahooChat { get; set; }

        #endregion


        #region "Base Method Implementations"

        private const string SC_SettingsPrefix = "Aarsys_ShoutcastStats_SC_";

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
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "IP", SC_IP);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Port", SC_Port);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(md, exc);
            }
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Password", SC_Password);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "AIM", SC_AIM.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "AOL", SC_AOL.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "ICQ", SC_ICQ.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }

            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "MSN", SC_MSN.ToString());
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateModuleSetting(md.ModuleId, SC_SettingsPrefix + "Yahoo", SC_Yahoo.ToString());
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
