// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VappNetwork
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk
{
  public class VappNetwork : VcloudEntity<VAppNetworkType>
  {
    private ReferenceType _vappReference;
    private ReferenceType _vappNetworkRepairReference;

    public VappNetwork(vCloudClient client, VAppNetworkType vappNetworkType)
      : base(client, vappNetworkType)
    {
      this.SortReferences_v1_5();
    }

    public static VappNetwork GetVappNetworkByReference(
      vCloudClient client,
      ReferenceType vappNetworkRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vappNetworkRef.href);
        return new VappNetwork(client, VcloudResource<VAppNetworkType>.GetResourceByReference(client, vappNetworkRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VappNetwork GetVappNetworkById(vCloudClient client, string vCloudId)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
      return new VappNetwork(client, VcloudEntity<VAppNetworkType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.network+xml"));
    }

    private void SortReferences_v1_5()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vApp+xml"))
          this._vappReference = (ReferenceType) linkType;
        else if (linkType.rel.Equals("repair"))
          this._vappNetworkRepairReference = (ReferenceType) linkType;
      }
    }

    public Task Reset()
    {
      try
      {
        if (this._vappNetworkRepairReference != null)
          return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this._vappNetworkRepairReference.href, (string) null, (string) null, 202));
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VAPP_NETWORK_NOT_DEPLOYED));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetVappReference()
    {
      try
      {
        if (this._vappReference != null)
          return this._vappReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
