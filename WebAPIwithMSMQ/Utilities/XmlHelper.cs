using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WebAPIwithMSMQ.Utilities
{
    /// <summary>
    /// Xml helper
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// Serialize object to MSMQ mail xml format
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="value">data send to MSMQ</param>
        /// <returns>string format</returns>
        public static string SerializeToMSMQMailFormat<T>(T value)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings()
            {
                Indent = false,
                OmitXmlDeclaration = true,
                NewLineOnAttributes = false,
                Encoding = new UnicodeEncoding(false, false)
            };

            using (var memoryStream = new MemoryStream())
            {
                using (var rt = XmlWriter.Create(memoryStream, settings))
                {
                    serializer.Serialize(rt, value, emptyNamepsaces);
                }

                string xmlString = Encoding.Unicode.GetString(memoryStream.ToArray());

                return xmlString;
            }
        }
    }
}