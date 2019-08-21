// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.ImageType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct ImageType
  {
    public static ImageType ISO = ImageType.Get("iso");
    public static ImageType FLOPPY = ImageType.Get("floppy");
    private string _value;

    private static ImageType Get(string str)
    {
      return new ImageType(str);
    }

    private ImageType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<ImageType> Values()
    {
      ImageType imageType = new ImageType();
      List<ImageType> imageTypeList = new List<ImageType>();
      foreach (FieldInfo field in imageType.GetType().GetFields())
        imageTypeList.Add((ImageType) field.GetValue((object) imageType));
      return imageTypeList;
    }

    public static ImageType FromValue(string value)
    {
      foreach (ImageType imageType in ImageType.Values())
      {
        if (imageType.Value().Equals(value))
          return imageType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
