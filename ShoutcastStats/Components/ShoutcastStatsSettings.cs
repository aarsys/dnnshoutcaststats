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
        }

        #endregion

    }

}
