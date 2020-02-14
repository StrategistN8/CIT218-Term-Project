using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int EnemyHP
        {
            get { return _enemyHP; }
            set { _enemyHP = value; }
        }
        public string EnemyName
        {
            get { return _enemyName; }
            set { _enemyName = value; }
        }
        public string EnemyAttack
        {
            get { return _enemyAttack; }
            set { _enemyAttack = value; }
        }
        public string EnemyDescription
        {
            get { return _enemyDescription; }
            set { _enemyDescription = value; }
        }
        public string EnemyImageSrc
        {
            get { return _enemyImageSrc; }
            set { _enemyImageSrc = value; }
        }


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