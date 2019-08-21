// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.NetworkAdapterType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct NetworkAdapterType
  {
    public static NetworkAdapterType E1000 = NetworkAdapterType.Get(nameof (E1000));
    public static NetworkAdapterType VLANCE = NetworkAdapterType.Get("PCNet32");
    public static NetworkAdapterType VMXNET = NetworkAdapterType.Get(nameof (VMXNET));
    public static NetworkAdapterType FLEXIBLE = NetworkAdapterType.Get("PCNet32");
    public static NetworkAdapterType VMXNET2 = NetworkAdapterType.Get(nameof (VMXNET2));
    public static NetworkAdapterType VMXNET3 = NetworkAdapterType.Get(nameof (VMXNET3));
    private string _value;

    private static NetworkAdapterType Get(string str)
    {
      return new NetworkAdapterType(str);
    }

    private NetworkAdapterType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<NetworkAdapterType> Values()
    {
      NetworkAdapterType networkAdapterType = new NetworkAdapterType();
      List<NetworkAdapterType> networkAdapterTypeList = new List<NetworkAdapterType>();
      foreach (FieldInfo field in networkAdapterType.GetType().GetFields())
        networkAdapterTypeList.Add((NetworkAdapterType) field.GetValue((object) networkAdapterType));
      return networkAdapterTypeList;
    }

    public static NetworkAdapterType FromValue(string value)
    {
      foreach (NetworkAdapterType networkAdapterType in NetworkAdapterType.Values())
      {
        if (networkAdapterType.Value().Equals(value))
          return networkAdapterType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
