// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VMWDatastore
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VMWDatastore : VcloudEntity<DatastoreType>
  {
    private VMWDatastore(vCloudClient client, DatastoreType VMWDatastoreType_v1_5)
      : base(client, VMWDatastoreType_v1_5)
    {
    }

    public static VMWDatastore GetVMWDatastoreByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new VMWDatastore(client, VcloudResource<DatastoreType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWDatastore GetVMWDatastoreById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new VMWDatastore(client, VcloudEntity<DatastoreType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.datastore+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWDatastore UpdateVMWDatastore(DatastoreType vmwDatastoreType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<DatastoreType>(vmwDatastoreType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new VMWDatastore(this.VcloudClient, SdkUtil.Put<DatastoreType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.datastore+xml", 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWDatastore Disable()
    {
      try
      {
        return new VMWDatastore(this.VcloudClient, SdkUtil.Post<DatastoreType>(this.VcloudClient, this.Reference.href + "/action/disable", (string) null, (string) null, 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWDatastore Disable(
      vCloudClient client,
      ReferenceType vmwDatastoreRef)
    {
      try
      {
        string url = vmwDatastoreRef.href + "/action/disable";
        return new VMWDatastore(client, SdkUtil.Post<DatastoreType>(client, url, (string) null, (string) null, 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWDatastore Enable()
    {
      try
      {
        return new VMWDatastore(this.VcloudClient, SdkUtil.Post<DatastoreType>(this.VcloudClient, this.Reference.href + "/action/enable", (string) null, (string) null, 200));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWDatastore Enable(
      vCloudClient client,
      ReferenceType vmwDatastoreRef)
    {
      try
      {
        string url = vmwDatastoreRef.href + "/action/enable";
        return new VMWDatastore(client, SdkUtil.Post<DatastoreType>(client, url, (string) null, (string) null, 200));
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
        SdkUtil.Delete<VMWDatastore>(this.VcloudClient, this.Reference.href, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType vmwDatastoreRef)
    {
      try
      {
        SdkUtil.Delete<VMWDatastore>(client, vmwDatastoreRef.href, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetDatastoreVimRef()
    {
      try
      {
        if (this.Resource.VimObjectRef != null)
          return this.Resource.VimObjectRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
