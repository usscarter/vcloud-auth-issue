// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryOrgNetworkField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  [Obsolete("This field type is deprecated  since API 5.1, SDK 5.1")]
  public struct QueryOrgNetworkField : QueryField
  {
    public static QueryOrgNetworkField ID = QueryOrgNetworkField.Get("id");
    public static QueryOrgNetworkField HREF = QueryOrgNetworkField.Get("href");
    public static QueryOrgNetworkField DNS1 = QueryOrgNetworkField.Get("dns1");
    public static QueryOrgNetworkField DNS2 = QueryOrgNetworkField.Get("dns2");
    public static QueryOrgNetworkField DNSSUFFIX = QueryOrgNetworkField.Get("dnsSuffix");
    public static QueryOrgNetworkField GATEWAY = QueryOrgNetworkField.Get("gateway");
    public static QueryOrgNetworkField IPSCOPEID = QueryOrgNetworkField.Get("ipScopeId");
    public static QueryOrgNetworkField IPSCOPEINHERITED = QueryOrgNetworkField.Get("ipScopeInherited");
    public static QueryOrgNetworkField ISBUSY = QueryOrgNetworkField.Get("isBusy");
    public static QueryOrgNetworkField NAME = QueryOrgNetworkField.Get("name");
    public static QueryOrgNetworkField NETPOOLID = QueryOrgNetworkField.Get("netPoolId");
    public static QueryOrgNetworkField NETPOOLNAME = QueryOrgNetworkField.Get("netPoolName");
    public static QueryOrgNetworkField NETMASK = QueryOrgNetworkField.Get("netmask");
    public static QueryOrgNetworkField SCOPETYPE = QueryOrgNetworkField.Get("scopeType");
    private string _value;

    private static QueryOrgNetworkField Get(string str)
    {
      return new QueryOrgNetworkField(str);
    }

    private QueryOrgNetworkField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryOrgNetworkField> Values()
    {
      QueryOrgNetworkField queryOrgNetworkField = new QueryOrgNetworkField();
      List<QueryOrgNetworkField> queryOrgNetworkFieldList = new List<QueryOrgNetworkField>();
      foreach (FieldInfo field in queryOrgNetworkField.GetType().GetFields())
        queryOrgNetworkFieldList.Add((QueryOrgNetworkField) field.GetValue((object) queryOrgNetworkField));
      return queryOrgNetworkFieldList;
    }

    public static QueryOrgNetworkField FromValue(string value)
    {
      foreach (QueryOrgNetworkField queryOrgNetworkField in QueryOrgNetworkField.Values())
      {
        if (queryOrgNetworkField.Value().Equals(value))
          return queryOrgNetworkField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
