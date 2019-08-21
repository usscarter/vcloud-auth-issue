// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAclRuleField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAclRuleField : QueryField
  {
    public static QueryAclRuleField ID = QueryAclRuleField.Get("id");
    public static QueryAclRuleField HREF = QueryAclRuleField.Get("href");
    public static QueryAclRuleField NAME = QueryAclRuleField.Get("name");
    public static QueryAclRuleField ORG = QueryAclRuleField.Get("org");
    public static QueryAclRuleField ORGACCESS = QueryAclRuleField.Get("orgAccess");
    public static QueryAclRuleField PRINCIPAL = QueryAclRuleField.Get("principal");
    public static QueryAclRuleField PRINCIPALACCESS = QueryAclRuleField.Get("principalAccess");
    public static QueryAclRuleField PRINCIPALTYPE = QueryAclRuleField.Get("principalType");
    public static QueryAclRuleField RESOURCECLASSACTION = QueryAclRuleField.Get("resourceClassAction");
    public static QueryAclRuleField SERVICERESOURCE = QueryAclRuleField.Get("serviceResource");
    public static QueryAclRuleField SERVICERESOURCEACCESS = QueryAclRuleField.Get("serviceResourceAccess");
    private string _value;

    private static QueryAclRuleField Get(string str)
    {
      return new QueryAclRuleField(str);
    }

    private QueryAclRuleField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAclRuleField> Values()
    {
      QueryAclRuleField queryAclRuleField = new QueryAclRuleField();
      List<QueryAclRuleField> queryAclRuleFieldList = new List<QueryAclRuleField>();
      foreach (FieldInfo field in queryAclRuleField.GetType().GetFields())
        queryAclRuleFieldList.Add((QueryAclRuleField) field.GetValue((object) queryAclRuleField));
      return queryAclRuleFieldList;
    }

    public static QueryAclRuleField FromValue(string value)
    {
      foreach (QueryAclRuleField queryAclRuleField in QueryAclRuleField.Values())
      {
        if (queryAclRuleField.Value().Equals(value))
          return queryAclRuleField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
