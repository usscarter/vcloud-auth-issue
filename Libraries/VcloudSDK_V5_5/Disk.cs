// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Disk
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;

namespace com.vmware.vcloud.sdk
{
  public class Disk : VcloudEntity<DiskType>
  {
    private ReferenceType vdcReference;

    public Disk(vCloudClient client, DiskType diskType)
      : base(client, diskType)
    {
      this.SortDiskFilesAndReferences();
    }

    public static Disk GetDiskByReference(vCloudClient client, ReferenceType diskRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + diskRef.href);
        return new Disk(client, VcloudResource<DiskType>.GetResourceByReference(client, diskRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Disk GetDiskById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new Disk(client, VcloudEntity<DiskType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.disk+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateDisk(string name, string description, ReferenceType storageProfileRef)
    {
      try
      {
        string href = this.Resource.href;
        if (name != null)
          this.Resource.name = name;
        if (description != null)
          this.Resource.Description = description;
        if (storageProfileRef != null)
          this.Resource.StorageProfile = storageProfileRef;
        string requestString = SerializationUtil.SerializeObject<DiskType>(this.Resource, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.vcloud.disk+xml", 202));
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
        return Disk.DeleteDisk(this.VcloudClient, this.Resource.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType diskRef)
    {
      try
      {
        return Disk.DeleteDisk(client, diskRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetVdcReference()
    {
      try
      {
        if (this.vdcReference != null)
          return this.vdcReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetOwner()
    {
      return this.Resource.Owner.User;
    }

    public BusType GetBus()
    {
      return BusType.FromValue(this.Resource.busType);
    }

    public BusSubType GetBusSub()
    {
      return BusSubType.FromValue(this.Resource.busSubType);
    }

    public static void ChangeOwner(
      vCloudClient client,
      ReferenceType diskRef,
      ReferenceType userReference)
    {
      try
      {
        Disk.ChangeOwner(diskRef.href + "/owner", userReference, client);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ChangeOwner(ReferenceType userReference)
    {
      try
      {
        Disk.ChangeOwner(this.Resource.href + "/owner", userReference, this.VcloudClient);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetAttachedVms()
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + this.Resource.href + "/attachedVms");
        VmsType vmsType = SdkUtil.Get<VmsType>(this.VcloudClient, this.Reference.href + "/attachedVms", 200);
        List<ReferenceType> referenceTypeList = new List<ReferenceType>();
        if (vmsType.VmReference == null)
          return new List<ReferenceType>();
        foreach (ReferenceType referenceType in vmsType.VmReference)
          referenceTypeList.Add(referenceType);
        return referenceTypeList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Task DeleteDisk(vCloudClient client, string diskUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, diskUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortDiskFilesAndReferences()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
          this.vdcReference = (ReferenceType) linkType;
      }
    }

    private static void ChangeOwner(string url, ReferenceType userReference, vCloudClient client)
    {
      try
      {
        string requestString = SerializationUtil.SerializeObject<OwnerType>(new OwnerType()
        {
          User = userReference
        }, "com.vmware.vcloud.api.rest.schema");
        SdkUtil.Put<OwnerType>(client, url, requestString, "application/vnd.vmware.vcloud.owner+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
