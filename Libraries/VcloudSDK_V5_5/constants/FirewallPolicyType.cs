// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.FirewallPolicyType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct FirewallPolicyType
  {
    public static FirewallPolicyType DROP = FirewallPolicyType.Get("drop");
    public static FirewallPolicyType ALLOW = FirewallPolicyType.Get("allow");
    private string _value;

    private static FirewallPolicyType Get(string str)
    {
      return new FirewallPolicyType(str);
    }

    private FirewallPolicyType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<FirewallPolicyType> Values()
    {
      FirewallPolicyType firewallPolicyType = new FirewallPolicyType();
      List<FirewallPolicyType> firewallPolicyTypeList = new List<FirewallPolicyType>();
      foreach (FieldInfo field in firewallPolicyType.GetType().GetFields())
        firewallPolicyTypeList.Add((FirewallPolicyType) field.GetValue((object) firewallPolicyType));
      return firewallPolicyTypeList;
    }

    public static FirewallPolicyType FromValue(string value)
    {
      foreach (FirewallPolicyType firewallPolicyType in FirewallPolicyType.Values())
      {
        if (firewallPolicyType.Value().Equals(value))
          return firewallPolicyType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
