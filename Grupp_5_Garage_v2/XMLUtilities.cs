using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp_5_Garage_v2
{
   public  class XMLUtilities
    {

        /// <summary>
        /// This method handles the XML Serialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <param name="Obj"></param>
        public static void XMLFileSerialize<T>(string filepath, T Obj)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            TextWriter w = default(TextWriter);
            try
            {
                w = new StreamWriter(filepath);
                s.Serialize(w, Obj);
            }
            finally
            {
                if ((w != null))
                    w.Close();
            }
        }

        /// <summary>
        /// This function handles the XML Deserialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static T XMLFileDeserialize<T>(string filepath)
        {
            using (TextReader r = new StreamReader(filepath))
            {
                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(T));
                    return (T)s.Deserialize(r);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}
