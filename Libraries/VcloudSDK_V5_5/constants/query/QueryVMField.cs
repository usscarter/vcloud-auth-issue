// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVMField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVMField : QueryField
  {
    public static QueryVMField ID = QueryVMField.Get("id");
    public static QueryVMField HREF = QueryVMField.Get("href");
    public static QueryVMField CATALOGNAME = QueryVMField.Get("catalogName");
    public static QueryVMField CONTAINER = QueryVMField.Get("container");
    public static QueryVMField GUESTOS = QueryVMField.Get("guestOs");
    public static QueryVMField HARDWAREVERSION = QueryVMField.Get("hardwareVersion");
    public static QueryVMField ISBUSY = QueryVMField.Get("isBusy");
    public static QueryVMField ISDELETED = QueryVMField.Get("isDeleted");
    public static QueryVMField ISDEPLOYED = QueryVMField.Get("isDeployed");
    public static QueryVMField ISINMAINTENANCEMODE = QueryVMField.Get("isInMaintenanceMode");
    public static QueryVMField ISPUBLISHED = QueryVMField.Get("isPublished");
    public static QueryVMField ISVAPPTEMPLATE = QueryVMField.Get("isVAppTemplate");
    public static QueryVMField MEMORYMB = QueryVMField.Get("memoryMB");
    public static QueryVMField NAME = QueryVMField.Get("name");
    public static QueryVMField NUMBEROFCPUS = QueryVMField.Get("numberOfCpus");
    public static QueryVMField STATUS = QueryVMField.Get("status");
    public static QueryVMField STORAGEPROFILENAME = QueryVMField.Get("storageProfileName");
    public static QueryVMField VAPPNAME = QueryVMField.Get("vappName");
    public static QueryVMField VDC = QueryVMField.Get("vdc");
    private string _value;

    private static QueryVMField Get(string str)
    {
      return new QueryVMField(str);
    }

    private QueryVMField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVMField> Values()
    {
      QueryVMField queryVmField = new QueryVMField();
      List<QueryVMField> queryVmFieldList = new List<QueryVMField>();
      foreach (FieldInfo field in queryVmField.GetType().GetFields())
        queryVmFieldList.Add((QueryVMField) field.GetValue((object) queryVmField));
      return queryVmFieldList;
    }

    public static QueryVMField FromValue(string value)
    {
      foreach (QueryVMField queryVmField in QueryVMField.Values())
      {
        if (queryVmField.Value().Equals(value))
          return queryVmField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
