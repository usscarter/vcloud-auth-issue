// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryServiceLinkField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryServiceLinkField : QueryField
  {
    public static QueryServiceLinkField ID = QueryServiceLinkField.Get("id");
    public static QueryServiceLinkField HREF = QueryServiceLinkField.Get("href");
    public static QueryServiceLinkField LINKHREF = QueryServiceLinkField.Get("linkHref");
    public static QueryServiceLinkField MIMETYPE = QueryServiceLinkField.Get("mimeType");
    public static QueryServiceLinkField REL = QueryServiceLinkField.Get("rel");
    public static QueryServiceLinkField RESOURCEID = QueryServiceLinkField.Get("resourceId");
    public static QueryServiceLinkField RESOURCETYPE = QueryServiceLinkField.Get("resourceType");
    public static QueryServiceLinkField SERVICE = QueryServiceLinkField.Get("service");
    private string _value;

    private static QueryServiceLinkField Get(string str)
    {
      return new QueryServiceLinkField(str);
    }

    private QueryServiceLinkField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryServiceLinkField> Values()
    {
      QueryServiceLinkField serviceLinkField = new QueryServiceLinkField();
      List<QueryServiceLinkField> serviceLinkFieldList = new List<QueryServiceLinkField>();
      foreach (FieldInfo field in serviceLinkField.GetType().GetFields())
        serviceLinkFieldList.Add((QueryServiceLinkField) field.GetValue((object) serviceLinkField));
      return serviceLinkFieldList;
    }

    public static QueryServiceLinkField FromValue(string value)
    {
      foreach (QueryServiceLinkField serviceLinkField in QueryServiceLinkField.Values())
      {
        if (serviceLinkField.Value().Equals(value))
          return serviceLinkField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
