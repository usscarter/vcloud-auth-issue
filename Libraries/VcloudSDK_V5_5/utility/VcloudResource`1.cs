// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.utility.VcloudResource`1
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using System;

namespace com.vmware.vcloud.sdk.utility
{
  public abstract class VcloudResource<T> : IDisposable where T : ResourceType
  {
    private T _resourceType = default (T);
    private ReferenceType _referenceType;
    private vCloudClient _client;

    protected VcloudResource(vCloudClient client, T resourceType)
    {
      ResourceType resource = (ResourceType) resourceType;
      this._resourceType = resourceType;
      this._client = client;
      this.SetReference(resource);
    }

    protected vCloudClient VcloudClient
    {
      get
      {
        return this._client;
      }
    }

    public T Resource
    {
      get
      {
        return this._resourceType;
      }
    }

    public ReferenceType Reference
    {
      get
      {
        return this._referenceType;
      }
    }

    private void SetReference(ResourceType resource)
    {
      this._referenceType = new ReferenceType();
      this._referenceType.href = resource.href;
      this._referenceType.type = resource.type;
      if (!(resource is IdentifiableResourceType))
        return;
      this._referenceType.id = ((IdentifiableResourceType) resource).id;
    }

    protected static T GetResourceByReference(vCloudClient client, ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return SdkUtil.Get<T>(client, reference.href, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    protected void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
