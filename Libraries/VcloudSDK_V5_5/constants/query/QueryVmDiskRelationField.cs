// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVmDiskRelationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVmDiskRelationField : QueryField
  {
    public static QueryVmDiskRelationField ID = QueryVmDiskRelationField.Get("id");
    public static QueryVmDiskRelationField HREF = QueryVmDiskRelationField.Get("href");
    public static QueryVmDiskRelationField DISK = QueryVmDiskRelationField.Get("disk");
    public static QueryVmDiskRelationField VDC = QueryVmDiskRelationField.Get("vdc");
    public static QueryVmDiskRelationField VM = QueryVmDiskRelationField.Get("vm");
    private string _value;

    private static QueryVmDiskRelationField Get(string str)
    {
      return new QueryVmDiskRelationField(str);
    }

    private QueryVmDiskRelationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVmDiskRelationField> Values()
    {
      QueryVmDiskRelationField diskRelationField = new QueryVmDiskRelationField();
      List<QueryVmDiskRelationField> diskRelationFieldList = new List<QueryVmDiskRelationField>();
      foreach (FieldInfo field in diskRelationField.GetType().GetFields())
        diskRelationFieldList.Add((QueryVmDiskRelationField) field.GetValue((object) diskRelationField));
      return diskRelationFieldList;
    }

    public static QueryVmDiskRelationField FromValue(string value)
    {
      foreach (QueryVmDiskRelationField diskRelationField in QueryVmDiskRelationField.Values())
      {
        if (diskRelationField.Value().Equals(value))
          return diskRelationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
