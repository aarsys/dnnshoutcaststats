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
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Aarsys.ShoutcastStats.Components;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using Aarsys.ShoutcastStats;


namespace Aarsys.ShoutcastStats
{
    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The StatsDNN_ShoutcastStats class displays the content 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 


    partial class Stats_ShoutcastStats : PortalModuleBase
    {

        #region "Event Handlers"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Page_Load runs when the control is loaded 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                using (ShoutCastSettings scs = new ShoutCastSettings())
                {
                    scs.LoadSettings(this);
                    using (ShoutcastServer s =
                        new ShoutcastServer("http://" + scs.SC_IP + ":" + scs.SC_Port + "/admin.cgi?mode=viewxml&pass=" + scs.SC_Password))
                    {
                        if (
                           s.StreamStatus != true)
                            lbl_Status.Text = Localization.GetString("Offline", this.LocalResourceFile);
                        else
                        {                             
                        lbl_ViewXml.Text = string.Format(Localization.GetString("Xml Config file has been viewed", this.LocalResourceFile) + " {0} " + Localization.GetString("times", this.LocalResourceFile) + ".", s.Webdata.ViewXml);
                        lbl_Listeners.Text = Localization.GetString("Diplaying info for", this.LocalResourceFile) + s.Listeners.Count + " " + Localization.GetString("listeners", this.LocalResourceFile) + "<br>";
                        foreach (Listener listener in s.Listeners)
                        {
                            int seconds;
                            int minutes = Math.DivRem(listener.ConnectTime, 60, out seconds);
                            int hours = Math.DivRem(minutes, 60, out minutes);
                            Label label = new Label();
                            label.Text = Localization.GetString("Listener", this.LocalResourceFile) + " " + listener.HostName + " " + Localization.GetString("has", this.LocalResourceFile) + " " + listener.Underruns + " " + Localization.GetString("Underruns so far and is connected for", this.LocalResourceFile) + " " + hours + " " + Localization.GetString("hours", this.LocalResourceFile) +", " 
                                + minutes + " " + Localization.GetString("minutes and", this.LocalResourceFile) + " " + seconds + " " + Localization.GetString("seconds", this.LocalResourceFile) + "<br>";
                            label.ID = listener.HostName;
                            Panel1.Controls.Add(label);
                            label.Dispose();
                        }
                        lbl_SongHistory.Text = Localization.GetString("Displaying the", this.LocalResourceFile) + " " + s.SongHistory.Count + " " + Localization.GetString("last played songs", this.LocalResourceFile) + "<br>";
                        foreach (Song song in s.SongHistory)
                        {
                            Label label = new Label();
                            label.Text = song.SongTitle + " " + Localization.GetString("Played At", this.LocalResourceFile) + " : " + song.PlayedAt.ToString() + "<br>";
                            label.ID = song.SongTitle;
                            Panel2.Controls.Add(label);
                            label.Dispose();
                        }
                    }
                }

            }
        }
            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }

        }
        
        #endregion



    }

}
