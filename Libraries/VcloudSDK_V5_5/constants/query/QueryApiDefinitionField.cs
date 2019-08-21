// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryApiDefinitionField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryApiDefinitionField : QueryField
  {
    public static QueryApiDefinitionField ID = QueryApiDefinitionField.Get("id");
    public static QueryApiDefinitionField HREF = QueryApiDefinitionField.Get("href");
    public static QueryApiDefinitionField APIVENDOR = QueryApiDefinitionField.Get("apiVendor");
    public static QueryApiDefinitionField ENTRYPOINT = QueryApiDefinitionField.Get("entryPoint");
    public static QueryApiDefinitionField NAME = QueryApiDefinitionField.Get("name");
    public static QueryApiDefinitionField NAMESPACE = QueryApiDefinitionField.Get("namespace");
    public static QueryApiDefinitionField SERVICE = QueryApiDefinitionField.Get("service");
    public static QueryApiDefinitionField SERVICENAME = QueryApiDefinitionField.Get("serviceName");
    public static QueryApiDefinitionField SERVICENAMESPACE = QueryApiDefinitionField.Get("serviceNamespace");
    public static QueryApiDefinitionField SERVICEVENDOR = QueryApiDefinitionField.Get("serviceVendor");
    private string _value;

    private static QueryApiDefinitionField Get(string str)
    {
      return new QueryApiDefinitionField(str);
    }

    private QueryApiDefinitionField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryApiDefinitionField> Values()
    {
      QueryApiDefinitionField apiDefinitionField = new QueryApiDefinitionField();
      List<QueryApiDefinitionField> apiDefinitionFieldList = new List<QueryApiDefinitionField>();
      foreach (FieldInfo field in apiDefinitionField.GetType().GetFields())
        apiDefinitionFieldList.Add((QueryApiDefinitionField) field.GetValue((object) apiDefinitionField));
      return apiDefinitionFieldList;
    }

    public static QueryApiDefinitionField FromValue(string value)
    {
      foreach (QueryApiDefinitionField apiDefinitionField in QueryApiDefinitionField.Values())
      {
        if (apiDefinitionField.Value().Equals(value))
          return apiDefinitionField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
