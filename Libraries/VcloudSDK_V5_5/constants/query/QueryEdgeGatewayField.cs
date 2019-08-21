// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryEdgeGatewayField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryEdgeGatewayField : QueryField
  {
    public static QueryEdgeGatewayField ID = QueryEdgeGatewayField.Get("id");
    public static QueryEdgeGatewayField HREF = QueryEdgeGatewayField.Get("href");
    public static QueryEdgeGatewayField GATEWAYSTATUS = QueryEdgeGatewayField.Get("gatewayStatus");
    public static QueryEdgeGatewayField HASTATUS = QueryEdgeGatewayField.Get("haStatus");
    public static QueryEdgeGatewayField ISBUSY = QueryEdgeGatewayField.Get("isBusy");
    public static QueryEdgeGatewayField NAME = QueryEdgeGatewayField.Get("name");
    public static QueryEdgeGatewayField NUMBEROFEXTNETWORKS = QueryEdgeGatewayField.Get("numberOfExtNetworks");
    public static QueryEdgeGatewayField NUMBEROFORGNETWORKS = QueryEdgeGatewayField.Get("numberOfOrgNetworks");
    public static QueryEdgeGatewayField VDC = QueryEdgeGatewayField.Get("vdc");
    private string _value;

    private static QueryEdgeGatewayField Get(string str)
    {
      return new QueryEdgeGatewayField(str);
    }

    private QueryEdgeGatewayField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryEdgeGatewayField> Values()
    {
      QueryEdgeGatewayField edgeGatewayField = new QueryEdgeGatewayField();
      List<QueryEdgeGatewayField> edgeGatewayFieldList = new List<QueryEdgeGatewayField>();
      foreach (FieldInfo field in edgeGatewayField.GetType().GetFields())
        edgeGatewayFieldList.Add((QueryEdgeGatewayField) field.GetValue((object) edgeGatewayField));
      return edgeGatewayFieldList;
    }

    public static QueryEdgeGatewayField FromValue(string value)
    {
      foreach (QueryEdgeGatewayField edgeGatewayField in QueryEdgeGatewayField.Values())
      {
        if (edgeGatewayField.Value().Equals(value))
          return edgeGatewayField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
