// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminVdcStorageProfile
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin
{
  public class AdminVdcStorageProfile : VcloudEntity<AdminVdcStorageProfileType>
  {
    private ReferenceType adminVdcReference;

    internal AdminVdcStorageProfile(
      vCloudClient client,
      AdminVdcStorageProfileType adminVdcStorageProfileType)
      : base(client, adminVdcStorageProfileType)
    {
      this.SortAdminVdcStorageProfileReferences();
    }

    public static AdminVdcStorageProfile GetAdminVdcStorageProfileByReference(
      vCloudClient client,
      ReferenceType adminVdcStorageProfileRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + adminVdcStorageProfileRef.href);
        return new AdminVdcStorageProfile(client, VcloudResource<AdminVdcStorageProfileType>.GetResourceByReference(client, adminVdcStorageProfileRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetAdminVdcReference()
    {
      try
      {
        if (this.adminVdcReference != null)
          return this.adminVdcReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminVdcStorageProfile UpdateAdminVdcStorageProfile(
      AdminVdcStorageProfileType adminVdcStorageProfileResource)
    {
      try
      {
        return new AdminVdcStorageProfile(this.VcloudClient, SdkUtil.Put<AdminVdcStorageProfileType>(this.VcloudClient, this.Reference.href, SerializationUtil.SerializeObject<AdminVdcStorageProfileType>(adminVdcStorageProfileResource, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.vdcStorageProfile+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortAdminVdcStorageProfileReferences()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.vdc+xml"))
          this.adminVdcReference = (ReferenceType) linkType;
      }
    }
  }
}
