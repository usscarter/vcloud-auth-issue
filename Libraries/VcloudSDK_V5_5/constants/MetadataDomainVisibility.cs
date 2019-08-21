// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.MetadataDomainVisibility
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct MetadataDomainVisibility
  {
    public static MetadataDomainVisibility PRIVATE = MetadataDomainVisibility.Get(nameof (PRIVATE));
    public static MetadataDomainVisibility READONLY = MetadataDomainVisibility.Get(nameof (READONLY));
    private string _value;

    private static MetadataDomainVisibility Get(string str)
    {
      return new MetadataDomainVisibility(str);
    }

    private MetadataDomainVisibility(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<MetadataDomainVisibility> Values()
    {
      MetadataDomainVisibility domainVisibility = new MetadataDomainVisibility();
      List<MetadataDomainVisibility> domainVisibilityList = new List<MetadataDomainVisibility>();
      foreach (FieldInfo field in domainVisibility.GetType().GetFields())
        domainVisibilityList.Add((MetadataDomainVisibility) field.GetValue((object) domainVisibility));
      return domainVisibilityList;
    }

    public static MetadataDomainVisibility FromValue(string value)
    {
      foreach (MetadataDomainVisibility domainVisibility in MetadataDomainVisibility.Values())
      {
        if (domainVisibility.Value().Equals(value))
          return domainVisibility;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
