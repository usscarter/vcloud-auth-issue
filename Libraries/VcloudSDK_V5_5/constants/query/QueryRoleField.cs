// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryRoleField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryRoleField : QueryField
  {
    public static QueryRoleField ID = QueryRoleField.Get("id");
    public static QueryRoleField HREF = QueryRoleField.Get("href");
    public static QueryRoleField NAME = QueryRoleField.Get("name");
    public static QueryRoleField ISREDAONLY = QueryRoleField.Get("isRedaOnly");
    public static QueryRoleField ROLETYPE = QueryRoleField.Get("roleType");
    private string _value;

    private static QueryRoleField Get(string str)
    {
      return new QueryRoleField(str);
    }

    private QueryRoleField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryRoleField> Values()
    {
      QueryRoleField queryRoleField = new QueryRoleField();
      List<QueryRoleField> queryRoleFieldList = new List<QueryRoleField>();
      foreach (FieldInfo field in queryRoleField.GetType().GetFields())
        queryRoleFieldList.Add((QueryRoleField) field.GetValue((object) queryRoleField));
      return queryRoleFieldList;
    }

    public static QueryRoleField FromValue(string value)
    {
      foreach (QueryRoleField queryRoleField in QueryRoleField.Values())
      {
        if (queryRoleField.Value().Equals(value))
          return queryRoleField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
