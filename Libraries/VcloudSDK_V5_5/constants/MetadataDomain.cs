// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.MetadataDomain
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct MetadataDomain
  {
    public static MetadataDomain SYSTEM = MetadataDomain.Get(nameof (SYSTEM));
    private string _value;

    private static MetadataDomain Get(string str)
    {
      return new MetadataDomain(str);
    }

    private MetadataDomain(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<MetadataDomain> Values()
    {
      MetadataDomain metadataDomain = new MetadataDomain();
      List<MetadataDomain> metadataDomainList = new List<MetadataDomain>();
      foreach (FieldInfo field in metadataDomain.GetType().GetFields())
        metadataDomainList.Add((MetadataDomain) field.GetValue((object) metadataDomain));
      return metadataDomainList;
    }

    public static MetadataDomain FromValue(string value)
    {
      foreach (MetadataDomain metadataDomain in MetadataDomain.Values())
      {
        if (metadataDomain.Value().Equals(value))
          return metadataDomain;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
