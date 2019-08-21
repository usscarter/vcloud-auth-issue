// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.Layer4ProtocolType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct Layer4ProtocolType
  {
    public static Layer4ProtocolType TCP = Layer4ProtocolType.Get(nameof (TCP));
    public static Layer4ProtocolType UDP = Layer4ProtocolType.Get(nameof (UDP));
    public static Layer4ProtocolType TCP_UDP = Layer4ProtocolType.Get(nameof (TCP_UDP));
    private string _value;

    private static Layer4ProtocolType Get(string str)
    {
      return new Layer4ProtocolType(str);
    }

    private Layer4ProtocolType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<Layer4ProtocolType> Values()
    {
      Layer4ProtocolType layer4ProtocolType = new Layer4ProtocolType();
      List<Layer4ProtocolType> layer4ProtocolTypeList = new List<Layer4ProtocolType>();
      foreach (FieldInfo field in layer4ProtocolType.GetType().GetFields())
        layer4ProtocolTypeList.Add((Layer4ProtocolType) field.GetValue((object) layer4ProtocolType));
      return layer4ProtocolTypeList;
    }

    public static Layer4ProtocolType FromValue(string value)
    {
      foreach (Layer4ProtocolType layer4ProtocolType in Layer4ProtocolType.Values())
      {
        if (layer4ProtocolType.Value().Equals(value))
          return layer4ProtocolType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
