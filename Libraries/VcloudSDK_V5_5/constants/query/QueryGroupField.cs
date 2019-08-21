// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryGroupField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryGroupField : QueryField
  {
    public static QueryGroupField ID = QueryGroupField.Get("id");
    public static QueryGroupField HREF = QueryGroupField.Get("href");
    public static QueryGroupField IDENTITYPROVIDERTYPE = QueryGroupField.Get("identityProviderType");
    public static QueryGroupField NAME = QueryGroupField.Get("name");
    public static QueryGroupField ISREADONLY = QueryGroupField.Get("isReadOnly");
    public static QueryGroupField ROLENAME = QueryGroupField.Get("roleName");
    private string _value;

    private static QueryGroupField Get(string str)
    {
      return new QueryGroupField(str);
    }

    private QueryGroupField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryGroupField> Values()
    {
      QueryGroupField queryGroupField = new QueryGroupField();
      List<QueryGroupField> queryGroupFieldList = new List<QueryGroupField>();
      foreach (FieldInfo field in queryGroupField.GetType().GetFields())
        queryGroupFieldList.Add((QueryGroupField) field.GetValue((object) queryGroupField));
      return queryGroupFieldList;
    }

    public static QueryGroupField FromValue(string value)
    {
      foreach (QueryGroupField queryGroupField in QueryGroupField.Values())
      {
        if (queryGroupField.Value().Equals(value))
          return queryGroupField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
