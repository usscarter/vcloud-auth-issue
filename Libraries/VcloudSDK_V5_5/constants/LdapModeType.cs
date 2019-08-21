// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.LdapModeType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct LdapModeType
  {
    public static LdapModeType NONE = LdapModeType.Get(nameof (NONE));
    public static LdapModeType SYSTEM = LdapModeType.Get(nameof (SYSTEM));
    public static LdapModeType CUSTOM = LdapModeType.Get(nameof (CUSTOM));
    private string _value;

    private static LdapModeType Get(string str)
    {
      return new LdapModeType(str);
    }

    private LdapModeType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<LdapModeType> Values()
    {
      LdapModeType ldapModeType = new LdapModeType();
      List<LdapModeType> ldapModeTypeList = new List<LdapModeType>();
      foreach (FieldInfo field in ldapModeType.GetType().GetFields())
        ldapModeTypeList.Add((LdapModeType) field.GetValue((object) ldapModeType));
      return ldapModeTypeList;
    }

    public static LdapModeType FromValue(string value)
    {
      foreach (LdapModeType ldapModeType in LdapModeType.Values())
      {
        if (ldapModeType.Value().Equals(value))
          return ldapModeType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
