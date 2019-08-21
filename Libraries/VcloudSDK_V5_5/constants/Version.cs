// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.Version
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct Version
  {
    public static Version V1_5 = Version.Get("1.5");
    public static Version V5_1 = Version.Get("5.1");
    public static Version V5_5 = Version.Get("5.5");
    private string _value;

    private static Version Get(string str)
    {
      return new Version(str);
    }

    private Version(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<Version> Values()
    {
      Version version = new Version();
      List<Version> versionList = new List<Version>();
      foreach (FieldInfo field in version.GetType().GetFields())
        versionList.Add((Version) field.GetValue((object) version));
      return versionList;
    }

    public static Version FromValue(string value)
    {
      Version version1 = new Version();
      foreach (FieldInfo field in version1.GetType().GetFields())
      {
        Version version2 = (Version) field.GetValue((object) version1);
        if (version2.Value() == value)
          return version2;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
