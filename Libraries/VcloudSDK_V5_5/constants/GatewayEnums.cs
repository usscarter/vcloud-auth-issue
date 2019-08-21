// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.GatewayEnums
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct GatewayEnums
  {
    public static GatewayEnums UPLINK = GatewayEnums.Get("uplink");
    public static GatewayEnums INTERNAL = GatewayEnums.Get("internal");
    private string _value;

    private static GatewayEnums Get(string str)
    {
      return new GatewayEnums(str);
    }

    private GatewayEnums(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<GatewayEnums> Values()
    {
      GatewayEnums gatewayEnums = new GatewayEnums();
      List<GatewayEnums> gatewayEnumsList = new List<GatewayEnums>();
      foreach (FieldInfo field in gatewayEnums.GetType().GetFields())
        gatewayEnumsList.Add((GatewayEnums) field.GetValue((object) gatewayEnums));
      return gatewayEnumsList;
    }

    public static GatewayEnums FromValue(string value)
    {
      foreach (GatewayEnums gatewayEnums in GatewayEnums.Values())
      {
        if (gatewayEnums.Value().Equals(value))
          return gatewayEnums;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
