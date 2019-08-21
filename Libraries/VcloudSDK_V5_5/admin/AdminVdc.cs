// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminVdc
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace com.vmware.vcloud.sdk.admin
{
  public class AdminVdc : VcloudEntity<AdminVdcType>
  {
    private Dictionary<string, ReferenceType> _vappRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _orgNetworkRefsByName = new Dictionary<string, ReferenceType>();
    private List<ReferenceType> _vappTemplateRefs;
    private List<ReferenceType> _mediaRefs;
    private List<ReferenceType> _storageProfileRefs;
    private List<ReferenceType> _diskRefs;
    private ReferenceType _adminOrgReference;
    private ReferenceType _vdcReference;
    private VimObjectRefType _primaryResourcePoolVimRef;
    private ReferenceType _orgVdcResourcePoolsRef;

    internal AdminVdc(vCloudClient client, AdminVdcType adminVdcType_v1_5)
      : base(client, adminVdcType_v1_5)
    {
      this.SortEntityAndNetworkRefs_v1_5();
    }

    public static AdminVdc GetAdminVdcByReference(vCloudClient client, ReferenceType vdcRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + vdcRef.href);
        return new AdminVdc(client, VcloudResource<AdminVdcType>.GetResourceByReference(client, vdcRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminVdc GetAdminVdcById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new AdminVdc(client, VcloudEntity<AdminVdcType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.vdc+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task UpdateAdminVdc(AdminVdcType adminVdcType)
    {
      try
      {
        string href = this.Reference.href;
        string requestString = SerializationUtil.SerializeObject<AdminVdcType>(adminVdcType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.PUT_URL_MSG) + " - " + href);
        return new Task(this.VcloudClient, SdkUtil.Put<TaskType>(this.VcloudClient, href, requestString, "application/vnd.vmware.admin.vdc+xml", 202));
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
        return AdminVdc.DeleteAdminVdc(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static Task Delete(vCloudClient client, ReferenceType adminVdcRef)
    {
      try
      {
        return AdminVdc.DeleteAdminVdc(client, adminVdcRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static Task DeleteAdminVdc(vCloudClient client, string adminVdcUrl)
    {
      try
      {
        return new Task(client, SdkUtil.Delete<TaskType>(client, adminVdcUrl, 202));
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
        AdminVdc.ExecuteVdcAction(this.VcloudClient, this.Reference.href + "/action/enable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Enable(vCloudClient client, ReferenceType adminVdcRef)
    {
      try
      {
        string orgActionUrl = adminVdcRef.href + "/action/enable";
        AdminVdc.ExecuteVdcAction(client, orgActionUrl, (string) null, (string) null, 204);
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
        AdminVdc.ExecuteVdcAction(this.VcloudClient, this.Reference.href + "/action/disable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Disable(vCloudClient client, ReferenceType adminVdcRef)
    {
      try
      {
        string orgActionUrl = adminVdcRef.href + "/action/disable";
        AdminVdc.ExecuteVdcAction(client, orgActionUrl, (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task EnableFastProvisioning()
    {
      try
      {
        AdminVdcType resource = this.Resource;
        resource.UsesFastProvisioning = true;
        return this.UpdateAdminVdc(resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task DisableFastProvisioning()
    {
      try
      {
        AdminVdcType resource = this.Resource;
        resource.UsesFastProvisioning = false;
        return this.UpdateAdminVdc(resource);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void ExecuteVdcAction(
      vCloudClient client,
      string orgActionUrl,
      string content,
      string contentType,
      int statusCode)
    {
      try
      {
        SdkUtil.Post<TaskType>(client, orgActionUrl, content, contentType, statusCode);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetAdminOrganizationReference()
    {
      try
      {
        if (this._adminOrgReference != null)
          return this._adminOrgReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
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
        if (this._vdcReference != null)
          return this._vdcReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public VimObjectRefType GetResourcePoolVimRef()
    {
      if (this._primaryResourcePoolVimRef != null)
        return this._primaryResourcePoolVimRef;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.VIM_OBJECT_REF_NOT_FOUND_MSG));
    }

    public Dictionary<string, VimObjectRefType> GetResourcePoolVimRefsByMoref()
    {
      try
      {
        if (this._orgVdcResourcePoolsRef == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        OrganizationResourcePoolSetType resourcePoolSetType = SdkUtil.Get<OrganizationResourcePoolSetType>(this.VcloudClient, this._orgVdcResourcePoolsRef.href, 200);
        Dictionary<string, VimObjectRefType> dictionary = new Dictionary<string, VimObjectRefType>();
        foreach (VimObjectRefType vimObjectRefType in resourcePoolSetType.ResourcePoolVimObjectRef)
          dictionary.Add(vimObjectRefType.MoRef, vimObjectRefType);
        return dictionary;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortEntityAndNetworkRefs_v1_5()
    {
      this._vappTemplateRefs = new List<ReferenceType>();
      this._mediaRefs = new List<ReferenceType>();
      this._vappRefsByName = new Dictionary<string, ReferenceType>();
      this._orgNetworkRefsByName = new Dictionary<string, ReferenceType>();
      this._storageProfileRefs = new List<ReferenceType>();
      this._diskRefs = new List<ReferenceType>();
      if (this.Resource.ResourceEntities != null)
      {
        ResourceEntitiesType resourceEntities = this.Resource.ResourceEntities;
        List<ResourceReferenceType> resourceReferenceTypeList = new List<ResourceReferenceType>();
        if (resourceEntities.ResourceEntity != null)
          resourceReferenceTypeList = ((IEnumerable<ResourceReferenceType>) resourceEntities.ResourceEntity).ToList<ResourceReferenceType>();
        if (resourceReferenceTypeList != null)
        {
          foreach (ResourceReferenceType resourceReferenceType in resourceReferenceTypeList)
          {
            if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.vAppTemplate+xml"))
              this._vappTemplateRefs.Add((ReferenceType) resourceReferenceType);
            else if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.media+xml"))
              this._mediaRefs.Add((ReferenceType) resourceReferenceType);
            else if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.vApp+xml"))
              this._vappRefsByName.Add(resourceReferenceType.name, (ReferenceType) resourceReferenceType);
            else if (resourceReferenceType.type.Equals("application/vnd.vmware.vcloud.disk+xml"))
              this._diskRefs.Add((ReferenceType) resourceReferenceType);
            else
              Logger.Log(TraceLevel.Warning, SdkUtil.GetI18nString(SdkMessage.UNKNOWN_REF_TYPE_MSG), resourceReferenceType.type);
          }
        }
      }
      if (this.Resource.AvailableNetworks != null)
      {
        AvailableNetworksType availableNetworks = this.Resource.AvailableNetworks;
        if (availableNetworks != null && availableNetworks.Network != null)
        {
          foreach (ReferenceType referenceType in availableNetworks.Network)
          {
            if (!this._orgNetworkRefsByName.ContainsKey(referenceType.name))
              this._orgNetworkRefsByName.Add(referenceType.name, referenceType);
          }
        }
      }
      if (this.Resource.Link != null)
      {
        foreach (LinkType linkType in this.Resource.Link)
        {
          if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.admin.organization+xml"))
            this._adminOrgReference = (ReferenceType) linkType;
          if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.vcloud.vdc+xml"))
            this._vdcReference = (ReferenceType) linkType;
          if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.admin.OrganizationVdcResourcePoolSet+xml"))
            this._orgVdcResourcePoolsRef = (ReferenceType) linkType;
        }
      }
      if (this.Resource.VCloudExtension != null)
      {
        foreach (VCloudExtensionType vcloudExtensionType in this.Resource.VCloudExtension)
        {
          foreach (XmlNode xmlNode in vcloudExtensionType.Any)
          {
            VimObjectRefType resource = Response.GetResource<VimObjectRefType>(xmlNode.OuterXml);
            if (resource.VimObjectType.Equals(VimObjectTypeEnum.RESOURCE_POOL.Value()))
              this._primaryResourcePoolVimRef = resource;
          }
        }
      }
      if (this.Resource.VdcStorageProfiles == null || this.Resource.VdcStorageProfiles.VdcStorageProfile == null)
        return;
      foreach (ReferenceType referenceType in this.Resource.VdcStorageProfiles.VdcStorageProfile)
        this._storageProfileRefs.Add(referenceType);
    }

    [Obsolete("This method is deprecated  since SDK 5.5.Use the Resource.AvailableNetworks.Please note when used against API 1.5 it returns the Org Network references.When used against API 5.1 it returns Org Vdc Network references.")]
    public Dictionary<string, ReferenceType> GetAdminOrgNetworkRefsByName()
    {
      return this._orgNetworkRefsByName;
    }

    [Obsolete("This method is deprecated  since SDK 5.5.Use the Resource.AvailableNetworks.Please note when used against API 1.5 it returns the Org Network references.When used against API 5.1 it returns Org Vdc Network references.")]
    public List<ReferenceType> GetAdminOrgNetworkRefs()
    {
      if (this._orgNetworkRefsByName.Values != null)
        return this._orgNetworkRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    [Obsolete("This method is deprecated  since SDK 5.5.Use the Resource.AvailableNetworks.Please note when used against API 1.5 it returns the Org Network references.When used against API 5.1 it returns Org Vdc Network references.")]
    public ReferenceType GetAdminOrgNetworkRefByName(string name)
    {
      return this._orgNetworkRefsByName[name];
    }

    public List<ReferenceType> GetVappTemplateRefs()
    {
      return this._vappTemplateRefs;
    }

    public List<ReferenceType> GetMediaRefs()
    {
      return this._mediaRefs;
    }

    public Dictionary<string, ReferenceType> GetVappRefsByName()
    {
      return this._vappRefsByName;
    }

    public List<ReferenceType> GetVappRefs()
    {
      if (this._vappRefsByName.Values != null)
        return this._vappRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetVappRefByName(string name)
    {
      return this._vappRefsByName[name];
    }

    public ReferenceType GetProviderVdcRef()
    {
      return this.Resource.ProviderVdcReference;
    }

    public ReferenceType GetNetworkPoolRef()
    {
      if (this.Resource.NetworkPoolReference != null)
        return this.Resource.NetworkPoolReference;
      throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
    }

    public List<ReferenceType> GetAdminVdcStorageProfileRefs()
    {
      return this._storageProfileRefs;
    }

    public List<ReferenceType> GetDiskRefs()
    {
      return this._diskRefs;
    }

    public Task UpdateAdminVdcStorageProfiles(
      List<VdcStorageProfileParamsType> addStorageProfiles,
      List<ReferenceType> removeStorageProfiles)
    {
      try
      {
        UpdateVdcStorageProfilesType storageProfilesType = new UpdateVdcStorageProfilesType();
        storageProfilesType.AddStorageProfile = addStorageProfiles.ToArray();
        ((IEnumerable<ReferenceType>) storageProfilesType.RemoveStorageProfile).ToList<ReferenceType>().AddRange((IEnumerable<ReferenceType>) removeStorageProfiles);
        string url = this.Reference.href + "/vdcStorageProfiles";
        string requestString = SerializationUtil.SerializeObject<UpdateVdcStorageProfilesType>(storageProfilesType, "com.vmware.vcloud.api.rest.schema");
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + url);
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, url, requestString, "application/vnd.vmware.admin.updateVdcStorageProfiles+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public EdgeGateway CreateEdgeGateway(GatewayType gatewayParams)
    {
      return new EdgeGateway(this.VcloudClient, SdkUtil.Post<GatewayType>(this.VcloudClient, this.Resource.href + "/edgeGateways", SerializationUtil.SerializeObject<GatewayType>(gatewayParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.edgeGateway+xml", 201));
    }

    public ReferenceResult GetEdgeGatewayRefs()
    {
      return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/edgeGateways?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
    }

    public ReferenceResult GetOrgVdcNetworkRefs()
    {
      return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultOrgVdcNetworkRecordType>(this.Reference.href + "/networks?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
    }

    public AdminOrgVdcNetwork CreateOrgVdcNetwork(
      OrgVdcNetworkType orgVdcNetworkParams)
    {
      try
      {
        return new AdminOrgVdcNetwork(this.VcloudClient, SdkUtil.Post<OrgVdcNetworkType>(this.VcloudClient, this.Resource.href + "/networks", SerializationUtil.SerializeObject<OrgVdcNetworkType>(orgVdcNetworkParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.vcloud.orgVdcNetwork+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Task RegisterVapp(RegisterVAppParamsType registerVappParams)
    {
      try
      {
        return new Task(this.VcloudClient, SdkUtil.Post<TaskType>(this.VcloudClient, this.Resource.href + "/action/registerVApp", SerializationUtil.SerializeObject<RegisterVAppParamsType>(registerVappParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.registerVAppParams+xml", 202));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
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
