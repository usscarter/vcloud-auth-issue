// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VMWExternalNetwork
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VMWExternalNetwork : VcloudEntity<VMWExternalNetworkType>
  {
    private ReferenceType _externalNetworkReference;

    internal VMWExternalNetwork(
      vCloudClient client,
      VMWExternalNetworkType vmwExternalNetworkType_v1_5)
      : base(client, vmwExternalNetworkType_v1_5)
    {
      this.SortReferences_v1_5();
    }

    public static VMWExternalNetwork GetVMWExternalNetworkByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new VMWExternalNetwork(client, VcloudResource<VMWExternalNetworkType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWExternalNetwork GetVMWExternalNetworkById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + client.VCloudApiURL + "/entity/" + vCloudId);
        foreach (LinkType linkType in SdkUtil.Get<EntityType>(client, client.VCloudApiURL + "/entity/" + vCloudId, 200).Link)
        {
          if (linkType.type.Equals("application/vnd.vmware.admin.vmwexternalnet+xml") || linkType.href.Contains("/externalnet/"))
            return new VMWExternalNetwork(client, SdkUtil.Get<VMWExternalNetworkType>(client, linkType.href, 200));
        }
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetExternalNetworkReference()
    {
      try
      {
        if (this._externalNetworkReference != null)
          return this._externalNetworkReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetPortGroupVimRef()
    {
      return this.Resource.VimPortGroupRef;
    }

    public VMWExternalNetwork UpdateVMWExternalNetwork(
      VMWExternalNetworkType vmwExternalNetworkType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<VMWExternalNetworkType>(vmwExternalNetworkType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new VMWExternalNetwork(this.VcloudClient, SdkUtil.Put<VMWExternalNetworkType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.vmwexternalnet+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task Delete()
    {
      try
      {
        return VMWExternalNetwork.DeleteVMWExternalNetwork(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType vmwExternalNetworkRef)
    {
      try
      {
        return VMWExternalNetwork.DeleteVMWExternalNetwork(client, vmwExternalNetworkRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1.This API method will not work with SDK 5.1")]
    public Task Reset()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.GetExternalNetworkReference().href + "/action/reset", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1.This API method will not work with SDK 5.1")]
    public static Task Reset(vCloudClient client, ReferenceType externalNetworkReference)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, externalNetworkReference.href + "/action/reset", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortReferences_v1_5()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.admin.network+xml"))
        {
          this._externalNetworkReference = (ReferenceType) linkType;
          break;
        }
      }
    }

    private static Task DeleteVMWExternalNetwork(
      vCloudClient client,
      string vmwExternalNetworkUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, vmwExternalNetworkUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
