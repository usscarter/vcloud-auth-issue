// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryMediaField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryMediaField : QueryField
  {
    public static QueryMediaField ID = QueryMediaField.Get("id");
    public static QueryMediaField HREF = QueryMediaField.Get("href");
    public static QueryMediaField CATALOG = QueryMediaField.Get("catalog");
    public static QueryMediaField CATALOGITEM = QueryMediaField.Get("catalogItem");
    public static QueryMediaField CATALOGNAME = QueryMediaField.Get("catalogName");
    public static QueryMediaField CREATIONDATE = QueryMediaField.Get("creationDate");
    public static QueryMediaField ISBUSY = QueryMediaField.Get("isBusy");
    public static QueryMediaField ISPUBLISHED = QueryMediaField.Get("isPublished");
    public static QueryMediaField NAME = QueryMediaField.Get("name");
    public static QueryMediaField ORG = QueryMediaField.Get("org");
    public static QueryMediaField OWNER = QueryMediaField.Get("owner");
    public static QueryMediaField OWNERNAME = QueryMediaField.Get("ownerName");
    public static QueryMediaField STATUS = QueryMediaField.Get("status");
    public static QueryMediaField STORAGEB = QueryMediaField.Get("storageB");
    public static QueryMediaField STORAGEPROFILENAME = QueryMediaField.Get("storageProfileName");
    public static QueryMediaField VDC = QueryMediaField.Get("vdc");
    public static QueryMediaField VDCNAME = QueryMediaField.Get("vdcName");
    private string _value;

    private static QueryMediaField Get(string str)
    {
      return new QueryMediaField(str);
    }

    private QueryMediaField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryMediaField> Values()
    {
      QueryMediaField queryMediaField = new QueryMediaField();
      List<QueryMediaField> queryMediaFieldList = new List<QueryMediaField>();
      foreach (FieldInfo field in queryMediaField.GetType().GetFields())
        queryMediaFieldList.Add((QueryMediaField) field.GetValue((object) queryMediaField));
      return queryMediaFieldList;
    }

    public static QueryMediaField FromValue(string value)
    {
      foreach (QueryMediaField queryMediaField in QueryMediaField.Values())
      {
        if (queryMediaField.Value().Equals(value))
          return queryMediaField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
