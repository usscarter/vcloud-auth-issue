// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminOrgVdcStorageProfileField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminOrgVdcStorageProfileField : QueryField
  {
    public static QueryAdminOrgVdcStorageProfileField ID = QueryAdminOrgVdcStorageProfileField.Get("id");
    public static QueryAdminOrgVdcStorageProfileField HREF = QueryAdminOrgVdcStorageProfileField.Get("id");
    public static QueryAdminOrgVdcStorageProfileField ISDEFAULTSTORAGEPROFILE = QueryAdminOrgVdcStorageProfileField.Get("isDefaultStorageProfile");
    public static QueryAdminOrgVdcStorageProfileField ISENABLED = QueryAdminOrgVdcStorageProfileField.Get("isEnabled");
    public static QueryAdminOrgVdcStorageProfileField NAME = QueryAdminOrgVdcStorageProfileField.Get("name");
    public static QueryAdminOrgVdcStorageProfileField NUMBEROFCONDITIONS = QueryAdminOrgVdcStorageProfileField.Get("numberOfConditions");
    public static QueryAdminOrgVdcStorageProfileField ORG = QueryAdminOrgVdcStorageProfileField.Get("org");
    public static QueryAdminOrgVdcStorageProfileField STORAGELIMITMB = QueryAdminOrgVdcStorageProfileField.Get("storageLimitMB");
    public static QueryAdminOrgVdcStorageProfileField STORAGEPROFILEMOREF = QueryAdminOrgVdcStorageProfileField.Get("storageProfileMoref");
    public static QueryAdminOrgVdcStorageProfileField STORAGEUSEDMB = QueryAdminOrgVdcStorageProfileField.Get("storageUsedMB");
    public static QueryAdminOrgVdcStorageProfileField VC = QueryAdminOrgVdcStorageProfileField.Get("vc");
    public static QueryAdminOrgVdcStorageProfileField VDC = QueryAdminOrgVdcStorageProfileField.Get("vdc");
    public static QueryAdminOrgVdcStorageProfileField VDCNAME = QueryAdminOrgVdcStorageProfileField.Get("vdcName");
    private string _value;

    private static QueryAdminOrgVdcStorageProfileField Get(
      string str)
    {
      return new QueryAdminOrgVdcStorageProfileField(str);
    }

    private QueryAdminOrgVdcStorageProfileField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminOrgVdcStorageProfileField> Values()
    {
      QueryAdminOrgVdcStorageProfileField storageProfileField = new QueryAdminOrgVdcStorageProfileField();
      List<QueryAdminOrgVdcStorageProfileField> storageProfileFieldList = new List<QueryAdminOrgVdcStorageProfileField>();
      foreach (FieldInfo field in storageProfileField.GetType().GetFields())
        storageProfileFieldList.Add((QueryAdminOrgVdcStorageProfileField) field.GetValue((object) storageProfileField));
      return storageProfileFieldList;
    }

    public static QueryAdminOrgVdcStorageProfileField FromValue(
      string value)
    {
      foreach (QueryAdminOrgVdcStorageProfileField storageProfileField in QueryAdminOrgVdcStorageProfileField.Values())
      {
        if (storageProfileField.Value().Equals(value))
          return storageProfileField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
