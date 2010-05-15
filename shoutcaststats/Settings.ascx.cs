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
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_AIM] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_AIM] as string, out show))
                            {
                                show = scs.SC_AIM; // Default to showing the SC_AIM.
                            }

                            SC_AIMCheckBox.Checked = show;
                        }
                    
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_AOL] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_AOL], out show))
                            {
                               show = scs.SC_AOL; // Default to showing the SC_AOL.
                            }
                            SC_AOLCheckBox.Checked = show;
                        }

                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_ICQ] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_ICQ], out show))
                            {
                              show = scs.SC_ICQ; // Default to showing the SC_ICQ.
                            }
                            SC_ICQCheckBox.Checked = show;
                        }
                    
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_MSN] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_MSN], out show))
                            {
                                show = scs.SC_MSN; // Default to showing the SC_MSN.
                            }
                            SC_MSNCheckBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_Yahoo] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_Yahoo], out show))
                            {
                                show = scs.SC_Yahoo; // Default to showing the SC_Yahoo.
                            }
                            SC_YahooCheckBox.Checked = show;
                        }
                    lblSC_MSG.Text = DotNetNuke.Services.Localization.Localization.GetString("lblSCMSG", LocalResourceFile);
                }
            }
        }
        
        public override void UpdateSettings()
        {
            using (ShoutCastSettings scs = new ShoutCastSettings { SC_IP = txtSC_IP.Text, SC_Port = txtSC_Port.Text, SC_Password = txtSC_Password.Text, SC_AIM = SC_AIMCheckBox.Checked, SC_AOL = SC_AOLCheckBox.Checked, SC_ICQ = SC_ICQCheckBox.Checked, SC_MSN = SC_MSNCheckBox.Checked, SC_Yahoo = SC_YahooCheckBox.Checked })
            {
                scs.UpdateSettings(this); 
            }
        }
        #endregion

       

      

    }

}

