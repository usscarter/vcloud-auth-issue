// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAllocatedExternalAddressField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  [Obsolete("This query constant is obsolete")]
  public struct QueryAllocatedExternalAddressField : QueryField
  {
    public static QueryAllocatedExternalAddressField ID = QueryAllocatedExternalAddressField.Get("id");
    public static QueryAllocatedExternalAddressField HREF = QueryAllocatedExternalAddressField.Get("href");
    public static QueryAllocatedExternalAddressField IPADDRESS = QueryAllocatedExternalAddressField.Get("ipAddress");
    public static QueryAllocatedExternalAddressField LINKEDNETWORK = QueryAllocatedExternalAddressField.Get("linkedNetwork");
    public static QueryAllocatedExternalAddressField NETWORK = QueryAllocatedExternalAddressField.Get("network");
    private string _value;

    private static QueryAllocatedExternalAddressField Get(
      string str)
    {
      return new QueryAllocatedExternalAddressField(str);
    }

    private QueryAllocatedExternalAddressField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAllocatedExternalAddressField> Values()
    {
      QueryAllocatedExternalAddressField externalAddressField = new QueryAllocatedExternalAddressField();
      List<QueryAllocatedExternalAddressField> externalAddressFieldList = new List<QueryAllocatedExternalAddressField>();
      foreach (FieldInfo field in externalAddressField.GetType().GetFields())
        externalAddressFieldList.Add((QueryAllocatedExternalAddressField) field.GetValue((object) externalAddressField));
      return externalAddressFieldList;
    }

    public static QueryAllocatedExternalAddressField FromValue(
      string value)
    {
      foreach (QueryAllocatedExternalAddressField externalAddressField in QueryAllocatedExternalAddressField.Values())
      {
        if (externalAddressField.Value().Equals(value))
          return externalAddressField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
