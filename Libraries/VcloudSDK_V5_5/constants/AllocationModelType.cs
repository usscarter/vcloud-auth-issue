// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.AllocationModelType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct AllocationModelType
  {
    public static AllocationModelType ALLOCATIONVAPP = AllocationModelType.Get("AllocationVApp");
    public static AllocationModelType ALLOCATIONPOOL = AllocationModelType.Get("AllocationPool");
    public static AllocationModelType RESERVATIONPOOL = AllocationModelType.Get("ReservationPool");
    private string _value;

    private static AllocationModelType Get(string str)
    {
      return new AllocationModelType(str);
    }

    private AllocationModelType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<AllocationModelType> Values()
    {
      AllocationModelType allocationModelType = new AllocationModelType();
      List<AllocationModelType> allocationModelTypeList = new List<AllocationModelType>();
      foreach (FieldInfo field in allocationModelType.GetType().GetFields())
        allocationModelTypeList.Add((AllocationModelType) field.GetValue((object) allocationModelType));
      return allocationModelTypeList;
    }

    public static AllocationModelType FromValue(string value)
    {
      foreach (AllocationModelType allocationModelType in AllocationModelType.Values())
      {
        if (allocationModelType.Value().Equals(value))
          return allocationModelType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
