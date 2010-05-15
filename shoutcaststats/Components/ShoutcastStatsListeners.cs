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
using System.Configuration;
using System.Data;
using System.Xml.Linq;
using System.Text;
using System.Web;
using System.Collections.Generic;


namespace Aarsys.ShoutcastStats.Components
{
    /// <summary>
    /// Represents a listener with details such as Hostname, UserAgent etc.
    /// </summary>
    public class Listener : IDisposable
    {
        public Listener(string HostName, string UserAgent, string Underruns, int ConnectTime, string Pointer, string UID)
        {
            this._HostName = HostName;
            this._UserAgent = UserAgent;
            this._Underruns = Underruns;
            this._ConnectTime = ConnectTime;
            this._Pointer = Pointer;
            this._UID = UID;
        }
        string _HostName, _UserAgent, _Underruns, _Pointer, _UID;
        int _ConnectTime;
        public string HostName
        {
            get { return _HostName; }
        }
        public string UserAgent
        {
            get { return _UserAgent; }
        }
        public string Underruns
        {
            get { return _Underruns; }
        }
        public int ConnectTime
        {
            get { return _ConnectTime; }
        }
        public string Pointer
        {
            get { return _Pointer; }
        }
        public string UID
        {
            get { return _UID; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            this._HostName = null;
            this._Pointer = null;
            this._UID = null;
            this._Underruns = null;
            this._UserAgent = null;
        }

        #endregion
    }
}

