// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.VappTemplateStatus
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct VappTemplateStatus
  {
    public static VappTemplateStatus FAILED_CREATION = VappTemplateStatus.Get(-1);
    public static VappTemplateStatus UNRESOLVED = VappTemplateStatus.Get(0);
    public static VappTemplateStatus RESOLVED = VappTemplateStatus.Get(1);
    public static VappTemplateStatus UNKNOWN = VappTemplateStatus.Get(6);
    public static VappTemplateStatus UNRECOGNIZE = VappTemplateStatus.Get(7);
    public static VappTemplateStatus POWERED_OFF = VappTemplateStatus.Get(8);
    public static VappTemplateStatus MIXED = VappTemplateStatus.Get(10);
    public static VappTemplateStatus DESCRIPTOR_PENDING = VappTemplateStatus.Get(11);
    public static VappTemplateStatus COPYING_CONTENTS = VappTemplateStatus.Get(12);
    public static VappTemplateStatus DISK_CONTENTS_PENDING = VappTemplateStatus.Get(13);
    public static VappTemplateStatus QUARANTINED = VappTemplateStatus.Get(14);
    public static VappTemplateStatus QUARANTINE_EXPIRED = VappTemplateStatus.Get(15);
    public static VappTemplateStatus REJECTED = VappTemplateStatus.Get(16);
    public static VappTemplateStatus TRANSFER_TIMEOUT = VappTemplateStatus.Get(17);
    private int _value;

    private static VappTemplateStatus Get(int num)
    {
      return new VappTemplateStatus(num);
    }

    private VappTemplateStatus(int value)
    {
      this._value = value;
    }

    public int Value()
    {
      return this._value;
    }

    public static List<VappTemplateStatus> Values()
    {
      VappTemplateStatus vappTemplateStatus = new VappTemplateStatus();
      List<VappTemplateStatus> vappTemplateStatusList = new List<VappTemplateStatus>();
      foreach (FieldInfo field in vappTemplateStatus.GetType().GetFields())
        vappTemplateStatusList.Add((VappTemplateStatus) field.GetValue((object) vappTemplateStatus));
      return vappTemplateStatusList;
    }

    public static VappTemplateStatus FromValue(int value)
    {
      VappTemplateStatus vappTemplateStatus1 = new VappTemplateStatus();
      foreach (FieldInfo field in vappTemplateStatus1.GetType().GetFields())
      {
        VappTemplateStatus vappTemplateStatus2 = (VappTemplateStatus) field.GetValue((object) vappTemplateStatus1);
        if (vappTemplateStatus2.Value() == value)
          return vappTemplateStatus2;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
