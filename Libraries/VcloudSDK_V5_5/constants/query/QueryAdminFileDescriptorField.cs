// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminFileDescriptorField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminFileDescriptorField : QueryField
  {
    public static QueryAdminFileDescriptorField ID = QueryAdminFileDescriptorField.Get("id");
    public static QueryAdminFileDescriptorField HREF = QueryAdminFileDescriptorField.Get("id");
    public static QueryAdminFileDescriptorField APIDEFINITION = QueryAdminFileDescriptorField.Get("apiDefinition");
    public static QueryAdminFileDescriptorField APINAME = QueryAdminFileDescriptorField.Get("apiName");
    public static QueryAdminFileDescriptorField APINAMESPACE = QueryAdminFileDescriptorField.Get("apiNamespace");
    public static QueryAdminFileDescriptorField APIVENDOR = QueryAdminFileDescriptorField.Get("apiVendor");
    public static QueryAdminFileDescriptorField FILEMIMETYPE = QueryAdminFileDescriptorField.Get("fileMimeType");
    public static QueryAdminFileDescriptorField FILEURL = QueryAdminFileDescriptorField.Get("fileUrl");
    public static QueryAdminFileDescriptorField NAME = QueryAdminFileDescriptorField.Get("name");
    public static QueryAdminFileDescriptorField SERVICE = QueryAdminFileDescriptorField.Get("service");
    public static QueryAdminFileDescriptorField SERVICENAME = QueryAdminFileDescriptorField.Get("serviceName");
    public static QueryAdminFileDescriptorField SERVICENAMESPACE = QueryAdminFileDescriptorField.Get("serviceNamespace");
    public static QueryAdminFileDescriptorField SERVICEVENDOR = QueryAdminFileDescriptorField.Get("serviceVendor");
    private string _value;

    private static QueryAdminFileDescriptorField Get(string str)
    {
      return new QueryAdminFileDescriptorField(str);
    }

    private QueryAdminFileDescriptorField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminFileDescriptorField> Values()
    {
      QueryAdminFileDescriptorField fileDescriptorField = new QueryAdminFileDescriptorField();
      List<QueryAdminFileDescriptorField> fileDescriptorFieldList = new List<QueryAdminFileDescriptorField>();
      foreach (FieldInfo field in fileDescriptorField.GetType().GetFields())
        fileDescriptorFieldList.Add((QueryAdminFileDescriptorField) field.GetValue((object) fileDescriptorField));
      return fileDescriptorFieldList;
    }

    public static QueryAdminFileDescriptorField FromValue(string value)
    {
      foreach (QueryAdminFileDescriptorField fileDescriptorField in QueryAdminFileDescriptorField.Values())
      {
        if (fileDescriptorField.Value().Equals(value))
          return fileDescriptorField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
