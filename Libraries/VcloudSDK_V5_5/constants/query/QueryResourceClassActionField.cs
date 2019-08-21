// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryResourceClassActionField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryResourceClassActionField : QueryField
  {
    public static QueryResourceClassActionField ID = QueryResourceClassActionField.Get("id");
    public static QueryResourceClassActionField HREF = QueryResourceClassActionField.Get("href");
    public static QueryResourceClassActionField HTTPMETHOD = QueryResourceClassActionField.Get("httpMethod");
    public static QueryResourceClassActionField NAME = QueryResourceClassActionField.Get("name");
    public static QueryResourceClassActionField RESOURCECLASS = QueryResourceClassActionField.Get("resourceClass");
    public static QueryResourceClassActionField URLPATTERN = QueryResourceClassActionField.Get("urlPattern");
    private string _value;

    private static QueryResourceClassActionField Get(string str)
    {
      return new QueryResourceClassActionField(str);
    }

    private QueryResourceClassActionField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryResourceClassActionField> Values()
    {
      QueryResourceClassActionField classActionField = new QueryResourceClassActionField();
      List<QueryResourceClassActionField> classActionFieldList = new List<QueryResourceClassActionField>();
      foreach (FieldInfo field in classActionField.GetType().GetFields())
        classActionFieldList.Add((QueryResourceClassActionField) field.GetValue((object) classActionField));
      return classActionFieldList;
    }

    public static QueryResourceClassActionField FromValue(string value)
    {
      foreach (QueryResourceClassActionField classActionField in QueryResourceClassActionField.Values())
      {
        if (classActionField.Value().Equals(value))
          return classActionField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
