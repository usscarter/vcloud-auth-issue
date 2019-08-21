// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminResourceClass
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminResourceClass : VcloudEntity<ResourceClassType>
  {
    private ReferenceType adminServiceRef;

    internal AdminResourceClass(vCloudClient client, ResourceClassType resourceClassParams)
      : base(client, resourceClassParams)
    {
      this.SortAdminResourceClassLinkRefs();
    }

    public static AdminResourceClass GetAdminResourceClassByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new AdminResourceClass(client, VcloudResource<ResourceClassType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminResourceClass GetAdminResourceClassById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminResourceClass(client, VcloudEntity<ResourceClassType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.resourceClass+xml"));
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
        SdkUtil.Delete<ResourceClassType>(this.VcloudClient, this.Reference.href, 204);
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

    public AdminResourceClassAction RegisterAdminResourceClassAction(
      ResourceClassActionType resourceClassActionParams)
    {
      try
      {
        return new AdminResourceClassAction(this.VcloudClient, SdkUtil.Post<ResourceClassActionType>(this.VcloudClient, this.Resource.href + "/resourceclassactions", SerializationUtil.SerializeObject<ResourceClassActionType>(resourceClassActionParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.resourceClassAction+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetAdminResourceClassActionRefs()
    {
      try
      {
        return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/resourceclassactions?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminServiceResource RegisterAdminServiceResource(
      ServiceResourceType serviceResParams)
    {
      try
      {
        return new AdminServiceResource(this.VcloudClient, SdkUtil.Post<ServiceResourceType>(this.VcloudClient, this.Resource.href + "/serviceresources", SerializationUtil.SerializeObject<ServiceResourceType>(serviceResParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.serviceResource+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetAdminServiceResourceRefs()
    {
      try
      {
        return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/serviceresources?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminResourceClassAction RegisterResourceClassAction(
      string actionName,
      string actionHttpMethod,
      string actionURLPattern,
      string actionOperationKey)
    {
      try
      {
        ResourceClassActionType resourceClassActionParams = new ResourceClassActionType();
        resourceClassActionParams.name = actionName;
        resourceClassActionParams.HttpMethod = actionHttpMethod;
        resourceClassActionParams.UrlPattern = actionURLPattern;
        resourceClassActionParams.operationKey = actionOperationKey;
        return this.RegisterAdminResourceClassAction(resourceClassActionParams);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortAdminResourceClassLinkRefs()
    {
      try
      {
        if (this.Resource == null)
          return;
        foreach (LinkType linkType in this.Resource.Link)
        {
          if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.service+xml"))
            this.adminServiceRef = (ReferenceType) linkType;
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
