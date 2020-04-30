using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        private string _levelScreenshotSrc;
        #endregion

        #region PROPERTIES
        [Index]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Display(Name = "Name")]
        public string LevelName
        {
            get { return _levelName; }
            set { _levelName = value; }
        }
        
        [Display(Name = "Description")]
        public string LevelDescription
        {
            get { return _levelDescription; }
            set { _levelDescription = value; }
        }

        [Display(Name ="Image")]
        public string LevelScreenshotSrc
        {
            get { return _levelScreenshotSrc; }
            set { _levelScreenshotSrc = value; }
        }

       [Display(Name = "New Enemies")]
       public virtual ICollection<EnemyModel> LevelEnemies { get; set; }

        [Display(Name = "New Items")]
        public virtual ICollection<ItemModel> LevelItems { get; set; }

        #endregion

        #region CONSTRUCTOR

        #endregion

        #region METHODS

        #endregion
    }
}