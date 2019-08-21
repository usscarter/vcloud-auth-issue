// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.ExpressionType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct ExpressionType
  {
    public static ExpressionType EQUALS = ExpressionType.Get("==");
    public static ExpressionType NOT_EQUALS = ExpressionType.Get("!=");
    public static ExpressionType NULL = ExpressionType.Get("");
    public static ExpressionType LESSER_THAN = ExpressionType.Get("=lt=");
    public static ExpressionType LESSER_THAN_OR_EQUAL = ExpressionType.Get("=le=");
    public static ExpressionType GREATER_THAN = ExpressionType.Get("=gt=");
    public static ExpressionType GREATER_THAN_OR_EQUAL = ExpressionType.Get("=ge=");
    private string _value;

    private static ExpressionType Get(string str)
    {
      return new ExpressionType(str);
    }

    private ExpressionType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<ExpressionType> Values()
    {
      ExpressionType expressionType = new ExpressionType();
      List<ExpressionType> expressionTypeList = new List<ExpressionType>();
      foreach (FieldInfo field in expressionType.GetType().GetFields())
        expressionTypeList.Add((ExpressionType) field.GetValue((object) expressionType));
      return expressionTypeList;
    }

    public static ExpressionType FromValue(string value)
    {
      foreach (ExpressionType expressionType in ExpressionType.Values())
      {
        if (expressionType.Value().Equals(value))
          return expressionType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
