// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VdcStorageProfile
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk
{
  public class VdcStorageProfile : VcloudEntity<VdcStorageProfileType>
  {
    private ReferenceType vdcReference;

    protected VdcStorageProfile(vCloudClient client, VdcStorageProfileType vdcStorageProfileType)
      : base(client, vdcStorageProfileType)
    {
      this.SortVdcStorageProfileReferences();
    }

    public static VdcStorageProfile GetVdcStorageProfileByReference(
      vCloudClient client,
      ReferenceType vdcStorageProfileRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vdcStorageProfileRef.href);
        return new VdcStorageProfile(client, VcloudResource<VdcStorageProfileType>.GetResourceByReference(client, vdcStorageProfileRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetVdcReference()
    {
      try
      {
        if (this.vdcReference != null)
          return this.vdcReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortVdcStorageProfileReferences()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
          this.vdcReference = (ReferenceType) linkType;
      }
    }
  }
}
