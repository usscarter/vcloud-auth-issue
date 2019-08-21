// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryServiceField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryServiceField : QueryField
  {
    public static QueryServiceField ID = QueryServiceField.Get("id");
    public static QueryServiceField HREF = QueryServiceField.Get("href");
    public static QueryServiceField NAME = QueryServiceField.Get("name");
    public static QueryServiceField NAMESPACE = QueryServiceField.Get("namespace");
    public static QueryServiceField VENDOR = QueryServiceField.Get("vendor");
    private string _value;

    private static QueryServiceField Get(string str)
    {
      return new QueryServiceField(str);
    }

    private QueryServiceField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryServiceField> Values()
    {
      QueryServiceField queryServiceField = new QueryServiceField();
      List<QueryServiceField> queryServiceFieldList = new List<QueryServiceField>();
      foreach (FieldInfo field in queryServiceField.GetType().GetFields())
        queryServiceFieldList.Add((QueryServiceField) field.GetValue((object) queryServiceField));
      return queryServiceFieldList;
    }

    public static QueryServiceField FromValue(string value)
    {
      foreach (QueryServiceField queryServiceField in QueryServiceField.Values())
      {
        if (queryServiceField.Value().Equals(value))
          return queryServiceField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
