// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.FenceModeValuesType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct FenceModeValuesType
  {
    public static FenceModeValuesType BRIDGED = FenceModeValuesType.Get("bridged");
    public static FenceModeValuesType ISOLATED = FenceModeValuesType.Get("isolated");
    public static FenceModeValuesType NATROUTED = FenceModeValuesType.Get("natRouted");
    private string _value;

    private static FenceModeValuesType Get(string str)
    {
      return new FenceModeValuesType(str);
    }

    private FenceModeValuesType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<FenceModeValuesType> Values()
    {
      FenceModeValuesType fenceModeValuesType = new FenceModeValuesType();
      List<FenceModeValuesType> fenceModeValuesTypeList = new List<FenceModeValuesType>();
      foreach (FieldInfo field in fenceModeValuesType.GetType().GetFields())
        fenceModeValuesTypeList.Add((FenceModeValuesType) field.GetValue((object) fenceModeValuesType));
      return fenceModeValuesTypeList;
    }

    public static FenceModeValuesType FromValue(string value)
    {
      foreach (FenceModeValuesType fenceModeValuesType in FenceModeValuesType.Values())
      {
        if (fenceModeValuesType.Value().Equals(value))
          return fenceModeValuesType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
