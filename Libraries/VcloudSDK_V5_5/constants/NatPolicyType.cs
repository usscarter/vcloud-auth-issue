// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.NatPolicyType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct NatPolicyType
  {
    public static NatPolicyType ALLOWTRAFFIC = NatPolicyType.Get("allowTraffic");
    public static NatPolicyType ALLOWTRAFFICIN = NatPolicyType.Get("allowTrafficIn");
    private string _value;

    private static NatPolicyType Get(string str)
    {
      return new NatPolicyType(str);
    }

    private NatPolicyType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<NatPolicyType> Values()
    {
      NatPolicyType natPolicyType = new NatPolicyType();
      List<NatPolicyType> natPolicyTypeList = new List<NatPolicyType>();
      foreach (FieldInfo field in natPolicyType.GetType().GetFields())
        natPolicyTypeList.Add((NatPolicyType) field.GetValue((object) natPolicyType));
      return natPolicyTypeList;
    }

    public static NatPolicyType FromValue(string value)
    {
      foreach (NatPolicyType natPolicyType in NatPolicyType.Values())
      {
        if (natPolicyType.Value().Equals(value))
          return natPolicyType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
