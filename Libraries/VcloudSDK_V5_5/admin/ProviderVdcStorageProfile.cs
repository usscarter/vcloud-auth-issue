// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.ProviderVdcStorageProfile
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin
{
  public class ProviderVdcStorageProfile : VcloudEntity<ProviderVdcStorageProfileType>
  {
    private ReferenceType providerVdcRef;

    internal ProviderVdcStorageProfile(
      vCloudClient client,
      ProviderVdcStorageProfileType providerVdcStorageProfileType)
      : base(client, providerVdcStorageProfileType)
    {
    }

    public static ProviderVdcStorageProfile GetProviderVdcStorageProfileByReference(
      vCloudClient client,
      ReferenceType providerVdcStorageProfileRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + providerVdcStorageProfileRef.href);
        return new ProviderVdcStorageProfile(client, VcloudResource<ProviderVdcStorageProfileType>.GetResourceByReference(client, providerVdcStorageProfileRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetProviderVdcReference()
    {
      try
      {
        if (this.providerVdcRef == null)
        {
          foreach (LinkType linkType in this.Resource.Link)
          {
            if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.providervdc+xml"))
              return (ReferenceType) linkType;
          }
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        }
        return this.providerVdcRef;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
