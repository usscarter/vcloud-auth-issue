// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminVAppTemplateField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminVAppTemplateField : QueryField
  {
    public static QueryAdminVAppTemplateField ID = QueryAdminVAppTemplateField.Get("id");
    public static QueryAdminVAppTemplateField HREF = QueryAdminVAppTemplateField.Get("href");
    public static QueryAdminVAppTemplateField CATALOG = QueryAdminVAppTemplateField.Get("catalog");
    public static QueryAdminVAppTemplateField CATALOGITEM = QueryAdminVAppTemplateField.Get("catalogItem");
    public static QueryAdminVAppTemplateField CATALOGNAME = QueryAdminVAppTemplateField.Get("catalogName");
    public static QueryAdminVAppTemplateField CREATIONDATE = QueryAdminVAppTemplateField.Get("creationDate");
    public static QueryAdminVAppTemplateField ISBUSY = QueryAdminVAppTemplateField.Get("isBusy");
    public static QueryAdminVAppTemplateField ISDEPLOYED = QueryAdminVAppTemplateField.Get("isDeployed");
    public static QueryAdminVAppTemplateField ISENABLED = QueryAdminVAppTemplateField.Get("isEnabled");
    public static QueryAdminVAppTemplateField ISEXPIRED = QueryAdminVAppTemplateField.Get("isExpired");
    public static QueryAdminVAppTemplateField ISGOLDMASTER = QueryAdminVAppTemplateField.Get("isGoldMaster");
    public static QueryAdminVAppTemplateField ISPUBLISHED = QueryAdminVAppTemplateField.Get("isPublished");
    public static QueryAdminVAppTemplateField ISVDCENABLED = QueryAdminVAppTemplateField.Get("isVdcEnabled");
    public static QueryAdminVAppTemplateField NAME = QueryAdminVAppTemplateField.Get("name");
    public static QueryAdminVAppTemplateField ORG = QueryAdminVAppTemplateField.Get("org");
    public static QueryAdminVAppTemplateField OWNER = QueryAdminVAppTemplateField.Get("owner");
    public static QueryAdminVAppTemplateField OWNERNAME = QueryAdminVAppTemplateField.Get("ownerName");
    public static QueryAdminVAppTemplateField VDCNAME = QueryAdminVAppTemplateField.Get("vdcName");
    public static QueryAdminVAppTemplateField STATUS = QueryAdminVAppTemplateField.Get("status");
    public static QueryAdminVAppTemplateField STORAGEPROFILENAME = QueryAdminVAppTemplateField.Get("storageProfileName");
    public static QueryAdminVAppTemplateField VDC = QueryAdminVAppTemplateField.Get("vdc");
    private string _value;

    private static QueryAdminVAppTemplateField Get(string str)
    {
      return new QueryAdminVAppTemplateField(str);
    }

    private QueryAdminVAppTemplateField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminVAppTemplateField> Values()
    {
      QueryAdminVAppTemplateField vappTemplateField = new QueryAdminVAppTemplateField();
      List<QueryAdminVAppTemplateField> vappTemplateFieldList = new List<QueryAdminVAppTemplateField>();
      foreach (FieldInfo field in vappTemplateField.GetType().GetFields())
        vappTemplateFieldList.Add((QueryAdminVAppTemplateField) field.GetValue((object) vappTemplateField));
      return vappTemplateFieldList;
    }

    public static QueryAdminVAppTemplateField FromValue(string value)
    {
      foreach (QueryAdminVAppTemplateField vappTemplateField in QueryAdminVAppTemplateField.Values())
      {
        if (vappTemplateField.Value().Equals(value))
          return vappTemplateField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
