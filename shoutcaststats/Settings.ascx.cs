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
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_Station] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_Station], out show))
                            {
                                show = scs.SC_Station; // Default to showing the SC_Station name.
                            }
                            SC_StationBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_CurrentListeners] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_CurrentListeners], out show))
                            {
                                show = scs.SC_CurrentListeners; // Default to showing the SC_CurrentListeners.
                            }
                            SC_CurrentListenersBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_PeakListeners] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_PeakListeners], out show))
                            {
                                show = scs.SC_PeakListeners; // Default to showing the SC_PeakListeners.
                            }
                            SC_PeakListenersBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_MaxListeners] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_MaxListeners], out show))
                            {
                                show = scs.SC_MaxListeners; // Default to showing the SC_MaxListeners.
                            }
                            SC_MaxListenersBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_genre] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_genre], out show))
                            {
                                show = scs.SC_genre; // Default to showing the SC_genre.
                            }
                            SC_genreBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_Song] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_Song], out show))
                            {
                                show = scs.SC_Song; // Default to showing the SC_Song.
                            }
                            SC_SongBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_DJ] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_DJ], out show))
                            {
                                show = scs.SC_DJ; // Default to showing the SC_DJ.
                            }
                            SC_DJBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_Bitrate] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_Bitrate], out show))
                            {
                                show = scs.SC_Bitrate; // Default to showing the SC_Bitrate.
                            }
                            SC_BitrateBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_Content] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_Content], out show))
                            {
                                show = scs.SC_Content; // Default to showing the SC_Content.
                            }
                            SC_ContentBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_Winamp] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_Winamp], out show))
                            {
                                show = scs.SC_Winamp; // Default to showing the SC_Winamp.
                            }
                            SC_WinampBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_MediaPlayer] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_MediaPlayer], out show))
                            {
                                show = scs.SC_MediaPlayer; // Default to showing the SC_MediaPlayer.
                            }
                            SC_MediaPlayerBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_RealPlayer] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_RealPlayer], out show))
                            {
                                show = scs.SC_RealPlayer; // Default to showing the SC_RealPlayer.
                            }
                            SC_RealPlayerBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_iTunes] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_iTunes], out show))
                            {
                                show = scs.SC_iTunes; // Default to showing the SC_iTunes.
                            }
                            SC_iTunesBox.Checked = show;
                        }
                    if (!IsPostBack)
                        if ((string)ModuleSettings[scs.SC_Player] != string.Empty)
                        {
                            bool show;
                            if (!bool.TryParse((string)ModuleSettings[scs.SC_Player], out show))
                            {
                                show = scs.SC_Player; // Default to showing the SC_Player Label.
                            }
                            SC_PlayerBox.Checked = show;
                        }
                    //lblSC_MSG.Text = DotNetNuke.Services.Localization.Localization.GetString("lblSCMSG", LocalResourceFile);
                }
            }
        }
        
        public override void UpdateSettings()
        {
            using (ShoutCastSettings scs = new ShoutCastSettings { SC_IP = txtSC_IP.Text, SC_Port = txtSC_Port.Text, SC_Password = txtSC_Password.Text, SC_AIM = SC_AIMCheckBox.Checked, SC_AOL = SC_AOLCheckBox.Checked, SC_ICQ = SC_ICQCheckBox.Checked, SC_MSN = SC_MSNCheckBox.Checked, SC_Yahoo = SC_YahooCheckBox.Checked, SC_Station = SC_StationBox.Checked, SC_CurrentListeners = SC_CurrentListenersBox.Checked, SC_PeakListeners = SC_PeakListenersBox.Checked, SC_MaxListeners = SC_MaxListenersBox.Checked, SC_genre = SC_genreBox.Checked, SC_Song = SC_SongBox.Checked, SC_DJ = SC_DJBox.Checked, SC_Bitrate = SC_BitrateBox.Checked, SC_Content = SC_ContentBox.Checked, SC_Winamp = SC_WinampBox.Checked, SC_MediaPlayer = SC_MediaPlayerBox.Checked, SC_RealPlayer = SC_RealPlayerBox.Checked, SC_iTunes = SC_iTunesBox.Checked, SC_Player = SC_PlayerBox.Checked })
            {
                scs.UpdateSettings(this); 
            }
        }
        #endregion
    }

}

