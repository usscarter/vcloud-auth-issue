// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminOrgVdcNetwork
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk.admin
{
  public class AdminOrgVdcNetwork : VcloudEntity<OrgVdcNetworkType>
  {
    private ReferenceType adminVdcReference;

    internal AdminOrgVdcNetwork(vCloudClient client, OrgVdcNetworkType orgVdcNetworkType)
      : base(client, orgVdcNetworkType)
    {
      this.SortRefs();
    }

    public ReferenceType GetAdminVdcReference()
    {
      if (this.adminVdcReference != null)
        return this.adminVdcReference;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
    }

    public NetworkConfigurationType GetConfiguration()
    {
      try
      {
        return this.Resource.Configuration;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminOrgVdcNetwork GetOrgVdcNetworkByReference(
      vCloudClient client,
      ReferenceType adminOrgVdcNetworkRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + adminOrgVdcNetworkRef.href);
        return new AdminOrgVdcNetwork(client, VcloudResource<OrgVdcNetworkType>.GetResourceByReference(client, adminOrgVdcNetworkRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminOrgVdcNetwork GetOrgVdcNetworkById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminOrgVdcNetwork(client, VcloudEntity<OrgVdcNetworkType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.network+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateOrgVdcNetwork(OrgVdcNetworkType orgVdcNetworkType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<OrgVdcNetworkType>(orgVdcNetworkType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.vcloud.orgVdcNetwork+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<AllocatedIpAddress> GetAllocatedAddresses()
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + this.Resource.href + "/allocatedAddresses");
        AllocatedIpAddressesType allocatedIpAddressesType = SdkUtil.Get<AllocatedIpAddressesType>(this.VcloudClient, this.Resource.href + "/allocatedAddresses", 200);
        List<AllocatedIpAddress> allocatedIpAddressList = new List<AllocatedIpAddress>();
        if (allocatedIpAddressesType.IpAddress != null)
        {
          foreach (AllocatedIpAddressType resourceType in allocatedIpAddressesType.IpAddress)
            allocatedIpAddressList.Add(new AllocatedIpAddress(this.VcloudClient, resourceType));
        }
        return allocatedIpAddressList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Reset()
    {
      return AdminOrgVdcNetwork.ExecuteAction(this.VcloudClient, this.Reference.href + "/action/reset", (string) null, (string) null, 202);
    }

    public static Task Reset(vCloudClient client, ReferenceType adminOrgNetworkReference)
    {
      return AdminOrgVdcNetwork.ExecuteAction(client, adminOrgNetworkReference.href + "/action/reset", (string) null, (string) null, 202);
    }

    public Task Delete()
    {
      try
      {
        return AdminOrgVdcNetwork.DeleteOrgVdcNetwork(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType adminOrgVdcNetworkRef)
    {
      try
      {
        return AdminOrgVdcNetwork.DeleteOrgVdcNetwork(client, adminOrgVdcNetworkRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortRefs()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.vdc+xml"))
          this.adminVdcReference = (ReferenceType) linkType;
      }
    }

    private static Task DeleteOrgVdcNetwork(vCloudClient client, string orgVdcNetworkUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, orgVdcNetworkUrl, 202));
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
  }
}
