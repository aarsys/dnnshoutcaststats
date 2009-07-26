using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Search;
using DotNetNuke.Entities.Modules;



namespace Aarsys.Modules.DNN_ShoutcastStats.Components
{
    /// <summary>
    /// Represents a node from the PLAYEDAT node collection of the shoucast xml
    /// </summary>
    public class Song : IDisposable
    {
        string _SongTitle;
        DateTime _PlayedAt;
        public string SongTitle
        {
            get
            {
                return this._SongTitle;
            }
        }
        public DateTime PlayedAt
        {
            get
            {
                return this._PlayedAt;
            }
        }
        public Song(string SongTitle, DateTime PlayedAt)
        {
            this._SongTitle = SongTitle;
            this._PlayedAt = PlayedAt;
        }

        #region IDisposable Members
        public void Dispose()
        {
            this._SongTitle = null;
        }
        #endregion
    }
}
