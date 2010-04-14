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

namespace Aarsys.ShoutcastStats
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
    public class ShoutcastStatsController : ISearchable, IPortable
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
        public List<ShoutcastStatsInfo> GetShoutcastStats(int ModuleId)
        {

            return CBO.FillCollection<Aarsys.ShoutcastStats.ShoutcastStatsInfo>(Aarsys.ShoutcastStats.DataProvider.Instance().GetShoutcastStats(ModuleId));

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
        public ShoutcastStatsInfo GetShoutcastStat(int ModuleId, int ItemId)
        {

            return (Aarsys.ShoutcastStats.ShoutcastStatsInfo)CBO.FillObject(Aarsys.ShoutcastStats.DataProvider.Instance().GetShoutcastStat(ModuleId, ItemId), typeof(Aarsys.ShoutcastStats.ShoutcastStatsInfo));

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// adds an object to the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="objShoutcastStat">The ShoutcastStatsInfo object</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void AddShoutcastStat(ShoutcastStatsInfo objShoutcastStat)
        {

            if (objShoutcastStat.Content.Trim() != "")
            {
                Aarsys.ShoutcastStats.DataProvider.Instance().AddShoutcastStat(objShoutcastStat.ModuleId, objShoutcastStat.Content, objShoutcastStat.CreatedByUser);
            }

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// saves an object to the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="objShoutcastStat">The ShoutcastStatsInfo object</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void UpdateShoutcastStats(ShoutcastStatsInfo objShoutcastStat)
        {

            if (objShoutcastStat.Content.Trim() != "")
            {
                Aarsys.ShoutcastStats.DataProvider.Instance().UpdateShoutcastStat(objShoutcastStat.ModuleId, objShoutcastStat.ItemId, objShoutcastStat.Content, objShoutcastStat.CreatedByUser);
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
        public void DeleteShoutcastStats(int ModuleId, int ItemId)
        {

            Aarsys.ShoutcastStats.DataProvider.Instance().DeleteShoutcastStat(ModuleId, ItemId);

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

            List<Aarsys.ShoutcastStats.ShoutcastStatsInfo> colShoutcastStats = GetShoutcastStats(ModInfo.ModuleID);
            foreach (Aarsys.ShoutcastStats.ShoutcastStatsInfo objShoutcastStat in colShoutcastStats)
            {
                SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objShoutcastStat.Content, objShoutcastStat.CreatedByUser, objShoutcastStat.CreatedDate, ModInfo.ModuleID, objShoutcastStat.ItemId.ToString(), objShoutcastStat.Content, "ItemId=" + objShoutcastStat.ItemId.ToString());
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

            List<Aarsys.ShoutcastStats.ShoutcastStatsInfo> colShoutcastStat = GetShoutcastStats(ModuleID);
            if (colShoutcastStat.Count != 0)
            {
                strXML += "<ShoutcastStats>";
                foreach (Aarsys.ShoutcastStats.ShoutcastStatsInfo objShoutcastStat in colShoutcastStat)
                {
                    strXML += "<ShoutcastStat>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objShoutcastStat.Content) + "</content>";
                    strXML += "</ShoutcastStats>";
                }
                strXML += "</ShoutcastStats>";
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

            XmlNode xmlDNN_ShoutcastStatss = Globals.GetContent(Content, "ShoutcastStats");
            foreach (XmlNode xmlDNN_ShoutcastStats in xmlDNN_ShoutcastStatss.SelectNodes("ShoutcastStat"))
            {
                Aarsys.ShoutcastStats.ShoutcastStatsInfo objShoutcastStat = new Aarsys.ShoutcastStats.ShoutcastStatsInfo();
                objShoutcastStat.ModuleId = ModuleID;
                objShoutcastStat.Content = xmlDNN_ShoutcastStats.SelectSingleNode("content").InnerText;
                objShoutcastStat.CreatedByUser = UserId;
                AddShoutcastStat(objShoutcastStat);
            }

        }

        #endregion

    }
}