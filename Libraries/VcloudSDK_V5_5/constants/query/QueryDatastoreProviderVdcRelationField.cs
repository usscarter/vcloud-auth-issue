// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryDatastoreProviderVdcRelationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryDatastoreProviderVdcRelationField : QueryField
  {
    public static QueryDatastoreProviderVdcRelationField ID = QueryDatastoreProviderVdcRelationField.Get("id");
    public static QueryDatastoreProviderVdcRelationField HREF = QueryDatastoreProviderVdcRelationField.Get("href");
    public static QueryDatastoreProviderVdcRelationField DATASTORE = QueryDatastoreProviderVdcRelationField.Get("datastore");
    public static QueryDatastoreProviderVdcRelationField DATASTORETYPE = QueryDatastoreProviderVdcRelationField.Get("datastoreType");
    public static QueryDatastoreProviderVdcRelationField ISDELETED = QueryDatastoreProviderVdcRelationField.Get("isDeleted");
    public static QueryDatastoreProviderVdcRelationField ISENABLED = QueryDatastoreProviderVdcRelationField.Get("isEnabled");
    public static QueryDatastoreProviderVdcRelationField MOREF = QueryDatastoreProviderVdcRelationField.Get("moref");
    public static QueryDatastoreProviderVdcRelationField NAME = QueryDatastoreProviderVdcRelationField.Get("name");
    public static QueryDatastoreProviderVdcRelationField PROVIDERVDC = QueryDatastoreProviderVdcRelationField.Get("providerVdc");
    public static QueryDatastoreProviderVdcRelationField REQUESTEDSTORAGEMB = QueryDatastoreProviderVdcRelationField.Get("requestedStorageMB");
    public static QueryDatastoreProviderVdcRelationField STORAGEMB = QueryDatastoreProviderVdcRelationField.Get("storageMB");
    public static QueryDatastoreProviderVdcRelationField STORAGEUSEDMB = QueryDatastoreProviderVdcRelationField.Get("storageUsedMB");
    public static QueryDatastoreProviderVdcRelationField VC = QueryDatastoreProviderVdcRelationField.Get("vc");
    public static QueryDatastoreProviderVdcRelationField VCNAME = QueryDatastoreProviderVdcRelationField.Get("vcName");
    private string _value;

    private static QueryDatastoreProviderVdcRelationField Get(
      string str)
    {
      return new QueryDatastoreProviderVdcRelationField(str);
    }

    private QueryDatastoreProviderVdcRelationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryDatastoreProviderVdcRelationField> Values()
    {
      QueryDatastoreProviderVdcRelationField vdcRelationField = new QueryDatastoreProviderVdcRelationField();
      List<QueryDatastoreProviderVdcRelationField> vdcRelationFieldList = new List<QueryDatastoreProviderVdcRelationField>();
      foreach (FieldInfo field in vdcRelationField.GetType().GetFields())
        vdcRelationFieldList.Add((QueryDatastoreProviderVdcRelationField) field.GetValue((object) vdcRelationField));
      return vdcRelationFieldList;
    }

    public static QueryDatastoreProviderVdcRelationField FromValue(
      string value)
    {
      foreach (QueryDatastoreProviderVdcRelationField vdcRelationField in QueryDatastoreProviderVdcRelationField.Values())
      {
        if (vdcRelationField.Value().Equals(value))
          return vdcRelationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
