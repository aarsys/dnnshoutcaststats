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
    /// Represents a node from the PLAYEDAT node collection of the shoucast xml
    /// </summary>
    public class Song : IDisposable
    {
        ///<summary>
        ///</summary>
        public string SongTitle { get; private set; }

        ///<summary>
        ///</summary>
        public DateTime PlayedAt { get; private set; }

        ///<summary>
        ///</summary>
        ///<param name="songTitle"></param>
        ///<param name="playedAt"></param>
        public Song(string songTitle, DateTime playedAt)
        {
            SongTitle = songTitle;
            PlayedAt = playedAt;
        }

        #region IDisposable Members
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            SongTitle = null;
        }
        #endregion
    }
}
