// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VMWNetworkPool
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Xml;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VMWNetworkPool : VcloudEntity<VMWNetworkPoolType>
  {
    internal VMWNetworkPool(vCloudClient client, VMWNetworkPoolType vmwNetworkPoolType_v1_5)
      : base(client, vmwNetworkPoolType_v1_5)
    {
    }

    public static VMWNetworkPool GetVMWNetworkPoolByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new VMWNetworkPool(client, VcloudResource<VMWNetworkPoolType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWNetworkPool GetVMWNetworkPoolById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new VMWNetworkPool(client, VcloudEntity<VMWNetworkPoolType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.networkPool+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWNetworkPool UpdateVMWNetworkPool(VMWNetworkPoolType vmwNetworkPoolType)
    {
      try
      {
        vmwNetworkPoolType.AnyAttr = (XmlAttribute[]) null;
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<VMWNetworkPoolType>(vmwNetworkPoolType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new VMWNetworkPool(this.VcloudClient, SdkUtil.Put<VMWNetworkPoolType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.networkPool+xml", 200));
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
        return VMWNetworkPool.DeleteVMWNetworkPool(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType vmwNetworkPoolRef)
    {
      try
      {
        return VMWNetworkPool.DeleteVMWNetworkPool(client, vmwNetworkPoolRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VendorServicesType GetVMWVendorServices()
    {
      return SdkUtil.Get<VendorServicesType>(this.VcloudClient, this.Reference.href + "/vendorServices", 200);
    }

    private static Task DeleteVMWNetworkPool(vCloudClient client, string vmwNetworkPoolUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, vmwNetworkPoolUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
