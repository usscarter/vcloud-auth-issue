// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.NatMappingModeType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct NatMappingModeType
  {
    public static NatMappingModeType AUTOMATIC = NatMappingModeType.Get("automatic");
    public static NatMappingModeType MANUAL = NatMappingModeType.Get("manual");
    private string _value;

    private static NatMappingModeType Get(string str)
    {
      return new NatMappingModeType(str);
    }

    private NatMappingModeType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<NatMappingModeType> Values()
    {
      NatMappingModeType natMappingModeType = new NatMappingModeType();
      List<NatMappingModeType> natMappingModeTypeList = new List<NatMappingModeType>();
      foreach (FieldInfo field in natMappingModeType.GetType().GetFields())
        natMappingModeTypeList.Add((NatMappingModeType) field.GetValue((object) natMappingModeType));
      return natMappingModeTypeList;
    }

    public static NatMappingModeType FromValue(string value)
    {
      foreach (NatMappingModeType natMappingModeType in NatMappingModeType.Values())
      {
        if (natMappingModeType.Value().Equals(value))
          return natMappingModeType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
