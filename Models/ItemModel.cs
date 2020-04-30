using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        private string _itemDescription;
        private string _itemImgSrc;
        #endregion

        #region PROPERTIES
        [Index]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        [Display(Name = "Name")]
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        [Display(Name = "Description")]
        public string ItemDescription
        {
            get { return _itemDescription; }
            set { _itemDescription = value; }
        }

        [Display(Name = "Image")] 
        public string ItemImageSrc
        {
            get { return _itemImgSrc; }
            set { _itemImgSrc = value; }
        }

        [Display(Name = "Level Introduced")]
        public int LevelModelId { get; set; }
        #endregion

        #region CONSTRUCTOR

        #endregion

        #region METHODS

        #endregion
    }
}