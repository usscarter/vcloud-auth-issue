// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.GatewayBackingConfigValuesType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct GatewayBackingConfigValuesType
  {
    public static GatewayBackingConfigValuesType COMPACT = GatewayBackingConfigValuesType.Get("compact");
    public static GatewayBackingConfigValuesType FULL = GatewayBackingConfigValuesType.Get("full");
    private string _value;

    private static GatewayBackingConfigValuesType Get(string str)
    {
      return new GatewayBackingConfigValuesType(str);
    }

    private GatewayBackingConfigValuesType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<GatewayBackingConfigValuesType> Values()
    {
      GatewayBackingConfigValuesType configValuesType = new GatewayBackingConfigValuesType();
      List<GatewayBackingConfigValuesType> configValuesTypeList = new List<GatewayBackingConfigValuesType>();
      foreach (FieldInfo field in configValuesType.GetType().GetFields())
        configValuesTypeList.Add((GatewayBackingConfigValuesType) field.GetValue((object) configValuesType));
      return configValuesTypeList;
    }

    public static GatewayBackingConfigValuesType FromValue(
      string value)
    {
      foreach (GatewayBackingConfigValuesType configValuesType in GatewayBackingConfigValuesType.Values())
      {
        if (configValuesType.Value().Equals(value))
          return configValuesType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
