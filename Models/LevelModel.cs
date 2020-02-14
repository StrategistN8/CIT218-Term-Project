using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbyssRunSite.Models
{
    /// <summary>
    /// Used to store information from game levels.
    /// </summary>
    public class LevelModel
    {
        #region FIELDS

        private int _id;
        private string _levelName;
        private string _levelDescription;

        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string LevelName
        {
            get { return _levelName; }
            set { _levelName = value; }
        }
        public string LevelDescription
        {
            get { return _levelDescription; }
            set { _levelDescription = value; }
        }
        
        #endregion

        #region CONSTRUCTOR

        #endregion

        #region METHODS

        #endregion
    }
}