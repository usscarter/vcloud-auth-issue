// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminOrgNetwork
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Xml;

namespace com.vmware.vcloud.sdk.admin
{
  [Obsolete("This AdminOrgNetwork class is obsolete since SDK 5.1;AdminOrgNetwork helper class works only for API 1.5. For API 5.1 use the AdminOrgVdcNetwork instead.")]
  public class AdminOrgNetwork : VcloudEntity<OrgNetworkType>
  {
    private ReferenceType _orgNetworkReference;
    private ReferenceType _adminOrgReference;

    internal AdminOrgNetwork(vCloudClient client, OrgNetworkType orgNetworkType_v1_5)
      : base(client, orgNetworkType_v1_5)
    {
      this.SortRefs_v1_5();
    }

    public ReferenceType GetAdminOrganizationReference()
    {
      try
      {
        if (this._adminOrgReference != null)
          return this._adminOrgReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetOrgNetworkReference()
    {
      try
      {
        if (this._orgNetworkReference != null)
          return this._orgNetworkReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public NetworkConfigurationType GetConfiguration()
    {
      return this.Resource.Configuration;
    }

    public VimObjectRefType GetNetworkVimRef()
    {
      if (this.Resource.VCloudExtension != null)
      {
        foreach (VCloudExtensionType vcloudExtensionType in this.Resource.VCloudExtension)
        {
          if (vcloudExtensionType.Any != null)
          {
            XmlElement[] any = vcloudExtensionType.Any;
            int index = 0;
            if (index < any.Length)
              return Response.GetResource<VimObjectRefType>(any[index].OuterXml);
          }
        }
      }
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
    }

    public static AdminOrgNetwork GetOrgNetworkByReference(
      vCloudClient client,
      ReferenceType orgNetworkRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + orgNetworkRef.href);
        return new AdminOrgNetwork(client, VcloudResource<OrgNetworkType>.GetResourceByReference(client, orgNetworkRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminOrgNetwork GetOrgNetworkById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminOrgNetwork(client, VcloudEntity<OrgNetworkType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.network+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateOrgNetwork(OrgNetworkType orgNetworkType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<OrgNetworkType>(orgNetworkType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.orgNetwork+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Reset()
    {
      return AdminOrgNetwork.ExecuteAction(this.VcloudClient, this.Reference.href + "/action/reset", (string) null, (string) null, 202);
    }

    public static Task Reset(vCloudClient client, ReferenceType adminOrgNetworkReference)
    {
      try
      {
        return AdminOrgNetwork.ExecuteAction(client, adminOrgNetworkReference.href + "/action/reset", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task SyncSyslogServer()
    {
      try
      {
        return AdminOrgNetwork.ExecuteAction(this.VcloudClient, this.Reference.href + "/action/syncSyslogServerSettings", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task SyncSyslogServer(
      vCloudClient client,
      ReferenceType adminOrgNetworkReference)
    {
      try
      {
        return AdminOrgNetwork.ExecuteAction(client, adminOrgNetworkReference.href + "/action/syncSyslogServerSettings", (string) null, (string) null, 202);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Delete()
    {
      return AdminOrgNetwork.DeleteOrgNetwork(this.VcloudClient, this.Reference.href);
    }

    public static Task Delete(vCloudClient client, ReferenceType orgNetworkRef)
    {
      try
      {
        return AdminOrgNetwork.DeleteOrgNetwork(client, orgNetworkRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortRefs_v1_5()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (this._adminOrgReference != null && this._orgNetworkReference != null)
          break;
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.organization+xml"))
          this._adminOrgReference = (ReferenceType) linkType;
        else if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.vcloud.orgNetwork+xml"))
          this._orgNetworkReference = (ReferenceType) linkType;
      }
    }

    private static Task DeleteOrgNetwork(vCloudClient client, string orgNetworkUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, orgNetworkUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Task ExecuteAction(
      vCloudClient client,
      string adminOrgActionUrl,
      string content,
      string contentType,
      int statusCode)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, adminOrgActionUrl, content, contentType, statusCode));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    protected new void Dispose(bool disposing)
    {
    }

    public new void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
