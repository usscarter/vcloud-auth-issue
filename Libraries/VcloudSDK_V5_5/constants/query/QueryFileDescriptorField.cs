// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryFileDescriptorField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryFileDescriptorField : QueryField
  {
    public static QueryFileDescriptorField ID = QueryFileDescriptorField.Get("id");
    public static QueryFileDescriptorField HREF = QueryFileDescriptorField.Get("href");
    public static QueryFileDescriptorField APIDEFINITION = QueryFileDescriptorField.Get("apiDefinition");
    public static QueryFileDescriptorField APINAME = QueryFileDescriptorField.Get("apiName");
    public static QueryFileDescriptorField APINAMESPACE = QueryFileDescriptorField.Get("apiNamespace");
    public static QueryFileDescriptorField APIVENDOR = QueryFileDescriptorField.Get("apiVendor");
    public static QueryFileDescriptorField FILEMIMETYPE = QueryFileDescriptorField.Get("fileMimeType");
    public static QueryFileDescriptorField FILEURL = QueryFileDescriptorField.Get("fileUrl");
    public static QueryFileDescriptorField NAME = QueryFileDescriptorField.Get("name");
    public static QueryFileDescriptorField SERVICE = QueryFileDescriptorField.Get("service");
    public static QueryFileDescriptorField SERVICENAME = QueryFileDescriptorField.Get("serviceName");
    public static QueryFileDescriptorField SERVICENAMESPACE = QueryFileDescriptorField.Get("serviceNamespace");
    public static QueryFileDescriptorField SERVICEVENDOR = QueryFileDescriptorField.Get("serviceVendor");
    private string _value;

    private static QueryFileDescriptorField Get(string str)
    {
      return new QueryFileDescriptorField(str);
    }

    private QueryFileDescriptorField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryFileDescriptorField> Values()
    {
      QueryFileDescriptorField fileDescriptorField = new QueryFileDescriptorField();
      List<QueryFileDescriptorField> fileDescriptorFieldList = new List<QueryFileDescriptorField>();
      foreach (FieldInfo field in fileDescriptorField.GetType().GetFields())
        fileDescriptorFieldList.Add((QueryFileDescriptorField) field.GetValue((object) fileDescriptorField));
      return fileDescriptorFieldList;
    }

    public static QueryFileDescriptorField FromValue(string value)
    {
      foreach (QueryFileDescriptorField fileDescriptorField in QueryFileDescriptorField.Values())
      {
        if (fileDescriptorField.Value().Equals(value))
          return fileDescriptorField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
