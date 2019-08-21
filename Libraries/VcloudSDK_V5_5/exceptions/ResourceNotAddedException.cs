// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.exceptions.ResourceNotAddedException
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;

namespace com.vmware.vcloud.sdk.exceptions
{
  public class ResourceNotAddedException : VCloudException
  {
    private ReferenceType resourceRef;

    public ResourceNotAddedException(VCloudException vcloudException, ReferenceType resourceRef)
      : base(vcloudException.GetVcloudError())
    {
      this.resourceRef = resourceRef;
    }

    public ReferenceType GetResourceRef()
    {
      return this.resourceRef;
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
