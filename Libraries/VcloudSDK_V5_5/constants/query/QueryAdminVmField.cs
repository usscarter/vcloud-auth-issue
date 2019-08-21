// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminVmField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminVmField : QueryField
  {
    public static QueryAdminVmField ID = QueryAdminVmField.Get("id");
    public static QueryAdminVmField HREF = QueryAdminVmField.Get("href");
    public static QueryAdminVmField CATALOGNAME = QueryAdminVmField.Get("catalogName");
    public static QueryAdminVmField CONTAINER = QueryAdminVmField.Get("container");
    public static QueryAdminVmField CONTAINERNAME = QueryAdminVmField.Get("containerName");
    public static QueryAdminVmField DATASTORENAME = QueryAdminVmField.Get("datastoreName");
    public static QueryAdminVmField GUESTOS = QueryAdminVmField.Get("guestOs");
    public static QueryAdminVmField HARDWAREVERSION = QueryAdminVmField.Get("hardwareVersion");
    public static QueryAdminVmField HOSTNAME = QueryAdminVmField.Get("hostName");
    public static QueryAdminVmField ISDELETED = QueryAdminVmField.Get("isDeleted");
    public static QueryAdminVmField ISDEPLOYED = QueryAdminVmField.Get("isDeployed");
    public static QueryAdminVmField ISPUBLISHED = QueryAdminVmField.Get("isPublished");
    public static QueryAdminVmField ISVAPPTEMPLATE = QueryAdminVmField.Get("isVAppTemplate");
    public static QueryAdminVmField ISVDCENABLED = QueryAdminVmField.Get("isVdcEnabled");
    public static QueryAdminVmField MEMORYMB = QueryAdminVmField.Get("memoryMB");
    public static QueryAdminVmField MOREF = QueryAdminVmField.Get("moref");
    public static QueryAdminVmField NAME = QueryAdminVmField.Get("name");
    public static QueryAdminVmField NETWORKNAME = QueryAdminVmField.Get("networkName");
    public static QueryAdminVmField NUMBEROFCPUS = QueryAdminVmField.Get("numberOfCpus");
    public static QueryAdminVmField ORG = QueryAdminVmField.Get("org");
    public static QueryAdminVmField STATUS = QueryAdminVmField.Get("status");
    public static QueryAdminVmField STORAGEPROFILENAME = QueryAdminVmField.Get("storageProfileName");
    public static QueryAdminVmField VC = QueryAdminVmField.Get("vc");
    public static QueryAdminVmField VDC = QueryAdminVmField.Get("vdc");
    public static QueryAdminVmField VMTOOLSVERSION = QueryAdminVmField.Get("vmToolsVersion");
    private string _value;

    private static QueryAdminVmField Get(string str)
    {
      return new QueryAdminVmField(str);
    }

    private QueryAdminVmField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminVmField> Values()
    {
      QueryAdminVmField queryAdminVmField = new QueryAdminVmField();
      List<QueryAdminVmField> queryAdminVmFieldList = new List<QueryAdminVmField>();
      foreach (FieldInfo field in queryAdminVmField.GetType().GetFields())
        queryAdminVmFieldList.Add((QueryAdminVmField) field.GetValue((object) queryAdminVmField));
      return queryAdminVmFieldList;
    }

    public static QueryAdminVmField FromValue(string value)
    {
      foreach (QueryAdminVmField queryAdminVmField in QueryAdminVmField.Values())
      {
        if (queryAdminVmField.Value().Equals(value))
          return queryAdminVmField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
