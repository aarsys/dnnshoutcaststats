﻿// 
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

using Aarsys.ShoutcastStats.Components;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Security;

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
            using (var scs = new ShoutCastSettings())
            {
                var portalSecurity = new PortalSecurity();
                scs.StatsLoadSettings(this);
                if (!IsPostBack)
                {
                    if (scs.SC_IP != "")
                        txtSCS_IP.Text = portalSecurity.InputFilter(scs.SC_IP, PortalSecurity.FilterFlag.NoMarkup);
                    if (!IsPostBack)
                        if (scs.SC_Port != "")
                            txtSCS_Port.Text = portalSecurity.InputFilter(scs.SC_Port, PortalSecurity.FilterFlag.NoMarkup);
                    if (!IsPostBack)
                        if (scs.SC_Password != "")
                            txtSCS_Password.Text = portalSecurity.InputFilter(scs.SC_Password, PortalSecurity.FilterFlag.NoMarkup);
                }
                if (!IsPostBack)
                    if (scs.SC_XMLFileCount)
                    {
                        SC_XMLFileCount.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_ListenerList)
                    {
                        SC_ListenerList.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_LastPlayed)
                    {
                        SC_LastPlayed.Checked = true;
                    }
              }
        }

         ///<summary>
         ///</summary>
         public override void UpdateSettings()
        {
            var portalSecurity = new PortalSecurity();
            using (var scs = new ShoutCastSettings { SC_IP = portalSecurity.InputFilter(txtSCS_IP.Text, PortalSecurity.FilterFlag.NoMarkup), SC_Port = portalSecurity.InputFilter(txtSCS_Port.Text, PortalSecurity.FilterFlag.NoMarkup), SC_Password = portalSecurity.InputFilter(txtSCS_Password.Text, PortalSecurity.FilterFlag.NoMarkup), SC_XMLFileCount = SC_XMLFileCount.Checked, SC_ListenerList = SC_ListenerList.Checked, SC_LastPlayed = SC_LastPlayed.Checked })
            {
                scs.StatsUpdateSettings(this); 
            }
        }
         #endregion
        }
    }
