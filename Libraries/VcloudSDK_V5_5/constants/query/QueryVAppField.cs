// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVAppField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVAppField : QueryField
  {
    public static QueryVAppField ID = QueryVAppField.Get("id");
    public static QueryVAppField HREF = QueryVAppField.Get("href");
    public static QueryVAppField AUTODELETEDATE = QueryVAppField.Get("autoDeleteDate");
    public static QueryVAppField AUTOUNDEPLOYDATE = QueryVAppField.Get("autoUndeployDate");
    public static QueryVAppField MUSTBEFENCED = QueryVAppField.Get("mustBeFenced");
    public static QueryVAppField NUMBERVMS = QueryVAppField.Get("numberVms");
    public static QueryVAppField MEMORYALLOCATIONMB = QueryVAppField.Get("memoryAllocationMB");
    public static QueryVAppField CPUALLOCATIONMHZ = QueryVAppField.Get("cpuAllocationMhz");
    public static QueryVAppField DATECREATED = QueryVAppField.Get("dateCreated");
    public static QueryVAppField ISDEPLOYED = QueryVAppField.Get("isDeployed");
    public static QueryVAppField ENTITYSTATUS = QueryVAppField.Get("entityStatus");
    public static QueryVAppField ISENABLED = QueryVAppField.Get("isEnabled");
    public static QueryVAppField ISEXPIRED = QueryVAppField.Get("isExpired");
    public static QueryVAppField ISBUSY = QueryVAppField.Get("isBusy");
    public static QueryVAppField ISGOLDMASTER = QueryVAppField.Get("isGoldMaster");
    public static QueryVAppField ISINMAINTENANCEMODE = QueryVAppField.Get("isInMaintenanceMode");
    public static QueryVAppField ISPUBLIC = QueryVAppField.Get("isPublic");
    public static QueryVAppField NAME = QueryVAppField.Get("name");
    public static QueryVAppField ORGVDCNAME = QueryVAppField.Get("orgVdcName");
    public static QueryVAppField OWNERNAME = QueryVAppField.Get("ownerName");
    public static QueryVAppField SIZEKB = QueryVAppField.Get("sizeKB");
    public static QueryVAppField VDC = QueryVAppField.Get("vdc");
    private string _value;

    private static QueryVAppField Get(string str)
    {
      return new QueryVAppField(str);
    }

    private QueryVAppField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVAppField> Values()
    {
      QueryVAppField queryVappField = new QueryVAppField();
      List<QueryVAppField> queryVappFieldList = new List<QueryVAppField>();
      foreach (FieldInfo field in queryVappField.GetType().GetFields())
        queryVappFieldList.Add((QueryVAppField) field.GetValue((object) queryVappField));
      return queryVappFieldList;
    }

    public static QueryVAppField FromValue(string value)
    {
      foreach (QueryVAppField queryVappField in QueryVAppField.Values())
      {
        if (queryVappField.Value().Equals(value))
          return queryVappField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
