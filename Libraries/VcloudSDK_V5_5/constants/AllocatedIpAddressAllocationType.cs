// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.AllocatedIpAddressAllocationType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct AllocatedIpAddressAllocationType
  {
    public static AllocatedIpAddressAllocationType VMALLOCATED = AllocatedIpAddressAllocationType.Get("vmAllocated");
    public static AllocatedIpAddressAllocationType NATROUTED = AllocatedIpAddressAllocationType.Get("natRouted");
    public static AllocatedIpAddressAllocationType VSMALLOCATED = AllocatedIpAddressAllocationType.Get("vsmAllocated");
    private string _value;

    private static AllocatedIpAddressAllocationType Get(string str)
    {
      return new AllocatedIpAddressAllocationType(str);
    }

    private AllocatedIpAddressAllocationType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<AllocatedIpAddressAllocationType> Values()
    {
      AllocatedIpAddressAllocationType addressAllocationType = new AllocatedIpAddressAllocationType();
      List<AllocatedIpAddressAllocationType> addressAllocationTypeList = new List<AllocatedIpAddressAllocationType>();
      foreach (FieldInfo field in addressAllocationType.GetType().GetFields())
        addressAllocationTypeList.Add((AllocatedIpAddressAllocationType) field.GetValue((object) addressAllocationType));
      return addressAllocationTypeList;
    }

    public static AllocatedIpAddressAllocationType FromValue(
      string value)
    {
      foreach (AllocatedIpAddressAllocationType addressAllocationType in AllocatedIpAddressAllocationType.Values())
      {
        if (addressAllocationType.Value().Equals(value))
          return addressAllocationType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
