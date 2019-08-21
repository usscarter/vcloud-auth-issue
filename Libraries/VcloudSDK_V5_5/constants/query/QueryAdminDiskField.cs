// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminDiskField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminDiskField : QueryField
  {
    public static QueryAdminDiskField ID = QueryAdminDiskField.Get("id");
    public static QueryAdminDiskField HREF = QueryAdminDiskField.Get("href");
    public static QueryAdminDiskField BUSSUBTYPE = QueryAdminDiskField.Get("busSubType");
    public static QueryAdminDiskField BUSTYPE = QueryAdminDiskField.Get("busType");
    public static QueryAdminDiskField BUSTYPEDESC = QueryAdminDiskField.Get("busTypeDesc");
    public static QueryAdminDiskField DATASTORE = QueryAdminDiskField.Get("datastore");
    public static QueryAdminDiskField DATASTORENAME = QueryAdminDiskField.Get("datastoreName");
    public static QueryAdminDiskField ISATTACHED = QueryAdminDiskField.Get("isAttached");
    public static QueryAdminDiskField NAME = QueryAdminDiskField.Get("name");
    public static QueryAdminDiskField ORG = QueryAdminDiskField.Get("org");
    public static QueryAdminDiskField OWNERNAME = QueryAdminDiskField.Get("ownerName");
    public static QueryAdminDiskField SIZEB = QueryAdminDiskField.Get("sizeB");
    public static QueryAdminDiskField STATUS = QueryAdminDiskField.Get("status");
    public static QueryAdminDiskField STORAGEPROFILE = QueryAdminDiskField.Get("storageProfile");
    public static QueryAdminDiskField STORAGEPROFILENAME = QueryAdminDiskField.Get("storageProfileName");
    public static QueryAdminDiskField TASK = QueryAdminDiskField.Get("task");
    public static QueryAdminDiskField VC = QueryAdminDiskField.Get("vc");
    public static QueryAdminDiskField VDC = QueryAdminDiskField.Get("vdc");
    public static QueryAdminDiskField VDCNAME = QueryAdminDiskField.Get("vdcName");
    private string _value;

    private static QueryAdminDiskField Get(string str)
    {
      return new QueryAdminDiskField(str);
    }

    private QueryAdminDiskField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminDiskField> Values()
    {
      QueryAdminDiskField queryAdminDiskField = new QueryAdminDiskField();
      List<QueryAdminDiskField> queryAdminDiskFieldList = new List<QueryAdminDiskField>();
      foreach (FieldInfo field in queryAdminDiskField.GetType().GetFields())
        queryAdminDiskFieldList.Add((QueryAdminDiskField) field.GetValue((object) queryAdminDiskField));
      return queryAdminDiskFieldList;
    }

    public static QueryAdminDiskField FromValue(string value)
    {
      foreach (QueryAdminDiskField queryAdminDiskField in QueryAdminDiskField.Values())
      {
        if (queryAdminDiskField.Value().Equals(value))
          return queryAdminDiskField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
