// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryOrgVdcGatewayField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryOrgVdcGatewayField : QueryField
  {
    public static QueryOrgVdcGatewayField ID = QueryOrgVdcGatewayField.Get("id");
    public static QueryOrgVdcGatewayField HREF = QueryOrgVdcGatewayField.Get("href");
    public static QueryOrgVdcGatewayField ISBUSY = QueryOrgVdcGatewayField.Get("isBusy");
    public static QueryOrgVdcGatewayField NAME = QueryOrgVdcGatewayField.Get("name");
    public static QueryOrgVdcGatewayField NUMBEROFEXTNETWORKS = QueryOrgVdcGatewayField.Get("numberOfExtNetworks");
    public static QueryOrgVdcGatewayField NUMBEROFORGNETWORKS = QueryOrgVdcGatewayField.Get("numberOfOrgNetworks");
    public static QueryOrgVdcGatewayField VDC = QueryOrgVdcGatewayField.Get("vdc");
    private string _value;

    private static QueryOrgVdcGatewayField Get(string str)
    {
      return new QueryOrgVdcGatewayField(str);
    }

    private QueryOrgVdcGatewayField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryOrgVdcGatewayField> Values()
    {
      QueryOrgVdcGatewayField orgVdcGatewayField = new QueryOrgVdcGatewayField();
      List<QueryOrgVdcGatewayField> orgVdcGatewayFieldList = new List<QueryOrgVdcGatewayField>();
      foreach (FieldInfo field in orgVdcGatewayField.GetType().GetFields())
        orgVdcGatewayFieldList.Add((QueryOrgVdcGatewayField) field.GetValue((object) orgVdcGatewayField));
      return orgVdcGatewayFieldList;
    }

    public static QueryOrgVdcGatewayField FromValue(string value)
    {
      foreach (QueryOrgVdcGatewayField orgVdcGatewayField in QueryOrgVdcGatewayField.Values())
      {
        if (orgVdcGatewayField.Value().Equals(value))
          return orgVdcGatewayField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
