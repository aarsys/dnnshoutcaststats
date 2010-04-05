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
    partial class Settings : ModuleSettingsBase
    {

        #region "Base Method Implementations"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// LoadSettings loads the settings from the Database and displays them 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
        public override void LoadSettings()
        {
            using (ShoutCastSettings scs = new ShoutCastSettings())
            {
                scs.LoadSettings(this);
                if (!IsPostBack)
                {
                    if (scs.SC_IP != "")
                        txtSC_IP.Text = scs.SC_IP;
                    if (!IsPostBack)
                        if (scs.SC_Port != "")
                            txtSC_Port.Text = scs.SC_Port;
                    if (!IsPostBack)
                        if (scs.SC_Password != "")
                            txtSC_Password.Text = scs.SC_Password;
                }
            }
        }

        public override void UpdateSettings()
        {
            using (ShoutCastSettings scs = new ShoutCastSettings { SC_IP = txtSC_IP.Text, SC_Port = txtSC_Port.Text, SC_Password = txtSC_Password.Text })
            {
                scs.UpdateSettings(this);
            }
        }
        #endregion

    }

}

