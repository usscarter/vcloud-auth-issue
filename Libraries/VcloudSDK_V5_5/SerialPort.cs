// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.SerialPort
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;

namespace com.vmware.vcloud.sdk
{
  [Obsolete("This class is obsolete; Internal API - NotSupported/UnImplemented")]
  public class SerialPort : HardwareItem
  {
    private SerialPort(RASD_Type serialPortItem)
      : base(serialPortItem)
    {
    }
  }
}
