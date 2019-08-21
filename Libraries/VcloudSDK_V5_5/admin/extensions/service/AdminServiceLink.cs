// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminServiceLink
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminServiceLink : VcloudResource<AdminServiceLinkType>
  {
    private ReferenceType adminServiceRef;

    internal AdminServiceLink(vCloudClient client, AdminServiceLinkType serviceLinkResource)
      : base(client, serviceLinkResource)
    {
      this.SortAdminServiceLinkRefs();
    }

    public static AdminServiceLink GetAdminServiceLinkByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new AdminServiceLink(client, VcloudResource<AdminServiceLinkType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminServiceLink GetAdminServiceLinkById(
      vCloudClient client,
      string vCloudId)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + client.VCloudApiURL + "/entity/" + vCloudId);
      foreach (LinkType linkType in SdkUtil.Get<EntityType>(client, client.VCloudApiURL + "/entity/" + vCloudId, 200).Link)
      {
        if (linkType.type.Equals("application/vnd.vmware.admin.serviceLink+xml"))
          return new AdminServiceLink(client, SdkUtil.Get<AdminServiceLinkType>(client, linkType.href, 200));
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
    }

    public void Delete()
    {
      try
      {
        SdkUtil.Delete<AdminServiceLinkType>(this.VcloudClient, this.Reference.href, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetAdminServiceReference()
    {
      try
      {
        if (this.adminServiceRef != null)
          return this.adminServiceRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortAdminServiceLinkRefs()
    {
      if (this.Resource == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.service+xml"))
          this.adminServiceRef = (ReferenceType) linkType;
      }
    }
  }
}
