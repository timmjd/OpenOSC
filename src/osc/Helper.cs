using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace OpenOSC
{
  class Helper
  {
    public static string xmlToString(object xml)
    {
      var writer = new StringWriter();
      var serializer = new XmlSerializer(xml.GetType());
      serializer.Serialize(writer, xml);
      return writer.ToString();
    }
  }
}
