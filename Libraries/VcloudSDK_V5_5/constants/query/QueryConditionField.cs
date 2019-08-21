// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryConditionField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryConditionField : QueryField
  {
    public static QueryConditionField ID = QueryConditionField.Get("id");
    public static QueryConditionField HREF = QueryConditionField.Get("href");
    public static QueryConditionField DETAILS = QueryConditionField.Get("details");
    public static QueryConditionField OBJECT = QueryConditionField.Get("object");
    public static QueryConditionField OBJECTTYPE = QueryConditionField.Get("objectType");
    public static QueryConditionField OCCURENCEDATE = QueryConditionField.Get("occurenceDate");
    public static QueryConditionField SEVERITY = QueryConditionField.Get("severity");
    public static QueryConditionField SUMMARY = QueryConditionField.Get("summary");
    private string _value;

    private static QueryConditionField Get(string str)
    {
      return new QueryConditionField(str);
    }

    private QueryConditionField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryConditionField> Values()
    {
      QueryConditionField queryConditionField = new QueryConditionField();
      List<QueryConditionField> queryConditionFieldList = new List<QueryConditionField>();
      foreach (FieldInfo field in queryConditionField.GetType().GetFields())
        queryConditionFieldList.Add((QueryConditionField) field.GetValue((object) queryConditionField));
      return queryConditionFieldList;
    }

    public static QueryConditionField FromValue(string value)
    {
      foreach (QueryConditionField queryConditionField in QueryConditionField.Values())
      {
        if (queryConditionField.Value().Equals(value))
          return queryConditionField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
