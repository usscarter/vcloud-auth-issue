// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.AccessLevelType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct AccessLevelType
  {
    public static AccessLevelType FULLCONTROL = AccessLevelType.Get("FullControl");
    public static AccessLevelType CHANGE = AccessLevelType.Get("Change");
    public static AccessLevelType READONLY = AccessLevelType.Get("ReadOnly");
    private string _value;

    private static AccessLevelType Get(string str)
    {
      return new AccessLevelType(str);
    }

    private AccessLevelType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<AccessLevelType> Values()
    {
      AccessLevelType accessLevelType = new AccessLevelType();
      List<AccessLevelType> accessLevelTypeList = new List<AccessLevelType>();
      foreach (FieldInfo field in accessLevelType.GetType().GetFields())
        accessLevelTypeList.Add((AccessLevelType) field.GetValue((object) accessLevelType));
      return accessLevelTypeList;
    }

    public static AccessLevelType FromValue(string value)
    {
      foreach (AccessLevelType accessLevelType in AccessLevelType.Values())
      {
        if (accessLevelType.Value().Equals(value))
          return accessLevelType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
