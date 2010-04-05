// 
// DotNetNuke® - http://www.dotnetnuke.com 
// Copyright (c) 2002-2009 
// by DotNetNuke Corporation 
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

namespace Aarsys.ShoutcastStats
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The ViewDNN_ShoutcastStats class displays the content 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    partial class View_ShoutcastStats : PortalModuleBase 
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
                        lbl_CurrentListeners.Text = "Current Listeners : " + s.CurrentListeners.ToString();
                        lbl_Bitrate.Text = "Bitrate : " + s.Bitrate + "Kbps";
                        lbl_MaxListeners.Text = "Max Listeners : " + s.MaxListeners.ToString();
                        lbl_SongTitle.Text = "Song Title : " + s.SongTitle;
                        lbl_AIM.Text = "Your DJ : " + s.AIM;
                        lbl_ViewXml.Text = string.Format("Xml Config file has been viewed {0} times.", s.Webdata.ViewXml);
                        lbl_Listeners.Text = "Diplaying info for " + s.Listeners.Count + " listeners<br>";
                        foreach (Listener listener in s.Listeners)
                        {
                            int seconds;
                            int minutes = Math.DivRem(listener.ConnectTime, 60, out seconds);
                            int hours = Math.DivRem(minutes, 60, out minutes);
                            Label label = new Label();
                            label.Text = "Listener " + listener.HostName + " has " + listener.Underruns +
                                " Underruns so far and is connected for " + hours + " hours, "
                                + minutes + " minutes and " + seconds + " seconds<br>";
                            label.ID = listener.HostName;
                            Panel1.Controls.Add(label);
                            label.Dispose();
                        }
                        lbl_SongHistory.Text = "Displaying the " + s.SongHistory.Count + " last played songs<br>";
                        foreach (Song song in s.SongHistory)
                        {
                            Label label = new Label();
                            label.Text = song.SongTitle + " Played At : " + song.PlayedAt.ToString() + "<br>";
                            label.ID = song.SongTitle;
                            Panel2.Controls.Add(label);
                            label.Dispose();
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