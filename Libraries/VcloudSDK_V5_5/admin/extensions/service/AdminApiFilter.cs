// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminApiFilter
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminApiFilter : VcloudResource<ApiFilterType>
  {
    private ReferenceType serviceRef;

    internal AdminApiFilter(vCloudClient client, ApiFilterType apiFilterResource)
      : base(client, apiFilterResource)
    {
      this.SortApiFilterRefs();
    }

    public static AdminApiFilter GetApiFilterByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new AdminApiFilter(client, VcloudResource<ApiFilterType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminApiFilter GetApiFilterById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + client.VCloudApiURL + "/entity/" + vCloudId);
        foreach (LinkType linkType in SdkUtil.Get<EntityType>(client, client.VCloudApiURL + "/entity/" + vCloudId, 200).Link)
        {
          if (linkType.type.Equals("application/vnd.vmware.admin.apiFilter+xml"))
            return new AdminApiFilter(client, SdkUtil.Get<ApiFilterType>(client, linkType.href, 200));
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void Delete()
    {
      try
      {
        SdkUtil.Delete<ApiFilterType>(this.VcloudClient, this.Reference.href, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetServiceReference()
    {
      try
      {
        if (this.serviceRef != null)
          return this.serviceRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortApiFilterRefs()
    {
      if (this.Resource == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.service+xml"))
          this.serviceRef = (ReferenceType) linkType;
      }
    }
  }
}
