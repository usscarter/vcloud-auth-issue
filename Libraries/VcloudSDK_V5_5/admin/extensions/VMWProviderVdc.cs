// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.VMWProviderVdc
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class VMWProviderVdc : VcloudEntity<VMWProviderVdcType>
  {
    private Dictionary<string, ReferenceType> _externalNetworkRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _vmwNetworkPoolRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _vmwHostRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, VMWProviderVdcResourcePoolType> _vmwProvVdcResPoolsByMoref = new Dictionary<string, VMWProviderVdcResourcePoolType>();
    private ReferenceType _providerVdcReference;
    private ReferenceType _vdcReferences;

    internal VMWProviderVdc(vCloudClient client, VMWProviderVdcType vmwProviderVdcType_v1_5)
      : base(client, vmwProviderVdcType_v1_5)
    {
      this.SortReferences_v1_5();
    }

    public static VMWProviderVdc GetVMWProviderVdcByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new VMWProviderVdc(client, VcloudResource<VMWProviderVdcType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static VMWProviderVdc GetVMWProviderVdcById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new VMWProviderVdc(client, VcloudEntity<VMWProviderVdcType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.vmwprovidervdc+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetProviderVdcReference()
    {
      try
      {
        if (this._providerVdcReference != null)
          return this._providerVdcReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VMWProviderVdc UpdateVMWProviderVdc(VMWProviderVdcType vmwProviderVdcType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<VMWProviderVdcType>(vmwProviderVdcType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new VMWProviderVdc(this.VcloudClient, SdkUtil.Put<VMWProviderVdcType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.vmwprovidervdc+xml", 200));
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
        return VMWProviderVdc.DeleteVMWProviderVdc(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType vmwProviderVdcRef)
    {
      try
      {
        return VMWProviderVdc.DeleteVMWProviderVdc(client, vmwProviderVdcRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void Disable()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/disable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Disable(vCloudClient client, ReferenceType vmwProviderVdcRef)
    {
      try
      {
        string url = vmwProviderVdcRef.href + "/action/disable";
        SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void Enable()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/enable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Enable(vCloudClient client, ReferenceType vmwProviderVdcRef)
    {
      try
      {
        string url = vmwProviderVdcRef.href + "/action/enable";
        SdkUtil.Post<TaskType>(client, url, (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetAdminVdcRefsByName()
    {
      try
      {
        return VMWProviderVdc.GetAdminVdcRefs(this.VcloudClient, this._vdcReferences.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<ReferenceType> GetVMWVimServerRefs()
    {
      return ((IEnumerable<ReferenceType>) this.Resource.VimServer).ToList<ReferenceType>();
    }

    public List<VimObjectRefType> GetResourcePoolVimRefs()
    {
      try
      {
        if (this.Resource.ResourcePoolRefs != null)
          return ((IEnumerable<VimObjectRefType>) this.Resource.ResourcePoolRefs).ToList<VimObjectRefType>();
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, VMWProviderVdcResourcePoolType> GetResourcePoolsByMoref()
    {
      try
      {
        if (this._vmwProvVdcResPoolsByMoref == null || this._vmwProvVdcResPoolsByMoref.Count == 0)
          this._vmwProvVdcResPoolsByMoref = VMWProviderVdc.GetResourcePools(this.VcloudClient, this.Reference);
        return this._vmwProvVdcResPoolsByMoref;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Dictionary<string, VMWProviderVdcResourcePoolType> GetResourcePoolsByMoref(
      vCloudClient client,
      ReferenceType vmwProvVdcRef)
    {
      try
      {
        return VMWProviderVdc.GetResourcePools(client, vmwProvVdcRef);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateResourcePools(
      List<VimObjectRefType> resourcePoolVimRefs,
      List<ReferenceType> resourcePoolRefs)
    {
      try
      {
        UpdateResourcePoolSetParamsType poolSetParamsType = new UpdateResourcePoolSetParamsType();
        ((IEnumerable<VimObjectRefType>) poolSetParamsType.AddItem).ToList<VimObjectRefType>().AddRange((IEnumerable<VimObjectRefType>) resourcePoolVimRefs);
        ((IEnumerable<ReferenceType>) poolSetParamsType.DeleteItem).ToList<ReferenceType>().AddRange((IEnumerable<ReferenceType>) resourcePoolRefs);
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/action/updateResourcePools", SerializationUtil.SerializeObject<UpdateResourcePoolSetParamsType>(poolSetParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.resourcePoolSetUpdateParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, VimObjectRefType> GetDatastoreVimRefsByMoref()
    {
      try
      {
        Dictionary<string, VimObjectRefType> dictionary = new Dictionary<string, VimObjectRefType>();
        if (this.Resource.DataStoreRefs != null)
        {
          foreach (VimObjectRefType dataStoreRef in this.Resource.DataStoreRefs)
            dictionary.Add(dataStoreRef.MoRef, dataStoreRef);
        }
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void DisableResourcePool(string morefValue)
    {
      try
      {
        if (!this.GetResourcePoolsByMoref().ContainsKey(morefValue))
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        SdkUtil.Post<TaskType>(this.VcloudClient, this.GetResourcePoolsByMoref()[morefValue].ResourcePoolRef.href + "/action/disable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void EnableResourcePool(string morefValue)
    {
      try
      {
        if (!this.GetResourcePoolsByMoref().ContainsKey(morefValue))
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        SdkUtil.Post<TaskType>(this.VcloudClient, this.GetResourcePoolsByMoref()[morefValue].ResourcePoolRef.href + "/action/enable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task MergeProviderVdcs(List<ReferenceType> vmwProvVdcRefs)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Resource.href + "/action/merge", SerializationUtil.SerializeObject<ProviderVdcMergeParamsType>(new ProviderVdcMergeParamsType()
        {
          ProviderVdcReference = vmwProvVdcRefs.ToArray()
        }, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.providerVdcMergeParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetExternalNetworkRefsByName()
    {
      return this._externalNetworkRefsByName;
    }

    public ReferenceType GetExternalNetworkRefByName(string name)
    {
      ReferenceType referenceType;
      this._externalNetworkRefsByName.TryGetValue(name, out referenceType);
      return referenceType;
    }

    public List<ReferenceType> GetExternalNetworkRefs()
    {
      if (this._externalNetworkRefsByName.Values != null)
        return this._externalNetworkRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public Dictionary<string, ReferenceType> GetVMWNetworkPoolRefsByName()
    {
      return this._vmwNetworkPoolRefsByName;
    }

    public ReferenceType GetVMWNetworkPoolRefByName(string name)
    {
      ReferenceType referenceType;
      this._vmwNetworkPoolRefsByName.TryGetValue(name, out referenceType);
      return referenceType;
    }

    public List<ReferenceType> GetVMWNetworkPoolRefs()
    {
      if (this._vmwNetworkPoolRefsByName.Values != null)
        return this._vmwNetworkPoolRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public Dictionary<string, ReferenceType> GetVMWHostRefsByName()
    {
      return this._vmwHostRefsByName;
    }

    public ReferenceType GetVMWHostRefByName(string name)
    {
      ReferenceType referenceType;
      this._vmwHostRefsByName.TryGetValue(name, out referenceType);
      return referenceType;
    }

    public List<ReferenceType> GetVMWHostRefs()
    {
      if (this._vmwHostRefsByName.Values != null)
        return this._vmwHostRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public List<ReferenceType> GetVMWProviderVdcStorageProfileRefs()
    {
      try
      {
        if (this.Resource.StorageProfiles == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
        return ((IEnumerable<ReferenceType>) this.Resource.StorageProfiles.ProviderVdcStorageProfile).ToList<ReferenceType>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public List<VMWStorageProfileType> GetAvailableVMWProviderVdcStorageProfiles()
    {
      try
      {
        return ((IEnumerable<VMWStorageProfileType>) SdkUtil.Get<VMWStorageProfilesType>(this.VcloudClient, this.Reference.href + "/availableStorageProfiles", 200).VMWStorageProfile).ToList<VMWStorageProfileType>();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateVMWProviderVdcStorageProfiles(
      List<string> addStorageProfiles,
      List<ReferenceType> removeStorageProfiles)
    {
      UpdateProviderVdcStorageProfilesParamsType profilesParamsType = new UpdateProviderVdcStorageProfilesParamsType();
      profilesParamsType.AddStorageProfile = addStorageProfiles.ToArray();
      profilesParamsType.RemoveStorageProfile = removeStorageProfiles.ToArray();
      string url = this.Reference.href + "/storageProfiles";
      string requestString = SerializationUtil.SerializeObject<UpdateProviderVdcStorageProfilesParamsType>(profilesParamsType, "com.vmware.vcloud.api.rest.schema");
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.admin.updateProviderVdcStorageProfiles+xml", 202));
    }

    public Task MigrateVms(
      string sourceResourcePoolMoref,
      List<ReferenceType> vmRefs,
      VimObjectRefType resourcePoolVimRef)
    {
      string requestString = SerializationUtil.SerializeObject<MigrateParamsType>(new MigrateParamsType()
      {
        ResourcePoolRef = resourcePoolVimRef,
        VmRef = vmRefs.ToArray()
      }, "com.vmware.vcloud.api.rest.schema");
      if (!this.GetResourcePoolsByMoref().ContainsKey(sourceResourcePoolMoref))
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG) + " " + sourceResourcePoolMoref);
      return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.GetResourcePoolsByMoref()[sourceResourcePoolMoref].ResourcePoolRef.href + "/action/migrateVms", requestString, "application/vnd.vmware.admin.migrateVmParams+xml", 202));
    }

    public ReferenceResult GetVMs(string resourcePoolMoref)
    {
      try
      {
        if (this.GetResourcePoolsByMoref()[resourcePoolMoref] == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.MOREF_NOT_FOUND));
        return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultVMRecordType>(this.GetResourcePoolsByMoref()[resourcePoolMoref].ResourcePoolRef.href + "/vmList?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortReferences_v1_5()
    {
      if (this.Resource.AvailableNetworks != null && this.Resource.AvailableNetworks.Network != null)
      {
        foreach (ReferenceType referenceType in this.Resource.AvailableNetworks.Network)
          this._externalNetworkRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.NetworkPoolReferences != null && this.Resource.NetworkPoolReferences.NetworkPoolReference != null)
      {
        foreach (ReferenceType referenceType in this.Resource.NetworkPoolReferences.NetworkPoolReference)
          this._vmwNetworkPoolRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.HostReferences != null && this.Resource.HostReferences.HostReference != null)
      {
        foreach (ReferenceType referenceType in this.Resource.HostReferences.HostReference)
          this._vmwHostRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (this._providerVdcReference != null && this._vdcReferences != null)
          break;
        if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.admin.providervdc+xml"))
          this._providerVdcReference = (ReferenceType) linkType;
        else if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.admin.vdcReferences+xml"))
          this._vdcReferences = (ReferenceType) linkType;
      }
    }

    private static Task DeleteVMWProviderVdc(vCloudClient client, string vmwProviderVdcUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, vmwProviderVdcUrl, 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Dictionary<string, ReferenceType> GetAdminVdcRefs(
      vCloudClient client,
      string url)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VdcReferencesType vdcReferencesType = SdkUtil.Get<VdcReferencesType>(client, url, 200);
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        if (vdcReferencesType.VdcReference != null)
          dictionary = ((IEnumerable<ReferenceType>) vdcReferencesType.VdcReference).ToDictionary<ReferenceType, string, ReferenceType>((Func<ReferenceType, string>) (vdcReference => vdcReference.name), (Func<ReferenceType, ReferenceType>) (vdcReference => vdcReference));
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Dictionary<string, VMWProviderVdcResourcePoolType> GetResourcePools(
      vCloudClient client,
      ReferenceType vmwProvVdcRef)
    {
      VMWProviderVdcResourcePoolSetType resourcePoolSetType = SdkUtil.Get<VMWProviderVdcResourcePoolSetType>(client, vmwProvVdcRef.href + "/resourcePools", 200);
      Dictionary<string, VMWProviderVdcResourcePoolType> dictionary = new Dictionary<string, VMWProviderVdcResourcePoolType>();
      foreach (VMWProviderVdcResourcePoolType resourcePoolType in resourcePoolSetType.VMWProviderVdcResourcePool)
        dictionary.Add(resourcePoolType.ResourcePoolVimObjectRef.MoRef, resourcePoolType);
      return dictionary;
    }
  }
}
