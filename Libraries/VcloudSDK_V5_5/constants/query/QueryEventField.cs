// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryEventField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryEventField : QueryField
  {
    public static QueryEventField ID = QueryEventField.Get("id");
    public static QueryEventField HREF = QueryEventField.Get("href");
    public static QueryEventField ENTITYID = QueryEventField.Get("entityId");
    public static QueryEventField ENTITYNAME = QueryEventField.Get("entityName");
    public static QueryEventField ENTITYTYPE = QueryEventField.Get("entityType");
    public static QueryEventField EVENTSTATUS = QueryEventField.Get("eventStatus");
    public static QueryEventField EVENTTYPE = QueryEventField.Get("eventType");
    public static QueryEventField ORGNAME = QueryEventField.Get("orgName");
    public static QueryEventField TIMESTAMP = QueryEventField.Get("timestamp");
    public static QueryEventField USERNAME = QueryEventField.Get("userName");
    public static QueryEventField SERVICENAMESPACE = QueryEventField.Get("serviceNamespace");
    private string _value;

    private static QueryEventField Get(string str)
    {
      return new QueryEventField(str);
    }

    private QueryEventField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryEventField> Values()
    {
      QueryEventField queryEventField = new QueryEventField();
      List<QueryEventField> queryEventFieldList = new List<QueryEventField>();
      foreach (FieldInfo field in queryEventField.GetType().GetFields())
        queryEventFieldList.Add((QueryEventField) field.GetValue((object) queryEventField));
      return queryEventFieldList;
    }

    public static QueryEventField FromValue(string value)
    {
      foreach (QueryEventField queryEventField in QueryEventField.Values())
      {
        if (queryEventField.Value().Equals(value))
          return queryEventField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
