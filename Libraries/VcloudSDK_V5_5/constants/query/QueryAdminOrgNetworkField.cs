// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminOrgNetworkField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  [Obsolete("This query constant is obsolete")]
  public struct QueryAdminOrgNetworkField : QueryField
  {
    public static QueryAdminOrgNetworkField ID = QueryAdminOrgNetworkField.Get("id");
    public static QueryAdminOrgNetworkField HREF = QueryAdminOrgNetworkField.Get("href");
    public static QueryAdminOrgNetworkField DNS1 = QueryAdminOrgNetworkField.Get("dns1");
    public static QueryAdminOrgNetworkField DNS2 = QueryAdminOrgNetworkField.Get("dns2");
    public static QueryAdminOrgNetworkField GATEWAY = QueryAdminOrgNetworkField.Get("gateway");
    public static QueryAdminOrgNetworkField IPSCOPEID = QueryAdminOrgNetworkField.Get("ipScopeId");
    public static QueryAdminOrgNetworkField IPSCOPEINHERITED = QueryAdminOrgNetworkField.Get("ipScopeInherited");
    public static QueryAdminOrgNetworkField ISBUSY = QueryAdminOrgNetworkField.Get("isBusy");
    public static QueryAdminOrgNetworkField NAME = QueryAdminOrgNetworkField.Get("name");
    public static QueryAdminOrgNetworkField NETPOOL = QueryAdminOrgNetworkField.Get("netPool");
    public static QueryAdminOrgNetworkField NETPOOLNAME = QueryAdminOrgNetworkField.Get("netPoolName");
    public static QueryAdminOrgNetworkField NETMASK = QueryAdminOrgNetworkField.Get("netmask");
    public static QueryAdminOrgNetworkField ORG = QueryAdminOrgNetworkField.Get("org");
    public static QueryAdminOrgNetworkField ORGNAME = QueryAdminOrgNetworkField.Get("orgName");
    private string _value;

    private static QueryAdminOrgNetworkField Get(string str)
    {
      return new QueryAdminOrgNetworkField(str);
    }

    private QueryAdminOrgNetworkField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminOrgNetworkField> Values()
    {
      QueryAdminOrgNetworkField adminOrgNetworkField = new QueryAdminOrgNetworkField();
      List<QueryAdminOrgNetworkField> adminOrgNetworkFieldList = new List<QueryAdminOrgNetworkField>();
      foreach (FieldInfo field in adminOrgNetworkField.GetType().GetFields())
        adminOrgNetworkFieldList.Add((QueryAdminOrgNetworkField) field.GetValue((object) adminOrgNetworkField));
      return adminOrgNetworkFieldList;
    }

    public static QueryAdminOrgNetworkField fromValue(string value)
    {
      foreach (QueryAdminOrgNetworkField adminOrgNetworkField in QueryAdminOrgNetworkField.Values())
      {
        if (adminOrgNetworkField.Value().Equals(value))
          return adminOrgNetworkField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
