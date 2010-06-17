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
using System.IO;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.UI.WebControls;
using Aarsys.ShoutcastStats;
using Aarsys.ShoutcastStats.Components;

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
    partial class View_ShoutcastStats : PortalModuleBase //, IActionable 
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
                        // Register the AJAX Postback Controls for the Player Links //
                        DotNetNuke.Framework.AJAX.RegisterPostBackControl(WinampStart);
                        DotNetNuke.Framework.AJAX.RegisterPostBackControl(MediaPlayerStart);
                        DotNetNuke.Framework.AJAX.RegisterPostBackControl(RealPlayerStart);
                        DotNetNuke.Framework.AJAX.RegisterPostBackControl(ITunesStart);


                        // Implements UpdatePanel to update the content //
                        if (DotNetNuke.Framework.AJAX.IsInstalled())
                        {
                            DotNetNuke.Framework.AJAX.RegisterScriptManager();
                            //DotNetNuke.Framework.AJAX.WrapUpdatePanelControl(SCS_UpdatePanel, true);
                            
                        }

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
                            lbl_PeakListeners.Visible = false;
                            lbl_Genre.Visible = false;
                            ITunesStart.Visible = false;
                            WinampStart.Visible = false;
                            MediaPlayerStart.Visible = false;
                            RealPlayerStart.Visible = false;
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
                            // Displaying the Peak of the Listeners //

                            lbl_PeakListeners.Text = Localization.GetString("PeakListeners", this.LocalResourceFile) + " : " + s.PeakListeners;
                            {
                                lbl_Station.Text = s.ServerTitle;
                            }
                            // Displaying the current Listeners //

                            lbl_CurrentListeners.Text = Localization.GetString("CurrentListeners", this.LocalResourceFile) + " : " + s.CurrentListeners.ToString();
                            // Displays the current Bitrate of the Stream //
                            lbl_Bitrate.Text = Localization.GetString("Bitrate", this.LocalResourceFile) + " : " + s.Bitrate + "Kbps";
                            // Displays the max. listeners of the Stream //
                            lbl_MaxListeners.Text = Localization.GetString("MaxListeners", this.LocalResourceFile) + " : " + s.MaxListeners.ToString();
                            // Displays the genre //
                            lbl_Genre.Text = Localization.GetString("Genre", this.LocalResourceFile) + " : " + s.ServerGenre;
                            lbl_ContentType.Text = Localization.GetString("ContentType", this.LocalResourceFile) + " : " + s.Content;
                            //Displays the current played song in a marquee //
                            lbl_SongTitle.Text = Localization.GetString("SongTitle", this.LocalResourceFile) + " : ";

                            lbl_ScsSong.Text = "<marquee class=\"scs_marquee\">" + s.SongTitle + "</marquee>";
                            // Shows the DJ name //
                            lbl_AIM.Text = Localization.GetString("YourDJ", this.LocalResourceFile) + " : " + s.AIM;
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
                                lkl_AIM.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
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
                                lkl_AOL.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
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
                                lkl_ICQ.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
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
                                lkl_MSN.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
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
                                lkl_Yahoo.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                lkl_Yahoo.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/yahoo-logo.jpg";
                            }

                            // Adding Attributes to the Start Player ImageButtons  //
                            lblStartPlayer.Text = Localization.GetString("StartPlayer", this.LocalResourceFile);
                            lblStartPlayer.ToolTip = Localization.GetString("StartPlayer", this.LocalResourceFile);
                            WinampStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/winamp.gif";
                            WinampStart.ToolTip = Localization.GetString("StartWinampPlayer.ToolTip", this.LocalResourceFile);
                            WinampStart.AlternateText = Localization.GetString("StartWinampPlayer.AlternateText", this.LocalResourceFile);
                            
                            MediaPlayerStart.ToolTip = Localization.GetString("StartMediaPlayer.ToolTip", this.LocalResourceFile);
                            MediaPlayerStart.AlternateText = Localization.GetString("StartMediaPlayer.AlternateText", this.LocalResourceFile);
                            MediaPlayerStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/mplayer.gif";

                            RealPlayerStart.ToolTip = Localization.GetString("StartRealPlayer.ToolTip", this.LocalResourceFile);
                            RealPlayerStart.AlternateText = Localization.GetString("StartRealPlayer.AlternateText", this.LocalResourceFile);
                            RealPlayerStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/realplayer.gif";
                            ITunesStart.ToolTip = Localization.GetString("StartITunes.ToolTip", this.LocalResourceFile);
                            ITunesStart.AlternateText = Localization.GetString("StartITunes.AlternateText", this.LocalResourceFile);
                            ITunesStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/itunes.gif";

                           
                        }
                    }
                }
            }


        //added catch Exception by order of VS
            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }

        }


        // Start  different Players by creating a memory stream for the file and download it by the client as a hyperlink  //
       
        protected void MediaButton_Click(object sender, EventArgs e)
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
                        //ImageButton MediaPlayerStart = (ImageButton)sender;
                        MemoryStream MediaPlayer = new MemoryStream();
                        
                        StreamWriter tw = new StreamWriter(MediaPlayer);
                        tw.WriteLine("<ASX version=\"3.0\">");
                        tw.WriteLine("<ABSTRACT>" + s.ServerUrl + "</ABSTRACT>");
                        tw.WriteLine("<TITLE>" + s.ServerTitle + "</TITLE>");
                        tw.WriteLine("<MOREINFO HREF=\"" + s.ServerUrl + "\"/>");
                        tw.WriteLine("<ref href=\"http://" + scs.SC_IP + ":" + scs.SC_Port + "\"/>");
                        tw.WriteLine("<ENTRY>");
                        tw.WriteLine("<ABSTRACT>" + s.ServerTitle + "</ABSTRACT>");
                        tw.WriteLine("<TITLE>" + s.ServerTitle + "</TITLE>");
                        tw.WriteLine("<AUTHOR>" + s.ServerUrl + "</AUTHOR>");
                        tw.WriteLine("<ref href=\"http://" + scs.SC_IP + ":" + scs.SC_Port + "\"/>");
                        tw.WriteLine("<ref href=\"icyx://" + scs.SC_IP + ":" + scs.SC_Port + "\"/>");
                        tw.WriteLine("<MOREINFO HREF=\"" + s.ServerUrl +"\"/>");
                        tw.WriteLine("</ENTRY>");
                        tw.WriteLine("</ASX>");
                        tw.Flush();
                        
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=" + scs.SC_Port +".asx"));
                        Response.ContentType = "video/x-ms-asf";
                       
                        MediaPlayer.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.Close();
                        Response.End();
                        MediaPlayer.Dispose();

                    }
                  }
                }
        

            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void WinampButton_Click(object sender, EventArgs e)
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
                        MemoryStream WinampPlayer = new MemoryStream();
                        StreamWriter wt = new StreamWriter(WinampPlayer);
                        wt.WriteLine("[playlist]");
                        wt.WriteLine("NumberOfEntries=1");
                        wt.WriteLine("File1=http://" + scs.SC_IP + ":" + scs.SC_Port + "/");
                        wt.Flush();
                                               
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=\"" + scs.SC_Port + ".pls\""));
                        Response.ContentType="audio/x-scpls";
                                                                        
                        WinampPlayer.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.Close();
                        Response.End();
                        WinampPlayer.Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void RealButton_Click(object sender, EventArgs e)
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
                        MemoryStream RealPlayer= new MemoryStream();
                        StreamWriter rt = new StreamWriter(RealPlayer);
                        rt.WriteLine("http://" + scs.SC_IP + ":" + scs.SC_Port + "/");
                        rt.Flush();
                        
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=" + scs.SC_Port + ".ram"));
                        Response.ContentType = "audio/x-pn-realaudio";
                        RealPlayer.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.Close();
                        Response.End();
                        RealPlayer.Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void ITunesButton_Click(object sender, EventArgs e)
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
                        
                        MemoryStream ITunes = new MemoryStream();
                        StreamWriter it = new StreamWriter(ITunes);
                        it.WriteLine("<?xml version=\"1.0\"?>");
                        it.WriteLine("<?quicktime type=\"application/x-quicktime-media-link\"?>");
                        it.WriteLine("<embed src=\"icy://" + scs.SC_IP + ":" + scs.SC_Port + "\" autoplay=\"true\" /> ");
                        it.Flush();
                       
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=\"" + scs.SC_Port + ".qtl\""));
                        Response.ContentType = "audio/x-mpegurl "; // Quicktime does not support AAC codec on Streams!

                        ITunes.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.Close();
                        Response.End();
                        ITunes.Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
        protected void SCS_TimerTick(object sender, EventArgs e)
        {
           
                        this.lbl_ScsSong.Text = lbl_ScsSong.Text;
                    }
                }
            
           
        
        
        #endregion

    
       
    }

 


