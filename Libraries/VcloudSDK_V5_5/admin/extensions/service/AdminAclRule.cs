// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminAclRule
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminAclRule : VcloudEntity<AclRuleType>
  {
    private ReferenceType adminResourceClassActionRef;

    public AdminAclRule(vCloudClient client, AclRuleType aclRuleParams)
      : base(client, aclRuleParams)
    {
      this.SortAdminAclRuleLinkRefs();
    }

    public static AdminAclRule GetAdminAclRuleByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new AdminAclRule(client, VcloudResource<AclRuleType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminAclRule GetAdminAclRuleById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminAclRule(client, VcloudEntity<AclRuleType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.aclRule+xml"));
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
        SdkUtil.Delete<AclRuleType>(this.VcloudClient, this.Reference.href, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetAdminResourceClassActionReference()
    {
      try
      {
        if (this.adminResourceClassActionRef != null)
          return this.adminResourceClassActionRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortAdminAclRuleLinkRefs()
    {
      try
      {
        if (this.Resource == null)
          return;
        foreach (LinkType linkType in this.Resource.Link)
        {
          if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.resourceClassAction+xml"))
            this.adminResourceClassActionRef = (ReferenceType) linkType;
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
