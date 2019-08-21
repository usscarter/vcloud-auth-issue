// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.FirewallDirectionType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct FirewallDirectionType
  {
    public static FirewallDirectionType IN = FirewallDirectionType.Get("in");
    public static FirewallDirectionType OUT = FirewallDirectionType.Get("out");
    private string _value;

    private static FirewallDirectionType Get(string str)
    {
      return new FirewallDirectionType(str);
    }

    private FirewallDirectionType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<FirewallDirectionType> Values()
    {
      FirewallDirectionType firewallDirectionType = new FirewallDirectionType();
      List<FirewallDirectionType> firewallDirectionTypeList = new List<FirewallDirectionType>();
      foreach (FieldInfo field in firewallDirectionType.GetType().GetFields())
        firewallDirectionTypeList.Add((FirewallDirectionType) field.GetValue((object) firewallDirectionType));
      return firewallDirectionTypeList;
    }

    public static FirewallDirectionType FromValue(string value)
    {
      foreach (FirewallDirectionType firewallDirectionType in FirewallDirectionType.Values())
      {
        if (firewallDirectionType.Value().Equals(value))
          return firewallDirectionType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
