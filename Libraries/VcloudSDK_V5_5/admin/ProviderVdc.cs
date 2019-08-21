// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.ProviderVdc
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.vmware.vcloud.sdk.admin
{
  public class ProviderVdc : VcloudEntity<ProviderVdcType>
  {
    private Dictionary<string, ReferenceType> _externalNetworkRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _networkPoolRefsByName = new Dictionary<string, ReferenceType>();

    internal ProviderVdc(vCloudClient client, ProviderVdcType providerVdcType_v1_5)
      : base(client, providerVdcType_v1_5)
    {
      this.SortRefs_v1_5();
    }

    public static ProviderVdc GetProviderVdcByReference(
      vCloudClient client,
      ReferenceType providerVdcRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + providerVdcRef.href);
        return new ProviderVdc(client, VcloudResource<ProviderVdcType>.GetResourceByReference(client, providerVdcRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ProviderVdc GetProviderVdcById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new ProviderVdc(client, VcloudEntity<ProviderVdcType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.providervdc+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortRefs_v1_5()
    {
      this._externalNetworkRefsByName = new Dictionary<string, ReferenceType>();
      this._networkPoolRefsByName = new Dictionary<string, ReferenceType>();
      if (this.Resource.AvailableNetworks != null && this.Resource.AvailableNetworks.Network != null)
      {
        foreach (ReferenceType referenceType in this.Resource.AvailableNetworks.Network)
          this._externalNetworkRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.NetworkPoolReferences == null || this.Resource.NetworkPoolReferences.NetworkPoolReference == null)
        return;
      foreach (ReferenceType referenceType in this.Resource.NetworkPoolReferences.NetworkPoolReference)
        this._networkPoolRefsByName.Add(referenceType.name, referenceType);
    }

    public static Dictionary<string, ReferenceType> GetAdminVdcRefsByName(
      vCloudClient client,
      ReferenceType vmwProviderVdcRef)
    {
      try
      {
        string url = vmwProviderVdcRef.href + "/vdcReferences";
        return ProviderVdc.GetAdminVdcRefs(client, url);
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
        return ProviderVdc.GetAdminVdcRefs(this.VcloudClient, this.Reference.href + "/vdcReferences");
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
        Dictionary<string, ReferenceType> dictionary = new Dictionary<string, ReferenceType>();
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + url);
        VdcReferencesType vdcReferencesType = SdkUtil.Get<VdcReferencesType>(client, url, 200);
        if (vdcReferencesType.VdcReference != null)
        {
          foreach (ReferenceType referenceType in vdcReferencesType.VdcReference)
            dictionary.Add(referenceType.name, referenceType);
        }
        return dictionary;
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

    public List<ReferenceType> GetExternalNetworkRefs()
    {
      if (this._externalNetworkRefsByName.Values != null)
        return this._externalNetworkRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetExternalNetworkRefByName(string externalNetworkName)
    {
      return this._externalNetworkRefsByName[externalNetworkName];
    }

    public Dictionary<string, ReferenceType> GetVMWNetworkPoolRefsByName()
    {
      return this._networkPoolRefsByName;
    }

    public List<ReferenceType> GetVMWNetworkPoolRefs()
    {
      if (this._networkPoolRefsByName.Values != null)
        return this._networkPoolRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetVMWNetworkPoolRefByName(string networkPoolName)
    {
      return this._networkPoolRefsByName[networkPoolName];
    }

    public List<ReferenceType> GetProviderVdcStorageProfileRefs()
    {
      if (this.Resource.StorageProfiles == null)
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.DATA_NOT_FOUND));
      return ((IEnumerable<ReferenceType>) this.Resource.StorageProfiles.ProviderVdcStorageProfile).ToList<ReferenceType>();
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
