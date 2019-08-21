// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryResourceClassField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryResourceClassField : QueryField
  {
    public static QueryResourceClassField ID = QueryResourceClassField.Get("id");
    public static QueryResourceClassField HREF = QueryResourceClassField.Get("href");
    public static QueryResourceClassField MIMETYPE = QueryResourceClassField.Get("mimeType");
    public static QueryResourceClassField NAME = QueryResourceClassField.Get("name");
    public static QueryResourceClassField NID = QueryResourceClassField.Get("nid");
    public static QueryResourceClassField SERVICE = QueryResourceClassField.Get("service");
    public static QueryResourceClassField URLTEMPLATE = QueryResourceClassField.Get("urlTemplate");
    public static QueryResourceClassField URNPATTERN = QueryResourceClassField.Get("urnPattern");
    private string _value;

    private static QueryResourceClassField Get(string str)
    {
      return new QueryResourceClassField(str);
    }

    private QueryResourceClassField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryResourceClassField> Values()
    {
      QueryResourceClassField resourceClassField = new QueryResourceClassField();
      List<QueryResourceClassField> resourceClassFieldList = new List<QueryResourceClassField>();
      foreach (FieldInfo field in resourceClassField.GetType().GetFields())
        resourceClassFieldList.Add((QueryResourceClassField) field.GetValue((object) resourceClassField));
      return resourceClassFieldList;
    }

    public static QueryResourceClassField FromValue(string value)
    {
      foreach (QueryResourceClassField resourceClassField in QueryResourceClassField.Values())
      {
        if (resourceClassField.Value().Equals(value))
          return resourceClassField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
