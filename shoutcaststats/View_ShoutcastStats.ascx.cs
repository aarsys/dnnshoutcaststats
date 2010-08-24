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

        
        #region "Event Handlers"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Page_Load runs when the control is loaded 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            var portalSecurity = new PortalSecurity();
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
                            if (portalSecurity.InputFilter(s.ServerTitle, PortalSecurity.FilterFlag.NoMarkup) == "N/A")
                                lbl_Station.Visible = false;
                            else
                            {

                                if (scs.SC_Station)
                                {
                                    lbl_Station.Visible = true;
                                    lbl_Station.Text = portalSecurity.InputFilter(s.ServerTitle, PortalSecurity.FilterFlag.NoMarkup);
                                }
                            }
                            //Displaying the Peak of the Listeners
                            if (scs.SC_PeakListeners)
                            {
                                lbl_PeakListeners.Visible = true;
                                lbl_PeakListeners.Text = Localization.GetString("PeakListeners", this.LocalResourceFile) + " : " + portalSecurity.InputFilter((s.PeakListeners.ToString()),PortalSecurity.FilterFlag.NoMarkup);
                            }

                            // Displaying the current Listeners //
                            // if ((string)scs.SC_CurrentListeners.ToString() != string.Empty)
                            //{
                            //bool showCurrentListeners;
                            //if (!bool.TryParse(scs.SC_CurrentListeners.ToString() as string, out showCurrentListeners))
                            //{
                            //    showCurrentListeners = scs.SC_CurrentListeners;
                            if (scs.SC_CurrentListeners)
                            {
                                lbl_CurrentListeners.Visible = true;   //showCurrentListeners;
                                lbl_CurrentListeners.Text = Localization.GetString("CurrentListeners", this.LocalResourceFile) + " : " + portalSecurity.InputFilter(s.CurrentListeners.ToString(), PortalSecurity.FilterFlag.NoMarkup);
                            }
                            // Displays the current Bitrate of the Stream //
                            if (scs.SC_Bitrate)
                            {
                                
                                lbl_Bitrate.Visible = true;  //showBitrate;
                                lbl_Bitrate.Text = Localization.GetString("Bitrate", this.LocalResourceFile) + " : " + portalSecurity.InputFilter(s.Bitrate.ToString(), PortalSecurity.FilterFlag.NoMarkup) + "Kbps";
                            }
                            // Displays the max. listeners of the Stream //
                            if (scs.SC_MaxListeners)
                            {
                                lbl_MaxListeners.Visible = true; // showMaxListeners;
                                lbl_MaxListeners.Text = Localization.GetString("MaxListeners", this.LocalResourceFile) + " : " + portalSecurity.InputFilter(s.MaxListeners.ToString(), PortalSecurity.FilterFlag.NoMarkup);
                            }
                            // Displays the genre //
                            if (scs.SC_genre)
                            {
                                lbl_Genre.Visible = true; //  showgenre;
                                lbl_Genre.Text = Localization.GetString("Genre", this.LocalResourceFile) + " : " + portalSecurity.InputFilter(s.ServerGenre, PortalSecurity.FilterFlag.NoMarkup);
                            }
                            //Displays the ContentType //
                            if (scs.SC_Content)
                            {
                               lbl_ContentType.Visible = true;  // showContenttype;
                               lbl_ContentType.Text = Localization.GetString("ContentType", this.LocalResourceFile) + " : " + portalSecurity.InputFilter(s.Content, PortalSecurity.FilterFlag.NoMarkup);
                            }
                            if (scs.SC_Song)
                            {
                               lbl_SongTitle.Visible = true;  //showsong;
                               lbl_SongTitle.Text = Localization.GetString("SongTitle", this.LocalResourceFile) + " : ";
                                lbl_ScsSong.Visible = true; // showsong;
                                lbl_ScsSong.Text = "<marquee class=\"scs_marquee\">" + portalSecurity.InputFilter(s.SongTitle, PortalSecurity.FilterFlag.NoMarkup) + "</marquee>";
                                // Shows the DJ name //
                                if (scs.SC_DJ)
                                {
                                    lbl_AIM.Visible = true; // showdj;
                                    lbl_AIM.Text = Localization.GetString("YourDJ", this.LocalResourceFile) + " : " + portalSecurity.InputFilter(s.AIM, PortalSecurity.FilterFlag.NoMarkup);
                                }
                                // Adding Messenger URLs could be enabled/disabled from the ModuleSettings //
                                // for AIM
                                if (scs.SC_AIM)
                                {
                                    lkl_AIM.Visible = true; // showAIM;
                                    lkl_AIM.NavigateUrl = Server.HtmlEncode("aim:goim?screenname=" + portalSecurity.InputFilter(s.AIM, PortalSecurity.FilterFlag.NoMarkup));
                                    lkl_AIM.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_AIM.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/aim.jpg";
                                }
                                //for AOL
                                if (scs.SC_AOL)
                                {
                                    lkl_AOL.Visible = true;  // showAOL;
                                    lkl_AOL.NavigateUrl = Server.HtmlEncode("aol://9293:" + portalSecurity.InputFilter(s.AIM, PortalSecurity.FilterFlag.NoMarkup));
                                    lkl_AOL.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_AOL.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/aol-logo.jpg";
                                }
                                //for ICQ
                                if (scs.SC_ICQ)
                                {
                                    lkl_ICQ.Visible = true;
                                    lkl_ICQ.NavigateUrl = Server.HtmlEncode("http://wwp.icq.com/scripts/contact.dll?msgto=" + portalSecurity.InputFilter(s.ICQ, PortalSecurity.FilterFlag.NoMarkup));
                                    lkl_ICQ.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_ICQ.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/icq-logo.jpg";

                                }
                                //for Live / MSN using the Shoutcast ICQ value
                                if (scs.SC_MSN)
                                {
                                    lkl_MSN.Visible = true;
                                    lkl_MSN.NavigateUrl = Server.HtmlEncode("msnim:chat?contact=" + portalSecurity.InputFilter(s.ICQ, PortalSecurity.FilterFlag.NoMarkup));
                                    lkl_MSN.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_MSN.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/live-logo.jpg";
                                }
                                //for Yahoo using the ICQ value
                                if (scs.SC_Yahoo)
                                {
                                    lkl_Yahoo.Visible = true;
                                    lkl_Yahoo.NavigateUrl = Server.HtmlEncode("ymsgr:sendim?" + portalSecurity.InputFilter(s.ICQ, PortalSecurity.FilterFlag.NoMarkup));
                                    lkl_Yahoo.ToolTip = Localization.GetString("ChatwithyourDJ", this.LocalResourceFile);
                                    lkl_Yahoo.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/yahoo-logo.jpg";
                                }


                                // Adding Attributes to the Start Player ImageButtons  //
                                //Adding text label "Start Player here"
                                if (scs.SC_Player)
                                {
                                    lblStartPlayer.Visible = true; // showPlayer;
                                    lblStartPlayer.Text = Localization.GetString("StartPlayer", this.LocalResourceFile);
                                    lblStartPlayer.ToolTip = Localization.GetString("StartPlayer", this.LocalResourceFile);
                                }
                                //Adding ImageButton for Winamp
                                if (scs.SC_Winamp)
                                {
                                    WinampStart.Visible = true;  // showwinamp;
                                    WinampStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/winamp.gif";
                                    WinampStart.ToolTip = Localization.GetString("StartWinampPlayer.ToolTip", this.LocalResourceFile);
                                    WinampStart.AlternateText = Localization.GetString("StartWinampPlayer.AlternateText", this.LocalResourceFile);
                                    WinampStart.Click += new ImageClickEventHandler(WinampButton_Click);
                                }
                                //Adding ImageButton for MediaPlayer 
                                if (scs.SC_MediaPlayer)
                                {
                                    MediaPlayerStart.Visible = true;  // showMediaplayer;
                                    MediaPlayerStart.ToolTip = Localization.GetString("StartMediaPlayer.ToolTip", this.LocalResourceFile);
                                    MediaPlayerStart.AlternateText = Localization.GetString("StartMediaPlayer.AlternateText", this.LocalResourceFile);
                                    MediaPlayerStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/mplayer.gif";
                                    MediaPlayerStart.Click += new ImageClickEventHandler(MediaButton_Click);
                                    //MediaPlayerStart.OnClientClick += (MediaButton_Click);
                                }
                                //Adding ImageButton for RealPlayer
                                if (scs.SC_RealPlayer)
                                {
                                    RealPlayerStart.Visible = true; // showRealplayer;
                                    RealPlayerStart.ToolTip = Localization.GetString("StartRealPlayer.ToolTip", this.LocalResourceFile);
                                    RealPlayerStart.AlternateText = Localization.GetString("StartRealPlayer.AlternateText", this.LocalResourceFile);
                                    RealPlayerStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/realplayer.gif";
                                    RealPlayerStart.Click += new ImageClickEventHandler(RealButton_Click);
                                }
                                //Adding ImageButton for Itunes/Quicktime
                                if (scs.SC_iTunes)
                                {
                                    ITunesStart.Visible = true;  //showitunes;
                                    ITunesStart.ToolTip = Localization.GetString("StartITunes.ToolTip", this.LocalResourceFile);
                                    ITunesStart.AlternateText = Localization.GetString("StartITunes.AlternateText", this.LocalResourceFile);
                                    ITunesStart.ImageUrl = Request.ApplicationPath + "DesktopModules/Aarsys/ShoutcastStats/images/itunes.gif";
                                    ITunesStart.Click += new ImageClickEventHandler(ITunesButton_Click);
                                }


                            }
                        }
                    }
                }
            }
        


            //catch (Exception exc)
            //{
            //    // Module failed to load
            //    Exceptions.ProcessModuleLoadException(this, exc);
            //}

            catch (Exception exc)
            {
                //Module failed to load
                string error = Localization.GetString("ConnectionFailed.error", this.LocalResourceFile);
                Exceptions.ProcessModuleLoadException(error, this, exc, true); ;
            }
        }


        // Start  different Players by creating a memory stream for the file and download it by the client as a ImageButton  //
        // Create Memorystream for MediaPlayer file
        protected void MediaButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (ShoutCastSettings scs = new ShoutCastSettings())
                {
                    // Loading the settings from ShoutcastStatsSettings Control //
                    scs.LoadSettings(this);
                    using (ShoutcastServer s =
                        new ShoutcastServer("http://" + (scs.SC_IP) + ":" + (scs.SC_Port) + "/admin.cgi?mode=viewxml&pass=" + (scs.SC_Password)))
                    {
                        //Creating MemoryStream
                        MemoryStream MediaPlayer = new MemoryStream();
                        
                        StreamWriter tw = new StreamWriter(MediaPlayer);
                        tw.WriteLine("<ASX version=\"3.0\">");
                        tw.WriteLine("<ABSTRACT>" + Server.HtmlEncode(s.ServerUrl) + "</ABSTRACT>");
                        tw.WriteLine("<TITLE>" + Server.HtmlEncode(s.ServerTitle) + "</TITLE>");
                        tw.WriteLine("<MOREINFO HREF=\"" + Server.HtmlEncode(s.ServerUrl) + "\"/>");
                        tw.WriteLine("<ref href=\"http://" + Server.HtmlEncode(scs.SC_IP) + ":" + Server.HtmlEncode(scs.SC_Port) + "\"/>");
                        tw.WriteLine("<ENTRY>");
                        tw.WriteLine("<ABSTRACT>" + Server.HtmlEncode(s.ServerTitle) + "</ABSTRACT>");
                        tw.WriteLine("<TITLE>" + Server.HtmlEncode(s.ServerTitle) + "</TITLE>");
                        tw.WriteLine("<AUTHOR>" + Server.HtmlEncode(s.ServerUrl) + "</AUTHOR>");
                        tw.WriteLine("<ref href=\"http://" + Server.HtmlEncode(scs.SC_IP) + ":" + Server.HtmlEncode(scs.SC_Port) + "\"/>");
                        tw.WriteLine("<ref href=\"icyx://" + Server.HtmlEncode(scs.SC_IP) + ":" + Server.HtmlEncode(scs.SC_Port) + "\"/>");
                        tw.WriteLine("<MOREINFO HREF=\"" + Server.HtmlEncode(s.ServerUrl) + "\"/>");
                        tw.WriteLine("</ENTRY>");
                        tw.WriteLine("</ASX>");
                        tw.Flush();
                        
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=" + Server.HtmlEncode(scs.SC_Port) + ".asx"));
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
        // Creating MemoryStream to create the file to start the Winamp player
        protected void WinampButton_Click(object sender, EventArgs e)
        {
            var portalSecurity = new PortalSecurity();
            try
            {
                using (ShoutCastSettings scs = new ShoutCastSettings())
                {
                    // Loading the settings from ShoutcastStatsSettings Control //
                    scs.LoadSettings(this);
                    using (ShoutcastServer s =
                        new ShoutcastServer("http://" + portalSecurity.InputFilter(scs.SC_IP, PortalSecurity.FilterFlag.NoMarkup) + ":" + portalSecurity.InputFilter(scs.SC_Port, PortalSecurity.FilterFlag.NoMarkup) + "/admin.cgi?mode=viewxml&pass=" + portalSecurity.InputFilter(scs.SC_Password, PortalSecurity.FilterFlag.NoMarkup)))
                    {
                        //Creating the MemoryStream
                        MemoryStream WinampPlayer = new MemoryStream();
                        StreamWriter wt = new StreamWriter(WinampPlayer);
                        wt.WriteLine("[playlist]");
                        wt.WriteLine("NumberOfEntries=1");
                        wt.WriteLine("File1=http://" + portalSecurity.InputFilter(scs.SC_IP, PortalSecurity.FilterFlag.NoMarkup) + ":" + portalSecurity.InputFilter(scs.SC_Port, PortalSecurity.FilterFlag.NoMarkup) + "/");
                        wt.Flush();
                                               
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=\"" + Server.HtmlEncode(scs.SC_Port) + ".pls\""));
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
        // Creating the Memorystream for the ImageButton of the Realplayer to create the downloadable file
        protected void RealButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (ShoutCastSettings scs = new ShoutCastSettings())
                {
                    // Loading the settings from ShoutcastStatsSettings Control //
                    scs.LoadSettings(this);
                    using (ShoutcastServer s =
                        new ShoutcastServer("http://" + Server.HtmlEncode(scs.SC_IP) + ":" + Server.HtmlEncode(scs.SC_Port) + "/admin.cgi?mode=viewxml&pass=" + Server.HtmlEncode(scs.SC_Password)))
                    {
                        // Creating the Memory Stream
                        MemoryStream RealPlayer= new MemoryStream();
                        StreamWriter rt = new StreamWriter(RealPlayer);
                        rt.WriteLine("http://" + Server.HtmlEncode(scs.SC_IP) + ":" + Server.HtmlEncode(scs.SC_Port) + "/");
                        rt.Flush();
                        
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=" + Server.HtmlEncode(scs.SC_Port) + ".ram"));
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
        // Creating the Memorystream for the ImageButton of The iTunes/QuickTime Player to create the daownloadable file
        protected void ITunesButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (ShoutCastSettings scs = new ShoutCastSettings())
                {
                    // Loading the settings from ShoutcastStatsSettings Control //
                    scs.LoadSettings(this);
                    using (ShoutcastServer s =
                        new ShoutcastServer("http://" + Server.HtmlEncode(scs.SC_IP) + ":" + Server.HtmlEncode(scs.SC_Port) + "/admin.cgi?mode=viewxml&pass=" + Server.HtmlEncode(scs.SC_Password)))
                    {
                        //Creating the MemoryStream
                        MemoryStream ITunes = new MemoryStream();
                        StreamWriter it = new StreamWriter(ITunes);
                        it.WriteLine("<?xml version=\"1.0\"?>");
                        it.WriteLine("<?quicktime type=\"application/x-quicktime-media-link\"?>");
                        it.WriteLine("<embed src=\"icy://" + Server.HtmlEncode(scs.SC_IP) + ":" + Server.HtmlEncode(scs.SC_Port) + "\" autoplay=\"true\" /> ");
                        it.Flush();
                       
                        Response.ClearHeaders();
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", String.Format("attachment;filename=\"" + Server.HtmlEncode(scs.SC_Port) + ".qtl\""));
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
        //Adding the TimerTick (set to 60 sek.) to refresh the content with the UpdatePanel
        protected void SCS_TimerTick(object sender, EventArgs e)
        {
            //Added this lines to make sure the values are viewed after each update - without this after a while the values are not viewed
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

 


