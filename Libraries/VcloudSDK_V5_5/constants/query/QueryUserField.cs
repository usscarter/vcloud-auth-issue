// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryUserField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryUserField : QueryField
  {
    public static QueryUserField ID = QueryUserField.Get("id");
    public static QueryUserField HREF = QueryUserField.Get("href");
    public static QueryUserField DEPLOYEDVMNUMBER = QueryUserField.Get("deployedVMNumber");
    public static QueryUserField DEPLOYEDVMQUOTA = QueryUserField.Get("deployedVMQuota");
    public static QueryUserField DEPLOYEDVMQUOTARANK = QueryUserField.Get("deployedVMQuotaRank");
    public static QueryUserField ISENABLED = QueryUserField.Get("isEnabled");
    public static QueryUserField FULLNAME = QueryUserField.Get("fullName");
    public static QueryUserField IDENTITYPROVIDERTYPE = QueryUserField.Get("identityProviderType");
    public static QueryUserField LDAPUSER = QueryUserField.Get("ldapUser");
    public static QueryUserField NAME = QueryUserField.Get("name");
    public static QueryUserField STOREDVMNUMBER = QueryUserField.Get("storedVMNumber");
    public static QueryUserField STOREDVMQUOTA = QueryUserField.Get("storedVMQuota");
    public static QueryUserField STOREDVMQUOTARANK = QueryUserField.Get("storedVMQuotaRank");
    private string _value;

    private static QueryUserField Get(string str)
    {
      return new QueryUserField(str);
    }

    private QueryUserField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryUserField> Values()
    {
      QueryUserField queryUserField = new QueryUserField();
      List<QueryUserField> queryUserFieldList = new List<QueryUserField>();
      foreach (FieldInfo field in queryUserField.GetType().GetFields())
        queryUserFieldList.Add((QueryUserField) field.GetValue((object) queryUserField));
      return queryUserFieldList;
    }

    public static QueryUserField FromValue(string value)
    {
      foreach (QueryUserField queryUserField in QueryUserField.Values())
      {
        if (queryUserField.Value().Equals(value))
          return queryUserField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
