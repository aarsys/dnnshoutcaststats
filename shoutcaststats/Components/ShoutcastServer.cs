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
using System.Xml.Linq;
using System.Collections.Generic;
using DotNetNuke.Services.Localization;


namespace Aarsys.ShoutcastStats.Components
{


    /// <summary>
    /// Creates an instance of a shoutcast server and gives access to all the properties of the xml file
    /// </summary>
    public class ShoutcastServer : DotNetNuke.Entities.Modules.PortalModuleBase, IDisposable
    {
        XDocument _shoutcastXml;
        readonly WebData _webdata;
        string _serverUrl;
        /// <summary>
        /// Create an instance of this class
        /// /// </summary>
        /// Example : http://localhost:8000/admin.cgi?mode=viewxml&#x26;pass=adminpass
        /// Should be gennerated with the Modulesettings as SC_IP, SC_Port, SC_Password

        
        protected string SharedResourceFile
        {
            get
            {
                return ControlPath + "/" + Localization.LocalResourceDirectory + "/" + Localization.LocalSharedResourceFile;
                //return DotNetNuke.Services.Localization.Localization.ApplicationResourceDirectory + "/SharedResources.resx";
            }
        }

   
        ///<summary>
        ///</summary>
        ///<param name="serverUrl"></param>
        ///<exception cref="ServerDownException"></exception>
        public ShoutcastServer(string serverUrl)
        {
            try
            {

                ShoutcastServerUrl = serverUrl;
                _shoutcastXml = XDocument.Load(GetXmlFile());
                _webdata = new WebData(this);
            }
            catch
            {
                throw new ServerDownException("Connection Failed");
                //throw new ServerDownException(Localization.GetString("ConnectionFailed.error", this.SharedResourceFile));
                
            }
        }
        private TextReader GetXmlFile()
        {
            var req = (HttpWebRequest)WebRequest.Create(ShoutcastServerUrl);
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            try
            {
                //Get Text from HttpWebResponse
                var res = (HttpWebResponse)req.GetResponse();
                var sw = new StreamReader(res.GetResponseStream());
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
            get { return _serverUrl; }
            set { _serverUrl = value; }
        }
        private static string GetProperty(XContainer x, ShoutcastProperties property)
        {
            //try
            
            //    var q = (from c in x.Descendants("SHOUTCASTSERVER")
            //             select (string)c.Element(Property.ToString())).First();
            //    return q;
            
            //catch (NullReferenceException)
            //{
            //    return "Undefiend";
            //    //return (DotNetNuke.Services.Localization.Localization.GetString("Undefined.Text", this.SharedResourceFile));
            //}
            return (from c in x.Descendants("SHOUTCASTSERVER")
                    select (string)c.Element(property.ToString())).FirstOrDefault()
                   ?? "Undefined";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        protected string GetWebDataProperty(XDocument x, ShoutcastWebDataProperties property)
        {
            try
            {
                var q = (from c in x.Descendants("WEBDATA")
                         select (string)c.Element(property.ToString())).First();
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
            _shoutcastXml = XDocument.Load(GetXmlFile());
        }
        enum ShoutcastProperties
        {
            SONGURL, IRC, ICQ, AIM, WEBHITS,
            STREAMHITS, STREAMSTATUS, BITRATE, CONTENT, VERSION,
            CURRENTLISTENERS, PEAKLISTENERS, MAXLISTENERS, REPORTEDLISTENERS,
            AVERAGETIME, SERVERGENRE, SERVERURL, SERVERTITLE, SONGTITLE
        }

        /// <summary>
        ///
        /// </summary>
        protected enum ShoutcastWebDataProperties
        {
            INDEX, LISTEN, PALM7, LOGIN, LOGINFAIL, PLAYED, COOKIE, ADMIN, UPDINFO, KICKSRC,
            KICKDST, UNBANDST, BANDST, VIEWBAN, UNRIPDST, RIPDST, VIEWRIP, VIEWXML, VIEWLOG, INVALID
        }

        #region Properties
        ///<summary>
        ///</summary>
        public string SongUrl
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.SONGURL); }
        }
        ///<summary>
        ///</summary>
        public string IRC
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.IRC); }
        }
        ///<summary>
        ///</summary>
        public string ICQ
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.ICQ); }
        }
        ///<summary>
        ///</summary>
        public string AIM
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.AIM); }
        }
        ///<summary>
        ///</summary>
        public int WebHits
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.WEBHITS)); }
        }
        ///<summary>
        ///</summary>
        public int StreamHits
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.STREAMHITS)); }
        }
        ///<summary>
        ///</summary>
        public bool StreamStatus
        {
            get { return Convert.ToBoolean(Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.STREAMSTATUS))); }
        }
        ///<summary>
        ///</summary>
        public int Bitrate
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.BITRATE)); }
        }
        ///<summary>
        ///</summary>
        public string Content
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.CONTENT); }
        }
        ///<summary>
        ///</summary>
        public string Version
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.VERSION); }
        }
        ///<summary>
        ///</summary>
        public int CurrentListeners
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.CURRENTLISTENERS)); }
        }
        ///<summary>
        ///</summary>
        public int PeakListeners
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.PEAKLISTENERS)); }
        }
        ///<summary>
        ///</summary>
        public int MaxListeners
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.MAXLISTENERS)); }
        }
        ///<summary>
        ///</summary>
        public int ReportedListeners
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.REPORTEDLISTENERS)); }
        }
        ///<summary>
        ///</summary>
        public string ServerGenre
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.SERVERGENRE); }
        }      
        ///<summary>
        ///</summary>
        public string ServerTitle
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.SERVERTITLE); }
        }
        ///<summary>
        ///</summary>
        public string ServerUrl
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.SERVERURL); }
        }
        ///<summary>
        ///</summary>
        public int AverageTime
        {
            get { return Convert.ToInt32(GetProperty(_shoutcastXml, ShoutcastProperties.AVERAGETIME)); }
        }
        ///<summary>
        ///</summary>
        public string SongTitle
        {
            get { return GetProperty(_shoutcastXml, ShoutcastProperties.SONGTITLE); }
        }
        //public List<Listener> Listeners
        ///<summary>
        ///</summary>
        public IEnumerable<Listener> Listeners
        {
            get
            {
                var listeners = new List<Listener>();
                var q = (from c in _shoutcastXml.Descendants("LISTENERS")
                         select c.Elements("LISTENER")).ToList();

                foreach (var item in q)
                {
                    item.ToList().ForEach(p =>
                         listeners.Add(new Listener(p.Element("HOSTNAME").Value, p.Element("USERAGENT").Value
                         , p.Element("UNDERRUNS").Value, Convert.ToInt32(p.Element("CONNECTTIME").Value)
                         , p.Element("POINTER").Value, p.Element("UID").Value
                         )));
                }
                return listeners;
            }
        }
        ///<summary>
        ///</summary>
        public List<Song> SongHistory
        {
            get
            {
                var songHistory = new List<Song>();
                var q = (from c in _shoutcastXml.Descendants("SONGHISTORY")
                         select c.Elements("SONG")).ToList();
                foreach (var item in q)
                {
                    item.ToList().ForEach(p =>
                         songHistory.Add(new Song(p.Element("TITLE").Value, ConvertFromUnixTimestamp(Convert.ToDouble(p.Element("PLAYEDAT").Value)))));
                }
                return songHistory;
            }
        }
        /// <summary>
        /// Contains all the values from the WEBDATA region of the xml file
        /// </summary>
        public WebData Webdata
        {
            get { return _webdata; }
        }
        #endregion
        ///<summary>
        ///</summary>
        public class WebData : IDisposable
        {
            ShoutcastServer _s;
            internal WebData(ShoutcastServer s)
            {
                _s = s;
            }
            #region WebData Properties
            /// <summary>
            /// Gets the INDEX value from WEBDATA
            /// </summary>
            public int Index
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.INDEX)); }
            }
            /// <summary>
            /// Gets the LISTEN value from WEBDATA
            /// </summary>
            public int Listen
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.LISTEN)); }
            }
            /// <summary>
            /// Gets the PALM7 value from WEBDATA
            /// </summary>
            public int Palm7
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.PALM7)); }
            }
            /// <summary>
            /// Gets the LOGIN value from WEBDATA
            /// </summary>
            public int Login
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.LOGIN)); }
            }
            /// <summary>
            /// Gets the LOGINFAIL value from WEBDATA
            /// </summary>
            public int LoginFail
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.LOGINFAIL)); }
            }
            /// <summary>
            /// Gets the PLAYED value from WEBDATA
            /// </summary>
            public int Played
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.PLAYED)); }
            }
            /// <summary>
            /// Gets the COOKIE value from WEBDATA
            /// </summary>
            public int Cookie
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.COOKIE)); }
            }
            /// <summary>
            /// Gets the ADMIN value from WEBDATA
            /// </summary>
            public int Admin
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.ADMIN)); }
            }
            /// <summary>
            /// Gets the UPDINFO value from WEBDATA
            /// </summary>
            public int UpdInfo
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.UPDINFO)); }
            }
            /// <summary>
            /// Gets the KICKSRC value from WEBDATA
            /// </summary>
            public int KickSrc
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.KICKSRC)); }
            }
            /// <summary>
            /// Gets the KICKDST value from WEBDATA
            /// </summary>
            public int KickDst
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.KICKDST)); }
            }
            /// <summary>
            /// Gets the UNBANDST value from WEBDATA
            /// </summary>
            public int UnBanDst
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.UNBANDST)); }
            }
            /// <summary>
            /// Gets the BANDST value from WEBDATA
            /// </summary>
            public int BanDst
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.BANDST)); }
            }
            /// <summary>
            /// Gets the VIEWBAN value from WEBDATA
            /// </summary>
            public int ViewBan
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.VIEWBAN)); }
            }
            /// <summary>
            /// Gets the UNRIPDST value from WEBDATA
            /// </summary>
            public int UnRipDst
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.UNRIPDST)); }
            }
            /// <summary>
            /// Gets the RIPDST value from WEBDATA
            /// </summary>
            public int RipDst
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.RIPDST)); }
            }
            /// <summary>
            /// Gets the VIEWRIP value from WEBDATA
            /// </summary>
            public int ViewRip
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.VIEWRIP)); }
            }
            /// <summary>
            /// Gets the VIEWXML value from WEBDATA
            /// </summary>
            public int ViewXml
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.VIEWXML)); }
            }
            /// <summary>
            /// Gets the VIEWLOG value from WEBDATA
            /// </summary>
            public int ViewLog
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.VIEWLOG)); }
            }
            /// <summary>
            /// Gets the INVALID value from WEBDATA
            /// </summary>
            public int Invalid
            {
                get { return Convert.ToInt32(_s.GetWebDataProperty(_s._shoutcastXml, ShoutcastWebDataProperties.INVALID)); }
            }

            #endregion
            #region IDisposable Members
            /// <summary>
            /// 
            /// </summary>
            public void Dispose()
            {
                _s = null;
            }
            #endregion
        }
        #region IDisposable Members
        /// <summary>
        /// 
        /// </summary>
        public override void Dispose()
        {
            _webdata.Dispose();
            _shoutcastXml = null;
            _serverUrl = null;
        }

        static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0); 
            
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

    ///<summary>
    ///</summary>
    [Serializable]
    public class ServerDownException : Exception
    {
        ///<summary>
        ///</summary>
        public ServerDownException() { }
        ///<summary>
        ///</summary>
        ///<param name="message"></param>
        public ServerDownException(string message) : base(message) { }
        ///<summary>
        ///</summary>
        ///<param name="message"></param>
        ///<param name="inner"></param>
        public ServerDownException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ServerDownException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }

}

