// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryDiskField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryDiskField : QueryField
  {
    public static QueryDiskField ID = QueryDiskField.Get("id");
    public static QueryDiskField HREF = QueryDiskField.Get("href");
    public static QueryDiskField BUSSUBTYPE = QueryDiskField.Get("busSubType");
    public static QueryDiskField BUSTYPE = QueryDiskField.Get("busType");
    public static QueryDiskField BUSTYPEDESC = QueryDiskField.Get("busTypeDesc");
    public static QueryDiskField DATASTORE = QueryDiskField.Get("datastore");
    public static QueryDiskField DATASTORENAME = QueryDiskField.Get("datastoreName");
    public static QueryDiskField ISATTACHED = QueryDiskField.Get("isAttached");
    public static QueryDiskField NAME = QueryDiskField.Get("name");
    public static QueryDiskField OWNERNAME = QueryDiskField.Get("ownerName");
    public static QueryDiskField SIZEB = QueryDiskField.Get("sizeB");
    public static QueryDiskField STATUS = QueryDiskField.Get("status");
    public static QueryDiskField STORAGEPROFILE = QueryDiskField.Get("storageProfile");
    public static QueryDiskField STORAGEPROFILENAME = QueryDiskField.Get("storageProfileName");
    public static QueryDiskField TASK = QueryDiskField.Get("task");
    public static QueryDiskField VDC = QueryDiskField.Get("vdc");
    public static QueryDiskField VDCNAME = QueryDiskField.Get("vdcName");
    private string _value;

    private static QueryDiskField Get(string str)
    {
      return new QueryDiskField(str);
    }

    private QueryDiskField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryDiskField> Values()
    {
      QueryDiskField queryDiskField = new QueryDiskField();
      List<QueryDiskField> queryDiskFieldList = new List<QueryDiskField>();
      foreach (FieldInfo field in queryDiskField.GetType().GetFields())
        queryDiskFieldList.Add((QueryDiskField) field.GetValue((object) queryDiskField));
      return queryDiskFieldList;
    }

    public static QueryDiskField FromValue(string value)
    {
      foreach (QueryDiskField queryDiskField in QueryDiskField.Values())
      {
        if (queryDiskField.Value().Equals(value))
          return queryDiskField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
