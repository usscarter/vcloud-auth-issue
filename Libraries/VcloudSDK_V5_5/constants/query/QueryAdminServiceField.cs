// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminServiceField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminServiceField : QueryField
  {
    public static QueryAdminServiceField ID = QueryAdminServiceField.Get("id");
    public static QueryAdminServiceField HREF = QueryAdminServiceField.Get("href");
    public static QueryAdminServiceField ENABLED = QueryAdminServiceField.Get("enabled");
    public static QueryAdminServiceField EXCHANGE = QueryAdminServiceField.Get("exchange");
    public static QueryAdminServiceField ISAUTHORIZATIONENABLED = QueryAdminServiceField.Get("isAuthorizationEnabled");
    public static QueryAdminServiceField NAME = QueryAdminServiceField.Get("name");
    public static QueryAdminServiceField NAMESPACE = QueryAdminServiceField.Get("namespace");
    public static QueryAdminServiceField PRIORITY = QueryAdminServiceField.Get("priority");
    public static QueryAdminServiceField ROUTINGKEY = QueryAdminServiceField.Get("routingKey");
    public static QueryAdminServiceField VENDOR = QueryAdminServiceField.Get("vendor");
    private string _value;

    private static QueryAdminServiceField Get(string str)
    {
      return new QueryAdminServiceField(str);
    }

    private QueryAdminServiceField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminServiceField> Values()
    {
      QueryAdminServiceField adminServiceField = new QueryAdminServiceField();
      List<QueryAdminServiceField> adminServiceFieldList = new List<QueryAdminServiceField>();
      foreach (FieldInfo field in adminServiceField.GetType().GetFields())
        adminServiceFieldList.Add((QueryAdminServiceField) field.GetValue((object) adminServiceField));
      return adminServiceFieldList;
    }

    public static QueryAdminServiceField FromValue(string value)
    {
      foreach (QueryAdminServiceField adminServiceField in QueryAdminServiceField.Values())
      {
        if (adminServiceField.Value().Equals(value))
          return adminServiceField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
