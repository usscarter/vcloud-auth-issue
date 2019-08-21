// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.IpAddressAllocationModeType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct IpAddressAllocationModeType
  {
    public static IpAddressAllocationModeType NONE = IpAddressAllocationModeType.Get(nameof (NONE));
    public static IpAddressAllocationModeType MANUAL = IpAddressAllocationModeType.Get(nameof (MANUAL));
    public static IpAddressAllocationModeType POOL = IpAddressAllocationModeType.Get(nameof (POOL));
    public static IpAddressAllocationModeType DHCP = IpAddressAllocationModeType.Get(nameof (DHCP));
    private string _value;

    private static IpAddressAllocationModeType Get(string str)
    {
      return new IpAddressAllocationModeType(str);
    }

    private IpAddressAllocationModeType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<IpAddressAllocationModeType> Values()
    {
      IpAddressAllocationModeType allocationModeType = new IpAddressAllocationModeType();
      List<IpAddressAllocationModeType> allocationModeTypeList = new List<IpAddressAllocationModeType>();
      foreach (FieldInfo field in allocationModeType.GetType().GetFields())
        allocationModeTypeList.Add((IpAddressAllocationModeType) field.GetValue((object) allocationModeType));
      return allocationModeTypeList;
    }

    public static IpAddressAllocationModeType FromValue(string value)
    {
      foreach (IpAddressAllocationModeType allocationModeType in IpAddressAllocationModeType.Values())
      {
        if (allocationModeType.Value().Equals(value))
          return allocationModeType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
