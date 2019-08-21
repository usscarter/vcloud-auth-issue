// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.OperatingSystemFamilyType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct OperatingSystemFamilyType
  {
    public static OperatingSystemFamilyType MICROSOFT_WINDOWS = OperatingSystemFamilyType.Get("Microsoft Windows", 1);
    public static OperatingSystemFamilyType LINUX = OperatingSystemFamilyType.Get("Linux", 2);
    public static OperatingSystemFamilyType OTHER = OperatingSystemFamilyType.Get("Other", 3);
    private string _name;
    private int _value;

    private static OperatingSystemFamilyType Get(string name, int id)
    {
      return new OperatingSystemFamilyType(name, id);
    }

    private OperatingSystemFamilyType(string name, int id)
    {
      this._name = name;
      this._value = id;
    }

    public string Name()
    {
      return this._name;
    }

    public int Value()
    {
      return this._value;
    }

    public static List<OperatingSystemFamilyType> Values()
    {
      OperatingSystemFamilyType systemFamilyType = new OperatingSystemFamilyType();
      List<OperatingSystemFamilyType> systemFamilyTypeList = new List<OperatingSystemFamilyType>();
      foreach (FieldInfo field in systemFamilyType.GetType().GetFields())
        systemFamilyTypeList.Add((OperatingSystemFamilyType) field.GetValue((object) systemFamilyType));
      return systemFamilyTypeList;
    }

    public static OperatingSystemFamilyType FromName(string name)
    {
      foreach (OperatingSystemFamilyType systemFamilyType in OperatingSystemFamilyType.Values())
      {
        if (systemFamilyType.Name().Equals(name))
          return systemFamilyType;
      }
      throw new ArgumentException(name.ToString());
    }

    public static OperatingSystemFamilyType FromValue(int value)
    {
      foreach (OperatingSystemFamilyType systemFamilyType in OperatingSystemFamilyType.Values())
      {
        if (systemFamilyType.Value().Equals(value))
          return systemFamilyType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
