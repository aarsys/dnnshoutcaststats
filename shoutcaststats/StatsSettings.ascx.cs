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
using DotNetNuke.Services.Localization;

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
    partial class StatsSettings : ModuleSettingsBase
    {

        #region "Base Method Implementations"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// StatsLoadSettings loads the settings from the Database and displays them 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
       
            public override void LoadSettings()
        {
            using (ShoutCastSettings scs = new ShoutCastSettings())
            {
                scs.StatsLoadSettings(this);
                if (!IsPostBack)
                {
                    if (scs.SC_IP != "")
                        txtSCS_IP.Text = scs.SC_IP;
                    if (!IsPostBack)
                        if (scs.SC_Port != "")
                            txtSCS_Port.Text = scs.SC_Port;
                    if (!IsPostBack)
                        if (scs.SC_Password != "")
                            txtSCS_Password.Text = scs.SC_Password;
                }
                if (!IsPostBack)
                    if ((string)ModuleSettings[scs.SC_XMLFileCount] != string.Empty)
                    {
                        bool show;
                        if (!bool.TryParse((string)ModuleSettings[scs.SC_XMLFileCount] as string, out show))
                        {
                            show = scs.SC_XMLFileCount; // Default to showing the SC_AIM.
                        }

                        SC_XMLFileCount.Checked = show;
                    }
                if (!IsPostBack)
                    if ((string)ModuleSettings[scs.SC_ListenerList] != string.Empty)
                    {
                        bool show;
                        if (!bool.TryParse((string)ModuleSettings[scs.SC_ListenerList] as string, out show))
                        {
                            show = scs.SC_ListenerList; // Default to showing the SC_ListenerList.
                        }

                        SC_ListenerList.Checked = show;
                    }
                if (!IsPostBack)
                    if ((string)ModuleSettings[scs.SC_LastPlayed] != string.Empty)
                    {
                        bool show;
                        if (!bool.TryParse((string)ModuleSettings[scs.SC_LastPlayed] as string, out show))
                        {
                            show = scs.SC_LastPlayed; // Default to showing the SC_LastPlayed.
                        }

                        SC_LastPlayed.Checked = show;
                    }
               // lblSCS_FeatureSettings.Text = (Localization.GetString("FeatureSettings", this.LocalResourceFile));
            }
        }

         public override void UpdateSettings()
        {
            using (ShoutCastSettings scs = new ShoutCastSettings { SC_IP = txtSCS_IP.Text, SC_Port = txtSCS_Port.Text, SC_Password = txtSCS_Password.Text, SC_XMLFileCount = SC_XMLFileCount.Checked, SC_ListenerList = SC_ListenerList.Checked, SC_LastPlayed = SC_LastPlayed.Checked })
            {
                scs.StatsUpdateSettings(this); 
            }
        }
         #endregion
        }
    }
