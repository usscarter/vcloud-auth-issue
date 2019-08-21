// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.BusSubType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct BusSubType
  {
    public static BusSubType BUS_LOGIC = BusSubType.Get("buslogic");
    public static BusSubType LSI_LOGIC = BusSubType.Get("lsilogic");
    public static BusSubType LSI_LOGIC_SAS = BusSubType.Get("lsilogicsas");
    public static BusSubType PARA_VIRTUAL = BusSubType.Get("VirtualSCSI");
    private string _value;

    private static BusSubType Get(string str)
    {
      return new BusSubType(str);
    }

    private BusSubType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<BusSubType> Values()
    {
      BusSubType busSubType = new BusSubType();
      List<BusSubType> busSubTypeList = new List<BusSubType>();
      foreach (FieldInfo field in busSubType.GetType().GetFields())
        busSubTypeList.Add((BusSubType) field.GetValue((object) busSubType));
      return busSubTypeList;
    }

    public static BusSubType FromValue(string value)
    {
      foreach (BusSubType busSubType in BusSubType.Values())
      {
        if (busSubType.Value().Equals(value))
          return busSubType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
