using System.Xml;

namespace Alsing.Serialization
{
    public class Field
    {
        public string Name;
        public MetaObject Value;

        public void Serialize(XmlTextWriter xml)
        {
            xml.WriteStartElement("field");
            xml.WriteAttributeString("name", Name);
            Value.SerializeReference(xml);
            xml.WriteEndElement();
        }
    }
}