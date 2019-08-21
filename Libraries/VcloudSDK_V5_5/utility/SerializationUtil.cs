// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.SerializationUtil
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace com.vmware.vcloud.sdk.utility
{
  public class SerializationUtil
  {
    private SerializationUtil()
    {
    }

    internal static string UTF8ByteArrayToString(byte[] characters)
    {
      return new UTF8Encoding().GetString(characters);
    }

    internal static byte[] StringToUTF8ByteArray(string pXmlString)
    {
      return new UTF8Encoding().GetBytes(pXmlString);
    }

    public static string SerializeObject<T>(T obj, string objectNamespace)
    {
      try
      {
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer xmlSerializer = objectNamespace.Trim().Length <= 0 ? new XmlSerializer(typeof (T)) : new XmlSerializer(typeof (T), objectNamespace);
        XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream) memoryStream, (Encoding) new UTF8Encoding(false));
        xmlSerializer.Serialize((XmlWriter) xmlTextWriter, (object) obj);
        return SerializationUtil.UTF8ByteArrayToString(((MemoryStream) xmlTextWriter.BaseStream).ToArray());
      }
      catch
      {
        return string.Empty;
      }
    }

    public static T DeserializeObject<T>(string xml, string objectNamespace)
    {
      XmlSerializer xmlSerializer = objectNamespace.Trim().Length <= 0 ? new XmlSerializer(typeof (T)) : new XmlSerializer(typeof (T), objectNamespace);
      MemoryStream memoryStream = new MemoryStream(SerializationUtil.StringToUTF8ByteArray(xml));
      XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream) memoryStream, (Encoding) new UTF8Encoding(false));
      return (T) xmlSerializer.Deserialize((Stream) memoryStream);
    }

    public static T DeserializeObject<T>(Stream inputStream, string objectNamespace)
    {
      return (T) (objectNamespace.Trim().Length <= 0 ? new XmlSerializer(typeof (T)) : new XmlSerializer(typeof (T), objectNamespace)).Deserialize(inputStream);
    }

    public static T DeserializeObject<T>(Stream inputStream)
    {
      return (T) new XmlSerializer(typeof (T)).Deserialize(inputStream);
    }
  }
}
