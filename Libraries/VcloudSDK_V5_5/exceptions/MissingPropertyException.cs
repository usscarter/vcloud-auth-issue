// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.exceptions.MissingPropertyException
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.sdk.utility;

namespace com.vmware.vcloud.sdk.exceptions
{
  public class MissingPropertyException : VCloudException
  {
    public MissingPropertyException(string message)
      : base(message)
    {
    }

    public override string Message
    {
      get
      {
        return base.Message;
      }
    }
  }
}
