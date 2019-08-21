// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryOrgVdcResourcePoolRelationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryOrgVdcResourcePoolRelationField : QueryField
  {
    public static QueryOrgVdcResourcePoolRelationField ID = QueryOrgVdcResourcePoolRelationField.Get("id");
    public static QueryOrgVdcResourcePoolRelationField HREF = QueryOrgVdcResourcePoolRelationField.Get("href");
    public static QueryOrgVdcResourcePoolRelationField RESOURCEPOOLMOREF = QueryOrgVdcResourcePoolRelationField.Get("resourcePoolMoref");
    public static QueryOrgVdcResourcePoolRelationField VC = QueryOrgVdcResourcePoolRelationField.Get("vc");
    public static QueryOrgVdcResourcePoolRelationField VDC = QueryOrgVdcResourcePoolRelationField.Get("vdc");
    private string _value;

    private static QueryOrgVdcResourcePoolRelationField Get(
      string str)
    {
      return new QueryOrgVdcResourcePoolRelationField(str);
    }

    private QueryOrgVdcResourcePoolRelationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryOrgVdcResourcePoolRelationField> Values()
    {
      QueryOrgVdcResourcePoolRelationField poolRelationField = new QueryOrgVdcResourcePoolRelationField();
      List<QueryOrgVdcResourcePoolRelationField> poolRelationFieldList = new List<QueryOrgVdcResourcePoolRelationField>();
      foreach (FieldInfo field in poolRelationField.GetType().GetFields())
        poolRelationFieldList.Add((QueryOrgVdcResourcePoolRelationField) field.GetValue((object) poolRelationField));
      return poolRelationFieldList;
    }

    public static QueryOrgVdcResourcePoolRelationField FromValue(
      string value)
    {
      foreach (QueryOrgVdcResourcePoolRelationField poolRelationField in QueryOrgVdcResourcePoolRelationField.Values())
      {
        if (poolRelationField.Value().Equals(value))
          return poolRelationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
