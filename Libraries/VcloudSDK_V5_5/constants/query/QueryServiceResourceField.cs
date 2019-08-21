// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryServiceResourceField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryServiceResourceField : QueryField
  {
    public static QueryServiceResourceField ID = QueryServiceResourceField.Get("id");
    public static QueryServiceResourceField HREF = QueryServiceResourceField.Get("href");
    public static QueryServiceResourceField EXTERNALOBJECTID = QueryServiceResourceField.Get("externalObjectId");
    public static QueryServiceResourceField NAME = QueryServiceResourceField.Get("name");
    public static QueryServiceResourceField ORG = QueryServiceResourceField.Get("org");
    public static QueryServiceResourceField RESOURCECLASS = QueryServiceResourceField.Get("resourceClass");
    private string _value;

    private static QueryServiceResourceField Get(string str)
    {
      return new QueryServiceResourceField(str);
    }

    private QueryServiceResourceField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryServiceResourceField> Values()
    {
      QueryServiceResourceField serviceResourceField = new QueryServiceResourceField();
      List<QueryServiceResourceField> serviceResourceFieldList = new List<QueryServiceResourceField>();
      foreach (FieldInfo field in serviceResourceField.GetType().GetFields())
        serviceResourceFieldList.Add((QueryServiceResourceField) field.GetValue((object) serviceResourceField));
      return serviceResourceFieldList;
    }

    public static QueryServiceResourceField FromValue(string value)
    {
      foreach (QueryServiceResourceField serviceResourceField in QueryServiceResourceField.Values())
      {
        if (serviceResourceField.Value().Equals(value))
          return serviceResourceField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
