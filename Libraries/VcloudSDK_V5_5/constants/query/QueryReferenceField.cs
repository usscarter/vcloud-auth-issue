// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryReferenceField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryReferenceField : QueryField
  {
    public static QueryReferenceField ID = QueryReferenceField.Get("id");
    public static QueryReferenceField HREF = QueryReferenceField.Get("href");
    public static QueryReferenceField NAME = QueryReferenceField.Get("name");
    private string _value;

    private static QueryReferenceField Get(string str)
    {
      return new QueryReferenceField(str);
    }

    private QueryReferenceField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryReferenceField> Values()
    {
      QueryReferenceField queryReferenceField = new QueryReferenceField();
      List<QueryReferenceField> queryReferenceFieldList = new List<QueryReferenceField>();
      foreach (PropertyInfo property in typeof (QueryReferenceField).GetProperties())
        queryReferenceFieldList.Add((QueryReferenceField) property.GetValue((object) queryReferenceField, (object[]) null));
      return queryReferenceFieldList;
    }

    public static QueryReferenceField FromValue(string value)
    {
      foreach (QueryReferenceField queryReferenceField in QueryReferenceField.Values())
      {
        if (queryReferenceField.Value().Equals(value))
          return queryReferenceField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
