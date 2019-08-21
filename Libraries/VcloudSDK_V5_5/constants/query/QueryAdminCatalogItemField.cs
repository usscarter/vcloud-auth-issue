// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminCatalogItemField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminCatalogItemField : QueryField
  {
    public static QueryAdminCatalogItemField ID = QueryAdminCatalogItemField.Get("id");
    public static QueryAdminCatalogItemField HREF = QueryAdminCatalogItemField.Get("href");
    public static QueryAdminCatalogItemField CATALOG = QueryAdminCatalogItemField.Get("catalog");
    public static QueryAdminCatalogItemField CATALOGNAME = QueryAdminCatalogItemField.Get("catalogName");
    public static QueryAdminCatalogItemField CREATIONDATE = QueryAdminCatalogItemField.Get("creationDate");
    public static QueryAdminCatalogItemField ENTITY = QueryAdminCatalogItemField.Get("entity");
    public static QueryAdminCatalogItemField ENTITYNAME = QueryAdminCatalogItemField.Get("entityName");
    public static QueryAdminCatalogItemField ENTITYTYPE = QueryAdminCatalogItemField.Get("entityType");
    public static QueryAdminCatalogItemField ISEXPIRED = QueryAdminCatalogItemField.Get("isExpired");
    public static QueryAdminCatalogItemField ISPUBLISHED = QueryAdminCatalogItemField.Get("isPublished");
    public static QueryAdminCatalogItemField ISVDCENABLED = QueryAdminCatalogItemField.Get("isVdcEnabled");
    public static QueryAdminCatalogItemField NAME = QueryAdminCatalogItemField.Get("name");
    public static QueryAdminCatalogItemField ORG = QueryAdminCatalogItemField.Get("org");
    public static QueryAdminCatalogItemField OWNER = QueryAdminCatalogItemField.Get("owner");
    public static QueryAdminCatalogItemField OWNERNAME = QueryAdminCatalogItemField.Get("ownerName");
    public static QueryAdminCatalogItemField STATUS = QueryAdminCatalogItemField.Get("status");
    public static QueryAdminCatalogItemField VDC = QueryAdminCatalogItemField.Get("vdc");
    public static QueryAdminCatalogItemField VDCNAME = QueryAdminCatalogItemField.Get("vdcName");
    private string _value;

    private static QueryAdminCatalogItemField Get(string str)
    {
      return new QueryAdminCatalogItemField(str);
    }

    private QueryAdminCatalogItemField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminCatalogItemField> Values()
    {
      QueryAdminCatalogItemField catalogItemField = new QueryAdminCatalogItemField();
      List<QueryAdminCatalogItemField> catalogItemFieldList = new List<QueryAdminCatalogItemField>();
      foreach (FieldInfo field in catalogItemField.GetType().GetFields())
        catalogItemFieldList.Add((QueryAdminCatalogItemField) field.GetValue((object) catalogItemField));
      return catalogItemFieldList;
    }

    public static QueryAdminCatalogItemField FromValue(string value)
    {
      foreach (QueryAdminCatalogItemField catalogItemField in QueryAdminCatalogItemField.Values())
      {
        if (catalogItemField.Value().Equals(value))
          return catalogItemField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
