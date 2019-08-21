// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryNetworkField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryNetworkField : QueryField
  {
    public static QueryNetworkField ID = QueryNetworkField.Get("id");
    public static QueryNetworkField HREF = QueryNetworkField.Get("href");
    public static QueryNetworkField DNS1 = QueryNetworkField.Get("dns1");
    public static QueryNetworkField DNS2 = QueryNetworkField.Get("dns2");
    public static QueryNetworkField DNSSUFFIX = QueryNetworkField.Get("dnsSuffix");
    public static QueryNetworkField GATEWAY = QueryNetworkField.Get("gateway");
    public static QueryNetworkField IPSCOPEID = QueryNetworkField.Get("ipScopeId");
    public static QueryNetworkField ISBUSY = QueryNetworkField.Get("isBusy");
    public static QueryNetworkField NAME = QueryNetworkField.Get("name");
    public static QueryNetworkField NETMASK = QueryNetworkField.Get("netmask");
    private string _value;

    private static QueryNetworkField Get(string str)
    {
      return new QueryNetworkField(str);
    }

    private QueryNetworkField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryNetworkField> Values()
    {
      QueryNetworkField queryNetworkField = new QueryNetworkField();
      List<QueryNetworkField> queryNetworkFieldList = new List<QueryNetworkField>();
      foreach (FieldInfo field in queryNetworkField.GetType().GetFields())
        queryNetworkFieldList.Add((QueryNetworkField) field.GetValue((object) queryNetworkField));
      return queryNetworkFieldList;
    }

    public static QueryNetworkField FromValue(string value)
    {
      foreach (QueryNetworkField queryNetworkField in QueryNetworkField.Values())
      {
        if (queryNetworkField.Value().Equals(value))
          return queryNetworkField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
