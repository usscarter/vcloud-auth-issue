// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryDatastoreField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryDatastoreField : QueryField
  {
    public static QueryDatastoreField ID = QueryDatastoreField.Get("id");
    public static QueryDatastoreField HREF = QueryDatastoreField.Get("href");
    public static QueryDatastoreField DATASTORETYPE = QueryDatastoreField.Get("datastoreType");
    public static QueryDatastoreField ISDELETED = QueryDatastoreField.Get("isDeleted");
    public static QueryDatastoreField ISENABLED = QueryDatastoreField.Get("isEnabled");
    public static QueryDatastoreField MOREF = QueryDatastoreField.Get("moref");
    public static QueryDatastoreField NAME = QueryDatastoreField.Get("name");
    public static QueryDatastoreField NUMBEROFPROVIDERVDCS = QueryDatastoreField.Get("numberOfProviderVdcs");
    public static QueryDatastoreField PROVISIONEDSTORAGEMB = QueryDatastoreField.Get("provisionedStorageMB");
    public static QueryDatastoreField REQUESTEDSTORAGEMB = QueryDatastoreField.Get("requestedStorageMB");
    public static QueryDatastoreField STORAGEMB = QueryDatastoreField.Get("storageMB");
    public static QueryDatastoreField STORAGEUSEDMB = QueryDatastoreField.Get("storageUsedMB");
    public static QueryDatastoreField VC = QueryDatastoreField.Get("vc");
    public static QueryDatastoreField VCNAME = QueryDatastoreField.Get("vcName");
    private string _value;

    private static QueryDatastoreField Get(string str)
    {
      return new QueryDatastoreField(str);
    }

    private QueryDatastoreField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryDatastoreField> Values()
    {
      QueryDatastoreField queryDatastoreField = new QueryDatastoreField();
      List<QueryDatastoreField> queryDatastoreFieldList = new List<QueryDatastoreField>();
      foreach (FieldInfo field in queryDatastoreField.GetType().GetFields())
        queryDatastoreFieldList.Add((QueryDatastoreField) field.GetValue((object) queryDatastoreField));
      return queryDatastoreFieldList;
    }

    public static QueryDatastoreField FromValue(string value)
    {
      foreach (QueryDatastoreField queryDatastoreField in QueryDatastoreField.Values())
      {
        if (queryDatastoreField.Value().Equals(value))
          return queryDatastoreField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
