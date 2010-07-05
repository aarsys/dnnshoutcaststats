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
                            lbl_CurrentListeners.Visible = false;
                            lbl_Bitrate.Visible = false;
                            lbl_MaxListeners.Visible = false;
                            lbl_ScsSong.Visible = false;
                            lbl_SongTitle.Visible = false;
                            lbl_PeakListeners.Visible = false;
                            lbl_Genre.Visible = false;
                            lbl_ContentType.Visible = false;
                            lbl_AIM.Visible = false;
                            lkl_AIM.Visible = false;
                            lkl_AOL.Visible = false;
                            lkl_ICQ.Visible = false;
                            lkl_MSN.Visible = false;
                            lkl_Yahoo.Visible = false;
                            lblStartPlayer.Visible = false;
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
                                if ((string)scs.SC_Station.ToString() != string.Empty)
                                {
                                    bool showStation;
                                    if (!bool.TryParse(scs.SC_Station.ToString() as string, out showStation))
                                    {
                                        showStation = scs.SC_Station;
                                    }
                                    lbl_Station.Visible = showStation;
                                    lbl_Station.Text = s.ServerTitle;
                                }
                            }
                            // Displaying the Peak of the Listeners //
                            if ((string)scs.SC_PeakListeners.ToString() != string.Empty)
                            {
                                bool showPeakListeners;
                                if (!bool.TryParse(scs.SC_PeakListeners.ToString() as string, out showPeakListeners))
                                {
                                    showPeakListeners = scs.SC_PeakListeners;
                                }
                                lbl_PeakListeners.Visible = showPeakListeners;
                                lbl_PeakListeners.Text = Localization.GetString("PeakListeners", this.LocalResourceFile) + " : " + s.PeakListeners;
                            }

                            // Displaying the current Listeners //
                            if ((string)scs.SC_CurrentListeners.ToString() != string.Empty)
                            {
                                bool showCurrentListeners;
                                if (!bool.TryParse(scs.SC_CurrentListeners.ToString() as string, out showCurrentListeners))
                                {
                                    showCurrentListeners = scs.SC_CurrentListeners;
                                }
                                lbl_CurrentListeners.Visible = showCurrentListeners;
                                lbl_CurrentListeners.Text = Localization.GetString("CurrentListeners", this.LocalResourceFile) + " : " + s.CurrentListeners.ToString();
                            }
                            // Displays the current Bitrate of the Stream //
                            if ((string)scs.SC_Bitrate.ToString() != string.Empty)
                            {
                                bool showBitrate;
                                if (!bool.TryParse(scs.SC_Bitrate.ToString() as string, out showBitrate))
                                {
                                    showBitrate = scs.SC_Bitrate;
                                }
                                lbl_Bitrate.Visible = showBitrate;
                                lbl_Bitrate.Text = Localization.GetString("Bitrate", this.LocalResourceFile) + " : " + s.Bitrate + "Kbps";
                            }
                            // Displays the max. listeners of the Stream //
                            if ((string)scs.SC_MaxListeners.ToString() != string.Empty)
                            {
                                bool showMaxListeners;
                                if (!bool.TryParse(scs.SC_MaxListeners.ToString() as string, out showMaxListeners))
                                {
                                    showMaxListeners = scs.SC_MaxListeners;
                                }
                                lbl_MaxListeners.Visible = showMaxListeners;
                                lbl_MaxListeners.Text = Localization.GetString("MaxListeners", this.LocalResourceFile) + " : " + s.MaxListeners.ToString();
                            }
                            // Displays the genre //
                            if ((string)scs.SC_genre.ToString() != string.Empty)
                            {
                                bool showgenre;
                                if (!bool.TryParse(scs.SC_genre.ToString() as string, out showgenre))
                                {
                                    showgenre = scs.SC_genre;
                                }
                                lbl_Genre.Visible = showgenre;

                                lbl_Genre.Text = Localization.GetString("Genre", this.LocalResourceFile) + " : " + s.ServerGenre;
                            }
                            //Displays the ContentType //
                            if ((string)scs.SC_Content.ToString() != string.Empty)
                            {
                                bool showContenttype;
                                if (!bool.TryParse(scs.SC_Content.ToString() as string, out showContenttype))
                                {
                                    showContenttype = scs.SC_Content;
                                }
                                lbl_ContentType.Visible = showContenttype;
                                lbl_ContentType.Text = Localization.GetString("ContentType", this.LocalResourceFile) + " : " + s.Content;
                            }
                            //Displays the current played song in a marquee //
                            if ((string)scs.SC_Song.ToString() != string.Empty)
                            {
                                bool showsong;
                                if (!bool.TryParse(scs.SC_Song.ToString() as string, out showsong))
                                {
                                    showsong = scs.SC_Song;
                                }
                                lbl_SongTitle.Visible = showsong;
                                lbl_SongTitle.Text = Localization.GetString("SongTitle", this.LocalResourceFile) + " : ";
                                lbl_ScsSong.Visible = showsong;
                                lbl_ScsSong.Text = "<marquee class=\"scs_marquee\">" + s.SongTitle + "</marquee>";
                                // Shows the DJ name //
                                if ((string)scs.SC_DJ.ToString() != string.Empty)
                                {
                                    bool showdj;
                                    if (!bool.TryParse(scs.SC_DJ.ToString() as string, out showdj))
                                    {
                                        showdj = scs.SC_DJ;
                                    }
                                    lbl_AIM.Visible = showdj;
                                    lbl_AIM.Text = Localization.GetString("YourDJ", this.LocalResourceFile) + " : " + s.AIM;
                                }
                                // Adding Messenger URLs could be enabled/disabled from the ModuleSettings // 
                                if ((string)scs.SC_AIM.ToString() != string.Empty)
                                {
                                    bool showAIM;
                                    if (!bool.TryParse(scs.SC_AIM.ToString() as string, out showAIM))
                                    {
                                        showAIM = true;
                                    }
                                    lkl_AIM.Visible = showAIM;
                                    lkl_AIM.NavigateUrl = "aim:goim?screenname=" + s.AIM;
                                    lkl_AIM.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_AIM.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/aim.jpg";
                                }
                                if ((string)scs.SC_AOL.ToString() != string.Empty)
                                {
                                    bool showAOL;
                                    if (!bool.TryParse(scs.SC_AOL.ToString() as string, out showAOL))
                                    {
                                        showAOL = true;
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
                                        showICQ = true;
                                    }

                                    lkl_ICQ.Visible = scs.SC_ICQ;
                                    lkl_ICQ.NavigateUrl = "http://wwp.icq.com/scripts/contact.dll?msgto=" + s.ICQ;
                                    lkl_ICQ.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_ICQ.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/icq-logo.jpg";

                                }
                                if ((string)scs.SC_MSN.ToString() != string.Empty)
                                {
                                    bool showMSN;
                                    if (!bool.TryParse(scs.SC_MSN.ToString() as string, out showMSN))
                                    {
                                        showMSN = true;
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
                                        showYahoo = true;
                                    }
                                    lkl_Yahoo.Visible = showYahoo;
                                    lkl_Yahoo.NavigateUrl = "ymsgr:sendim?" + s.ICQ;
                                    lkl_Yahoo.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_Yahoo.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/yahoo-logo.jpg";
                                }

                                // Adding Attributes to the Start Player ImageButtons  //
                                if ((string)scs.SC_Player.ToString() != string.Empty)
                                {
                                    bool showPlayer;
                                    if (!bool.TryParse(scs.SC_Player.ToString() as string, out showPlayer))
                                    {
                                        showPlayer = true;
                                    }
                                    lblStartPlayer.Visible = showPlayer;
                                    lblStartPlayer.Text = Localization.GetString("StartPlayer", this.LocalResourceFile);
                                    lblStartPlayer.ToolTip = Localization.GetString("StartPlayer", this.LocalResourceFile);
                                }
                                if ((string)scs.SC_Winamp.ToString() != string.Empty)
                                {
                                    bool showwinamp;
                                    if (!bool.TryParse(scs.SC_Winamp.ToString() as string, out showwinamp))
                                    {
                                        showwinamp = true;
                                    }
                                    WinampStart.Visible = showwinamp;
                                    WinampStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/winamp.gif";
                                    WinampStart.ToolTip = Localization.GetString("StartWinampPlayer.ToolTip", this.LocalResourceFile);
                                    WinampStart.AlternateText = Localization.GetString("StartWinampPlayer.AlternateText", this.LocalResourceFile);
                                }
                                if ((string)scs.SC_MediaPlayer.ToString() != string.Empty)
                                {
                                    bool showMediaplayer;
                                    if (!bool.TryParse(scs.SC_MediaPlayer.ToString() as string, out showMediaplayer))
                                    {
                                        showMediaplayer = true;
                                    }
                                    MediaPlayerStart.Visible = showMediaplayer;
                                    MediaPlayerStart.ToolTip = Localization.GetString("StartMediaPlayer.ToolTip", this.LocalResourceFile);
                                    MediaPlayerStart.AlternateText = Localization.GetString("StartMediaPlayer.AlternateText", this.LocalResourceFile);
                                    MediaPlayerStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/mplayer.gif";
                                }
                                if ((string)scs.SC_RealPlayer.ToString() != string.Empty)
                                {
                                    bool showRealplayer;
                                    if (!bool.TryParse(scs.SC_RealPlayer.ToString() as string, out showRealplayer))
                                    {
                                        showRealplayer = true;
                                    }
                                    RealPlayerStart.Visible = showRealplayer;
                                    RealPlayerStart.ToolTip = Localization.GetString("StartRealPlayer.ToolTip", this.LocalResourceFile);
                                    RealPlayerStart.AlternateText = Localization.GetString("StartRealPlayer.AlternateText", this.LocalResourceFile);
                                    RealPlayerStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/realplayer.gif";
                                }
                                if ((string)scs.SC_iTunes.ToString() != string.Empty)
                                {
                                    bool showitunes;
                                    if (!bool.TryParse(scs.SC_iTunes.ToString() as string, out showitunes))
                                    {
                                        showitunes = true;
                                    }
                                    ITunesStart.Visible = showitunes;
                                    ITunesStart.ToolTip = Localization.GetString("StartITunes.ToolTip", this.LocalResourceFile);
                                    ITunesStart.AlternateText = Localization.GetString("StartITunes.AlternateText", this.LocalResourceFile);
                                    ITunesStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/itunes.gif";
                                }


                            }
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
            //catch (ServerDownException ex)
            //{
            //   Response.Write(ex.Message);
            //}
            //catch (Exception exc)
            //{
            //     Module failed to load
            //    string error = Localization.GetString("ConnectionFailed.error", this.LocalResourceFile);
            //    Exceptions.ProcessModuleLoadException(error, this, exc, true); ;
            //}


        }
        protected void SCS_TimerTick(object sender, EventArgs e)
        {
           
                        this.lbl_Station.Text = lbl_Station.Text;
                        this.lbl_CurrentListeners.Text = lbl_CurrentListeners.Text;
                        this.lbl_Bitrate.Text = lbl_Bitrate.Text;
                        this.lbl_MaxListeners.Text = lbl_MaxListeners.Text;
                        this.lbl_ScsSong.Text = lbl_ScsSong.Text;
                        this.lbl_SongTitle.Text = lbl_SongTitle.Text;
                        this.lbl_PeakListeners.Text = lbl_PeakListeners.Text;
                        this.lbl_Genre.Text = lbl_Genre.Text;
                        this.lbl_ContentType.Text = lbl_ContentType.Text;
                        this.lbl_Status.Text = lbl_Status.Text;
                    }
                }
            
           
        
        
        #endregion

    
       
    }

 


