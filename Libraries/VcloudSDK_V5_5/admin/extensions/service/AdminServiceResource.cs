// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminServiceResource
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminServiceResource : VcloudEntity<ServiceResourceType>
  {
    private ReferenceType adminResourceClassRef;

    internal AdminServiceResource(vCloudClient client, ServiceResourceType serviceResParams)
      : base(client, serviceResParams)
    {
      this.SortAdminServiceResourceLinkRefs();
    }

    public static AdminServiceResource GetAdminServiceResourceByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
      return new AdminServiceResource(client, VcloudResource<ServiceResourceType>.GetResourceByReference(client, reference));
    }

    public static AdminServiceResource GetAdminServiceResourceById(
      vCloudClient client,
      string vCloudId)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
      return new AdminServiceResource(client, VcloudEntity<ServiceResourceType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.serviceResource+xml"));
    }

    public void Delete()
    {
      SdkUtil.Delete<ServiceResourceType>(this.VcloudClient, this.Reference.href, 204);
    }

    public ReferenceType GetAdminResourceClassReference()
    {
      if (this.adminResourceClassRef != null)
        return this.adminResourceClassRef;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
    }

    private void SortAdminServiceResourceLinkRefs()
    {
      if (this.Resource == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.resourceClass+xml"))
          this.adminResourceClassRef = (ReferenceType) linkType;
      }
    }
  }
}
