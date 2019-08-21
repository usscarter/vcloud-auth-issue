// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminApiDefinition
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminApiDefinition : VcloudEntity<AdminApiDefinitionType>
  {
    private ReferenceType adminServiceRef;

    public AdminApiDefinition(vCloudClient client, AdminApiDefinitionType apiDefinitionParams)
      : base(client, apiDefinitionParams)
    {
      this.SortAdminApiDefinitionRefs();
    }

    public static AdminApiDefinition GetAdminApiDefinitionByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new AdminApiDefinition(client, VcloudResource<AdminApiDefinitionType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminApiDefinition GetAdminApiDefinitionById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminApiDefinition(client, VcloudEntity<AdminApiDefinitionType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.apiDefinition+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminFileDescriptor CreateAdminFileDescriptor(
      AdminFileDescriptorType fileDescParams)
    {
      try
      {
        return new AdminFileDescriptor(this.VcloudClient, SdkUtil.Post<AdminFileDescriptorType>(this.VcloudClient, this.Resource.href + "/files", SerializationUtil.SerializeObject<AdminFileDescriptorType>(fileDescParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.fileDescriptor+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult GetAdminFileDescriptorRefs()
    {
      try
      {
        return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultAdminFileDescriptorRecordType>(this.Reference.href + "/files?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
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
        SdkUtil.Delete<ApiDefinitionType>(this.VcloudClient, this.Reference.href, 204);
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

    private void SortAdminApiDefinitionRefs()
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
