// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryCellField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryCellField : QueryField
  {
    public static QueryCellField ID = QueryCellField.Get("id");
    public static QueryCellField HREF = QueryCellField.Get("href");
    public static QueryCellField BUILDDATE = QueryCellField.Get("buildDate");
    public static QueryCellField ISACTIVE = QueryCellField.Get("isActive");
    public static QueryCellField NAME = QueryCellField.Get("name");
    public static QueryCellField PRIMARYIP = QueryCellField.Get("primaryIP");
    public static QueryCellField ISVMWAREVC = QueryCellField.Get("isVMwareVc");
    public static QueryCellField VERSION = QueryCellField.Get("version");
    private string _value;

    private static QueryCellField Get(string str)
    {
      return new QueryCellField(str);
    }

    private QueryCellField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryCellField> Values()
    {
      QueryCellField queryCellField = new QueryCellField();
      List<QueryCellField> queryCellFieldList = new List<QueryCellField>();
      foreach (FieldInfo field in queryCellField.GetType().GetFields())
        queryCellFieldList.Add((QueryCellField) field.GetValue((object) queryCellField));
      return queryCellFieldList;
    }

    public static QueryCellField FromValue(string value)
    {
      foreach (QueryCellField queryCellField in QueryCellField.Values())
      {
        if (queryCellField.Value().Equals(value))
          return queryCellField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
