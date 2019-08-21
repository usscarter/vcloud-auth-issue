// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminVdcField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminVdcField : QueryField
  {
    public static QueryAdminVdcField ID = QueryAdminVdcField.Get("id");
    public static QueryAdminVdcField HREF = QueryAdminVdcField.Get("href");
    public static QueryAdminVdcField CPUALLOCATIONMHZ = QueryAdminVdcField.Get("cpuAllocationMhz");
    public static QueryAdminVdcField CPULIMITMHZ = QueryAdminVdcField.Get("cpuLimitMhz");
    public static QueryAdminVdcField CPUUSEDMHZ = QueryAdminVdcField.Get("cpuUsedMhz");
    public static QueryAdminVdcField ISBUSY = QueryAdminVdcField.Get("isBusy");
    public static QueryAdminVdcField ISENABLED = QueryAdminVdcField.Get("isEnabled");
    [Obsolete("This property is deprecated  since API 5.1 and SDK 5.1")]
    public static QueryAdminVdcField ISSYSTEMVDC = QueryAdminVdcField.Get("isSystemVdc");
    public static QueryAdminVdcField MEMORYALLOCATIONMB = QueryAdminVdcField.Get("memoryAllocationMB");
    public static QueryAdminVdcField MEMORYLIMITMB = QueryAdminVdcField.Get("memoryLimitMB");
    public static QueryAdminVdcField MEMORYUSEDMB = QueryAdminVdcField.Get("memoryUsedMB");
    public static QueryAdminVdcField NAME = QueryAdminVdcField.Get("name");
    public static QueryAdminVdcField NUMBEROFDISKS = QueryAdminVdcField.Get("numberOfDisks");
    public static QueryAdminVdcField NETWORKPOOL = QueryAdminVdcField.Get("networkPool");
    public static QueryAdminVdcField NUMBEROFMEDIA = QueryAdminVdcField.Get("numberOfMedia");
    public static QueryAdminVdcField NUMBEROFSTORAGEPROFILES = QueryAdminVdcField.Get("numberOfStorageProfiles");
    public static QueryAdminVdcField NUMBEROFTEMPLATES = QueryAdminVdcField.Get("numberOfTemplates");
    public static QueryAdminVdcField NUMBEROFVAPPS = QueryAdminVdcField.Get("numberOfVApps");
    public static QueryAdminVdcField ORG = QueryAdminVdcField.Get("org");
    public static QueryAdminVdcField ORGNAME = QueryAdminVdcField.Get("orgName");
    public static QueryAdminVdcField PROVIDERVDC = QueryAdminVdcField.Get("providerVdc");
    public static QueryAdminVdcField PROVIDERVDCNAME = QueryAdminVdcField.Get("providerVdcName");
    public static QueryAdminVdcField STATUS = QueryAdminVdcField.Get("status");
    [Obsolete("This property is deprecated  since API 5.1 and SDK 5.1")]
    public static QueryAdminVdcField STORAGEALLOCATIONMB = QueryAdminVdcField.Get("storageAllocationMB");
    public static QueryAdminVdcField STORAGELIMITMB = QueryAdminVdcField.Get("storageLimitMB");
    public static QueryAdminVdcField STORAGEUSEDMB = QueryAdminVdcField.Get("storageUsedMB");
    private string _value;

    private static QueryAdminVdcField Get(string str)
    {
      return new QueryAdminVdcField(str);
    }

    private QueryAdminVdcField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminVdcField> Values()
    {
      QueryAdminVdcField queryAdminVdcField = new QueryAdminVdcField();
      List<QueryAdminVdcField> queryAdminVdcFieldList = new List<QueryAdminVdcField>();
      foreach (FieldInfo field in queryAdminVdcField.GetType().GetFields())
        queryAdminVdcFieldList.Add((QueryAdminVdcField) field.GetValue((object) queryAdminVdcField));
      return queryAdminVdcFieldList;
    }

    public static QueryAdminVdcField FromValue(string value)
    {
      foreach (QueryAdminVdcField queryAdminVdcField in QueryAdminVdcField.Values())
      {
        if (queryAdminVdcField.Value().Equals(value))
          return queryAdminVdcField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
