// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.OrgVdcNetwork
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk
{
  public class OrgVdcNetwork : VcloudEntity<OrgVdcNetworkType>
  {
    private ReferenceType _vdcReference;

    internal OrgVdcNetwork(vCloudClient client, OrgVdcNetworkType orgVdcNetworkType)
      : base(client, orgVdcNetworkType)
    {
      this.SortRefs();
    }

    private void SortRefs()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
          this._vdcReference = (ReferenceType) linkType;
      }
    }

    public ReferenceType GetVdcReference()
    {
      try
      {
        if (this._vdcReference != null)
          return this._vdcReference;
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

    public static OrgVdcNetwork GetOrgVdcNetworkByReference(
      vCloudClient client,
      ReferenceType orgVdcNetworkRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + orgVdcNetworkRef.href);
        return new OrgVdcNetwork(client, VcloudResource<OrgVdcNetworkType>.GetResourceByReference(client, orgVdcNetworkRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static OrgVdcNetwork GetOrgVdcNetworkById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new OrgVdcNetwork(client, VcloudEntity<OrgVdcNetworkType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.network+xml"));
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
  }
}
