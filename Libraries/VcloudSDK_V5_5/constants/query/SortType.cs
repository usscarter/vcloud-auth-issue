// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.SortType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct SortType
  {
    public static SortType SORT_ASC = SortType.Get("sortAsc");
    public static SortType SORT_DESC = SortType.Get("sortDesc");
    private string _value;

    private static SortType Get(string str)
    {
      return new SortType(str);
    }

    private SortType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<SortType> Values()
    {
      SortType sortType = new SortType();
      List<SortType> sortTypeList = new List<SortType>();
      foreach (FieldInfo field in sortType.GetType().GetFields())
        sortTypeList.Add((SortType) field.GetValue((object) sortType));
      return sortTypeList;
    }

    public static SortType FromValue(string value)
    {
      foreach (SortType sortType in SortType.Values())
      {
        if (sortType.Value().Equals(value))
          return sortType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
