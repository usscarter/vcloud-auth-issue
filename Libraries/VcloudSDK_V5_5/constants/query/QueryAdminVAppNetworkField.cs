// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminVAppNetworkField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminVAppNetworkField : QueryField
  {
    public static QueryAdminVAppNetworkField ID = QueryAdminVAppNetworkField.Get("id");
    public static QueryAdminVAppNetworkField HREF = QueryAdminVAppNetworkField.Get("href");
    public static QueryAdminVAppNetworkField DNS1 = QueryAdminVAppNetworkField.Get("dns1");
    public static QueryAdminVAppNetworkField DNS2 = QueryAdminVAppNetworkField.Get("dns2");
    public static QueryAdminVAppNetworkField DNSSUFFIX = QueryAdminVAppNetworkField.Get("dnsSuffix");
    public static QueryAdminVAppNetworkField GATEWAY = QueryAdminVAppNetworkField.Get("gateway");
    public static QueryAdminVAppNetworkField ISBUSY = QueryAdminVAppNetworkField.Get("isBusy");
    public static QueryAdminVAppNetworkField IPSCOPEINHERITED = QueryAdminVAppNetworkField.Get("ipScopeInherited");
    public static QueryAdminVAppNetworkField NAME = QueryAdminVAppNetworkField.Get("name");
    public static QueryAdminVAppNetworkField NETMASK = QueryAdminVAppNetworkField.Get("netmask");
    public static QueryAdminVAppNetworkField ORG = QueryAdminVAppNetworkField.Get("org");
    public static QueryAdminVAppNetworkField VAPP = QueryAdminVAppNetworkField.Get("vApp");
    public static QueryAdminVAppNetworkField VAPPNAME = QueryAdminVAppNetworkField.Get("vappName");
    private string _value;

    private static QueryAdminVAppNetworkField Get(string str)
    {
      return new QueryAdminVAppNetworkField(str);
    }

    private QueryAdminVAppNetworkField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminVAppNetworkField> Values()
    {
      QueryAdminVAppNetworkField vappNetworkField = new QueryAdminVAppNetworkField();
      List<QueryAdminVAppNetworkField> vappNetworkFieldList = new List<QueryAdminVAppNetworkField>();
      foreach (FieldInfo field in vappNetworkField.GetType().GetFields())
        vappNetworkFieldList.Add((QueryAdminVAppNetworkField) field.GetValue((object) vappNetworkField));
      return vappNetworkFieldList;
    }

    public static QueryAdminVAppNetworkField FromValue(string value)
    {
      foreach (QueryAdminVAppNetworkField vappNetworkField in QueryAdminVAppNetworkField.Values())
      {
        if (vappNetworkField.Value().Equals(value))
          return vappNetworkField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
