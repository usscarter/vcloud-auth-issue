// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminGroupField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminGroupField : QueryField
  {
    public static QueryAdminGroupField ID = QueryAdminGroupField.Get("id");
    public static QueryAdminGroupField HREF = QueryAdminGroupField.Get("href");
    public static QueryAdminGroupField IDENTITYPROVIDERTYPE = QueryAdminGroupField.Get("identityProviderType");
    public static QueryAdminGroupField ISREADONLY = QueryAdminGroupField.Get("isReadOnly");
    public static QueryAdminGroupField NAME = QueryAdminGroupField.Get("name");
    public static QueryAdminGroupField ORG = QueryAdminGroupField.Get("org");
    public static QueryAdminGroupField ROLENAME = QueryAdminGroupField.Get("roleName");
    private string _value;

    private static QueryAdminGroupField Get(string str)
    {
      return new QueryAdminGroupField(str);
    }

    private QueryAdminGroupField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminGroupField> Values()
    {
      QueryAdminGroupField queryAdminGroupField = new QueryAdminGroupField();
      List<QueryAdminGroupField> queryAdminGroupFieldList = new List<QueryAdminGroupField>();
      foreach (FieldInfo field in queryAdminGroupField.GetType().GetFields())
        queryAdminGroupFieldList.Add((QueryAdminGroupField) field.GetValue((object) queryAdminGroupField));
      return queryAdminGroupFieldList;
    }

    public static QueryAdminGroupField FromValue(string value)
    {
      foreach (QueryAdminGroupField queryAdminGroupField in QueryAdminGroupField.Values())
      {
        if (queryAdminGroupField.Value().Equals(value))
          return queryAdminGroupField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
