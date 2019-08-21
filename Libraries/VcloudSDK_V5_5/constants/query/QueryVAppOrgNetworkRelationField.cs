// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVAppOrgNetworkRelationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  [Obsolete("This query constant is obsolete")]
  public struct QueryVAppOrgNetworkRelationField : QueryField
  {
    public static QueryVAppOrgNetworkRelationField ID = QueryVAppOrgNetworkRelationField.Get("id");
    public static QueryVAppOrgNetworkRelationField HREF = QueryVAppOrgNetworkRelationField.Get("href");
    public static QueryVAppOrgNetworkRelationField CONFIGURATIONTYPE = QueryVAppOrgNetworkRelationField.Get("configurationType");
    public static QueryVAppOrgNetworkRelationField NAME = QueryVAppOrgNetworkRelationField.Get("name");
    public static QueryVAppOrgNetworkRelationField ORG = QueryVAppOrgNetworkRelationField.Get("org");
    public static QueryVAppOrgNetworkRelationField ORGNETWORK = QueryVAppOrgNetworkRelationField.Get("orgNetwork");
    public static QueryVAppOrgNetworkRelationField ORGNETWORKNAME = QueryVAppOrgNetworkRelationField.Get("orgNetworkName");
    public static QueryVAppOrgNetworkRelationField OWNER = QueryVAppOrgNetworkRelationField.Get("owner");
    public static QueryVAppOrgNetworkRelationField STATUS = QueryVAppOrgNetworkRelationField.Get("status");
    private string _value;

    private static QueryVAppOrgNetworkRelationField Get(string str)
    {
      return new QueryVAppOrgNetworkRelationField(str);
    }

    private QueryVAppOrgNetworkRelationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVAppOrgNetworkRelationField> Values()
    {
      QueryVAppOrgNetworkRelationField networkRelationField = new QueryVAppOrgNetworkRelationField();
      List<QueryVAppOrgNetworkRelationField> networkRelationFieldList = new List<QueryVAppOrgNetworkRelationField>();
      foreach (FieldInfo field in networkRelationField.GetType().GetFields())
        networkRelationFieldList.Add((QueryVAppOrgNetworkRelationField) field.GetValue((object) networkRelationField));
      return networkRelationFieldList;
    }

    public static QueryVAppOrgNetworkRelationField FromValue(
      string value)
    {
      foreach (QueryVAppOrgNetworkRelationField networkRelationField in QueryVAppOrgNetworkRelationField.Values())
      {
        if (networkRelationField.Value().Equals(value))
          return networkRelationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
