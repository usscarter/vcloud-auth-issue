// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryCatalogField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryCatalogField : QueryField
  {
    public static QueryCatalogField ID = QueryCatalogField.Get("id");
    public static QueryCatalogField HREF = QueryCatalogField.Get("href");
    public static QueryCatalogField CREATIONDATE = QueryCatalogField.Get("creationDate");
    public static QueryCatalogField ISPUBLISHED = QueryCatalogField.Get("isPublished");
    public static QueryCatalogField ISSHARED = QueryCatalogField.Get("isShared");
    public static QueryCatalogField NAME = QueryCatalogField.Get("name");
    public static QueryCatalogField NUMBEROFMEDIA = QueryCatalogField.Get("numberOfMedia");
    public static QueryCatalogField NUMBEROFVAPPTEMPLATES = QueryCatalogField.Get("numberOfVAppTemplates");
    public static QueryCatalogField ORGNAME = QueryCatalogField.Get("orgName");
    public static QueryCatalogField OWNER = QueryCatalogField.Get("owner");
    public static QueryCatalogField OWNERNAME = QueryCatalogField.Get("ownerName");
    private string _value;

    private static QueryCatalogField Get(string str)
    {
      return new QueryCatalogField(str);
    }

    private QueryCatalogField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryCatalogField> Values()
    {
      QueryCatalogField queryCatalogField = new QueryCatalogField();
      List<QueryCatalogField> queryCatalogFieldList = new List<QueryCatalogField>();
      foreach (FieldInfo field in queryCatalogField.GetType().GetFields())
        queryCatalogFieldList.Add((QueryCatalogField) field.GetValue((object) queryCatalogField));
      return queryCatalogFieldList;
    }

    public static QueryCatalogField FromValue(string value)
    {
      foreach (QueryCatalogField queryCatalogField in QueryCatalogField.Values())
      {
        if (queryCatalogField.Value().Equals(value))
          return queryCatalogField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
