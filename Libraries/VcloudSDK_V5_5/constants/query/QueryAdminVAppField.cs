// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminVAppField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminVAppField : QueryField
  {
    public static QueryAdminVAppField ID = QueryAdminVAppField.Get("id");
    public static QueryAdminVAppField HREF = QueryAdminVAppField.Get("href");
    [Obsolete("This property is deprecated  since API 5.1 and SDK 5.1")]
    public static QueryAdminVAppField CPUALLOCATIONMHZ = QueryAdminVAppField.Get("cpuAllocationMhz");
    public static QueryAdminVAppField CREATIONDATE = QueryAdminVAppField.Get("creationDate");
    public static QueryAdminVAppField ISBUSY = QueryAdminVAppField.Get("isBusy");
    public static QueryAdminVAppField ISDEPLOYED = QueryAdminVAppField.Get("isDeployed");
    public static QueryAdminVAppField ISENABLED = QueryAdminVAppField.Get("isEnabled");
    public static QueryAdminVAppField ISEXPIRED = QueryAdminVAppField.Get("isExpired");
    public static QueryAdminVAppField ISINMAINTENANCEMODE = QueryAdminVAppField.Get("isInMaintenanceMode");
    public static QueryAdminVAppField ISVDCENABLED = QueryAdminVAppField.Get("isVdcEnabled");
    public static QueryAdminVAppField MEMORYALLOCATIONMB = QueryAdminVAppField.Get("memoryAllocationMB");
    public static QueryAdminVAppField NAME = QueryAdminVAppField.Get("name");
    public static QueryAdminVAppField NUMBEROFVMS = QueryAdminVAppField.Get("numberOfVMs");
    public static QueryAdminVAppField ORG = QueryAdminVAppField.Get("org");
    public static QueryAdminVAppField OWNERNAME = QueryAdminVAppField.Get("ownerName");
    public static QueryAdminVAppField VDC = QueryAdminVAppField.Get("vdc");
    public static QueryAdminVAppField VDCNAME = QueryAdminVAppField.Get("vdcName");
    public static QueryAdminVAppField STORAGEKB = QueryAdminVAppField.Get("storageKB");
    public static QueryAdminVAppField STATUS = QueryAdminVAppField.Get("status");
    private string _value;

    private static QueryAdminVAppField Get(string str)
    {
      return new QueryAdminVAppField(str);
    }

    private QueryAdminVAppField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminVAppField> Values()
    {
      QueryAdminVAppField queryAdminVappField = new QueryAdminVAppField();
      List<QueryAdminVAppField> queryAdminVappFieldList = new List<QueryAdminVAppField>();
      foreach (FieldInfo field in queryAdminVappField.GetType().GetFields())
        queryAdminVappFieldList.Add((QueryAdminVAppField) field.GetValue((object) queryAdminVappField));
      return queryAdminVappFieldList;
    }

    public static QueryAdminVAppField FromValue(string value)
    {
      foreach (QueryAdminVAppField queryAdminVappField in QueryAdminVAppField.Values())
      {
        if (queryAdminVappField.Value().Equals(value))
          return queryAdminVappField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
