// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.IpsecVpnEncryptionProtocolType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct IpsecVpnEncryptionProtocolType
  {
    public static IpsecVpnEncryptionProtocolType AES = IpsecVpnEncryptionProtocolType.Get(nameof (AES));
    public static IpsecVpnEncryptionProtocolType AES256 = IpsecVpnEncryptionProtocolType.Get(nameof (AES256));
    public static IpsecVpnEncryptionProtocolType TRIPLEDES = IpsecVpnEncryptionProtocolType.Get(nameof (TRIPLEDES));
    private string _value;

    private static IpsecVpnEncryptionProtocolType Get(string str)
    {
      return new IpsecVpnEncryptionProtocolType(str);
    }

    private IpsecVpnEncryptionProtocolType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<IpsecVpnEncryptionProtocolType> Values()
    {
      IpsecVpnEncryptionProtocolType encryptionProtocolType = new IpsecVpnEncryptionProtocolType();
      List<IpsecVpnEncryptionProtocolType> encryptionProtocolTypeList = new List<IpsecVpnEncryptionProtocolType>();
      foreach (FieldInfo field in encryptionProtocolType.GetType().GetFields())
        encryptionProtocolTypeList.Add((IpsecVpnEncryptionProtocolType) field.GetValue((object) encryptionProtocolType));
      return encryptionProtocolTypeList;
    }

    public static IpsecVpnEncryptionProtocolType FromValue(
      string value)
    {
      foreach (IpsecVpnEncryptionProtocolType encryptionProtocolType in IpsecVpnEncryptionProtocolType.Values())
      {
        if (encryptionProtocolType.Value().Equals(value))
          return encryptionProtocolType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
