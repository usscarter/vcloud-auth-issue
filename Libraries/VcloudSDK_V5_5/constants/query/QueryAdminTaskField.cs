// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminTaskField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminTaskField : QueryField
  {
    public static QueryAdminTaskField ID = QueryAdminTaskField.Get("id");
    public static QueryAdminTaskField HREF = QueryAdminTaskField.Get("href");
    public static QueryAdminTaskField CELLNAME = QueryAdminTaskField.Get("cellName");
    public static QueryAdminTaskField ENDDATE = QueryAdminTaskField.Get("endDate");
    public static QueryAdminTaskField HASOWNER = QueryAdminTaskField.Get("hasOwner");
    public static QueryAdminTaskField NAME = QueryAdminTaskField.Get("name");
    public static QueryAdminTaskField OBJECT = QueryAdminTaskField.Get("object");
    public static QueryAdminTaskField OBJECTNAME = QueryAdminTaskField.Get("objectName");
    public static QueryAdminTaskField OBJECTTYPE = QueryAdminTaskField.Get("objectType");
    public static QueryAdminTaskField ORG = QueryAdminTaskField.Get("org");
    public static QueryAdminTaskField ORGNAME = QueryAdminTaskField.Get("orgName");
    public static QueryAdminTaskField OWNER = QueryAdminTaskField.Get("owner");
    public static QueryAdminTaskField OWNERNAME = QueryAdminTaskField.Get("ownerName");
    public static QueryAdminTaskField SERVICENAMESPACE = QueryAdminTaskField.Get("serviceNamespace");
    public static QueryAdminTaskField STARTDATE = QueryAdminTaskField.Get("startDate");
    public static QueryAdminTaskField STATUS = QueryAdminTaskField.Get("status");
    private string _value;

    private static QueryAdminTaskField Get(string str)
    {
      return new QueryAdminTaskField(str);
    }

    private QueryAdminTaskField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminTaskField> Values()
    {
      QueryAdminTaskField queryAdminTaskField = new QueryAdminTaskField();
      List<QueryAdminTaskField> queryAdminTaskFieldList = new List<QueryAdminTaskField>();
      foreach (FieldInfo field in queryAdminTaskField.GetType().GetFields())
        queryAdminTaskFieldList.Add((QueryAdminTaskField) field.GetValue((object) queryAdminTaskField));
      return queryAdminTaskFieldList;
    }

    public static QueryAdminTaskField FromValue(string value)
    {
      foreach (QueryAdminTaskField queryAdminTaskField in QueryAdminTaskField.Values())
      {
        if (queryAdminTaskField.Value().Equals(value))
          return queryAdminTaskField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
