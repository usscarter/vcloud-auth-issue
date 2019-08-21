// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.Levels
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

namespace com.vmware.vcloud.sdk.utility
{
  public enum Levels
  {
    Off = 1,
    Critical = 2,
    Error = 4,
    Warning = 8,
    Information = 16, // 0x00000010
    Verbose = 32, // 0x00000020
    ActivityTracing = 64, // 0x00000040
    All = 128, // 0x00000080
  }
}
