using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace _225_Final_Project.Resources
{
    [Serializable()]
    public class SerializedObject
    {
        /// <summary>
        /// Stores the paths of the files from the main form
        /// </summary>
        public List<string> FilePaths { get; private set; } = new List<string>();
        /// <summary>
        /// Stores the names of the files from the main form
        /// </summary>
        public List<string> Names { get; private set; } = new List<string>();
        /// <summary>
        /// Saves the last state of the Logging class
        /// </summary>
        public bool SaveType = false;
        /// <summary>
        /// Says if the Table has been made
        /// </summary>
        public bool ErrorTable = false;

        /// <summary>
        /// Saves the Objects to this file for serialization
        /// </summary>
        /// <param name="FilePaths"></param>
        /// <param name="ObjectNames"></param>
        /// <param name="SaveType"></param>
        /// <param name="ErrorTable"></param>
        public void Save(List<string> FilePaths, List<string> ObjectNames)
        {
            this.FilePaths = FilePaths;
            this.Names = ObjectNames;
            this.SaveType = ErrorLogging.Logging.OutputType;
            this.ErrorTable = ErrorLogging.Logging.TableBuilt;
        }
        /// <summary>
        /// Serializes the class to a specified File
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="obj"></param>
        public void SerializeClass(string FileName)
        {
            using (Stream stream = File.Open(FileName, FileMode.Open))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                binFormat.Serialize(stream, this);
            }
        }
        /// <summary>
        /// DeSerializes the class from a specified File
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static SerializedObject DeSerializeClass(string FileName, SerializedObject obj = null)
        {
            using (Stream stream = File.Open(FileName, FileMode.Open))
            {
                try
                {
                    BinaryFormatter binFormat = new BinaryFormatter();
                    obj = (SerializedObject)binFormat.Deserialize(stream);
                }
                catch
                {
                    
                }
            }
            return obj;
        }
    }
}
