// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.BusType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct BusType
  {
    public static BusType IDE = BusType.Get("5");
    public static BusType SCSI = BusType.Get("6");
    private string _value;

    private static BusType Get(string str)
    {
      return new BusType(str);
    }

    private BusType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<BusType> Values()
    {
      BusType busType = new BusType();
      List<BusType> busTypeList = new List<BusType>();
      foreach (FieldInfo field in busType.GetType().GetFields())
        busTypeList.Add((BusType) field.GetValue((object) busType));
      return busTypeList;
    }

    public static BusType FromValue(string value)
    {
      foreach (BusType busType in BusType.Values())
      {
        if (busType.Value().Equals(value))
          return busType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
