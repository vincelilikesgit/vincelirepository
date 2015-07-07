using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace MovieStore
{

    /// <summary>
    /// Serializes and Deserializes movie data lists
    /// to persist the data, and to retrieve
    /// the data stored in a MOVIE type file
    /// </summary>
    class FileSerializer
    {

        /// <summary>
        /// Use a binary formatter to save the movie data
        /// to a custom file
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="myFile"></param>
        public static void Serialize(string strPath, List<MovieData> myFile)
        {
            FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, myFile);
                fs.Close();
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Deserialize an existing file back into a
        /// list of type MovieData
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static List<MovieData> Deserialize(string strPath)
        {
            FileStream fs = new FileStream(strPath, FileMode.Open);
            List<MovieData> myFile = new List<MovieData>();

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                myFile = ((List<MovieData>)(formatter.Deserialize(fs)));
                fs.Close();
                return myFile;
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return myFile;
            }
        }


    }
}