using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore
{
    [Serializable]
    public class MovieData
    {
#region Member Variables

        private Guid mId;
        //For the Movie Application
        //private int mID;
        private string mTitle;
        private string mDirector;
        private DateTime mReleaseDate;

        #endregion

#region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MovieData()
        {
            mId = Guid.NewGuid();
        }


        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="moviename"></param>
        public MovieData(string Title, string Director, DateTime ReleaseDate)
        {
            mId = Guid.NewGuid();
            mTitle = Title;
            mDirector = Director;
            mReleaseDate = ReleaseDate;
        }

#endregion

#region Properties

        public Guid ID
        {
            get
            {
                return mId;
            }
        }


        public string Title
        {
            get
            {
                return mTitle;
            }
            set
            {
                mTitle = value;
            }
        }


        public string Director
        {
            get
            {
                return mDirector;
            }
            set
            {
                mDirector = value;
            }
        }


        public DateTime ReleaseDate
        {
            get
            {
                return mReleaseDate;
            }
            set
            {
                mReleaseDate = value;
            }
        }

        #endregion


    }
}
