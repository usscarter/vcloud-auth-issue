// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryRightField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryRightField : QueryField
  {
    public static QueryRightField ID = QueryRightField.Get("id");
    public static QueryRightField HREF = QueryRightField.Get("href");
    public static QueryRightField CATEGORY = QueryRightField.Get("category");
    public static QueryRightField NAME = QueryRightField.Get("name");
    private string _value;

    private static QueryRightField Get(string str)
    {
      return new QueryRightField(str);
    }

    private QueryRightField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryRightField> Values()
    {
      QueryRightField queryRightField = new QueryRightField();
      List<QueryRightField> queryRightFieldList = new List<QueryRightField>();
      foreach (FieldInfo field in queryRightField.GetType().GetFields())
        queryRightFieldList.Add((QueryRightField) field.GetValue((object) queryRightField));
      return queryRightFieldList;
    }

    public static QueryRightField FromValue(string value)
    {
      foreach (QueryRightField queryRightField in QueryRightField.Values())
      {
        if (queryRightField.Value().Equals(value))
          return queryRightField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
