using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbyssRunSite.Models
{
    /// <summary>
    /// Class used to store information about game items.
    /// </summary>
    public class ItemModel
    {

        #region FIELDS
        private int _id;
        private string _itemName;

       


        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        #endregion

        #region CONSTRUCTOR

        #endregion

        #region METHODS

        #endregion
    }
}