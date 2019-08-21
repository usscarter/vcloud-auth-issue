// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryExternalLocalizationField
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryExternalLocalizationField : QueryField
  {
    public static QueryExternalLocalizationField ID = QueryExternalLocalizationField.Get("id");
    public static QueryExternalLocalizationField HREF = QueryExternalLocalizationField.Get("href");
    public static QueryExternalLocalizationField KEY = QueryExternalLocalizationField.Get("key");
    public static QueryExternalLocalizationField LOCALE = QueryExternalLocalizationField.Get("locale");
    public static QueryExternalLocalizationField SERVICENAMESPACE = QueryExternalLocalizationField.Get("serviceNamespace");
    public static QueryExternalLocalizationField VALUE = QueryExternalLocalizationField.Get("value");
    private string _value;

    private static QueryExternalLocalizationField Get(string str)
    {
      return new QueryExternalLocalizationField(str);
    }

    private QueryExternalLocalizationField(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryExternalLocalizationField> Values()
    {
      QueryExternalLocalizationField localizationField = new QueryExternalLocalizationField();
      List<QueryExternalLocalizationField> localizationFieldList = new List<QueryExternalLocalizationField>();
      foreach (FieldInfo field in localizationField.GetType().GetFields())
        localizationFieldList.Add((QueryExternalLocalizationField) field.GetValue((object) localizationField));
      return localizationFieldList;
    }

    public static QueryExternalLocalizationField FromValue(
      string value)
    {
      foreach (QueryExternalLocalizationField localizationField in QueryExternalLocalizationField.Values())
      {
        if (localizationField.Value().Equals(value))
          return localizationField;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
