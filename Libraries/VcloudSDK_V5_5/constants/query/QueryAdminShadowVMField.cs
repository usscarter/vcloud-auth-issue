// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminShadowVMField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminShadowVMField : QueryField
  {
    public static QueryAdminShadowVMField ID = QueryAdminShadowVMField.Get("id");
    public static QueryAdminShadowVMField HREF = QueryAdminShadowVMField.Get("href");
    public static QueryAdminShadowVMField DATASTORENAME = QueryAdminShadowVMField.Get("datastoreName");
    public static QueryAdminShadowVMField ISBUSY = QueryAdminShadowVMField.Get("isBusy");
    public static QueryAdminShadowVMField ISDELETED = QueryAdminShadowVMField.Get("isDeleted");
    public static QueryAdminShadowVMField ISPUBLISHED = QueryAdminShadowVMField.Get("isPublished");
    public static QueryAdminShadowVMField NAME = QueryAdminShadowVMField.Get("name");
    public static QueryAdminShadowVMField ORG = QueryAdminShadowVMField.Get("org");
    public static QueryAdminShadowVMField PRIMARYVAPPNAME = QueryAdminShadowVMField.Get("primaryVAppName");
    public static QueryAdminShadowVMField PRIMARYVAPPTEMPLATE = QueryAdminShadowVMField.Get("primaryVAppTemplate");
    public static QueryAdminShadowVMField PRIMARYVM = QueryAdminShadowVMField.Get("primaryVM");
    public static QueryAdminShadowVMField PRIMARYVMCATALOG = QueryAdminShadowVMField.Get("primaryVMCatalog");
    public static QueryAdminShadowVMField PRIMARYVMNAME = QueryAdminShadowVMField.Get("primaryVmName");
    public static QueryAdminShadowVMField PRIMARYVMOWNER = QueryAdminShadowVMField.Get("primaryVMOwner");
    [Obsolete("This property is deprecated  since API 5.1 and SDK 5.1")]
    public static QueryAdminShadowVMField SHADOWVAPP = QueryAdminShadowVMField.Get("shadowVApp");
    public static QueryAdminShadowVMField STATUS = QueryAdminShadowVMField.Get("status");
    public static QueryAdminShadowVMField VCNAME = QueryAdminShadowVMField.Get("vcName");
    private string _value;

    private static QueryAdminShadowVMField Get(string str)
    {
      return new QueryAdminShadowVMField(str);
    }

    private QueryAdminShadowVMField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminShadowVMField> Values()
    {
      QueryAdminShadowVMField adminShadowVmField = new QueryAdminShadowVMField();
      List<QueryAdminShadowVMField> adminShadowVmFieldList = new List<QueryAdminShadowVMField>();
      foreach (FieldInfo field in adminShadowVmField.GetType().GetFields())
        adminShadowVmFieldList.Add((QueryAdminShadowVMField) field.GetValue((object) adminShadowVmField));
      return adminShadowVmFieldList;
    }

    public static QueryAdminShadowVMField FromValue(string value)
    {
      foreach (QueryAdminShadowVMField adminShadowVmField in QueryAdminShadowVMField.Values())
      {
        if (adminShadowVmField.Value().Equals(value))
          return adminShadowVmField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
