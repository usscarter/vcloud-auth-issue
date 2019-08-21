// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.VappStatus
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct VappStatus
  {
    public static VappStatus FAILED_CREATION = VappStatus.Get(-1);
    public static VappStatus UNRESOLVED = VappStatus.Get(0);
    public static VappStatus RESOLVED = VappStatus.Get(1);
    public static VappStatus SUSPENDED = VappStatus.Get(3);
    public static VappStatus POWERED_ON = VappStatus.Get(4);
    public static VappStatus WAITING_FOR_INPUT = VappStatus.Get(5);
    public static VappStatus UNKNOWN = VappStatus.Get(6);
    public static VappStatus UNRECOGNIZED = VappStatus.Get(7);
    public static VappStatus POWERED_OFF = VappStatus.Get(8);
    public static VappStatus INCONSISTENT_STATE = VappStatus.Get(9);
    public static VappStatus MIXED = VappStatus.Get(10);
    private int _value;

    private static VappStatus Get(int num)
    {
      return new VappStatus(num);
    }

    private VappStatus(int value)
    {
      this._value = value;
    }

    public int Value()
    {
      return this._value;
    }

    public static List<VappStatus> Values()
    {
      VappStatus vappStatus = new VappStatus();
      List<VappStatus> vappStatusList = new List<VappStatus>();
      foreach (FieldInfo field in vappStatus.GetType().GetFields())
        vappStatusList.Add((VappStatus) field.GetValue((object) vappStatus));
      return vappStatusList;
    }

    public static VappStatus FromValue(int value)
    {
      VappStatus vappStatus1 = new VappStatus();
      foreach (FieldInfo field in vappStatus1.GetType().GetFields())
      {
        VappStatus vappStatus2 = (VappStatus) field.GetValue((object) vappStatus1);
        if (vappStatus2.Value() == value)
          return vappStatus2;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
