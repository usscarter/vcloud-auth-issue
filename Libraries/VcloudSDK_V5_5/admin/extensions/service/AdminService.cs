// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminService
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminService : VcloudEntity<AdminServiceType>
  {
    public AdminService(vCloudClient client, AdminServiceType serviceResource)
      : base(client, serviceResource)
    {
    }

    public static AdminService GetAdminServiceByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
      return new AdminService(client, VcloudResource<AdminServiceType>.GetResourceByReference(client, reference));
    }

    public static AdminService GetAdminServiceById(vCloudClient client, string vCloudId)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
      return new AdminService(client, VcloudEntity<AdminServiceType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.service+xml"));
    }

    public AdminService UpdateAdminService(AdminServiceType serviceParams)
    {
      return new AdminService(this.VcloudClient, SdkUtil.Put<AdminServiceType>(this.VcloudClient, this.Resource.href, SerializationUtil.SerializeObject<AdminServiceType>(serviceParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.service+xml", 200));
    }

    public void Delete()
    {
      SdkUtil.Delete<AdminServiceType>(this.VcloudClient, this.Reference.href, 204);
    }

    public Right CreateRight(RightType rightType)
    {
      return new Right(this.VcloudClient, SdkUtil.Post<RightType>(this.VcloudClient, this.Resource.href + "/rights", SerializationUtil.SerializeObject<RightType>(rightType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.right+xml", 201));
    }

    public AdminServiceLink CreateAdminLink(AdminServiceLinkType serviceLinkParams)
    {
      return new AdminServiceLink(this.VcloudClient, SdkUtil.Post<AdminServiceLinkType>(this.VcloudClient, this.Resource.href + "/links", SerializationUtil.SerializeObject<AdminServiceLinkType>(serviceLinkParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.serviceLink+xml", 201));
    }

    public AdminApiDefinition CreateAdminApiDefinition(
      AdminApiDefinitionType apiDefinitionParams)
    {
      return new AdminApiDefinition(this.VcloudClient, SdkUtil.Post<AdminApiDefinitionType>(this.VcloudClient, this.Resource.href + "/apidefinitions", SerializationUtil.SerializeObject<AdminApiDefinitionType>(apiDefinitionParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.apiDefinition+xml", 201));
    }

    public AdminResourceClass RegisterAdminResourceClass(
      ResourceClassType resourceClassParams)
    {
      return new AdminResourceClass(this.VcloudClient, SdkUtil.Post<ResourceClassType>(this.VcloudClient, this.Resource.href + "/resourceclasses", SerializationUtil.SerializeObject<ResourceClassType>(resourceClassParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.resourceClass+xml", 201));
    }

    public AdminApiFilter CreateAdminApiFilter(ApiFilterType apiFilterParams)
    {
      return new AdminApiFilter(this.VcloudClient, SdkUtil.Post<ApiFilterType>(this.VcloudClient, this.Resource.href + "/apifilters", SerializationUtil.SerializeObject<ApiFilterType>(apiFilterParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.apiFilter+xml", 201));
    }

    public List<ReferenceType> GetRightRefs()
    {
      RightRefsType rightRefsType = SdkUtil.Get<RightRefsType>(this.VcloudClient, this.Resource.href + "/rights", 200);
      if (rightRefsType.Right == null)
        return new List<ReferenceType>();
      return ((IEnumerable<ReferenceType>) rightRefsType.Right).ToList<ReferenceType>();
    }

    public ReferenceResult GetAdminLinkRefs()
    {
      return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/links?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
    }

    public ReferenceResult GetAdminApiDefinitionRefs()
    {
      return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultAdminApiDefinitionRecordType>(this.Reference.href + "/apidefinitions?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
    }

    public ReferenceResult GetAdminResourceClassRefs()
    {
      return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/resourceclasses?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
    }

    public ReferenceResult GetAdminApiFilterRefs()
    {
      return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/apifilters?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
    }

    public bool IsAuthorized(
      AuthorizationCheckParamsType authorizationCheckParamsType)
    {
      try
      {
        return SdkUtil.Post<AuthorizationCheckResponseType>(this.VcloudClient, this.Resource.href + "/authorizationcheck", SerializationUtil.SerializeObject<AuthorizationCheckParamsType>(authorizationCheckParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.authorizationCheckParams+xml", 200).IsAuthorized;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminService Disable()
    {
      try
      {
        AdminServiceType resource = this.Resource;
        resource.Enabled = false;
        return this.UpdateAdminService(resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Right CreateRight(
      string rightName,
      string rightDescription,
      string rightCategory,
      string bundleKey,
      string operationKey,
      string serviceNamespace)
    {
      try
      {
        RightType rightType = new RightType();
        rightType.name = rightName;
        rightType.Description = rightDescription;
        rightType.Category = rightCategory;
        rightType.BundleKey = bundleKey;
        rightType.operationKey = operationKey;
        rightType.ServiceNamespace = serviceNamespace;
        return this.CreateRight(rightType);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminServiceLink CreateServiceLink(
      string linkHref,
      string relation,
      string resourceType,
      string mimeType,
      string resourceId)
    {
      try
      {
        return this.CreateAdminLink(new AdminServiceLinkType()
        {
          LinkHref = linkHref,
          Rel = relation,
          ResourceType1 = resourceType,
          MimeType = mimeType,
          ResourceId = resourceId
        });
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminResourceClass RegisterResourceClass(
      string name,
      string type,
      string nid,
      string urlTemplate,
      string urnPattern,
      string mimeType)
    {
      try
      {
        ResourceClassType resourceClassParams = new ResourceClassType();
        resourceClassParams.MimeType = mimeType;
        resourceClassParams.UrlTemplate = urlTemplate;
        resourceClassParams.UrnPattern = urnPattern;
        resourceClassParams.type = type;
        resourceClassParams.Nid = nid;
        resourceClassParams.name = name;
        return this.RegisterAdminResourceClass(resourceClassParams);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminApiFilter CreateURLFilter(List<string> urlPatterns)
    {
      try
      {
        ApiFilterType apiFilterParams = new ApiFilterType();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string urlPattern in urlPatterns)
          stringBuilder.Append("(").Append(urlPattern).Append(")|");
        apiFilterParams.UrlPattern = stringBuilder.ToString();
        return this.CreateAdminApiFilter(apiFilterParams);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminApiFilter CreateResponseContentFilter(string responseContentType)
    {
      return this.CreateAdminApiFilter(new ApiFilterType()
      {
        ResponseContentType = responseContentType
      });
    }
  }
}
