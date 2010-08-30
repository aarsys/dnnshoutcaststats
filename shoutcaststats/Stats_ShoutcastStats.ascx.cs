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
using System.Web.UI.WebControls;
using System.Linq;
using Aarsys.ShoutcastStats.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;


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


    partial class StatsShoutcastStats : PortalModuleBase
    {

        #region "Event Handlers"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Page_Load runs when the control is loaded 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
        protected void Page_Load(object sender, EventArgs e)
        {
            var portalSecurity = new PortalSecurity();
            try
            {
                using (var scs = new ShoutCastSettings())
                {
                   // Used http strings instead of secure strings about Shoutcast server do not support SSL! //
                    scs.StatsLoadSettings(this);
                    using (var s =
                        new ShoutcastServer("http://" + scs.SC_IP + ":" + scs.SC_Port + "/admin.cgi?mode=viewxml&pass=" + scs.SC_Password))
                    {
                        if (s.StreamStatus != true)
                            lbl_Status.Text = Localization.GetString("Offline", LocalResourceFile);
                        else
                        {

                            if (scs.SC_XMLFileCount)
                                {
                                lbl_ViewXml.Visible = true;
                                lbl_ViewXml.Text = string.Format(Localization.GetString("Xml Config file has been viewed", LocalResourceFile) + portalSecurity.InputFilter((" {0} "),PortalSecurity.FilterFlag.NoMarkup) + Localization.GetString("times", LocalResourceFile) + ".", s.Webdata.ViewXml);
                            }
                            else
                            {
                                lbl_ViewXml.Visible = false;
                            }
                            if (scs.SC_ListenerList)
                            {
                                lbl_Listeners.Visible = true;
                                lbl_Listeners.Text = Localization.GetString("Diplaying info for", LocalResourceFile) +
                                                     (s.Listeners.Count()) + @" " +
                                                     Localization.GetString("listeners", LocalResourceFile) + @"<br />";
                                foreach (var listener in s.Listeners)
                                {
                                    int seconds;
                                    int minutes = Math.DivRem(listener.ConnectTime, 60, out seconds);
                                    int hours = Math.DivRem(minutes, 60, out minutes);
                                    var label = new Label
                                                    {
                                                        Visible = true,
                                                        Text =
                                                            Localization.GetString("Listener", LocalResourceFile) + @" " +
                                                            portalSecurity.InputFilter(listener.HostName,
                                                                                       PortalSecurity.FilterFlag.
                                                                                           NoMarkup) + @" " +
                                                            Localization.GetString("has", LocalResourceFile) + @" " +
                                                            portalSecurity.InputFilter(listener.Underruns,
                                                                                       PortalSecurity.FilterFlag.
                                                                                           NoMarkup) + @" " +
                                                            Localization.GetString(
                                                                "Underruns so far and is connected for",
                                                                LocalResourceFile) + @" " + hours + @" " +
                                                            Localization.GetString("hours", LocalResourceFile) + @", "
                                                            + minutes + @" " +
                                                            Localization.GetString("minutes and", LocalResourceFile) +
                                                            @" " + seconds + @" " +
                                                            Localization.GetString("seconds", LocalResourceFile) +
                                                            @"<br />",
                                                        ID = Server.HtmlEncode(listener.HostName)
                                                    };
                                    Panel1.Controls.Add(label);
                                    //label.Dispose();
                                }
                            }
                            else
                            {
                                lbl_Listeners.Visible = false;
                            }
                            //if ((string)scs.SC_LastPlayed.ToString() != string.Empty)
                           // {
                                //bool showlastPlayed;
                                //if (!bool.TryParse(scs.SC_LastPlayed.ToString() as string, out showlastPlayed))
                                //{
                                //    showlastPlayed = true;
                                //}   Still prevent s.SongHistory for XXS using HtmlEncode or else 
                                if (scs.SC_LastPlayed)
                                {
                                lbl_SongHistory.Visible = true;
                                lbl_SongHistory.Text = Localization.GetString("Displaying the", LocalResourceFile) + @" " + (s.SongHistory.Count) + @" " + Localization.GetString("last played songs", LocalResourceFile) + @"<br>";
                                foreach (var label in s.SongHistory.Select(song => new Label
                                                                                       {
                                                                                           Visible = true, Text = portalSecurity.InputFilter(song.SongTitle, PortalSecurity.FilterFlag.NoMarkup) + @" " + Localization.GetString("Played At", LocalResourceFile) + @" : " + portalSecurity.InputFilter((song.PlayedAt.ToString()), PortalSecurity.FilterFlag.NoMarkup) + @"<br />", ID = portalSecurity.InputFilter(song.SongTitle, PortalSecurity.FilterFlag.NoMarkup)
                                                                                       }))
                                {
                                    Panel2.Controls.Add(label);
                                }
                            }
                                else
                                {
                                    lbl_SongHistory.Visible = false;
                                }
                    }
                }

            }
        }
            
            // Module Failed To Load Exception Handling
            catch (Exception exc)
            {
                //Module failed to load
                var error = Localization.GetString("ConnectionFailed.error", LocalResourceFile);
                Exceptions.ProcessModuleLoadException(error, this, exc, true); 
            }

        }
        
        #endregion



    }

}
