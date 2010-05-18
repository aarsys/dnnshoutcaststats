// 
// Aarsys� M. Schlomann - http://www.aarsys.de 
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
using System.IO;
using Aarsys.ShoutcastStats.Components;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.UI.WebControls;

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

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    lbl_refresh.Text = Localization.GetString("Not refreshed yet", this.LocalResourceFile);
        //}
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
                    // Loading the settings from ShoutcastStatsSettings Control //
                    scs.LoadSettings(this);
                    using (ShoutcastServer s =
                        new ShoutcastServer("http://" + scs.SC_IP + ":" + scs.SC_Port + "/admin.cgi?mode=viewxml&pass=" + scs.SC_Password))
                    {
                        // Checking the Stream status and displays offline if the stream is off //
                        if (
                           s.StreamStatus != true)
                        {
                            lbl_Status.Text = Localization.GetString("Offline", this.LocalResourceFile);
                            lbl_Station.Visible = false;
                            lbl_SongTitle.Visible = false;
                            lbl_CurrentListeners.Visible = false;
                            lbl_Bitrate.Visible = false;
                            lbl_MaxListeners.Visible = false;
                            lbl_ScsSong.Visible = false;
                            lbl_SongTitle.Visible = false;
                        }

                        else
                        {
                            lbl_Status.Visible = false;
                            // Displays the text of the Station Name //
                            if (s.ServerTitle == "N/A")
                                lbl_Station.Visible = false;
                            else
                            {
                                lbl_Station.Text = s.ServerTitle;
                            }
                            // Displaying the current Listeners //

                            lbl_CurrentListeners.Text = Localization.GetString("Current Listeners", this.LocalResourceFile) + " : " + s.CurrentListeners.ToString();
                            // Displays the current Bitrate of the Stream //
                            lbl_Bitrate.Text = Localization.GetString("Bitrate", this.LocalResourceFile) + " : " + s.Bitrate + "Kbps";
                            // Displays the max. listeners of the Stream //
                            lbl_MaxListeners.Text = Localization.GetString("Max Listeners", this.LocalResourceFile) + " : " + s.MaxListeners.ToString();
                            //Displays the current played song in a marquee //
                            lbl_SongTitle.Text = Localization.GetString("Song Title", this.LocalResourceFile) + " : ";

                            lbl_ScsSong.Text = "<marquee class=\"scs_marquee\">" + s.SongTitle + "</marquee>";
                            // Shows the DJ name //
                            lbl_AIM.Text = Localization.GetString("Your DJ", this.LocalResourceFile) + " : " + s.AIM;
                            // Adding Messenger URLs could be enabled/disabled from the ModuleSettings // 
                            if ((string)scs.SC_AIM.ToString() != string.Empty)
                            {
                                bool showAIM;
                                if (!bool.TryParse(scs.SC_AIM.ToString() as string, out showAIM))
                                {
                                    showAIM = true;
                                }
                                lkl_AIM.Visible = scs.SC_AIM;
                                lkl_AIM.NavigateUrl = "aim:goim?screenname=" + s.AIM;
                                lkl_AIM.ToolTip = Localization.GetString("Chat with your DJ", this.LocalResourceFile);
                                lkl_AIM.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/aim.jpg";
                            }
                            if ((string)scs.SC_AOL.ToString() != string.Empty)
                            {
                                bool showAOL;
                                if (!bool.TryParse(scs.SC_AOL.ToString() as string, out showAOL))
                                {
                                    showAOL = scs.SC_AOL;
                                }
                                lkl_AOL.Visible = showAOL;
                                lkl_AOL.NavigateUrl = "aol://9293:" + s.AIM;
                                lkl_AOL.ToolTip = Localization.GetString("Chat with your DJ", this.LocalResourceFile);
                                lkl_AOL.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/aol-logo.jpg";
                            }
                            if ((string)scs.SC_ICQ.ToString() != string.Empty)
                            {
                                bool showICQ;
                                if (!bool.TryParse(scs.SC_ICQ.ToString() as string, out showICQ))
                                {
                                    showICQ = scs.SC_ICQ;
                                }

                                lkl_ICQ.Visible = showICQ;
                                lkl_ICQ.NavigateUrl = "http://wwp.icq.com/scripts/contact.dll?msgto=" + s.ICQ;
                                lkl_ICQ.ToolTip = Localization.GetString("Chat with your DJ", this.LocalResourceFile);
                                lkl_ICQ.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/icq-logo.jpg";

                            }
                            if ((string)scs.SC_MSN.ToString() != string.Empty)
                            {
                                bool showMSN;
                                if (!bool.TryParse(scs.SC_MSN.ToString() as string, out showMSN))
                                {
                                    showMSN = scs.SC_MSN;
                                }
                                lkl_MSN.Visible = showMSN;
                                lkl_MSN.NavigateUrl = "msnim:chat?contact=" + s.ICQ;
                                lkl_MSN.ToolTip = Localization.GetString("Chat with your DJ", this.LocalResourceFile);
                                lkl_MSN.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/live-logo.jpg";
                            }
                            if ((string)scs.SC_Yahoo.ToString() != string.Empty)
                            {
                                bool showYahoo;
                                if (!bool.TryParse(scs.SC_Yahoo.ToString() as string, out showYahoo))
                                {
                                    showYahoo = scs.SC_Yahoo;
                                }
                                lkl_Yahoo.Visible = showYahoo;
                                lkl_Yahoo.NavigateUrl = "ymsgr:sendim?" + s.ICQ;
                                lkl_Yahoo.ToolTip = Localization.GetString("Chat with your DJ", this.LocalResourceFile);
                                lkl_Yahoo.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/yahoo-logo.jpg";
                            }
                            // Create File stream for MediaPlayer //
                            //Response.ContentType = "video/x-ms-asx";
                            //Response.AddHeader("content-disposition", "attachment; filename=MediaPlayer.asx");

                            //FileStream media = new FileStream(@"Media.asx", FileMode.Create, FileAccess.Write);
                            //StreamWriter sw = new StreamWriter(media);
                            //sw.WriteLine("<ASX version=\"3.0\">");
                            //sw.WriteLine("<ABSTRACT>" + s.ServerTitle + "</ABSTRACT>");
                            //sw.WriteLine("<TITLE>" + s.ServerTitle + "</TITLE>");
                            //sw.WriteLine("<ENTRY>");
                            //sw.WriteLine("<ref href=\"" + scs.SC_IP + ":" + scs.SC_Port + "/>");
                            //sw.Close();
                            //media.Close();

                            //// Create Stream File reader for MediaPlayer Link //
                            //StreamReader mediar = new StreamReader(media);
                            //string mediaplayer = mediar.ReadToEnd();
                            //mediar.Close();
                            //media.Close();
                            //lkl_media.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/yahoo-logo.jpg";
                            //lkl_media.NavigateUrl = Response.TransmitFile(sw);



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