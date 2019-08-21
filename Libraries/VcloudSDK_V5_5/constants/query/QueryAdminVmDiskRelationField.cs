// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminVmDiskRelationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminVmDiskRelationField : QueryField
  {
    public static QueryAdminVmDiskRelationField ID = QueryAdminVmDiskRelationField.Get("id");
    public static QueryAdminVmDiskRelationField HREF = QueryAdminVmDiskRelationField.Get("href");
    public static QueryAdminVmDiskRelationField DISK = QueryAdminVmDiskRelationField.Get("disk");
    public static QueryAdminVmDiskRelationField VDC = QueryAdminVmDiskRelationField.Get("vdc");
    public static QueryAdminVmDiskRelationField VM = QueryAdminVmDiskRelationField.Get("vm");
    private string _value;

    private static QueryAdminVmDiskRelationField Get(string str)
    {
      return new QueryAdminVmDiskRelationField(str);
    }

    private QueryAdminVmDiskRelationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminVmDiskRelationField> Values()
    {
      QueryAdminVmDiskRelationField diskRelationField = new QueryAdminVmDiskRelationField();
      List<QueryAdminVmDiskRelationField> diskRelationFieldList = new List<QueryAdminVmDiskRelationField>();
      foreach (FieldInfo field in diskRelationField.GetType().GetFields())
        diskRelationFieldList.Add((QueryAdminVmDiskRelationField) field.GetValue((object) diskRelationField));
      return diskRelationFieldList;
    }

    public static QueryAdminVmDiskRelationField FromValue(string value)
    {
      foreach (QueryAdminVmDiskRelationField diskRelationField in QueryAdminVmDiskRelationField.Values())
      {
        if (diskRelationField.Value().Equals(value))
          return diskRelationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
