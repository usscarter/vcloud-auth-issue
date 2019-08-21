// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryResourcePoolField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryResourcePoolField : QueryField
  {
    public static QueryResourcePoolField ID = QueryResourcePoolField.Get("id");
    public static QueryResourcePoolField HREF = QueryResourcePoolField.Get("href");
    public static QueryResourcePoolField ISDELETED = QueryResourcePoolField.Get("isDeleted");
    public static QueryResourcePoolField NAME = QueryResourcePoolField.Get("name");
    public static QueryResourcePoolField MOREF = QueryResourcePoolField.Get("moref");
    public static QueryResourcePoolField VC = QueryResourcePoolField.Get("vc");
    public static QueryResourcePoolField VCNAME = QueryResourcePoolField.Get("vcName");
    private string _value;

    private static QueryResourcePoolField Get(string str)
    {
      return new QueryResourcePoolField(str);
    }

    private QueryResourcePoolField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryResourcePoolField> Values()
    {
      QueryResourcePoolField resourcePoolField = new QueryResourcePoolField();
      List<QueryResourcePoolField> resourcePoolFieldList = new List<QueryResourcePoolField>();
      foreach (FieldInfo field in resourcePoolField.GetType().GetFields())
        resourcePoolFieldList.Add((QueryResourcePoolField) field.GetValue((object) resourcePoolField));
      return resourcePoolFieldList;
    }

    public static QueryResourcePoolField FromValue(string value)
    {
      foreach (QueryResourcePoolField resourcePoolField in QueryResourcePoolField.Values())
      {
        if (resourcePoolField.Value().Equals(value))
          return resourcePoolField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
