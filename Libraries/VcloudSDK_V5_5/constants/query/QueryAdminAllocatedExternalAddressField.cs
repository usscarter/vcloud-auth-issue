// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminAllocatedExternalAddressField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  [Obsolete("This query constant is obsolete")]
  public struct QueryAdminAllocatedExternalAddressField : QueryField
  {
    public static QueryAdminAllocatedExternalAddressField ID = QueryAdminAllocatedExternalAddressField.Get("id");
    public static QueryAdminAllocatedExternalAddressField HREF = QueryAdminAllocatedExternalAddressField.Get("href");
    public static QueryAdminAllocatedExternalAddressField IPADDRESS = QueryAdminAllocatedExternalAddressField.Get("ipAddress");
    public static QueryAdminAllocatedExternalAddressField LINKEDNETWORK = QueryAdminAllocatedExternalAddressField.Get("linkedNetwork");
    public static QueryAdminAllocatedExternalAddressField NETWORK = QueryAdminAllocatedExternalAddressField.Get("network");
    public static QueryAdminAllocatedExternalAddressField ORG = QueryAdminAllocatedExternalAddressField.Get("org");
    private string _value;

    private static QueryAdminAllocatedExternalAddressField Get(
      string str)
    {
      return new QueryAdminAllocatedExternalAddressField(str);
    }

    private QueryAdminAllocatedExternalAddressField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminAllocatedExternalAddressField> Values()
    {
      QueryAdminAllocatedExternalAddressField externalAddressField = new QueryAdminAllocatedExternalAddressField();
      List<QueryAdminAllocatedExternalAddressField> externalAddressFieldList = new List<QueryAdminAllocatedExternalAddressField>();
      foreach (FieldInfo field in externalAddressField.GetType().GetFields())
        externalAddressFieldList.Add((QueryAdminAllocatedExternalAddressField) field.GetValue((object) externalAddressField));
      return externalAddressFieldList;
    }

    public static QueryAdminAllocatedExternalAddressField FromValue(
      string value)
    {
      foreach (QueryAdminAllocatedExternalAddressField externalAddressField in QueryAdminAllocatedExternalAddressField.Values())
      {
        if (externalAddressField.Value().Equals(value))
          return externalAddressField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
