// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryOrgField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryOrgField : QueryField
  {
    public static QueryOrgField ID = QueryOrgField.Get("id");
    public static QueryOrgField HREF = QueryOrgField.Get("href");
    public static QueryOrgField CANPUBLISHCATALOGS = QueryOrgField.Get("canPublishCatalogs");
    public static QueryOrgField CATALOGS = QueryOrgField.Get("catalogs");
    public static QueryOrgField DEPLOYEDVMQUOTA = QueryOrgField.Get("deployedVMQuota");
    public static QueryOrgField DISPLAYNAME = QueryOrgField.Get("displayName");
    public static QueryOrgField ISENABLED = QueryOrgField.Get("isEnabled");
    public static QueryOrgField NAME = QueryOrgField.Get("name");
    public static QueryOrgField ISREADONLY = QueryOrgField.Get("isReadOnly");
    public static QueryOrgField RUNNINGVMS = QueryOrgField.Get("runningVms");
    public static QueryOrgField STOREDVMQUOTA = QueryOrgField.Get("storedVMQuota");
    public static QueryOrgField USERGROUPS = QueryOrgField.Get("userGroups");
    public static QueryOrgField VAPPS = QueryOrgField.Get("vApps");
    public static QueryOrgField VDCS = QueryOrgField.Get("vdcs");
    public static QueryOrgField NUMBEROFDISKS = QueryOrgField.Get("numberOfDisks");
    private string _value;

    private static QueryOrgField Get(string str)
    {
      return new QueryOrgField(str);
    }

    private QueryOrgField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryOrgField> Values()
    {
      QueryOrgField queryOrgField = new QueryOrgField();
      List<QueryOrgField> queryOrgFieldList = new List<QueryOrgField>();
      foreach (FieldInfo field in queryOrgField.GetType().GetFields())
        queryOrgFieldList.Add((QueryOrgField) field.GetValue((object) queryOrgField));
      return queryOrgFieldList;
    }

    public static QueryOrgField FromValue(string value)
    {
      foreach (QueryOrgField queryOrgField in QueryOrgField.Values())
      {
        if (queryOrgField.Value().Equals(value))
          return queryOrgField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
