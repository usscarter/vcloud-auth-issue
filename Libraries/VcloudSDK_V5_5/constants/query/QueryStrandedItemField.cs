// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryStrandedItemField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryStrandedItemField : QueryField
  {
    public static QueryStrandedItemField ID = QueryStrandedItemField.Get("id");
    public static QueryStrandedItemField HREF = QueryStrandedItemField.Get("href");
    public static QueryStrandedItemField DELETIONDATE = QueryStrandedItemField.Get("deletionDate");
    public static QueryStrandedItemField NAME = QueryStrandedItemField.Get("name");
    public static QueryStrandedItemField NUMBEROFPURGEATTEMPTS = QueryStrandedItemField.Get("numberOfPurgeAttempts");
    public static QueryStrandedItemField PARENT = QueryStrandedItemField.Get("parent");
    public static QueryStrandedItemField PARENTNAME = QueryStrandedItemField.Get("parentName");
    public static QueryStrandedItemField VIMOBJECTTYPE = QueryStrandedItemField.Get("vimObjectType");
    private string _value;

    private static QueryStrandedItemField Get(string str)
    {
      return new QueryStrandedItemField(str);
    }

    private QueryStrandedItemField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryStrandedItemField> Values()
    {
      QueryStrandedItemField strandedItemField = new QueryStrandedItemField();
      List<QueryStrandedItemField> strandedItemFieldList = new List<QueryStrandedItemField>();
      foreach (FieldInfo field in strandedItemField.GetType().GetFields())
        strandedItemFieldList.Add((QueryStrandedItemField) field.GetValue((object) strandedItemField));
      return strandedItemFieldList;
    }

    public static QueryStrandedItemField FromValue(string value)
    {
      foreach (QueryStrandedItemField strandedItemField in QueryStrandedItemField.Values())
      {
        if (strandedItemField.Value().Equals(value))
          return strandedItemField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
