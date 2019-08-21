// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.VCloudException
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;

namespace com.vmware.vcloud.sdk.utility
{
  public class VCloudException : Exception
  {
    private ErrorType _vcloudError;

    public VCloudException(ErrorType vcloudError)
      : base(vcloudError.message)
    {
      this._vcloudError = vcloudError;
    }

    public VCloudException(string message)
      : base(message)
    {
    }

    public ErrorType GetVcloudError()
    {
      return this._vcloudError;
    }
  }
}
