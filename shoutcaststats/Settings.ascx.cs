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
            var portalSecurity = new PortalSecurity();
            using (var scs = new ShoutCastSettings())
            {
                scs.LoadSettings(this);
                if (IsPostBack) return;
                if (scs.SC_IP != "")
                    txtSC_IP.Text = portalSecurity.InputFilter(scs.SC_IP, PortalSecurity.FilterFlag.NoMarkup);
                if (!IsPostBack)
                    if (scs.SC_Port != "")
                        txtSC_Port.Text = portalSecurity.InputFilter(scs.SC_Port, PortalSecurity.FilterFlag.NoMarkup);
                if (!IsPostBack)
                    if (scs.SC_Password != "")
                        txtSC_Password.Text = portalSecurity.InputFilter(scs.SC_Password, PortalSecurity.FilterFlag.NoMarkup);
                if (!IsPostBack)
                    if (scs.SC_AIM)
                    {
                        //bool show;
                        //if (!bool.TryParse((string)ModuleSettings[scs.SC_AIM] as string, out show))
                        //{
                        //    show = scs.SC_AIM; // Default to showing the SC_AIM.
                        //}

                        SC_AIMCheckBox.Checked = true;
                    }
                    
                if (!IsPostBack)
                    if (scs.SC_AOL)
                    {
                        SC_AOLCheckBox.Checked = true;
                    }

                if (!IsPostBack)
                    if (scs.SC_ICQ)
                    {
                        SC_ICQCheckBox.Checked = true;
                    }
                    
                if (!IsPostBack)
                    if (scs.SC_MSN)
                    {
                        SC_MSNCheckBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_Yahoo)
                    {
                        SC_YahooCheckBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_Station)
                    {
                        SC_StationBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_CurrentListeners)
                    {
                        SC_CurrentListenersBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_PeakListeners)
                    {
                        SC_PeakListenersBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_MaxListeners)
                    {
                        SC_MaxListenersBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_genre)
                    {
                        SC_genreBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_Song)
                    {
                        SC_SongBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_DJ)
                    {
                        SC_DJBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_Bitrate)
                    {
                        SC_BitrateBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_Content)
                    {
                        SC_ContentBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_Winamp)
                    {
                        SC_WinampBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_MediaPlayer)
                    {
                        SC_MediaPlayerBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_RealPlayer)
                    {
                        SC_RealPlayerBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_iTunes)
                    {
                        SC_iTunesBox.Checked = true;
                    }
                if (!IsPostBack)
                    if (scs.SC_Player)
                    {
                        SC_PlayerBox.Checked = true;
                    }
            }
        }
        
        ///<summary>
        ///</summary>
        public override void UpdateSettings()
        {
            var portalSecurity = new PortalSecurity();
            using (var scs = new ShoutCastSettings { SC_IP = portalSecurity.InputFilter(txtSC_IP.Text, PortalSecurity.FilterFlag.NoMarkup), SC_Port = portalSecurity.InputFilter(txtSC_Port.Text, PortalSecurity.FilterFlag.NoMarkup), SC_Password = portalSecurity.InputFilter(txtSC_Password.Text, PortalSecurity.FilterFlag.NoMarkup), SC_AIM = SC_AIMCheckBox.Checked, SC_AOL = SC_AOLCheckBox.Checked, SC_ICQ = SC_ICQCheckBox.Checked, SC_MSN = SC_MSNCheckBox.Checked, SC_Yahoo = SC_YahooCheckBox.Checked, SC_Station = SC_StationBox.Checked, SC_CurrentListeners = SC_CurrentListenersBox.Checked, SC_PeakListeners = SC_PeakListenersBox.Checked, SC_MaxListeners = SC_MaxListenersBox.Checked, SC_genre = SC_genreBox.Checked, SC_Song = SC_SongBox.Checked, SC_DJ = SC_DJBox.Checked, SC_Bitrate = SC_BitrateBox.Checked, SC_Content = SC_ContentBox.Checked, SC_Winamp = SC_WinampBox.Checked, SC_MediaPlayer = SC_MediaPlayerBox.Checked, SC_RealPlayer = SC_RealPlayerBox.Checked, SC_iTunes = SC_iTunesBox.Checked, SC_Player = SC_PlayerBox.Checked })
            {
                scs.UpdateSettings(this); 
            }
        }
        #endregion
    }

}

