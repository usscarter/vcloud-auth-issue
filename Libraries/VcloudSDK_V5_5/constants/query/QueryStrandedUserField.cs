// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryStrandedUserField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryStrandedUserField : QueryField
  {
    public static QueryStrandedUserField ID = QueryStrandedUserField.Get("id");
    public static QueryStrandedUserField HREF = QueryStrandedUserField.Get("href");
    public static QueryStrandedUserField FULLNAME = QueryStrandedUserField.Get("fullname");
    public static QueryStrandedUserField INSYNC = QueryStrandedUserField.Get("inSync");
    public static QueryStrandedUserField NAME = QueryStrandedUserField.Get("name");
    public static QueryStrandedUserField DEPLOYEDVMNUMBER = QueryStrandedUserField.Get("deployedVMNumber");
    public static QueryStrandedUserField STOREDVMNUMBER = QueryStrandedUserField.Get("storedVMNumber");
    public static QueryStrandedUserField ORG = QueryStrandedUserField.Get("org");
    private string _value;

    private static QueryStrandedUserField Get(string str)
    {
      return new QueryStrandedUserField(str);
    }

    private QueryStrandedUserField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryStrandedUserField> Values()
    {
      QueryStrandedUserField strandedUserField = new QueryStrandedUserField();
      List<QueryStrandedUserField> strandedUserFieldList = new List<QueryStrandedUserField>();
      foreach (FieldInfo field in strandedUserField.GetType().GetFields())
        strandedUserFieldList.Add((QueryStrandedUserField) field.GetValue((object) strandedUserField));
      return strandedUserFieldList;
    }

    public static QueryStrandedUserField FromValue(string value)
    {
      foreach (QueryStrandedUserField strandedUserField in QueryStrandedUserField.Values())
      {
        if (strandedUserField.Value().Equals(value))
          return strandedUserField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
