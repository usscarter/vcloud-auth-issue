// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.LdapConnectorType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct LdapConnectorType
  {
    public static LdapConnectorType ACTIVE_DIRECTORY = LdapConnectorType.Get(nameof (ACTIVE_DIRECTORY));
    public static LdapConnectorType OPEN_LDAP = LdapConnectorType.Get(nameof (OPEN_LDAP));
    private string _value;

    private static LdapConnectorType Get(string str)
    {
      return new LdapConnectorType(str);
    }

    private LdapConnectorType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<LdapConnectorType> Values()
    {
      LdapConnectorType ldapConnectorType = new LdapConnectorType();
      List<LdapConnectorType> ldapConnectorTypeList = new List<LdapConnectorType>();
      foreach (FieldInfo field in ldapConnectorType.GetType().GetFields())
        ldapConnectorTypeList.Add((LdapConnectorType) field.GetValue((object) ldapConnectorType));
      return ldapConnectorTypeList;
    }

    public static LdapConnectorType FromValue(string value)
    {
      foreach (LdapConnectorType ldapConnectorType in LdapConnectorType.Values())
      {
        if (ldapConnectorType.Value().Equals(value))
          return ldapConnectorType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
