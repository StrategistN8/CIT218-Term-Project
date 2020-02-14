using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbyssRunSite.Models
{
    /// <summary>
    /// Class used to store user feedback:
    /// </summary>
    public class FeedbackModel
    {

        #region FIELDS
                
        private int _id;
        private string _feedbackEmail;
        private string _feedbackMessage;

        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FeedbackEmail
        {
            get { return _feedbackEmail; }
            set { _feedbackEmail = value; }
        }
        public string FeedbackMessage
        {
            get { return _feedbackMessage; }
            set { _feedbackMessage = value; }
        }
        #endregion

        #region CONTRUCTORS
        public FeedbackModel()
        {

        }
        #endregion

        #region METHODS

        #endregion
    }
}