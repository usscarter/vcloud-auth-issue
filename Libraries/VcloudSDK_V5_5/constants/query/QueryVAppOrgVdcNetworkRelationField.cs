// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVAppOrgVdcNetworkRelationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVAppOrgVdcNetworkRelationField : QueryField
  {
    public static QueryVAppOrgVdcNetworkRelationField ID = QueryVAppOrgVdcNetworkRelationField.Get("id");
    public static QueryVAppOrgVdcNetworkRelationField HREF = QueryVAppOrgVdcNetworkRelationField.Get("href");
    public static QueryVAppOrgVdcNetworkRelationField ENTITYTYPE = QueryVAppOrgVdcNetworkRelationField.Get("entityType");
    public static QueryVAppOrgVdcNetworkRelationField NAME = QueryVAppOrgVdcNetworkRelationField.Get("name");
    public static QueryVAppOrgVdcNetworkRelationField ORG = QueryVAppOrgVdcNetworkRelationField.Get("org");
    public static QueryVAppOrgVdcNetworkRelationField ORGVDCNETWORK = QueryVAppOrgVdcNetworkRelationField.Get("orgVdcNetwork");
    public static QueryVAppOrgVdcNetworkRelationField ORGVDCNETWORKNAME = QueryVAppOrgVdcNetworkRelationField.Get("orgVdcNetworkName");
    public static QueryVAppOrgVdcNetworkRelationField OWNERNAME = QueryVAppOrgVdcNetworkRelationField.Get("ownerName");
    public static QueryVAppOrgVdcNetworkRelationField STATUS = QueryVAppOrgVdcNetworkRelationField.Get("status");
    private string _value;

    private static QueryVAppOrgVdcNetworkRelationField Get(
      string str)
    {
      return new QueryVAppOrgVdcNetworkRelationField(str);
    }

    private QueryVAppOrgVdcNetworkRelationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVAppOrgVdcNetworkRelationField> Values()
    {
      QueryVAppOrgVdcNetworkRelationField networkRelationField = new QueryVAppOrgVdcNetworkRelationField();
      List<QueryVAppOrgVdcNetworkRelationField> networkRelationFieldList = new List<QueryVAppOrgVdcNetworkRelationField>();
      foreach (FieldInfo field in networkRelationField.GetType().GetFields())
        networkRelationFieldList.Add((QueryVAppOrgVdcNetworkRelationField) field.GetValue((object) networkRelationField));
      return networkRelationFieldList;
    }

    public static QueryVAppOrgVdcNetworkRelationField FromValue(
      string value)
    {
      foreach (QueryVAppOrgVdcNetworkRelationField networkRelationField in QueryVAppOrgVdcNetworkRelationField.Values())
      {
        if (networkRelationField.Value().Equals(value))
          return networkRelationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
