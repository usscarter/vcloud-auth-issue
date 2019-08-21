// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryBlockingTaskField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryBlockingTaskField : QueryField
  {
    public static QueryBlockingTaskField ID = QueryBlockingTaskField.Get("id");
    public static QueryBlockingTaskField HREF = QueryBlockingTaskField.Get("href");
    public static QueryBlockingTaskField CREATIONDATE = QueryBlockingTaskField.Get("creationDate");
    public static QueryBlockingTaskField EXPIRATIONTIME = QueryBlockingTaskField.Get("expirationTime");
    public static QueryBlockingTaskField HASOWNER = QueryBlockingTaskField.Get("hasOwner");
    public static QueryBlockingTaskField JOBSTATUS = QueryBlockingTaskField.Get("jobStatus");
    public static QueryBlockingTaskField OPERATIONNAME = QueryBlockingTaskField.Get("operationName");
    public static QueryBlockingTaskField ORIGINATINGORGNAME = QueryBlockingTaskField.Get("originatingOrgName");
    public static QueryBlockingTaskField ORIGINATIONGORG = QueryBlockingTaskField.Get("originationgOrg");
    public static QueryBlockingTaskField OWNER = QueryBlockingTaskField.Get("owner");
    public static QueryBlockingTaskField TASK = QueryBlockingTaskField.Get("task");
    public static QueryBlockingTaskField TIMEOUTACTION = QueryBlockingTaskField.Get("timeoutAction");
    public static QueryBlockingTaskField USERNAME = QueryBlockingTaskField.Get("userName");
    private string _value;

    private static QueryBlockingTaskField Get(string str)
    {
      return new QueryBlockingTaskField(str);
    }

    private QueryBlockingTaskField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryBlockingTaskField> Values()
    {
      QueryBlockingTaskField blockingTaskField = new QueryBlockingTaskField();
      List<QueryBlockingTaskField> blockingTaskFieldList = new List<QueryBlockingTaskField>();
      foreach (FieldInfo field in blockingTaskField.GetType().GetFields())
        blockingTaskFieldList.Add((QueryBlockingTaskField) field.GetValue((object) blockingTaskField));
      return blockingTaskFieldList;
    }

    public static QueryBlockingTaskField FromValue(string value)
    {
      foreach (QueryBlockingTaskField blockingTaskField in QueryBlockingTaskField.Values())
      {
        if (blockingTaskField.Value().Equals(value))
          return blockingTaskField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
