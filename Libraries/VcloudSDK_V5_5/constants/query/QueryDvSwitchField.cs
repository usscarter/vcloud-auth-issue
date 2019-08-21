// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryDvSwitchField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryDvSwitchField : QueryField
  {
    public static QueryDvSwitchField ID = QueryDvSwitchField.Get("id");
    public static QueryDvSwitchField HREF = QueryDvSwitchField.Get("href");
    public static QueryDvSwitchField MOREF = QueryDvSwitchField.Get("moref");
    public static QueryDvSwitchField NAME = QueryDvSwitchField.Get("name");
    public static QueryDvSwitchField VC = QueryDvSwitchField.Get("vc");
    public static QueryDvSwitchField ISVCENABLED = QueryDvSwitchField.Get("isVCEnabled");
    public static QueryDvSwitchField VCNAME = QueryDvSwitchField.Get("vcName");
    private string _value;

    private static QueryDvSwitchField Get(string str)
    {
      return new QueryDvSwitchField(str);
    }

    private QueryDvSwitchField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryDvSwitchField> Values()
    {
      QueryDvSwitchField queryDvSwitchField = new QueryDvSwitchField();
      List<QueryDvSwitchField> queryDvSwitchFieldList = new List<QueryDvSwitchField>();
      foreach (FieldInfo field in queryDvSwitchField.GetType().GetFields())
        queryDvSwitchFieldList.Add((QueryDvSwitchField) field.GetValue((object) queryDvSwitchField));
      return queryDvSwitchFieldList;
    }

    public static QueryDvSwitchField FromValue(string value)
    {
      foreach (QueryDvSwitchField queryDvSwitchField in QueryDvSwitchField.Values())
      {
        if (queryDvSwitchField.Value().Equals(value))
          return queryDvSwitchField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
