// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminMediaField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminMediaField : QueryField
  {
    public static QueryAdminMediaField ID = QueryAdminMediaField.Get("id");
    public static QueryAdminMediaField HREF = QueryAdminMediaField.Get("href");
    public static QueryAdminMediaField CATALOG = QueryAdminMediaField.Get("catalog");
    public static QueryAdminMediaField CATALOGITEM = QueryAdminMediaField.Get("catalogItem");
    public static QueryAdminMediaField CATALOGNAME = QueryAdminMediaField.Get("catalogName");
    public static QueryAdminMediaField CREATIONDATE = QueryAdminMediaField.Get("creationDate");
    public static QueryAdminMediaField ISBUSY = QueryAdminMediaField.Get("isBusy");
    public static QueryAdminMediaField ISPUBLISHED = QueryAdminMediaField.Get("isPublished");
    public static QueryAdminMediaField ISVDCENABLED = QueryAdminMediaField.Get("isVdcEnabled");
    public static QueryAdminMediaField NAME = QueryAdminMediaField.Get("name");
    public static QueryAdminMediaField ORG = QueryAdminMediaField.Get("org");
    public static QueryAdminMediaField OWNER = QueryAdminMediaField.Get("owner");
    public static QueryAdminMediaField OWNERNAME = QueryAdminMediaField.Get("ownerName");
    public static QueryAdminMediaField STORAGEB = QueryAdminMediaField.Get("storageB");
    public static QueryAdminMediaField STATUS = QueryAdminMediaField.Get("status");
    public static QueryAdminMediaField STORAGEPROFILENAME = QueryAdminMediaField.Get("storageProfileName");
    public static QueryAdminMediaField VDC = QueryAdminMediaField.Get("vdc");
    public static QueryAdminMediaField VDCNAME = QueryAdminMediaField.Get("vdcName");
    private string _value;

    private static QueryAdminMediaField Get(string str)
    {
      return new QueryAdminMediaField(str);
    }

    private QueryAdminMediaField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminMediaField> Values()
    {
      QueryAdminMediaField queryAdminMediaField = new QueryAdminMediaField();
      List<QueryAdminMediaField> queryAdminMediaFieldList = new List<QueryAdminMediaField>();
      foreach (FieldInfo field in queryAdminMediaField.GetType().GetFields())
        queryAdminMediaFieldList.Add((QueryAdminMediaField) field.GetValue((object) queryAdminMediaField));
      return queryAdminMediaFieldList;
    }

    public static QueryAdminMediaField FromValue(string value)
    {
      foreach (QueryAdminMediaField queryAdminMediaField in QueryAdminMediaField.Values())
      {
        if (queryAdminMediaField.Value().Equals(value))
          return queryAdminMediaField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
