// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VMWProviderVdcStorageProfile
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VMWProviderVdcStorageProfile : VcloudEntity<VMWProviderVdcStorageProfileType>
  {
    private ReferenceType _vmwProviderVdcRef;

    internal VMWProviderVdcStorageProfile(
      vCloudClient client,
      VMWProviderVdcStorageProfileType vmwProviderVdcStorageProfileType)
      : base(client, vmwProviderVdcStorageProfileType)
    {
    }

    public static VMWProviderVdcStorageProfile GetVMWProviderVdcStorageProfileByReference(
      vCloudClient client,
      ReferenceType vmwProviderVdcStorageProfileRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vmwProviderVdcStorageProfileRef.href);
        return new VMWProviderVdcStorageProfile(client, VcloudResource<VMWProviderVdcStorageProfileType>.GetResourceByReference(client, vmwProviderVdcStorageProfileRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetVMWProviderVdcReference()
    {
      try
      {
        if (this._vmwProviderVdcRef == null)
        {
          foreach (LinkType linkType in this.Resource.Link)
          {
            if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.vmwprovidervdc+xml"))
              return (ReferenceType) linkType;
          }
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        }
        return this._vmwProviderVdcRef;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWProviderVdcStorageProfile UpdateVMWProviderVdcStorageProfile(
      VMWProviderVdcStorageProfileType vmwProviderVdcStorageProfileResource)
    {
      return new VMWProviderVdcStorageProfile(this.VcloudClient, SdkUtil.Put<VMWProviderVdcStorageProfileType>(this.VcloudClient, this.Reference.href, SerializationUtil.SerializeObject<VMWProviderVdcStorageProfileType>(vmwProviderVdcStorageProfileResource, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.vmwPvdcStorageProfile+xml", 200));
    }
  }
}
