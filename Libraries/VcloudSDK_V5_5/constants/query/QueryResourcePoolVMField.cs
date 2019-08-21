// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryResourcePoolVMField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryResourcePoolVMField : QueryField
  {
    public static QueryResourcePoolVMField ID = QueryResourcePoolVMField.Get("id");
    public static QueryResourcePoolVMField HREF = QueryResourcePoolVMField.Get("href");
    public static QueryResourcePoolVMField CONTAINERNAME = QueryResourcePoolVMField.Get("containerName");
    public static QueryResourcePoolVMField GUESTOS = QueryResourcePoolVMField.Get("guestOs");
    public static QueryResourcePoolVMField HARDWAREVERSION = QueryResourcePoolVMField.Get("hardwareVersion");
    public static QueryResourcePoolVMField ISBUSY = QueryResourcePoolVMField.Get("isBusy");
    public static QueryResourcePoolVMField ISDEPLOYED = QueryResourcePoolVMField.Get("isDeployed");
    public static QueryResourcePoolVMField NAME = QueryResourcePoolVMField.Get("name");
    public static QueryResourcePoolVMField STATUS = QueryResourcePoolVMField.Get("status");
    private string _value;

    private static QueryResourcePoolVMField Get(string str)
    {
      return new QueryResourcePoolVMField(str);
    }

    private QueryResourcePoolVMField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryResourcePoolVMField> Values()
    {
      QueryResourcePoolVMField resourcePoolVmField = new QueryResourcePoolVMField();
      List<QueryResourcePoolVMField> resourcePoolVmFieldList = new List<QueryResourcePoolVMField>();
      foreach (FieldInfo field in resourcePoolVmField.GetType().GetFields())
        resourcePoolVmFieldList.Add((QueryResourcePoolVMField) field.GetValue((object) resourcePoolVmField));
      return resourcePoolVmFieldList;
    }

    public static QueryResourcePoolVMField FromValue(string value)
    {
      foreach (QueryResourcePoolVMField resourcePoolVmField in QueryResourcePoolVMField.Values())
      {
        if (resourcePoolVmField.Value().Equals(value))
          return resourcePoolVmField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
