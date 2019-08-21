// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminCatalogField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminCatalogField : QueryField
  {
    public static QueryAdminCatalogField ID = QueryAdminCatalogField.Get("id");
    public static QueryAdminCatalogField HREF = QueryAdminCatalogField.Get("href");
    public static QueryAdminCatalogField CREATIONDATE = QueryAdminCatalogField.Get("creationDate");
    public static QueryAdminCatalogField ISPUBLISHED = QueryAdminCatalogField.Get("isPublished");
    public static QueryAdminCatalogField ISSHARED = QueryAdminCatalogField.Get("isShared");
    public static QueryAdminCatalogField NAME = QueryAdminCatalogField.Get("name");
    public static QueryAdminCatalogField NUMBEROFMEDIA = QueryAdminCatalogField.Get("numberOfMedia");
    public static QueryAdminCatalogField NUMBEROFTEMPLATES = QueryAdminCatalogField.Get("numberOfTemplates");
    public static QueryAdminCatalogField ORG = QueryAdminCatalogField.Get("org");
    public static QueryAdminCatalogField ORGNAME = QueryAdminCatalogField.Get("orgName");
    public static QueryAdminCatalogField OWNER = QueryAdminCatalogField.Get("owner");
    public static QueryAdminCatalogField OWNERNAME = QueryAdminCatalogField.Get("ownerName");
    private string _value;

    private static QueryAdminCatalogField Get(string str)
    {
      return new QueryAdminCatalogField(str);
    }

    private QueryAdminCatalogField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminCatalogField> Values()
    {
      QueryAdminCatalogField adminCatalogField = new QueryAdminCatalogField();
      List<QueryAdminCatalogField> adminCatalogFieldList = new List<QueryAdminCatalogField>();
      foreach (FieldInfo field in adminCatalogField.GetType().GetFields())
        adminCatalogFieldList.Add((QueryAdminCatalogField) field.GetValue((object) adminCatalogField));
      return adminCatalogFieldList;
    }

    public static QueryAdminCatalogField FromValue(string value)
    {
      foreach (QueryAdminCatalogField adminCatalogField in QueryAdminCatalogField.Values())
      {
        if (adminCatalogField.Value().Equals(value))
          return adminCatalogField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
