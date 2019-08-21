// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryAdminEventField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryAdminEventField : QueryField
  {
    public static QueryAdminEventField ID = QueryAdminEventField.Get("id");
    public static QueryAdminEventField HREF = QueryAdminEventField.Get("href");
    public static QueryAdminEventField ENTITY = QueryAdminEventField.Get("entity");
    public static QueryAdminEventField ENTITYNAME = QueryAdminEventField.Get("entityName");
    public static QueryAdminEventField ENTITYTYPE = QueryAdminEventField.Get("entityType");
    public static QueryAdminEventField EVENTID = QueryAdminEventField.Get("eventId");
    public static QueryAdminEventField EVENTSTATUS = QueryAdminEventField.Get("eventStatus");
    public static QueryAdminEventField EVENTTYPE = QueryAdminEventField.Get("eventType");
    public static QueryAdminEventField ORG = QueryAdminEventField.Get("org");
    public static QueryAdminEventField ORGNAME = QueryAdminEventField.Get("orgName");
    public static QueryAdminEventField PRODUCTVERSION = QueryAdminEventField.Get("productVersion");
    public static QueryAdminEventField SERVICENAMESPACE = QueryAdminEventField.Get("serviceNamespace");
    public static QueryAdminEventField TIMESTAMP = QueryAdminEventField.Get("timeStamp");
    public static QueryAdminEventField USERNAME = QueryAdminEventField.Get("userName");
    private string _value;

    private static QueryAdminEventField Get(string str)
    {
      return new QueryAdminEventField(str);
    }

    private QueryAdminEventField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryAdminEventField> Values()
    {
      QueryAdminEventField queryAdminEventField = new QueryAdminEventField();
      List<QueryAdminEventField> queryAdminEventFieldList = new List<QueryAdminEventField>();
      foreach (FieldInfo field in queryAdminEventField.GetType().GetFields())
        queryAdminEventFieldList.Add((QueryAdminEventField) field.GetValue((object) queryAdminEventField));
      return queryAdminEventFieldList;
    }

    public static QueryAdminEventField FromValue(string value)
    {
      foreach (QueryAdminEventField queryAdminEventField in QueryAdminEventField.Values())
      {
        if (queryAdminEventField.Value().Equals(value))
          return queryAdminEventField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
