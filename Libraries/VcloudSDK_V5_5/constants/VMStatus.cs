// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.VMStatus
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct VMStatus
  {
    public static VMStatus FAILED_CREATION = VMStatus.Get(-1);
    public static VMStatus UNRESOLVED = VMStatus.Get(0);
    public static VMStatus RESOLVED = VMStatus.Get(1);
    public static VMStatus SUSPENDED = VMStatus.Get(3);
    public static VMStatus POWERED_ON = VMStatus.Get(4);
    public static VMStatus WAITING_FOR_INPUT = VMStatus.Get(5);
    public static VMStatus UNKNOWN = VMStatus.Get(6);
    public static VMStatus UNRECOGNIZED = VMStatus.Get(7);
    public static VMStatus POWERED_OFF = VMStatus.Get(8);
    public static VMStatus INCONSISTENT_STATE = VMStatus.Get(9);
    private int _value;

    private static VMStatus Get(int num)
    {
      return new VMStatus(num);
    }

    private VMStatus(int value)
    {
      this._value = value;
    }

    public int Value()
    {
      return this._value;
    }

    public static List<VMStatus> Values()
    {
      VMStatus vmStatus = new VMStatus();
      List<VMStatus> vmStatusList = new List<VMStatus>();
      foreach (FieldInfo field in vmStatus.GetType().GetFields())
        vmStatusList.Add((VMStatus) field.GetValue((object) vmStatus));
      return vmStatusList;
    }

    public static VMStatus FromValue(int value)
    {
      VMStatus vmStatus1 = new VMStatus();
      foreach (FieldInfo field in vmStatus1.GetType().GetFields())
      {
        VMStatus vmStatus2 = (VMStatus) field.GetValue((object) vmStatus1);
        if (vmStatus2.Value() == value)
          return vmStatus2;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
