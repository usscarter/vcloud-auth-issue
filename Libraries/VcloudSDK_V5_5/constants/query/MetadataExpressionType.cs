// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.MetadataExpressionType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct MetadataExpressionType
  {
    public static MetadataExpressionType EQUALS = MetadataExpressionType.Get("==");
    public static MetadataExpressionType NOT_EQUALS = MetadataExpressionType.Get("!=");
    public static MetadataExpressionType LESSER_THAN = MetadataExpressionType.Get("=lt=");
    public static MetadataExpressionType LESSER_THAN_OR_EQUAL = MetadataExpressionType.Get("=le=");
    public static MetadataExpressionType GREATER_THAN = MetadataExpressionType.Get("=gt=");
    public static MetadataExpressionType GREATER_THAN_OR_EQUAL = MetadataExpressionType.Get("=ge=");
    private string _value;

    private static MetadataExpressionType Get(string str)
    {
      return new MetadataExpressionType(str);
    }

    private MetadataExpressionType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<MetadataExpressionType> Values()
    {
      MetadataExpressionType metadataExpressionType = new MetadataExpressionType();
      List<MetadataExpressionType> metadataExpressionTypeList = new List<MetadataExpressionType>();
      foreach (FieldInfo field in metadataExpressionType.GetType().GetFields())
        metadataExpressionTypeList.Add((MetadataExpressionType) field.GetValue((object) metadataExpressionType));
      return metadataExpressionTypeList;
    }

    public static MetadataExpressionType FromValue(string value)
    {
      foreach (MetadataExpressionType metadataExpressionType in MetadataExpressionType.Values())
      {
        if (metadataExpressionType.Value().Equals(value))
          return metadataExpressionType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
