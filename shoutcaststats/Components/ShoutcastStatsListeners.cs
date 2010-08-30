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


namespace Aarsys.ShoutcastStats.Components
{
    /// <summary>
    /// Represents a listener with details such as Hostname, UserAgent etc.
    /// </summary>
    public class Listener : IDisposable
    {
        ///<summary>
        ///</summary>
        ///<param name="hostName"></param>
        ///<param name="userAgent"></param>
        ///<param name="underruns"></param>
        ///<param name="connectTime"></param>
        ///<param name="pointer"></param>
        ///<param name="uid"></param>
        public Listener(string hostName, string userAgent, string underruns, int connectTime, string pointer, string uid)
        {
            HostName = hostName;
            UserAgent = userAgent;
            Underruns = underruns;
            ConnectTime = connectTime;
            Pointer = pointer;
            UID = uid;
        }

        ///<summary>
        ///</summary>
        public string HostName { get; private set; }

        ///<summary>
        ///</summary>
        public string UserAgent { get; private set; }

        ///<summary>
        ///</summary>
        public string Underruns { get; private set; }

        ///<summary>
        ///</summary>
        public int ConnectTime { get; private set; }

        ///<summary>
        ///</summary>
        public string Pointer { get; private set; }

        ///<summary>
        ///</summary>
        public string UID { get; private set; }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            HostName = null;
            Pointer = null;
            UID = null;
            Underruns = null;
            UserAgent = null;
        }

        #endregion
    }
}

