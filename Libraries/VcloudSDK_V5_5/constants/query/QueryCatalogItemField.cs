// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryCatalogItemField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryCatalogItemField : QueryField
  {
    public static QueryCatalogItemField ID = QueryCatalogItemField.Get("id");
    public static QueryCatalogItemField HREF = QueryCatalogItemField.Get("href");
    public static QueryCatalogItemField CATALOG = QueryCatalogItemField.Get("catalog");
    public static QueryCatalogItemField CATALOGNAME = QueryCatalogItemField.Get("catalogName");
    public static QueryCatalogItemField CREATIONDATE = QueryCatalogItemField.Get("creationDate");
    public static QueryCatalogItemField ENTITY = QueryCatalogItemField.Get("entity");
    public static QueryCatalogItemField ENTITYNAME = QueryCatalogItemField.Get("entityName");
    public static QueryCatalogItemField ENTITYTYPE = QueryCatalogItemField.Get("entityType");
    public static QueryCatalogItemField ISEXPIRED = QueryCatalogItemField.Get("isExpired");
    public static QueryCatalogItemField ISPUBLISHED = QueryCatalogItemField.Get("isPublished");
    public static QueryCatalogItemField ISVDCENABLED = QueryCatalogItemField.Get("isVdcEnabled");
    public static QueryCatalogItemField NAME = QueryCatalogItemField.Get("name");
    public static QueryCatalogItemField OWNER = QueryCatalogItemField.Get("owner");
    public static QueryCatalogItemField OWNERNAME = QueryCatalogItemField.Get("ownerName");
    public static QueryCatalogItemField STATUS = QueryCatalogItemField.Get("status");
    public static QueryCatalogItemField VDCNAME = QueryCatalogItemField.Get("vdcName");
    public static QueryCatalogItemField VDC = QueryCatalogItemField.Get("vdc");
    private string _value;

    private static QueryCatalogItemField Get(string str)
    {
      return new QueryCatalogItemField(str);
    }

    private QueryCatalogItemField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryCatalogItemField> Values()
    {
      QueryCatalogItemField catalogItemField = new QueryCatalogItemField();
      List<QueryCatalogItemField> catalogItemFieldList = new List<QueryCatalogItemField>();
      foreach (FieldInfo field in catalogItemField.GetType().GetFields())
        catalogItemFieldList.Add((QueryCatalogItemField) field.GetValue((object) catalogItemField));
      return catalogItemFieldList;
    }

    public static QueryCatalogItemField FromValue(string value)
    {
      foreach (QueryCatalogItemField catalogItemField in QueryCatalogItemField.Values())
      {
        if (catalogItemField.Value().Equals(value))
          return catalogItemField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
