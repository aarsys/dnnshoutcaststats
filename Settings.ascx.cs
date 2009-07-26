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

using DotNetNuke;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace Aarsys.Modules.DNN_ShoutcastStats
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
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    if ((string)TabModuleSettings["Aarsys_ShoutcastStats_SC_IP"] != "")
                    {
                        txtSC_IP.Text = (string)TabModuleSettings["Aarsys_ShoutcastStats_SC_IP"];
                    }
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                if (!IsPostBack)
                {
                    if ((string)TabModuleSettings["Aarsys_ShoutcastStats_SC_Port"] != "")
                    {
                        txtSC_Port.Text = (string)TabModuleSettings["Aarsys_ShoutcastStats_SC_Port"];
                    }
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                if (!IsPostBack)
                {
                    if ((string)TabModuleSettings["Aarsys_ShoutcastStats_SC_Password"] != "")
                    {
                        txtSC_Password.Text = (string)TabModuleSettings["Aarsys_ShoutcastStats_SC_Password"];
                    }
                }
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// UpdateSettings saves the modified settings to the Database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public override void UpdateSettings()
        {
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateTabModuleSetting(TabModuleId, "Aarsys_ShoutcastStats_SC_IP", txtSC_IP.Text);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateTabModuleSetting(TabModuleId, "Aarsys_ShoutcastStats_SC_Port", txtSC_Port.Text);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            try
            {
                ModuleController objModules = new ModuleController();

                objModules.UpdateTabModuleSetting(TabModuleId, "Aarsys_ShoutcastStats_SC_Password", txtSC_Password.Text);
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

    }

}

