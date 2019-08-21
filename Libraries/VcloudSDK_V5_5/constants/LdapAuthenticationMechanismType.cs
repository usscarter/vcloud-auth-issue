// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.LdapAuthenticationMechanismType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct LdapAuthenticationMechanismType
  {
    public static LdapAuthenticationMechanismType SIMPLE = LdapAuthenticationMechanismType.Get(nameof (SIMPLE));
    public static LdapAuthenticationMechanismType KERBEROS = LdapAuthenticationMechanismType.Get(nameof (KERBEROS));
    public static LdapAuthenticationMechanismType MD5DIGEST = LdapAuthenticationMechanismType.Get(nameof (MD5DIGEST));
    public static LdapAuthenticationMechanismType NTLM = LdapAuthenticationMechanismType.Get(nameof (NTLM));
    private string _value;

    private static LdapAuthenticationMechanismType Get(string str)
    {
      return new LdapAuthenticationMechanismType(str);
    }

    private LdapAuthenticationMechanismType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<LdapAuthenticationMechanismType> Values()
    {
      LdapAuthenticationMechanismType authenticationMechanismType = new LdapAuthenticationMechanismType();
      List<LdapAuthenticationMechanismType> authenticationMechanismTypeList = new List<LdapAuthenticationMechanismType>();
      foreach (FieldInfo field in authenticationMechanismType.GetType().GetFields())
        authenticationMechanismTypeList.Add((LdapAuthenticationMechanismType) field.GetValue((object) authenticationMechanismType));
      return authenticationMechanismTypeList;
    }

    public static LdapAuthenticationMechanismType FromValue(
      string value)
    {
      foreach (LdapAuthenticationMechanismType authenticationMechanismType in LdapAuthenticationMechanismType.Values())
      {
        if (authenticationMechanismType.Value().Equals(value))
          return authenticationMechanismType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
