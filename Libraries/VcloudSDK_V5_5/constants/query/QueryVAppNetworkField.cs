// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVAppNetworkField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVAppNetworkField : QueryField
  {
    public static QueryVAppNetworkField ID = QueryVAppNetworkField.Get("id");
    public static QueryVAppNetworkField HREF = QueryVAppNetworkField.Get("href");
    public static QueryVAppNetworkField DNS1 = QueryVAppNetworkField.Get("dns1");
    public static QueryVAppNetworkField DNS2 = QueryVAppNetworkField.Get("dns2");
    public static QueryVAppNetworkField DNSSUFFIX = QueryVAppNetworkField.Get("dnsSuffix");
    public static QueryVAppNetworkField GATEWAY = QueryVAppNetworkField.Get("gateway");
    public static QueryVAppNetworkField IPSCOPEID = QueryVAppNetworkField.Get("ipScopeId");
    public static QueryVAppNetworkField IPSCOPEINHERITED = QueryVAppNetworkField.Get("ipScopeInherited");
    public static QueryVAppNetworkField ISBUSY = QueryVAppNetworkField.Get("isBusy");
    public static QueryVAppNetworkField ISVCENABLED = QueryVAppNetworkField.Get("isVCEnabled");
    public static QueryVAppNetworkField NAME = QueryVAppNetworkField.Get("name");
    public static QueryVAppNetworkField NETMASK = QueryVAppNetworkField.Get("netmask");
    public static QueryVAppNetworkField REALNETWORKNAME = QueryVAppNetworkField.Get("realNetworkName");
    public static QueryVAppNetworkField REALNETWORKPORTGROUPID = QueryVAppNetworkField.Get("realNetworkPortgroupId");
    public static QueryVAppNetworkField REALNETWORKPORTGROUPNAME = QueryVAppNetworkField.Get("realNetworkPortgroupName");
    public static QueryVAppNetworkField SCOPETYPE = QueryVAppNetworkField.Get("scopeType");
    public static QueryVAppNetworkField VAPP = QueryVAppNetworkField.Get("vapp");
    public static QueryVAppNetworkField VAPPNAME = QueryVAppNetworkField.Get("vAppName");
    public static QueryVAppNetworkField VC = QueryVAppNetworkField.Get("vc");
    public static QueryVAppNetworkField VCNAME = QueryVAppNetworkField.Get("vcName");
    private string _value;

    private static QueryVAppNetworkField Get(string str)
    {
      return new QueryVAppNetworkField(str);
    }

    private QueryVAppNetworkField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVAppNetworkField> Values()
    {
      QueryVAppNetworkField vappNetworkField = new QueryVAppNetworkField();
      List<QueryVAppNetworkField> vappNetworkFieldList = new List<QueryVAppNetworkField>();
      foreach (FieldInfo field in vappNetworkField.GetType().GetFields())
        vappNetworkFieldList.Add((QueryVAppNetworkField) field.GetValue((object) vappNetworkField));
      return vappNetworkFieldList;
    }

    public static QueryVAppNetworkField FromValue(string value)
    {
      foreach (QueryVAppNetworkField vappNetworkField in QueryVAppNetworkField.Values())
      {
        if (vappNetworkField.Value().Equals(value))
          return vappNetworkField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
