// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.VcloudAdmin
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
  public class VcloudAdmin
  {
    private Dictionary<string, ReferenceType> _roleRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _rightRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _providerVdcRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _externalNetworkRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _adminOrganizationRefsByName = new Dictionary<string, ReferenceType>();
    private VCloudType _vcloudResource_v1_5;
    private vCloudClient _client;
    private ReferenceType _systemAdminOrgReference;

    public VcloudAdmin(vCloudClient client)
    {
      try
      {
        this._client = client;
        this._vcloudResource_v1_5 = SdkUtil.Get<VCloudType>(client, client.VCloudApiURL + "/admin/", 200);
        this.SortAdminRefs_v1_5();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminQueryService GetAdminQueryService()
    {
      return new AdminQueryService(this._client);
    }

    public VCloudType Resource
    {
      get
      {
        return this._vcloudResource_v1_5;
      }
    }

    private void SortAdminRefs_v1_5()
    {
      this._adminOrganizationRefsByName = new Dictionary<string, ReferenceType>();
      this._providerVdcRefsByName = new Dictionary<string, ReferenceType>();
      this._rightRefsByName = new Dictionary<string, ReferenceType>();
      this._roleRefsByName = new Dictionary<string, ReferenceType>();
      this._externalNetworkRefsByName = new Dictionary<string, ReferenceType>();
      if (this._vcloudResource_v1_5 == null)
        return;
      if (this._vcloudResource_v1_5.OrganizationReferences != null && this._vcloudResource_v1_5.OrganizationReferences.OrganizationReference != null && (this.Resource.OrganizationReferences != null && this.Resource.OrganizationReferences.OrganizationReference != null))
      {
        foreach (OrganizationReferenceType organizationReferenceType in this.Resource.OrganizationReferences.OrganizationReference)
          this._adminOrganizationRefsByName.Add(organizationReferenceType.name, (ReferenceType) organizationReferenceType);
      }
      if (this._vcloudResource_v1_5.ProviderVdcReferences != null && this._vcloudResource_v1_5.ProviderVdcReferences.ProviderVdcReference != null && (this.Resource.ProviderVdcReferences != null && this.Resource.ProviderVdcReferences.ProviderVdcReference != null))
      {
        foreach (ReferenceType referenceType in this.Resource.ProviderVdcReferences.ProviderVdcReference)
          this._providerVdcRefsByName.Add(referenceType.name, referenceType);
      }
      if (this._vcloudResource_v1_5.RightReferences != null && this._vcloudResource_v1_5.RightReferences.RightReference != null && (this.Resource.RightReferences != null && this.Resource.RightReferences.RightReference != null))
      {
        foreach (ReferenceType referenceType in this.Resource.RightReferences.RightReference)
          this._rightRefsByName.Add(referenceType.name, referenceType);
      }
      if (this._vcloudResource_v1_5.RoleReferences != null && this._vcloudResource_v1_5.RoleReferences.RoleReference != null && (this.Resource.RoleReferences != null && this.Resource.RoleReferences.RoleReference != null))
      {
        foreach (ReferenceType referenceType in this.Resource.RoleReferences.RoleReference)
          this._roleRefsByName.Add(referenceType.name, referenceType);
      }
      if (this._vcloudResource_v1_5.Networks != null && this._vcloudResource_v1_5.Networks.Network != null && (this.Resource.Networks != null && this.Resource.Networks.Network != null))
      {
        foreach (ReferenceType referenceType in this.Resource.Networks.Network)
          this._externalNetworkRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.admin.systemOrganization+xml"))
        {
          this._systemAdminOrgReference = new ReferenceType();
          this._systemAdminOrgReference = (ReferenceType) linkType;
          break;
        }
      }
    }

    public AdminOrganization GetSystemAdminOrg()
    {
      try
      {
        if (this._systemAdminOrgReference == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        return AdminOrganization.GetAdminOrgByReference(this._client, this._systemAdminOrgReference);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Role CreateRole(RoleType roleType)
    {
      try
      {
        return new Role(this._client, SdkUtil.Post<RoleType>(this._client, this.Resource.href + "roles", SerializationUtil.SerializeObject<RoleType>(roleType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.role+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminOrganization CreateAdminOrg(AdminOrgType adminOrgType)
    {
      try
      {
        return new AdminOrganization(this._client, SdkUtil.Post<AdminOrgType>(this._client, this.Resource.href + "orgs", SerializationUtil.SerializeObject<AdminOrgType>(adminOrgType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.organization+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetAdminOrgRefsByName()
    {
      return this._adminOrganizationRefsByName;
    }

    public List<ReferenceType> GetAdminOrgRefs()
    {
      if (this._adminOrganizationRefsByName.Values != null)
        return this._adminOrganizationRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetAdminOrgRefByName(string name)
    {
      return this._adminOrganizationRefsByName[name];
    }

    public Dictionary<string, ReferenceType> GetProviderVdcRefsByName()
    {
      return this._providerVdcRefsByName;
    }

    public List<ReferenceType> GetProviderVdcRefs()
    {
      if (this._providerVdcRefsByName.Values != null)
        return this._providerVdcRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetProviderVdcRefByName(string name)
    {
      return this._providerVdcRefsByName[name];
    }

    public Dictionary<string, ReferenceType> GetRightRefsByName()
    {
      return this._rightRefsByName;
    }

    public List<ReferenceType> GetRightRefs()
    {
      if (this._rightRefsByName.Values != null)
        return this._rightRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetRightRefByName(string name)
    {
      return this._rightRefsByName[name];
    }

    public Dictionary<string, ReferenceType> GetRoleRefsByName()
    {
      return this._roleRefsByName;
    }

    public List<ReferenceType> GetRoleRefs()
    {
      if (this._roleRefsByName.Values != null)
        return this._roleRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetRoleRefByName(string name)
    {
      return this._roleRefsByName[name];
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

    public ReferenceType GetExternalNetworkRefByName(string name)
    {
      return this._externalNetworkRefsByName[name];
    }
  }
}
