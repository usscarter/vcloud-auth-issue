// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.UndeployPowerActionType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct UndeployPowerActionType
  {
    public static UndeployPowerActionType SUSPEND = UndeployPowerActionType.Get("suspend");
    public static UndeployPowerActionType POWEROFF = UndeployPowerActionType.Get("powerOff");
    public static UndeployPowerActionType DEFAULT = UndeployPowerActionType.Get("default");
    public static UndeployPowerActionType SHUTDOWN = UndeployPowerActionType.Get("shutdown");
    public static UndeployPowerActionType FORCE = UndeployPowerActionType.Get("force");
    private string _value;

    private static UndeployPowerActionType Get(string str)
    {
      return new UndeployPowerActionType(str);
    }

    private UndeployPowerActionType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<UndeployPowerActionType> Values()
    {
      UndeployPowerActionType undeployPowerActionType = new UndeployPowerActionType();
      List<UndeployPowerActionType> undeployPowerActionTypeList = new List<UndeployPowerActionType>();
      foreach (FieldInfo field in undeployPowerActionType.GetType().GetFields())
        undeployPowerActionTypeList.Add((UndeployPowerActionType) field.GetValue((object) undeployPowerActionType));
      return undeployPowerActionTypeList;
    }

    public static UndeployPowerActionType FromValue(string value)
    {
      foreach (UndeployPowerActionType undeployPowerActionType in UndeployPowerActionType.Values())
      {
        if (undeployPowerActionType.Value().Equals(value))
          return undeployPowerActionType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
