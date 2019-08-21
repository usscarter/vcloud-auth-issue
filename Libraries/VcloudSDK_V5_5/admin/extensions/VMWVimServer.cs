// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VMWVimServer
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VMWVimServer : VcloudEntity<VimServerType>
  {
    private ReferenceType vShieldManagerReference;

    internal VMWVimServer(vCloudClient client, VimServerType vimServerType_v1_5)
      : base(client, vimServerType_v1_5)
    {
      this.SortLinks();
    }

    private void SortLinks()
    {
      if (this.Resource == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.admin.vshieldmanager+xml"))
        {
          this.vShieldManagerReference = (ReferenceType) linkType;
          break;
        }
      }
    }

    public static VMWVimServer GetVMWVimServerByReference(
      vCloudClient client,
      ReferenceType vmwVimServerRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vmwVimServerRef.href);
        return new VMWVimServer(client, VcloudResource<VimServerType>.GetResourceByReference(client, vmwVimServerRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWVimServer GetVMWVimServerById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new VMWVimServer(client, VcloudEntity<VimServerType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.vmwvirtualcenter+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateVMWVimServer(VimServerType vimServerType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<VimServerType>(vimServerType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.vmwvirtualcenter+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task ForceVMWVimServerReconnect()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/forcevimserverreconnect", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task ForceVMWVimServerReconnect(
      vCloudClient client,
      ReferenceType vmwVimServerRef)
    {
      try
      {
        string url = vmwVimServerRef.href + "/action/forcevimserverreconnect";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task RefreshVimServer()
    {
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/refresh", (string) null, (string) null, 202));
    }

    public Task UnregisterVMWVimServer()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/unregister", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task UnregisterVMWVimServer(
      vCloudClient client,
      ReferenceType vmwVimServerRef)
    {
      try
      {
        string url = vmwVimServerRef.href + "/action/unregister";
        return new Task(client, SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, ResourcePoolType> GetResourcePools(
      vCloudClient client,
      ReferenceType vimServerRef)
    {
      try
      {
        string url = vimServerRef.href + "/resourcePoolList";
        return VMWVimServer.GetResourcePools(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ResourcePoolType> GetResourcePools()
    {
      try
      {
        return VMWVimServer.GetResourcePools(this.VcloudClient, this.Reference.href + "/resourcePoolList");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, VimObjectRefType> GetNetworkVimRefsByMoref()
    {
      try
      {
        return VMWVimServer.GetNetworkVimRefsByMoref(this.VcloudClient, this.Reference.href + "/networks");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, VimObjectRefType> GetNetworkVimRefsByMoref(
      vCloudClient client,
      ReferenceType vimServerRef)
    {
      try
      {
        string url = vimServerRef.href + "/networks";
        return VMWVimServer.GetNetworkVimRefsByMoref(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetVMWHostRefsByName()
    {
      try
      {
        return VMWVimServer.GetVMWHostRefsByName(this.VcloudClient, this.Reference.href + "/hostReferences");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, ReferenceType> GetVMWHostRefsByName(
      vCloudClient client,
      ReferenceType vimServerRef)
    {
      try
      {
        string url = vimServerRef.href + "/hostReferences";
        return VMWVimServer.GetVMWHostRefsByName(client, url);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, VmObjectRefType> GetVms()
    {
      try
      {
        return VMWVimServer.GetVms(this.VcloudClient, this.Reference.href + "/vmsList");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, VmObjectRefType> GetVms(
      int page,
      int pageSize)
    {
      try
      {
        return VMWVimServer.GetVms(this.VcloudClient, this.Reference.href + "/vmsList?page=" + (object) page + "&pageSize=" + (object) pageSize);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, VmObjectRefType> GetVms(int page)
    {
      try
      {
        return VMWVimServer.GetVms(this.VcloudClient, this.Reference.href + "/vmsList?page=" + (object) page);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, VmObjectRefType> GetVms(
      vCloudClient client,
      ReferenceType vimServerRef)
    {
      try
      {
        return VMWVimServer.GetVms(client, vimServerRef.href + "/vmsList");
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, VmObjectRefType> GetVms(
      vCloudClient client,
      ReferenceType vimServerRef,
      int page)
    {
      try
      {
        return VMWVimServer.GetVms(client, vimServerRef.href + "/vmsList?page=" + (object) page);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, VmObjectRefType> GetVms(
      vCloudClient client,
      ReferenceType vimServerRef,
      int page,
      int pageSize)
    {
      try
      {
        return VMWVimServer.GetVms(client, vimServerRef.href + "/vmsList?page=" + (object) page + "&pageSize=" + (object) pageSize);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Vapp ImportVmAsVApp(ImportVmAsVAppParamsType importVmAsVAppParamsType)
    {
      try
      {
        string url = this.Reference.href + "/importVmAsVApp";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        string requestString = SerializationUtil.SerializeObject<ImportVmAsVAppParamsType>(importVmAsVAppParamsType, "com.vmware.vcloud.api.rest.schema");
        return new Vapp(this.VcloudClient, SdkUtil.Post<VAppType>(this.VcloudClient, url, requestString, "application/vnd.vmware.admin.importVmAsVAppParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task ImportVmIntoVApp(
      ImportVmIntoExistingVAppParamsType importVmIntoVAppParamsType)
    {
      try
      {
        string url = this.Reference.href + "/importVmIntoExistingVApp";
        string requestString = SerializationUtil.SerializeObject<ImportVmIntoExistingVAppParamsType>(importVmIntoVAppParamsType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.admin.importVmIntoExistingVAppParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VappTemplate ImportVmAsVAppTemplate(
      ImportVmAsVAppTemplateParamsType importVmAsVAppTemplateParamsType)
    {
      try
      {
        string url = this.Resource.href + "/importVmAsVAppTemplate";
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        string requestString = SerializationUtil.SerializeObject<ImportVmAsVAppTemplateParamsType>(importVmAsVAppTemplateParamsType, "com.vmware.vcloud.api.rest.schema");
        return new VappTemplate(this.VcloudClient, SdkUtil.Post<VAppTemplateType>(this.VcloudClient, url, requestString, "application/vnd.vmware.admin.importVmAsVAppTemplateParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Media ImportMedia(ImportMediaParamsType importMediaParamsType)
    {
      try
      {
        string url = this.Reference.href + "/importMedia";
        string requestString = SerializationUtil.SerializeObject<ImportMediaParamsType>(importMediaParamsType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new Media(this.VcloudClient, SdkUtil.Post<com.vmware.vcloud.api.rest.schema.MediaType>(this.VcloudClient, url, requestString, "application/vnd.vmware.admin.importMediaParams+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ShieldManagerType GetvShieldManager()
    {
      try
      {
        if (this.vShieldManagerReference == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + this.vShieldManagerReference.href);
        return SdkUtil.Get<ShieldManagerType>(this.VcloudClient, this.vShieldManagerReference.href, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdatevShieldManager(ShieldManagerType shieldManager)
    {
      try
      {
        if (this.vShieldManagerReference == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        string href = this.vShieldManagerReference.href;
        string requestString = SerializationUtil.SerializeObject<ShieldManagerType>(shieldManager, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.vshieldmanager+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<VMWStorageProfileType> GetVMWStorageProfiles()
    {
      try
      {
        List<VMWStorageProfileType> storageProfileTypeList = new List<VMWStorageProfileType>();
        VMWStorageProfilesType storageProfilesType = SdkUtil.Get<VMWStorageProfilesType>(this.VcloudClient, this.Reference.href + "/storageProfiles", 200);
        if (storageProfilesType.VMWStorageProfile != null)
          storageProfileTypeList = ((IEnumerable<VMWStorageProfileType>) storageProfilesType.VMWStorageProfile).ToList<VMWStorageProfileType>();
        return storageProfileTypeList;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task RefreshStorageProfiles()
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/refreshStorageProfiles", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task RefreshStorageProfiles(
      vCloudClient client,
      ReferenceType vmwVimServerRef)
    {
      try
      {
        return new Task(client, SdkUtil.Post<TaskType>(client, vmwVimServerRef.href + "/action/refreshStorageProfiles", (string) null, (string) null, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public string GetvSphereWebClientUrl(string vimObjectType, string vimObjectMoref)
    {
      return SdkUtil.Get<VSphereWebClientUrlType>(this.VcloudClient, this.Resource.href + "/" + vimObjectType + "/" + vimObjectMoref + "/vSphereWebClientUrl", 200).URL;
    }

    private static Dictionary<string, ReferenceType> GetVMWHostRefsByName(
      vCloudClient client,
      string url)
    {
      try
      {
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VMWHostReferencesType hostReferencesType = SdkUtil.Get<VMWHostReferencesType>(client, url, 200);
        if (hostReferencesType.HostReference != null)
        {
          foreach (ReferenceType referenceType in hostReferencesType.HostReference)
            dictionary.Add(referenceType.name, referenceType);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Dictionary<string, VimObjectRefType> GetNetworkVimRefsByMoref(
      vCloudClient client,
      string url)
    {
      Dictionary<string, VimObjectRefType> dictionary = new Dictionary<string, VimObjectRefType>();
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
      VimObjectRefListType objectRefListType = SdkUtil.Get<VimObjectRefListType>(client, url, 200);
      if (objectRefListType.VimObjectRefs != null)
      {
        foreach (VimObjectRefType vimObjectRef in objectRefListType.VimObjectRefs)
          dictionary.Add(vimObjectRef.MoRef, vimObjectRef);
      }
      return dictionary;
    }

    private static Dictionary<string, ResourcePoolType> GetResourcePools(
      vCloudClient client,
      string url)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        RestUtil.Get(client, url);
        ResourcePoolListType resourcePoolListType = SdkUtil.Get<ResourcePoolListType>(client, url, 200);
        Dictionary<string, ResourcePoolType> dictionary = new Dictionary<string, ResourcePoolType>();
        if (resourcePoolListType != null && resourcePoolListType.ResourcePool != null)
        {
          foreach (ResourcePoolType resourcePoolType in resourcePoolListType.ResourcePool)
          {
            if (!dictionary.ContainsKey(resourcePoolType.name))
              dictionary.Add(resourcePoolType.name, resourcePoolType);
          }
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Dictionary<string, VmObjectRefType> GetVms(
      vCloudClient client,
      string url)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        RestUtil.Get(client, url);
        VmObjectRefsListType objectRefsListType = SdkUtil.Get<VmObjectRefsListType>(client, url, 200);
        Dictionary<string, VmObjectRefType> dictionary = new Dictionary<string, VmObjectRefType>();
        if (objectRefsListType != null && objectRefsListType.VmObjectRef != null)
        {
          foreach (VmObjectRefType vmObjectRefType in objectRefsListType.VmObjectRef)
            dictionary.Add(vmObjectRefType.name, vmObjectRefType);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
