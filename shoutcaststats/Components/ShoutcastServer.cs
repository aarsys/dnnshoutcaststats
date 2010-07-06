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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
using System.Data;
using System.Xml.Linq;
using System.Web;
using System.Collections.Generic;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using System.Collections.ObjectModel;


namespace Aarsys.ShoutcastStats.Components
{


    /// <summary>
    /// Creates an instance of a shoutcast server and gives access to all the properties of the xml file
    /// </summary>
    public class ShoutcastServer : DotNetNuke.Entities.Modules.PortalModuleBase, IDisposable
    {
        XDocument ShoutcastXml;
        WebData webdata;
        string _ServerUrl;
        /// <summary>
        /// Create an instance of this class
        /// </summary>
        /// <param name="ServerUrl">The Streaming Url of the server 
        /// Example : http://localhost:8000/admin.cgi?mode=viewxml&#x26;pass=adminpass </param>
        /// Should be gennerated with the Modulesettings as SC_IP, SC_Port, SC_Password

        
        protected string SharedResourceFile
        {
            get
            {
                //return this.ControlPath + "/" + Localization.LocalResourceDirectory + "/" + Localization.LocalSharedResourceFile;
                return DotNetNuke.Services.Localization.Localization.ApplicationResourceDirectory + "/SharedResources.resx";
            }
        }

   
        public ShoutcastServer(string ServerUrl)
        {
            try
            {

                this.ShoutcastServerUrl = ServerUrl;
                ShoutcastXml = XDocument.Load(Get_XMLFile());
                webdata = new WebData(this);
            }
            catch
            {
                throw new ServerDownException("Connection Failed");
                //throw new ServerDownException((DotNetNuke.Services.Localization.Localization.GetString("ConnectionFailed.Text", this.SharedResourceFile)));
                
            }
        }
        private TextReader Get_XMLFile()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.ShoutcastServerUrl);
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                TextReader sw = new StreamReader(res.GetResponseStream());
                res = null;
                return sw;
            }
            catch
            {
                return null;
            }
            finally
            {
                req = null;
            }
        }
        ///<summary>
        ///The Streaming url of the shoutcast server
        ///Example : http://localhost:8000/admin.cgi?mode=viewxml&#x26;pass=adminpass
        ///</summary>
        public string ShoutcastServerUrl
        {
            get { return _ServerUrl; }
            set { _ServerUrl = value; }
        }
        private string GetProperty(XDocument x, ShoutcastProperties Property)
        {
            try
            {
                var q = (from c in x.Descendants("SHOUTCASTSERVER")
                         select (string)c.Element(Property.ToString())).First();
                return q;
            }
            catch (NullReferenceException)
            {
                return "Undefiend";
                //return (DotNetNuke.Services.Localization.Localization.GetString("Undefined.Text", this.SharedResourceFile));
            }

        }
        protected string GetWebDataProperty(XDocument x, ShoutcastWebDataProperties Property)
        {
            try
            {
                var q = (from c in x.Descendants("WEBDATA")
                         select (string)c.Element(Property.ToString())).First();
                return q;
            }
            catch (NullReferenceException)
            {
                return "-1";
            }

        }
        /// <summary>
        /// Gets an updated version of the Shoutcast xml file with update statistics
        /// More useful at WinForm applications
        /// </summary>
        public void Refresh()
        {
            ShoutcastXml = XDocument.Load(Get_XMLFile());
        }
        enum ShoutcastProperties
        {
            SONGURL, IRC, ICQ, AIM, WEBHITS,
            STREAMHITS, STREAMSTATUS, BITRATE, CONTENT, VERSION,
            CURRENTLISTENERS, PEAKLISTENERS, MAXLISTENERS, REPORTEDLISTENERS,
            AVERAGETIME, SERVERGENRE, SERVERURL, SERVERTITLE, SONGTITLE
        }
        protected enum ShoutcastWebDataProperties
        {
            INDEX, LISTEN, PALM7, LOGIN, LOGINFAIL, PLAYED, COOKIE, ADMIN, UPDINFO, KICKSRC,
            KICKDST, UNBANDST, BANDST, VIEWBAN, UNRIPDST, RIPDST, VIEWRIP, VIEWXML, VIEWLOG, INVALID
        }

        #region Properties
        public string SongUrl
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.SONGURL); }
        }
        public string IRC
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.IRC); }
        }
        public string ICQ
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.ICQ); }
        }
        public string AIM
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.AIM); }
        }
        public int WebHits
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.WEBHITS)); }
        }
        public int StreamHits
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.STREAMHITS)); }
        }
        public bool StreamStatus
        {
            get { return Convert.ToBoolean(Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.STREAMSTATUS))); }
        }
        public int Bitrate
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.BITRATE)); }
        }
        public string Content
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.CONTENT); }
        }
        public string Version
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.VERSION); }
        }
        public int CurrentListeners
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.CURRENTLISTENERS)); }
        }
        public int PeakListeners
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.PEAKLISTENERS)); }
        }
        public int MaxListeners
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.MAXLISTENERS)); }
        }
        public int ReportedListeners
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.REPORTEDLISTENERS)); }
        }
        public string ServerGenre
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.SERVERGENRE); }
        }
        public string ServerTitle
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.SERVERTITLE); }
        }
        public string ServerUrl
        {
            get { return GetProperty(ShoutcastXml, ShoutcastProperties.SERVERURL); }
        }
        public int AverageTime
        {
            get { return Convert.ToInt32(GetProperty(ShoutcastXml, ShoutcastProperties.AVERAGETIME)); }
        }
        public string SongTitle
        {
            get { return this.GetProperty(this.ShoutcastXml, ShoutcastProperties.SONGTITLE); }
        }
        public List<Listener> Listeners
        {
            get
            {
                List<Listener> Listeners = new List<Listener>();
                var q = (from c in this.ShoutcastXml.Descendants("LISTENERS")
                         select c.Elements("LISTENER")).ToList();

                foreach (var item in q)
                {
                    item.ToList().ForEach(p =>
                         Listeners.Add(new Listener(p.Element("HOSTNAME").Value, p.Element("USERAGENT").Value
                         , p.Element("UNDERRUNS").Value, Convert.ToInt32(p.Element("CONNECTTIME").Value)
                         , p.Element("POINTER").Value, p.Element("UID").Value
                         )));
                }
                return Listeners;
            }
        }
        public List<Song> SongHistory
        {
            get
            {
                List<Song> SongHistory = new List<Song>();
                var q = (from c in this.ShoutcastXml.Descendants("SONGHISTORY")
                         select c.Elements("SONG")).ToList();
                foreach (var item in q)
                {
                    item.ToList().ForEach(p =>
                         SongHistory.Add(new Song(p.Element("TITLE").Value, ShoutcastServer.ConvertFromUnixTimestamp(Convert.ToDouble(p.Element("PLAYEDAT").Value)))));
                }
                return SongHistory;
            }
        }
        /// <summary>
        /// Contains all the values from the WEBDATA region of the xml file
        /// </summary>
        public WebData Webdata
        {
            get { return this.webdata; }
        }
        #endregion
        public class WebData : IDisposable
        {
            ShoutcastServer s;
            internal WebData(ShoutcastServer s)
            {
                this.s = s;
            }
            #region WebData Properties
            /// <summary>
            /// Gets the INDEX value from WEBDATA
            /// </summary>
            public int Index
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.INDEX)); }
            }
            /// <summary>
            /// Gets the LISTEN value from WEBDATA
            /// </summary>
            public int Listen
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.LISTEN)); }
            }
            /// <summary>
            /// Gets the PALM7 value from WEBDATA
            /// </summary>
            public int Palm7
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.PALM7)); }
            }
            /// <summary>
            /// Gets the LOGIN value from WEBDATA
            /// </summary>
            public int Login
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.LOGIN)); }
            }
            /// <summary>
            /// Gets the LOGINFAIL value from WEBDATA
            /// </summary>
            public int LoginFail
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.LOGINFAIL)); }
            }
            /// <summary>
            /// Gets the PLAYED value from WEBDATA
            /// </summary>
            public int Played
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.PLAYED)); }
            }
            /// <summary>
            /// Gets the COOKIE value from WEBDATA
            /// </summary>
            public int Cookie
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.COOKIE)); }
            }
            /// <summary>
            /// Gets the ADMIN value from WEBDATA
            /// </summary>
            public int Admin
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.ADMIN)); }
            }
            /// <summary>
            /// Gets the UPDINFO value from WEBDATA
            /// </summary>
            public int UpdInfo
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.UPDINFO)); }
            }
            /// <summary>
            /// Gets the KICKSRC value from WEBDATA
            /// </summary>
            public int KickSrc
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.KICKSRC)); }
            }
            /// <summary>
            /// Gets the KICKDST value from WEBDATA
            /// </summary>
            public int KickDst
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.KICKDST)); }
            }
            /// <summary>
            /// Gets the UNBANDST value from WEBDATA
            /// </summary>
            public int UnBanDst
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.UNBANDST)); }
            }
            /// <summary>
            /// Gets the BANDST value from WEBDATA
            /// </summary>
            public int BanDst
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.BANDST)); }
            }
            /// <summary>
            /// Gets the VIEWBAN value from WEBDATA
            /// </summary>
            public int ViewBan
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.VIEWBAN)); }
            }
            /// <summary>
            /// Gets the UNRIPDST value from WEBDATA
            /// </summary>
            public int UnRipDst
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.UNRIPDST)); }
            }
            /// <summary>
            /// Gets the RIPDST value from WEBDATA
            /// </summary>
            public int RipDst
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.RIPDST)); }
            }
            /// <summary>
            /// Gets the VIEWRIP value from WEBDATA
            /// </summary>
            public int ViewRip
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.VIEWRIP)); }
            }
            /// <summary>
            /// Gets the VIEWXML value from WEBDATA
            /// </summary>
            public int ViewXml
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.VIEWXML)); }
            }
            /// <summary>
            /// Gets the VIEWLOG value from WEBDATA
            /// </summary>
            public int ViewLog
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.VIEWLOG)); }
            }
            /// <summary>
            /// Gets the INVALID value from WEBDATA
            /// </summary>
            public int Invalid
            {
                get { return Convert.ToInt32(s.GetWebDataProperty(s.ShoutcastXml, ShoutcastWebDataProperties.INVALID)); }
            }

            #endregion
            #region IDisposable Members
            public void Dispose()
            {
                s = null;
            }
            #endregion
        }
        #region IDisposable Members

        public void Dispose()
        {
            webdata.Dispose();
            ShoutcastXml = null;
            _ServerUrl = null;
        }

        static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0); 
            
            //Using Offset to handle the DateTime where the user is - Enhancement for later use
            // best is to use Timezone of the usersetting and a fallback to the site Timezone for unregistered users or get them Thimezone using javascript
            //DateTime dstDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //DateTimeOffset thisTime;

            //thisTime = new DateTimeOffset(dstDate, new TimeSpan(0, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-12, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-11, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-10, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-9, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-8, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-7, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-6, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-5, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-4, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-3, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-2, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(-1, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(0, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+1, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+2, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+3, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+4, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+5, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+6, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+7, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+8, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+9, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+10, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+11, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+12, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+13, 0, 0));
            //ShowPossibleTimeZones(thisTime);

            //thisTime = new DateTimeOffset(origin, new TimeSpan(+14, 0, 0));
            //ShowPossibleTimeZones(thisTime);


            return origin.AddSeconds(timestamp).ToLocalTime();
        }

        // For letter adding a client site Timezone and DateTime
        //private static void ShowPossibleTimeZones(DateTimeOffset offsetTime)
        //{
        //    TimeSpan offset = offsetTime.Offset;
        //    ReadOnlyCollection<TimeZoneInfo> timeZones;

        //    //Console.WriteLine("{0} could belong to the following time zones:",
        //    //                  offsetTime.ToString());
        //    // Get all time zones defined on local system
        //    timeZones = TimeZoneInfo.GetSystemTimeZones();
        //    // Iterate time zones 
        //    foreach (TimeZoneInfo timeZone in timeZones)
        //    {
        //        // Compare offset with offset for that date in that time zone
        //        if (timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
        //            //        Console.WriteLine("   {0}", timeZone.DisplayName);
                    
        //    }
        //    //Console.WriteLine();
        //} 

        #endregion
    }

    [global::System.Serializable]
    public class ServerDownException : Exception
    {
        public ServerDownException() { }
        public ServerDownException(string message) : base(message) { }
        public ServerDownException(string message, Exception inner) : base(message, inner) { }
        protected ServerDownException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }

}

