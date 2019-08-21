// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryOrgVdcField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryOrgVdcField : QueryField
  {
    public static QueryOrgVdcField ID = QueryOrgVdcField.Get("id");
    public static QueryOrgVdcField HREF = QueryOrgVdcField.Get("href");
    public static QueryOrgVdcField ALLOCATIONMODEL = QueryOrgVdcField.Get("allocationModel");
    public static QueryOrgVdcField CPUALLOCATIONMHZ = QueryOrgVdcField.Get("cpuAllocationMhz");
    public static QueryOrgVdcField CPULIMITMHZ = QueryOrgVdcField.Get("cpuLimitMhz");
    public static QueryOrgVdcField CPUOVERHEADMHZ = QueryOrgVdcField.Get("cpuOverheadMhz");
    public static QueryOrgVdcField CPUUSEDMHZ = QueryOrgVdcField.Get("cpuUsedMhz");
    public static QueryOrgVdcField CREATIONSTATUS = QueryOrgVdcField.Get("creationStatus");
    public static QueryOrgVdcField DATASTORES = QueryOrgVdcField.Get("datastores");
    public static QueryOrgVdcField ISBUSY = QueryOrgVdcField.Get("isBusy");
    public static QueryOrgVdcField ISENABLED = QueryOrgVdcField.Get("isEnabled");
    public static QueryOrgVdcField MEMORYALLOCATIONMB = QueryOrgVdcField.Get("memoryAllocationMB");
    public static QueryOrgVdcField MEMORYLIMITMB = QueryOrgVdcField.Get("memoryLimitMB");
    public static QueryOrgVdcField MEMORYOVERHEADMB = QueryOrgVdcField.Get("memoryOverheadMB");
    public static QueryOrgVdcField MEMORYUSEDMB = QueryOrgVdcField.Get("memoryUsedMB");
    public static QueryOrgVdcField NAME = QueryOrgVdcField.Get("name");
    public static QueryOrgVdcField NETWORKPOOL = QueryOrgVdcField.Get("networkPool");
    public static QueryOrgVdcField NUMBEROFMEDIA = QueryOrgVdcField.Get("numberOfMedia");
    public static QueryOrgVdcField NUMBEROFSTORAGEPROFILES = QueryOrgVdcField.Get("numberOfStorageProfiles");
    public static QueryOrgVdcField NUMBEROFTEMPLATES = QueryOrgVdcField.Get("numberOfTemplates");
    public static QueryOrgVdcField NUMBEROFVAPPS = QueryOrgVdcField.Get("numberOfVApps");
    public static QueryOrgVdcField ORG = QueryOrgVdcField.Get("org");
    public static QueryOrgVdcField PROVIDERVDC = QueryOrgVdcField.Get("providerVdc");
    public static QueryOrgVdcField PROVIDERVDCNAME = QueryOrgVdcField.Get("providerVdcName");
    public static QueryOrgVdcField RESOURCEPOOL = QueryOrgVdcField.Get("resourcePool");
    [Obsolete("This property is deprecated  since API 5.1 and SDK 5.1")]
    public static QueryOrgVdcField STORAGEALLOCATIONMB = QueryOrgVdcField.Get("storageAllocationMB");
    public static QueryOrgVdcField STORAGELIMITMB = QueryOrgVdcField.Get("storageLimitMB");
    public static QueryOrgVdcField STORAGEOVERHEADMB = QueryOrgVdcField.Get("storageOverheadMB");
    public static QueryOrgVdcField STORAGEUSEDMB = QueryOrgVdcField.Get("storageUsedMB");
    [Obsolete("This property is deprecated  since API 5.1 and SDK 5.1")]
    public static QueryOrgVdcField ISSYSTEMVDC = QueryOrgVdcField.Get("isSystemVdc");
    public static QueryOrgVdcField VIRTUALCENTERNAME = QueryOrgVdcField.Get("virtualCenterName");
    public static QueryOrgVdcField NUMBEROFDISKS = QueryOrgVdcField.Get("numberOfDisks");
    private string _value;

    private static QueryOrgVdcField Get(string str)
    {
      return new QueryOrgVdcField(str);
    }

    private QueryOrgVdcField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryOrgVdcField> Values()
    {
      QueryOrgVdcField queryOrgVdcField = new QueryOrgVdcField();
      List<QueryOrgVdcField> queryOrgVdcFieldList = new List<QueryOrgVdcField>();
      foreach (FieldInfo field in queryOrgVdcField.GetType().GetFields())
        queryOrgVdcFieldList.Add((QueryOrgVdcField) field.GetValue((object) queryOrgVdcField));
      return queryOrgVdcFieldList;
    }

    public static QueryOrgVdcField FromValue(string value)
    {
      foreach (QueryOrgVdcField queryOrgVdcField in QueryOrgVdcField.Values())
      {
        if (queryOrgVdcField.Value().Equals(value))
          return queryOrgVdcField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
