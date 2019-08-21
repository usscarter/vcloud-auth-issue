// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminUserField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminUserField : QueryField
  {
    public static QueryAdminUserField ID = QueryAdminUserField.Get("id");
    public static QueryAdminUserField HREF = QueryAdminUserField.Get("href");
    public static QueryAdminUserField DEPLOYEDVMQUOTA = QueryAdminUserField.Get("deployedVMQuota");
    public static QueryAdminUserField DEPLOYEDVMQUOTARANK = QueryAdminUserField.Get("deployedVMQuotaRank");
    public static QueryAdminUserField FULLNAME = QueryAdminUserField.Get("fullName");
    public static QueryAdminUserField IDENTITYPROVIDERTYPE = QueryAdminUserField.Get("identityProviderType");
    public static QueryAdminUserField ISENABLED = QueryAdminUserField.Get("isEnabled");
    public static QueryAdminUserField ISLDAPUSER = QueryAdminUserField.Get("isLdapUser");
    public static QueryAdminUserField NAME = QueryAdminUserField.Get("name");
    public static QueryAdminUserField NUMBEROFDEPLOYEDVMS = QueryAdminUserField.Get("numberOfDeployedVMs");
    public static QueryAdminUserField NUMBEROFSTOREDVMS = QueryAdminUserField.Get("numberOfStoredVMs");
    public static QueryAdminUserField ORG = QueryAdminUserField.Get("org");
    public static QueryAdminUserField STOREDVMQUOTA = QueryAdminUserField.Get("storedVMQuota");
    public static QueryAdminUserField STOREDVMQUOTARANK = QueryAdminUserField.Get("storedVMQuotaRank");
    private string _value;

    private static QueryAdminUserField Get(string str)
    {
      return new QueryAdminUserField(str);
    }

    private QueryAdminUserField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminUserField> Values()
    {
      QueryAdminUserField queryAdminUserField = new QueryAdminUserField();
      List<QueryAdminUserField> queryAdminUserFieldList = new List<QueryAdminUserField>();
      foreach (FieldInfo field in queryAdminUserField.GetType().GetFields())
        queryAdminUserFieldList.Add((QueryAdminUserField) field.GetValue((object) queryAdminUserField));
      return queryAdminUserFieldList;
    }

    public static QueryAdminUserField FromValue(string value)
    {
      foreach (QueryAdminUserField queryAdminUserField in QueryAdminUserField.Values())
      {
        if (queryAdminUserField.Value().Equals(value))
          return queryAdminUserField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
