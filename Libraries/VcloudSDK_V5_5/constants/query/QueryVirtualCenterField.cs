// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryVirtualCenterField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryVirtualCenterField : QueryField
  {
    public static QueryVirtualCenterField ID = QueryVirtualCenterField.Get("id");
    public static QueryVirtualCenterField HREF = QueryVirtualCenterField.Get("href");
    public static QueryVirtualCenterField ISBUSY = QueryVirtualCenterField.Get("isBusy");
    public static QueryVirtualCenterField ISENABLED = QueryVirtualCenterField.Get("isEnabled");
    public static QueryVirtualCenterField NAME = QueryVirtualCenterField.Get("name");
    public static QueryVirtualCenterField STATUS = QueryVirtualCenterField.Get("status");
    public static QueryVirtualCenterField URL = QueryVirtualCenterField.Get("url");
    public static QueryVirtualCenterField USERNAME = QueryVirtualCenterField.Get("username");
    public static QueryVirtualCenterField VCVERSION = QueryVirtualCenterField.Get("vcVersion");
    public static QueryVirtualCenterField VSMIP = QueryVirtualCenterField.Get("vsmIP");
    public static QueryVirtualCenterField VSMID = QueryVirtualCenterField.Get("vsmId");
    public static QueryVirtualCenterField ISSUPPORTED = QueryVirtualCenterField.Get("isSupported");
    private string _value;

    private static QueryVirtualCenterField Get(string str)
    {
      return new QueryVirtualCenterField(str);
    }

    private QueryVirtualCenterField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryVirtualCenterField> Values()
    {
      QueryVirtualCenterField virtualCenterField = new QueryVirtualCenterField();
      List<QueryVirtualCenterField> virtualCenterFieldList = new List<QueryVirtualCenterField>();
      foreach (FieldInfo field in virtualCenterField.GetType().GetFields())
        virtualCenterFieldList.Add((QueryVirtualCenterField) field.GetValue((object) virtualCenterField));
      return virtualCenterFieldList;
    }

    public static QueryVirtualCenterField FromValue(string value)
    {
      foreach (QueryVirtualCenterField virtualCenterField in QueryVirtualCenterField.Values())
      {
        if (virtualCenterField.Value().Equals(value))
          return virtualCenterField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
