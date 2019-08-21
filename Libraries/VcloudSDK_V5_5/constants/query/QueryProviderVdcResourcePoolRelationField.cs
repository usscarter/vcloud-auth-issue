// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryProviderVdcResourcePoolRelationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryProviderVdcResourcePoolRelationField : QueryField
  {
    public static QueryProviderVdcResourcePoolRelationField ID = QueryProviderVdcResourcePoolRelationField.Get("id");
    public static QueryProviderVdcResourcePoolRelationField HREF = QueryProviderVdcResourcePoolRelationField.Get("href");
    public static QueryProviderVdcResourcePoolRelationField CPURESERVATIONALLOCATIONMHZ = QueryProviderVdcResourcePoolRelationField.Get("cpuReservationAllocationMhz");
    public static QueryProviderVdcResourcePoolRelationField CPURESERVATIONLIMITMHZ = QueryProviderVdcResourcePoolRelationField.Get("cpuReservationLimitMhz");
    public static QueryProviderVdcResourcePoolRelationField ISENABLED = QueryProviderVdcResourcePoolRelationField.Get("isEnabled");
    public static QueryProviderVdcResourcePoolRelationField ISPRIMARY = QueryProviderVdcResourcePoolRelationField.Get("isPrimary");
    public static QueryProviderVdcResourcePoolRelationField MEMORYRESERVATIONALLOCATIONMB = QueryProviderVdcResourcePoolRelationField.Get("memoryReservationAllocationMB");
    public static QueryProviderVdcResourcePoolRelationField MEMORYRESERVATIONLIMITMB = QueryProviderVdcResourcePoolRelationField.Get("memoryReservationLimitMB");
    public static QueryProviderVdcResourcePoolRelationField NAME = QueryProviderVdcResourcePoolRelationField.Get("name");
    public static QueryProviderVdcResourcePoolRelationField NUMBEROFVMS = QueryProviderVdcResourcePoolRelationField.Get("numberOfVMs");
    public static QueryProviderVdcResourcePoolRelationField PROVIDERVDC = QueryProviderVdcResourcePoolRelationField.Get("providerVdc");
    public static QueryProviderVdcResourcePoolRelationField RESOURCEPOOLMOREF = QueryProviderVdcResourcePoolRelationField.Get("resourcePoolMoref");
    public static QueryProviderVdcResourcePoolRelationField VC = QueryProviderVdcResourcePoolRelationField.Get("vc");
    public static QueryProviderVdcResourcePoolRelationField VCNAME = QueryProviderVdcResourcePoolRelationField.Get("vcName");
    private string _value;

    private static QueryProviderVdcResourcePoolRelationField Get(
      string str)
    {
      return new QueryProviderVdcResourcePoolRelationField(str);
    }

    private QueryProviderVdcResourcePoolRelationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryProviderVdcResourcePoolRelationField> Values()
    {
      QueryProviderVdcResourcePoolRelationField poolRelationField = new QueryProviderVdcResourcePoolRelationField();
      List<QueryProviderVdcResourcePoolRelationField> poolRelationFieldList = new List<QueryProviderVdcResourcePoolRelationField>();
      foreach (FieldInfo field in poolRelationField.GetType().GetFields())
        poolRelationFieldList.Add((QueryProviderVdcResourcePoolRelationField) field.GetValue((object) poolRelationField));
      return poolRelationFieldList;
    }

    public static QueryProviderVdcResourcePoolRelationField FromValue(
      string value)
    {
      foreach (QueryProviderVdcResourcePoolRelationField poolRelationField in QueryProviderVdcResourcePoolRelationField.Values())
      {
        if (poolRelationField.Value().Equals(value))
          return poolRelationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
