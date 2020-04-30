using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbyssRunSite.Models
{
    /// <summary>
    /// Class used to store information about the game's enemies.
    /// </summary>
    public class EnemyModel
    {
        #region FIELDS
        private int _id;
        private int _enemyHP;
        private string _enemyName;
        private string _enemyAttack;
        private string _enemyDescription;
        private string _enemyImageSrc; // Temp
        #endregion

        #region PROPERTIES

        [Index]
        [Required]
        [ConcurrencyCheck]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
       
        [Display(Name = "HP")]
        [Range(1, 10)]
        public int EnemyHP
        {
            get { return _enemyHP; }
            set { _enemyHP = value; }
        }

        [Index]
        [Display(Name = "Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Names should be limited to 1-50 upper or lowercase letters")]
        [MaxLength(50, ErrorMessage = "Names should be limited to 50 characters")]
        public string EnemyName
        {
            get { return _enemyName; }
            set { _enemyName = value; }
        }

        [Display(Name = "Weapons")]
        //[MaxLength(150, ErrorMessage = "Limited to 150 characters")]
        public string EnemyAttack
        {
            get { return _enemyAttack; }
            set { _enemyAttack = value; }
        }

        [Display(Name = "Description")]
        //[MaxLength(250, ErrorMessage = "Descriptions should be limited to 250 characters")]
        public string EnemyDescription
        {
            get { return _enemyDescription; }
            set { _enemyDescription = value; }
        }

        [Display(Name = "Sprite")]   
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No Image")]
        public string EnemyImageSrc
        {
            get { return _enemyImageSrc; }
            set { _enemyImageSrc = value; }
        }

        [Display(Name = "Level Introduced")]
        [Index]
        public int LevelModelId { get; set; }

        #endregion

        #region CONSTRUCTOR
        public EnemyModel()
        {

        }
        #endregion

        #region METHODS

        #endregion


    }
}