// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.IdentityProviderSourceType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct IdentityProviderSourceType
  {
    public static IdentityProviderSourceType INTEGRATED = IdentityProviderSourceType.Get(nameof (INTEGRATED));
    public static IdentityProviderSourceType SAML = IdentityProviderSourceType.Get(nameof (SAML));
    private string _value;

    private static IdentityProviderSourceType Get(string str)
    {
      return new IdentityProviderSourceType(str);
    }

    private IdentityProviderSourceType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<IdentityProviderSourceType> Values()
    {
      IdentityProviderSourceType providerSourceType = new IdentityProviderSourceType();
      List<IdentityProviderSourceType> providerSourceTypeList = new List<IdentityProviderSourceType>();
      foreach (FieldInfo field in providerSourceType.GetType().GetFields())
        providerSourceTypeList.Add((IdentityProviderSourceType) field.GetValue((object) providerSourceType));
      return providerSourceTypeList;
    }

    public static IdentityProviderSourceType FromValue(string value)
    {
      foreach (IdentityProviderSourceType providerSourceType in IdentityProviderSourceType.Values())
      {
        if (providerSourceType.Value().Equals(value))
          return providerSourceType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
