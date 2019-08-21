// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVAppTemplateField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVAppTemplateField : QueryField
  {
    public static QueryVAppTemplateField ID = QueryVAppTemplateField.Get("id");
    public static QueryVAppTemplateField HREF = QueryVAppTemplateField.Get("href");
    public static QueryVAppTemplateField AUTODELETEDATE = QueryVAppTemplateField.Get("autoDeleteDate");
    public static QueryVAppTemplateField CATALOGNAME = QueryVAppTemplateField.Get("catalogName");
    public static QueryVAppTemplateField CREATEDON = QueryVAppTemplateField.Get("createdOn");
    public static QueryVAppTemplateField ISBUSY = QueryVAppTemplateField.Get("isBusy");
    public static QueryVAppTemplateField ISDEPLOYED = QueryVAppTemplateField.Get("isDeployed");
    public static QueryVAppTemplateField ISENABLED = QueryVAppTemplateField.Get("isEnabled");
    public static QueryVAppTemplateField ISGOLDMASTER = QueryVAppTemplateField.Get("isGoldMaster");
    public static QueryVAppTemplateField ISPUBLISHED = QueryVAppTemplateField.Get("isPublished");
    public static QueryVAppTemplateField ISVDCENABLED = QueryVAppTemplateField.Get("isVdcEnabled");
    public static QueryVAppTemplateField NAME = QueryVAppTemplateField.Get("name");
    public static QueryVAppTemplateField ORG = QueryVAppTemplateField.Get("org");
    public static QueryVAppTemplateField ORGVDCNAME = QueryVAppTemplateField.Get("orgVdcName");
    public static QueryVAppTemplateField OWNER = QueryVAppTemplateField.Get("owner");
    public static QueryVAppTemplateField OWNERNAME = QueryVAppTemplateField.Get("ownerName");
    public static QueryVAppTemplateField SIZEKB = QueryVAppTemplateField.Get("sizeKB");
    public static QueryVAppTemplateField STATUS = QueryVAppTemplateField.Get("status");
    public static QueryVAppTemplateField STORAGEPROFILENAME = QueryVAppTemplateField.Get("storageProfileName");
    public static QueryVAppTemplateField VDC = QueryVAppTemplateField.Get("vdc");
    private string _value;

    private static QueryVAppTemplateField Get(string str)
    {
      return new QueryVAppTemplateField(str);
    }

    private QueryVAppTemplateField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVAppTemplateField> Values()
    {
      QueryVAppTemplateField vappTemplateField = new QueryVAppTemplateField();
      List<QueryVAppTemplateField> vappTemplateFieldList = new List<QueryVAppTemplateField>();
      foreach (FieldInfo field in vappTemplateField.GetType().GetFields())
        vappTemplateFieldList.Add((QueryVAppTemplateField) field.GetValue((object) vappTemplateField));
      return vappTemplateFieldList;
    }

    public static QueryVAppTemplateField FromValue(string value)
    {
      foreach (QueryVAppTemplateField vappTemplateField in QueryVAppTemplateField.Values())
      {
        if (vappTemplateField.Value().Equals(value))
          return vappTemplateField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
