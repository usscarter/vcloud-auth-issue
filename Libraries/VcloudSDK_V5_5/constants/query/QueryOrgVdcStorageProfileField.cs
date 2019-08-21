// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryOrgVdcStorageProfileField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryOrgVdcStorageProfileField : QueryField
  {
    public static QueryOrgVdcStorageProfileField ID = QueryOrgVdcStorageProfileField.Get("id");
    public static QueryOrgVdcStorageProfileField HREF = QueryOrgVdcStorageProfileField.Get("href");
    public static QueryOrgVdcStorageProfileField ISDEFAULTSTORAGEPROFILE = QueryOrgVdcStorageProfileField.Get("isDefaultStorageProfile");
    public static QueryOrgVdcStorageProfileField ISENABLED = QueryOrgVdcStorageProfileField.Get("isEnabled");
    public static QueryOrgVdcStorageProfileField ISVDCBUSY = QueryOrgVdcStorageProfileField.Get("isVdcBusy");
    public static QueryOrgVdcStorageProfileField NAME = QueryOrgVdcStorageProfileField.Get("name");
    public static QueryOrgVdcStorageProfileField NUMBEROFCONDITIONS = QueryOrgVdcStorageProfileField.Get("numberOfConditions");
    public static QueryOrgVdcStorageProfileField STORAGELIMITMB = QueryOrgVdcStorageProfileField.Get("storageLimitMB");
    public static QueryOrgVdcStorageProfileField STORAGEUSEDMB = QueryOrgVdcStorageProfileField.Get("storageUsedMB");
    public static QueryOrgVdcStorageProfileField VDC = QueryOrgVdcStorageProfileField.Get("vdc");
    public static QueryOrgVdcStorageProfileField VDCNAME = QueryOrgVdcStorageProfileField.Get("vdcName");
    private string _value;

    private static QueryOrgVdcStorageProfileField Get(string str)
    {
      return new QueryOrgVdcStorageProfileField(str);
    }

    private QueryOrgVdcStorageProfileField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryOrgVdcStorageProfileField> Values()
    {
      QueryOrgVdcStorageProfileField storageProfileField = new QueryOrgVdcStorageProfileField();
      List<QueryOrgVdcStorageProfileField> storageProfileFieldList = new List<QueryOrgVdcStorageProfileField>();
      foreach (FieldInfo field in storageProfileField.GetType().GetFields())
        storageProfileFieldList.Add((QueryOrgVdcStorageProfileField) field.GetValue((object) storageProfileField));
      return storageProfileFieldList;
    }

    public static QueryOrgVdcStorageProfileField FromValue(
      string value)
    {
      foreach (QueryOrgVdcStorageProfileField storageProfileField in QueryOrgVdcStorageProfileField.Values())
      {
        if (storageProfileField.Value().Equals(value))
          return storageProfileField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
