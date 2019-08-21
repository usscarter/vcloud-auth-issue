// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.NatTypeType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct NatTypeType
  {
    public static NatTypeType IPTRANSLATION = NatTypeType.Get("ipTranslation");
    public static NatTypeType PORTFORWARDING = NatTypeType.Get("portForwarding");
    private string _value;

    private static NatTypeType Get(string str)
    {
      return new NatTypeType(str);
    }

    private NatTypeType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<NatTypeType> Values()
    {
      NatTypeType natTypeType = new NatTypeType();
      List<NatTypeType> natTypeTypeList = new List<NatTypeType>();
      foreach (FieldInfo field in natTypeType.GetType().GetFields())
        natTypeTypeList.Add((NatTypeType) field.GetValue((object) natTypeType));
      return natTypeTypeList;
    }

    public static NatTypeType FromValue(string value)
    {
      foreach (NatTypeType natTypeType in NatTypeType.Values())
      {
        if (natTypeType.Value().Equals(value))
          return natTypeType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
