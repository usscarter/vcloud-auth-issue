// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryApiFilterField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryApiFilterField : QueryField
  {
    public static QueryApiFilterField ID = QueryApiFilterField.Get("id");
    public static QueryApiFilterField HREF = QueryApiFilterField.Get("href");
    public static QueryApiFilterField SERVICE = QueryApiFilterField.Get("service");
    public static QueryApiFilterField URLPATTERN = QueryApiFilterField.Get("urlPattern");
    private string _value;

    private static QueryApiFilterField Get(string str)
    {
      return new QueryApiFilterField(str);
    }

    private QueryApiFilterField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryApiFilterField> Values()
    {
      QueryApiFilterField queryApiFilterField = new QueryApiFilterField();
      List<QueryApiFilterField> queryApiFilterFieldList = new List<QueryApiFilterField>();
      foreach (FieldInfo field in queryApiFilterField.GetType().GetFields())
        queryApiFilterFieldList.Add((QueryApiFilterField) field.GetValue((object) queryApiFilterField));
      return queryApiFilterFieldList;
    }

    public static QueryApiFilterField FromValue(string value)
    {
      foreach (QueryApiFilterField queryApiFilterField in QueryApiFilterField.Values())
      {
        if (queryApiFilterField.Value().Equals(value))
          return queryApiFilterField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
