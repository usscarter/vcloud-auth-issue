// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryOrgVdcNetworkField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryOrgVdcNetworkField : QueryField
  {
    public static QueryOrgVdcNetworkField ID = QueryOrgVdcNetworkField.Get("id");
    public static QueryOrgVdcNetworkField HREF = QueryOrgVdcNetworkField.Get("href");
    public static QueryOrgVdcNetworkField CONNECTEDTO = QueryOrgVdcNetworkField.Get("connectedTo");
    public static QueryOrgVdcNetworkField DEFAULTGATEWAY = QueryOrgVdcNetworkField.Get("defaultGateway");
    public static QueryOrgVdcNetworkField DNS1 = QueryOrgVdcNetworkField.Get("dns1");
    public static QueryOrgVdcNetworkField DNS2 = QueryOrgVdcNetworkField.Get("dns2");
    public static QueryOrgVdcNetworkField DNSSUFFIX = QueryOrgVdcNetworkField.Get("dnsSuffix");
    public static QueryOrgVdcNetworkField ISBUSY = QueryOrgVdcNetworkField.Get("isBusy");
    public static QueryOrgVdcNetworkField ISIPSCOPEINHERITED = QueryOrgVdcNetworkField.Get("isIpScopeInherited");
    public static QueryOrgVdcNetworkField ISSHARED = QueryOrgVdcNetworkField.Get("isShared");
    public static QueryOrgVdcNetworkField LINKTYPE = QueryOrgVdcNetworkField.Get("linkType");
    public static QueryOrgVdcNetworkField NAME = QueryOrgVdcNetworkField.Get("name");
    public static QueryOrgVdcNetworkField NETMASK = QueryOrgVdcNetworkField.Get("netmask");
    public static QueryOrgVdcNetworkField VDC = QueryOrgVdcNetworkField.Get("vdc");
    public static QueryOrgVdcNetworkField VDCNAME = QueryOrgVdcNetworkField.Get("vdcName");
    private string _value;

    private static QueryOrgVdcNetworkField Get(string str)
    {
      return new QueryOrgVdcNetworkField(str);
    }

    private QueryOrgVdcNetworkField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryOrgVdcNetworkField> Values()
    {
      QueryOrgVdcNetworkField orgVdcNetworkField = new QueryOrgVdcNetworkField();
      List<QueryOrgVdcNetworkField> orgVdcNetworkFieldList = new List<QueryOrgVdcNetworkField>();
      foreach (FieldInfo field in orgVdcNetworkField.GetType().GetFields())
        orgVdcNetworkFieldList.Add((QueryOrgVdcNetworkField) field.GetValue((object) orgVdcNetworkField));
      return orgVdcNetworkFieldList;
    }

    public static QueryOrgVdcNetworkField FromValue(string value)
    {
      foreach (QueryOrgVdcNetworkField orgVdcNetworkField in QueryOrgVdcNetworkField.Values())
      {
        if (orgVdcNetworkField.Value().Equals(value))
          return orgVdcNetworkField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
