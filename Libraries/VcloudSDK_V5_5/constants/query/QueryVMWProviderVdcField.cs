// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVMWProviderVdcField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVMWProviderVdcField : QueryField
  {
    public static QueryVMWProviderVdcField ID = QueryVMWProviderVdcField.Get("id");
    public static QueryVMWProviderVdcField HREF = QueryVMWProviderVdcField.Get("href");
    public static QueryVMWProviderVdcField CPUALLOCATIONMHZ = QueryVMWProviderVdcField.Get("cpuAllocationMhz");
    public static QueryVMWProviderVdcField CPULIMITMHZ = QueryVMWProviderVdcField.Get("cpuLimitMhz");
    public static QueryVMWProviderVdcField CPUOVERHEADMHZ = QueryVMWProviderVdcField.Get("cpuOverheadMhz");
    public static QueryVMWProviderVdcField CPUUSEDMHZ = QueryVMWProviderVdcField.Get("cpuUsedMhz");
    public static QueryVMWProviderVdcField CREATIONSTATUS = QueryVMWProviderVdcField.Get("creationStatus");
    public static QueryVMWProviderVdcField ISDELETED = QueryVMWProviderVdcField.Get("isDeleted");
    public static QueryVMWProviderVdcField ISENABLED = QueryVMWProviderVdcField.Get("isEnabled");
    public static QueryVMWProviderVdcField ISBUSY = QueryVMWProviderVdcField.Get("isBusy");
    public static QueryVMWProviderVdcField ISVCENABLED = QueryVMWProviderVdcField.Get("isVCEnabled");
    public static QueryVMWProviderVdcField MEMORYALLOCATIONMB = QueryVMWProviderVdcField.Get("memoryAllocationMB");
    public static QueryVMWProviderVdcField MEMORYOVERHEADMB = QueryVMWProviderVdcField.Get("memoryOverheadMB");
    public static QueryVMWProviderVdcField MEMORYUSEDMB = QueryVMWProviderVdcField.Get("memoryUsedMB");
    public static QueryVMWProviderVdcField NAME = QueryVMWProviderVdcField.Get("name");
    public static QueryVMWProviderVdcField NUMBEROFDATASTORES = QueryVMWProviderVdcField.Get("numberOfDatastores");
    public static QueryVMWProviderVdcField NUMBEROFSTORAGEPROFILES = QueryVMWProviderVdcField.Get("numberOfStorageProfiles");
    public static QueryVMWProviderVdcField NUMBEROFORGVDCS = QueryVMWProviderVdcField.Get("numberOfOrgVdcs");
    public static QueryVMWProviderVdcField RESOURCEPOOL = QueryVMWProviderVdcField.Get("resourcePool");
    public static QueryVMWProviderVdcField STORAGEALLOCATIONMB = QueryVMWProviderVdcField.Get("storageAllocationMB");
    public static QueryVMWProviderVdcField STORAGEOVERHEADMB = QueryVMWProviderVdcField.Get("storageOverheadMB");
    public static QueryVMWProviderVdcField STORAGELIMITMB = QueryVMWProviderVdcField.Get("storageLimitMB");
    public static QueryVMWProviderVdcField STORAGEUSEDMB = QueryVMWProviderVdcField.Get("storageUsedMB");
    public static QueryVMWProviderVdcField VCPURATINGMHZ = QueryVMWProviderVdcField.Get("vcpuRatingMhz");
    public static QueryVMWProviderVdcField VIRTUALCENTERNAME = QueryVMWProviderVdcField.Get("virtualCenterName");
    private string _value;

    private static QueryVMWProviderVdcField Get(string str)
    {
      return new QueryVMWProviderVdcField(str);
    }

    private QueryVMWProviderVdcField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVMWProviderVdcField> Values()
    {
      QueryVMWProviderVdcField providerVdcField = new QueryVMWProviderVdcField();
      List<QueryVMWProviderVdcField> providerVdcFieldList = new List<QueryVMWProviderVdcField>();
      foreach (FieldInfo field in providerVdcField.GetType().GetFields())
        providerVdcFieldList.Add((QueryVMWProviderVdcField) field.GetValue((object) providerVdcField));
      return providerVdcFieldList;
    }

    public static QueryVMWProviderVdcField FromValue(string value)
    {
      foreach (QueryVMWProviderVdcField providerVdcField in QueryVMWProviderVdcField.Values())
      {
        if (providerVdcField.Value().Equals(value))
          return providerVdcField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
