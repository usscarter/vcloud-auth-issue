// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryHostField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryHostField : QueryField
  {
    public static QueryHostField ID = QueryHostField.Get("id");
    public static QueryHostField HREF = QueryHostField.Get("href");
    public static QueryHostField ISBUSY = QueryHostField.Get("isBusy");
    public static QueryHostField ISCROSSHOSTENABLED = QueryHostField.Get("isCrossHostEnabled");
    public static QueryHostField ISDELETED = QueryHostField.Get("isDeleted");
    public static QueryHostField ISENABLED = QueryHostField.Get("isEnabled");
    public static QueryHostField ISHUNG = QueryHostField.Get("isHung");
    public static QueryHostField ISINMAINTENANCEMODE = QueryHostField.Get("isInMaintenanceMode");
    public static QueryHostField ISPENDINGUPGRADE = QueryHostField.Get("isPendingUpgrade");
    public static QueryHostField ISPREPARED = QueryHostField.Get("isPrepared");
    public static QueryHostField ISSUPPORTED = QueryHostField.Get("isSupported");
    public static QueryHostField NAME = QueryHostField.Get("name");
    public static QueryHostField NUMBEROFVMS = QueryHostField.Get("numberOfVms");
    public static QueryHostField OSVERSION = QueryHostField.Get("osVersion");
    public static QueryHostField STATE = QueryHostField.Get("state");
    public static QueryHostField VC = QueryHostField.Get("vc");
    public static QueryHostField VCNAME = QueryHostField.Get("vcName");
    private string _value;

    private static QueryHostField Get(string str)
    {
      return new QueryHostField(str);
    }

    private QueryHostField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryHostField> Values()
    {
      QueryHostField queryHostField = new QueryHostField();
      List<QueryHostField> queryHostFieldList = new List<QueryHostField>();
      foreach (FieldInfo field in queryHostField.GetType().GetFields())
        queryHostFieldList.Add((QueryHostField) field.GetValue((object) queryHostField));
      return queryHostFieldList;
    }

    public static QueryHostField FromValue(string value)
    {
      foreach (QueryHostField queryHostField in QueryHostField.Values())
      {
        if (queryHostField.Value().Equals(value))
          return queryHostField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
