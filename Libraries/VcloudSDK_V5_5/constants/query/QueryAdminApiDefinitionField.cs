// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminApiDefinitionField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminApiDefinitionField : QueryField
  {
    public static QueryAdminApiDefinitionField ID = QueryAdminApiDefinitionField.Get("id");
    public static QueryAdminApiDefinitionField HREF = QueryAdminApiDefinitionField.Get("href");
    public static QueryAdminApiDefinitionField APIVENDOR = QueryAdminApiDefinitionField.Get("apiVendor");
    public static QueryAdminApiDefinitionField ENTRYPOINT = QueryAdminApiDefinitionField.Get("entryPoint");
    public static QueryAdminApiDefinitionField NAME = QueryAdminApiDefinitionField.Get("name");
    public static QueryAdminApiDefinitionField NAMESPACE = QueryAdminApiDefinitionField.Get("namespace");
    public static QueryAdminApiDefinitionField SERVICE = QueryAdminApiDefinitionField.Get("service");
    public static QueryAdminApiDefinitionField SERVICENAME = QueryAdminApiDefinitionField.Get("serviceName");
    public static QueryAdminApiDefinitionField SERVICENAMESPACE = QueryAdminApiDefinitionField.Get("serviceNamespace");
    public static QueryAdminApiDefinitionField SERVICEVENDOR = QueryAdminApiDefinitionField.Get("serviceVendor");
    private string _value;

    private static QueryAdminApiDefinitionField Get(string str)
    {
      return new QueryAdminApiDefinitionField(str);
    }

    private QueryAdminApiDefinitionField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminApiDefinitionField> Values()
    {
      QueryAdminApiDefinitionField apiDefinitionField = new QueryAdminApiDefinitionField();
      List<QueryAdminApiDefinitionField> apiDefinitionFieldList = new List<QueryAdminApiDefinitionField>();
      foreach (FieldInfo field in apiDefinitionField.GetType().GetFields())
        apiDefinitionFieldList.Add((QueryAdminApiDefinitionField) field.GetValue((object) apiDefinitionField));
      return apiDefinitionFieldList;
    }

    public static QueryAdminApiDefinitionField FromValue(string value)
    {
      foreach (QueryAdminApiDefinitionField apiDefinitionField in QueryAdminApiDefinitionField.Values())
      {
        if (apiDefinitionField.Value().Equals(value))
          return apiDefinitionField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
