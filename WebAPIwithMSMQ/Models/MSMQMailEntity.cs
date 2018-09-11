using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WebAPIwithMSMQ.Models
{
    /// <summary>
    /// MSMQ Email Entity
    /// </summary>
    [Serializable]
    public class MSMQMailEntity
    {
        /// <summary>
        /// campaign element attribute
        /// </summary>
        [XmlAttribute]
        public string Campaignfile { get; set; }

        /// <summary>
        /// campaign element attribute
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// campaign element node
        /// </summary>
        public Recipient recipient { get; set; }
    }

    /// <summary>
    /// campaign element's node
    /// </summary>
    [Serializable]
    public class Recipient
    {
        /// <summary>
        /// recipient element's attribute
        /// </summary>
        [XmlAttribute]
        public string address { get; set; }

        /// <summary>
        /// recipient element's node
        /// </summary>
        /// <remarks>
        /// Always do not have value
        /// </remarks>
        public string trace { get; set; }

        /// <summary>
        /// recipient element's node
        /// </summary>
        [XmlElement(ElementName = "param")]
        public List<Param> param { get; set; }
    }

    /// <summary>
    /// recipient element's node
    /// </summary>
    [Serializable]
    public class Param
    {
        /// <summary>
        /// param element's attribute
        /// </summary>
        [XmlAttribute]
        public string name { get; set; }

        /// <summary>
        /// param element's attribute
        /// </summary>
        [XmlAttribute]
        public string encodeType { get; set; }

        /// <summary>
        /// param element's value
        /// will output as a CData format
        /// </summary>
        [XmlIgnore]
        public string textContent { get; set; }

        /// <summary>
        /// Output textContent's value as CData format
        /// </summary>
        [XmlText]
        public XmlNode[] CDatatextContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(textContent) };
            }
            set
            {
                if (value == null)
                {
                    textContent = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException(String.Format("Invalid array length {0}", value.Length));
                }

                textContent = value[0].Value;
            }
        }
    }
}