// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryNetworkPoolField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryNetworkPoolField : QueryField
  {
    public static QueryNetworkPoolField ID = QueryNetworkPoolField.Get("id");
    public static QueryNetworkPoolField HREF = QueryNetworkPoolField.Get("href");
    public static QueryNetworkPoolField ISBUSY = QueryNetworkPoolField.Get("isBusy");
    public static QueryNetworkPoolField NAME = QueryNetworkPoolField.Get("name");
    public static QueryNetworkPoolField NETWORKPOOLTYPE = QueryNetworkPoolField.Get("networkPoolType");
    private string _value;

    private static QueryNetworkPoolField Get(string str)
    {
      return new QueryNetworkPoolField(str);
    }

    private QueryNetworkPoolField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryNetworkPoolField> Values()
    {
      QueryNetworkPoolField networkPoolField = new QueryNetworkPoolField();
      List<QueryNetworkPoolField> networkPoolFieldList = new List<QueryNetworkPoolField>();
      foreach (FieldInfo field in networkPoolField.GetType().GetFields())
        networkPoolFieldList.Add((QueryNetworkPoolField) field.GetValue((object) networkPoolField));
      return networkPoolFieldList;
    }

    public static QueryNetworkPoolField FromValue(string value)
    {
      foreach (QueryNetworkPoolField networkPoolField in QueryNetworkPoolField.Values())
      {
        if (networkPoolField.Value().Equals(value))
          return networkPoolField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
