// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminResourceClassAction
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminResourceClassAction : VcloudEntity<ResourceClassActionType>
  {
    private ReferenceType adminResourceClassRef;

    public AdminResourceClassAction(
      vCloudClient client,
      ResourceClassActionType resourceClassActionParams)
      : base(client, resourceClassActionParams)
    {
      this.SortAdminResourceClassActionLinkRefs();
    }

    public static AdminResourceClassAction GetAdminResourceClassActionByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new AdminResourceClassAction(client, VcloudResource<ResourceClassActionType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminResourceClassAction GetAdminResourceClassActionById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminResourceClassAction(client, VcloudEntity<ResourceClassActionType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.resourceClassAction+xml"));
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
        SdkUtil.Delete<ResourceClassActionType>(this.VcloudClient, this.Reference.href, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetAdminResourceClassReference()
    {
      try
      {
        if (this.adminResourceClassRef != null)
          return this.adminResourceClassRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminAclRule RegisterAdminAclRule(AclRuleType aclRuleParams)
    {
      try
      {
        return new AdminAclRule(this.VcloudClient, SdkUtil.Post<AclRuleType>(this.VcloudClient, this.Resource.href + "/aclrules", SerializationUtil.SerializeObject<AclRuleType>(aclRuleParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.aclRule+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetAdminAclRuleRefs()
    {
      try
      {
        return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/aclrules?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminAclRule RegisterACLRule(
      string ruleName,
      AclAccessType serviceAclAccess,
      AclAccessType orgAccess,
      AclAccessType principalAccess)
    {
      try
      {
        AclRuleType aclRuleParams = new AclRuleType();
        aclRuleParams.name = ruleName;
        aclRuleParams.ServiceResourceAccess = serviceAclAccess;
        aclRuleParams.OrganizationAccess = orgAccess;
        aclRuleParams.PrincipalAccess = principalAccess;
        return this.RegisterAdminAclRule(aclRuleParams);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortAdminResourceClassActionLinkRefs()
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
