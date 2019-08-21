// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryProviderVdcStorageProfileField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryProviderVdcStorageProfileField : QueryField
  {
    public static QueryProviderVdcStorageProfileField ID = QueryProviderVdcStorageProfileField.Get("id");
    public static QueryProviderVdcStorageProfileField HREF = QueryProviderVdcStorageProfileField.Get("href");
    public static QueryProviderVdcStorageProfileField ISENABLED = QueryProviderVdcStorageProfileField.Get("isEnabled");
    public static QueryProviderVdcStorageProfileField NAME = QueryProviderVdcStorageProfileField.Get("name");
    public static QueryProviderVdcStorageProfileField NUMBEROFCONDITIONS = QueryProviderVdcStorageProfileField.Get("numberOfConditions");
    public static QueryProviderVdcStorageProfileField PROVIDERVDC = QueryProviderVdcStorageProfileField.Get("providerVdc");
    public static QueryProviderVdcStorageProfileField STORAGEPROFILEMOREF = QueryProviderVdcStorageProfileField.Get("storageProfileMoref");
    public static QueryProviderVdcStorageProfileField STORAGEPROVISIONEDMB = QueryProviderVdcStorageProfileField.Get("storageProvisionedMB");
    public static QueryProviderVdcStorageProfileField STORAGEREQUESTEDMB = QueryProviderVdcStorageProfileField.Get("storageRequestedMB");
    public static QueryProviderVdcStorageProfileField STORAGETOTALMB = QueryProviderVdcStorageProfileField.Get("storageTotalMB");
    public static QueryProviderVdcStorageProfileField STORAGEUSEDMB = QueryProviderVdcStorageProfileField.Get("storageUsedMB");
    public static QueryProviderVdcStorageProfileField VC = QueryProviderVdcStorageProfileField.Get("vc");
    private string _value;

    private static QueryProviderVdcStorageProfileField Get(
      string str)
    {
      return new QueryProviderVdcStorageProfileField(str);
    }

    private QueryProviderVdcStorageProfileField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryProviderVdcStorageProfileField> Values()
    {
      QueryProviderVdcStorageProfileField storageProfileField = new QueryProviderVdcStorageProfileField();
      List<QueryProviderVdcStorageProfileField> storageProfileFieldList = new List<QueryProviderVdcStorageProfileField>();
      foreach (FieldInfo field in storageProfileField.GetType().GetFields())
        storageProfileFieldList.Add((QueryProviderVdcStorageProfileField) field.GetValue((object) storageProfileField));
      return storageProfileFieldList;
    }

    public static QueryProviderVdcStorageProfileField FromValue(
      string value)
    {
      foreach (QueryProviderVdcStorageProfileField storageProfileField in QueryProviderVdcStorageProfileField.Values())
      {
        if (storageProfileField.Value().Equals(value))
          return storageProfileField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
