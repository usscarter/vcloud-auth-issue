// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.VimObjectTypeEnum
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct VimObjectTypeEnum
  {
    public static VimObjectTypeEnum CLUSTER_COMPUTE_RESOURCE = VimObjectTypeEnum.Get(nameof (CLUSTER_COMPUTE_RESOURCE));
    public static VimObjectTypeEnum RESOURCE_POOL = VimObjectTypeEnum.Get(nameof (RESOURCE_POOL));
    public static VimObjectTypeEnum DATASTORE = VimObjectTypeEnum.Get(nameof (DATASTORE));
    public static VimObjectTypeEnum HOST = VimObjectTypeEnum.Get(nameof (HOST));
    public static VimObjectTypeEnum VIRTUAL_MACHINE = VimObjectTypeEnum.Get(nameof (VIRTUAL_MACHINE));
    public static VimObjectTypeEnum VIRTUAL_APP = VimObjectTypeEnum.Get(nameof (VIRTUAL_APP));
    public static VimObjectTypeEnum NETWORK = VimObjectTypeEnum.Get(nameof (NETWORK));
    public static VimObjectTypeEnum DV_PORTGROUP = VimObjectTypeEnum.Get(nameof (DV_PORTGROUP));
    public static VimObjectTypeEnum DV_SWITCH = VimObjectTypeEnum.Get(nameof (DV_SWITCH));
    public static VimObjectTypeEnum FILE = VimObjectTypeEnum.Get(nameof (FILE));
    public static VimObjectTypeEnum FOLDER = VimObjectTypeEnum.Get(nameof (FOLDER));
    public static VimObjectTypeEnum DATASTORE_CLUSTER = VimObjectTypeEnum.Get(nameof (DATASTORE_CLUSTER));
    public static VimObjectTypeEnum STORAGE_PROFILE = VimObjectTypeEnum.Get(nameof (STORAGE_PROFILE));
    public static VimObjectTypeEnum SHIELD_MANAGER = VimObjectTypeEnum.Get(nameof (SHIELD_MANAGER));
    private string _value;

    private static VimObjectTypeEnum Get(string str)
    {
      return new VimObjectTypeEnum(str);
    }

    private VimObjectTypeEnum(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<VimObjectTypeEnum> Values()
    {
      VimObjectTypeEnum vimObjectTypeEnum = new VimObjectTypeEnum();
      List<VimObjectTypeEnum> vimObjectTypeEnumList = new List<VimObjectTypeEnum>();
      foreach (FieldInfo field in vimObjectTypeEnum.GetType().GetFields())
        vimObjectTypeEnumList.Add((VimObjectTypeEnum) field.GetValue((object) vimObjectTypeEnum));
      return vimObjectTypeEnumList;
    }

    public static VimObjectTypeEnum FromValue(string value)
    {
      foreach (VimObjectTypeEnum vimObjectTypeEnum in VimObjectTypeEnum.Values())
      {
        if (vimObjectTypeEnum.Value().Equals(value))
          return vimObjectTypeEnum;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
