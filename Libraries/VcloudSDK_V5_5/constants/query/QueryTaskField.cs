// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryTaskField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryTaskField : QueryField
  {
    public static QueryTaskField ID = QueryTaskField.Get("id");
    public static QueryTaskField HREF = QueryTaskField.Get("href");
    public static QueryTaskField ENDDATE = QueryTaskField.Get("endDate");
    public static QueryTaskField NAME = QueryTaskField.Get("name");
    public static QueryTaskField OBJECT = QueryTaskField.Get("object");
    public static QueryTaskField OBJECTNAME = QueryTaskField.Get("objectName");
    public static QueryTaskField OBJECTTYPE = QueryTaskField.Get("objectType");
    public static QueryTaskField ORG = QueryTaskField.Get("org");
    public static QueryTaskField ORGNAME = QueryTaskField.Get("orgName");
    public static QueryTaskField OWNERNAME = QueryTaskField.Get("ownerName");
    public static QueryTaskField SERVICENAMESPACE = QueryTaskField.Get("serviceNamespace");
    public static QueryTaskField STARTDATE = QueryTaskField.Get("startDate");
    public static QueryTaskField STATUS = QueryTaskField.Get("status");
    private string _value;

    private static QueryTaskField Get(string str)
    {
      return new QueryTaskField(str);
    }

    private QueryTaskField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryTaskField> Values()
    {
      QueryTaskField queryTaskField = new QueryTaskField();
      List<QueryTaskField> queryTaskFieldList = new List<QueryTaskField>();
      foreach (FieldInfo field in queryTaskField.GetType().GetFields())
        queryTaskFieldList.Add((QueryTaskField) field.GetValue((object) queryTaskField));
      return queryTaskFieldList;
    }

    public static QueryTaskField FromValue(string value)
    {
      foreach (QueryTaskField queryTaskField in QueryTaskField.Values())
      {
        if (queryTaskField.Value().Equals(value))
          return queryTaskField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
