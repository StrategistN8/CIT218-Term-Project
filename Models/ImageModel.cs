using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbyssRunSite.Models
{
    /// <summary>
    /// Small class used to store image information to other classes.
    /// </summary>
    public class ImageModel
    {

        #region FIELD
        private int _id;
        private string _imageSrc;
        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ImageSrc
        {
            get { return _imageSrc; }
            set { _imageSrc = value; }
        }

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        #endregion
    }
}