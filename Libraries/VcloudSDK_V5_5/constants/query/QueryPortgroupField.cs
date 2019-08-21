// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryPortgroupField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryPortgroupField : QueryField
  {
    public static QueryPortgroupField ID = QueryPortgroupField.Get("id");
    public static QueryPortgroupField HREF = QueryPortgroupField.Get("href");
    public static QueryPortgroupField ISVCENABLED = QueryPortgroupField.Get("isVCEnabled");
    public static QueryPortgroupField MOREF = QueryPortgroupField.Get("moref");
    public static QueryPortgroupField NAME = QueryPortgroupField.Get("name");
    [Obsolete("This property is obsolete since SDK 5.1; Use property NETWORKNAME instead of  NETNAME")]
    public static QueryPortgroupField NETNAME = QueryPortgroupField.Get("netName");
    public static QueryPortgroupField NETWORKNAME = QueryPortgroupField.Get("networkName");
    public static QueryPortgroupField NETWORK = QueryPortgroupField.Get("network");
    public static QueryPortgroupField PORTGROUPTYPE = QueryPortgroupField.Get("portgroupType");
    public static QueryPortgroupField SCOPETYPE = QueryPortgroupField.Get("scopeType");
    public static QueryPortgroupField VC = QueryPortgroupField.Get("vc");
    public static QueryPortgroupField VCNAME = QueryPortgroupField.Get("vcName");
    private string _value;

    private static QueryPortgroupField Get(string str)
    {
      return new QueryPortgroupField(str);
    }

    private QueryPortgroupField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryPortgroupField> Values()
    {
      QueryPortgroupField queryPortgroupField = new QueryPortgroupField();
      List<QueryPortgroupField> queryPortgroupFieldList = new List<QueryPortgroupField>();
      foreach (FieldInfo field in queryPortgroupField.GetType().GetFields())
        queryPortgroupFieldList.Add((QueryPortgroupField) field.GetValue((object) queryPortgroupField));
      return queryPortgroupFieldList;
    }

    public static QueryPortgroupField FromValue(string value)
    {
      foreach (QueryPortgroupField queryPortgroupField in QueryPortgroupField.Values())
      {
        if (queryPortgroupField.Value().Equals(value))
          return queryPortgroupField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
