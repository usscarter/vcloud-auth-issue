// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.service.AdminFileDescriptor
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions.service
{
  public class AdminFileDescriptor : VcloudResource<AdminFileDescriptorType>
  {
    private ReferenceType apiDefinitionRef;

    public AdminFileDescriptor(vCloudClient client, AdminFileDescriptorType fileDescResource)
      : base(client, fileDescResource)
    {
      this.SortAdminFileDescriptorRefs();
    }

    public static AdminFileDescriptor GetAdminFileDescriptorByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new AdminFileDescriptor(client, VcloudResource<AdminFileDescriptorType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminFileDescriptor GetAdminFileDescriptorById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + client.VCloudApiURL + "/entity/" + vCloudId);
        foreach (LinkType linkType in SdkUtil.Get<EntityType>(client, client.VCloudApiURL + "/entity/" + vCloudId, 200).Link)
        {
          if (linkType.type.Equals("application/vnd.vmware.admin.fileDescriptor+xml"))
            return new AdminFileDescriptor(client, SdkUtil.Get<AdminFileDescriptorType>(client, linkType.href, 200));
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
        SdkUtil.Delete<FileDescriptorType>(this.VcloudClient, this.Reference.href, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetApiDefinitionReference()
    {
      try
      {
        if (this.apiDefinitionRef != null)
          return this.apiDefinitionRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortAdminFileDescriptorRefs()
    {
      try
      {
        if (this.Resource == null)
          return;
        foreach (LinkType linkType in this.Resource.Link)
        {
          if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.apiDefinition+xml"))
            this.apiDefinitionRef = (ReferenceType) linkType;
        }
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
