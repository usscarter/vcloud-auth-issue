﻿// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.FilterType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct FilterType
  {
    public static FilterType AND = FilterType.Get(";");
    public static FilterType OR = FilterType.Get(",");
    public static FilterType NULL = FilterType.Get("");
    private string _value;

    private static FilterType Get(string str)
    {
      return new FilterType(str);
    }

    private FilterType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<FilterType> Values()
    {
      FilterType filterType = new FilterType();
      List<FilterType> filterTypeList = new List<FilterType>();
      foreach (FieldInfo field in filterType.GetType().GetFields())
        filterTypeList.Add((FilterType) field.GetValue((object) filterType));
      return filterTypeList;
    }

    public static FilterType FromValue(string value)
    {
      foreach (FilterType filterType in FilterType.Values())
      {
        if (filterType.Value().Equals(value))
          return filterType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}