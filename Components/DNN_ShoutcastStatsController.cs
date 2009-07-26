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
using System.Configuration;
using System.Data;
using System.Xml;
using System.Web;
using System.Collections.Generic;

using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Search;
using DotNetNuke.Entities.Modules;

namespace Aarsys.Modules.DNN_ShoutcastStats
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The Controller class for DNN_ShoutcastStats 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    public class DNN_ShoutcastStatsController : ISearchable, IPortable
    {

        #region "Public Methods"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// gets an object from the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleId">The Id of the module</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public List<DNN_ShoutcastStatsInfo> GetDNN_ShoutcastStatss(int ModuleId)
        {

            return CBO.FillCollection<Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo>(Aarsys.Modules.DNN_ShoutcastStats.DataProvider.Instance().GetDNN_ShoutcastStatss(ModuleId));

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// gets an object from the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleId">The Id of the module</param> 
        /// <param name="ItemId">The Id of the item</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public DNN_ShoutcastStatsInfo GetDNN_ShoutcastStats(int ModuleId, int ItemId)
        {

            return (Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo)CBO.FillObject(Aarsys.Modules.DNN_ShoutcastStats.DataProvider.Instance().GetDNN_ShoutcastStats(ModuleId, ItemId), typeof(Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo));

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// adds an object to the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="objDNN_ShoutcastStats">The DNN_ShoutcastStatsInfo object</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void AddDNN_ShoutcastStats(DNN_ShoutcastStatsInfo objDNN_ShoutcastStats)
        {

            if (objDNN_ShoutcastStats.Content.Trim() != "")
            {
                Aarsys.Modules.DNN_ShoutcastStats.DataProvider.Instance().AddDNN_ShoutcastStats(objDNN_ShoutcastStats.ModuleId, objDNN_ShoutcastStats.Content, objDNN_ShoutcastStats.CreatedByUser);
            }

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// saves an object to the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="objDNN_ShoutcastStats">The DNN_ShoutcastStatsInfo object</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void UpdateDNN_ShoutcastStats(DNN_ShoutcastStatsInfo objDNN_ShoutcastStats)
        {

            if (objDNN_ShoutcastStats.Content.Trim() != "")
            {
                Aarsys.Modules.DNN_ShoutcastStats.DataProvider.Instance().UpdateDNN_ShoutcastStats(objDNN_ShoutcastStats.ModuleId, objDNN_ShoutcastStats.ItemId, objDNN_ShoutcastStats.Content, objDNN_ShoutcastStats.CreatedByUser);
            }

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// deletes an object from the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleId">The Id of the module</param> 
        /// <param name="ItemId">The Id of the item</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void DeleteDNN_ShoutcastStats(int ModuleId, int ItemId)
        {

            Aarsys.Modules.DNN_ShoutcastStats.DataProvider.Instance().DeleteDNN_ShoutcastStats(ModuleId, ItemId);

        }

        #endregion

        #region "Optional Interfaces"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// GetSearchItems implements the ISearchable Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {

            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            List<Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo> colDNN_ShoutcastStatss = GetDNN_ShoutcastStatss(ModInfo.ModuleID);
            foreach (Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo objDNN_ShoutcastStats in colDNN_ShoutcastStatss)
            {
                SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objDNN_ShoutcastStats.Content, objDNN_ShoutcastStats.CreatedByUser, objDNN_ShoutcastStats.CreatedDate, ModInfo.ModuleID, objDNN_ShoutcastStats.ItemId.ToString(), objDNN_ShoutcastStats.Content, "ItemId=" + objDNN_ShoutcastStats.ItemId.ToString());
                SearchItemCollection.Add(SearchItem);
            }

            return SearchItemCollection;

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// ExportModule implements the IPortable ExportModule Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleID">The Id of the module to be exported</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public string ExportModule(int ModuleID)
        {

            string strXML = "";

            List<Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo> colDNN_ShoutcastStatss = GetDNN_ShoutcastStatss(ModuleID);
            if (colDNN_ShoutcastStatss.Count != 0)
            {
                strXML += "<DNN_ShoutcastStatss>";
                foreach (Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo objDNN_ShoutcastStats in colDNN_ShoutcastStatss)
                {
                    strXML += "<DNN_ShoutcastStats>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objDNN_ShoutcastStats.Content) + "</content>";
                    strXML += "</DNN_ShoutcastStats>";
                }
                strXML += "</DNN_ShoutcastStatss>";
            }

            return strXML;

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// ImportModule implements the IPortable ImportModule Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleID">The Id of the module to be imported</param> 
        /// <param name="Content">The content to be imported</param> 
        /// <param name="Version">The version of the module to be imported</param> 
        /// <param name="UserId">The Id of the user performing the import</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {

            XmlNode xmlDNN_ShoutcastStatss = Globals.GetContent(Content, "DNN_ShoutcastStatss");
            foreach (XmlNode xmlDNN_ShoutcastStats in xmlDNN_ShoutcastStatss.SelectNodes("DNN_ShoutcastStats"))
            {
                Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo objDNN_ShoutcastStats = new Aarsys.Modules.DNN_ShoutcastStats.DNN_ShoutcastStatsInfo();
                objDNN_ShoutcastStats.ModuleId = ModuleID;
                objDNN_ShoutcastStats.Content = xmlDNN_ShoutcastStats.SelectSingleNode("content").InnerText;
                objDNN_ShoutcastStats.CreatedByUser = UserId;
                AddDNN_ShoutcastStats(objDNN_ShoutcastStats);
            }

        }

        #endregion

    }
}