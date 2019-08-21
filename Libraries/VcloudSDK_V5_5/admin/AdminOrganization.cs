// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminOrganization
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
  public class AdminOrganization : VcloudEntity<AdminOrgType>
  {
    private Dictionary<string, ReferenceType> _userRefsByName = new Dictionary<string, ReferenceType>();
    private List<ReferenceType> _catalogRefs = new List<ReferenceType>();
    private Dictionary<string, ReferenceType> _groupRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _adminVdcRefsByName = new Dictionary<string, ReferenceType>();
    private Dictionary<string, ReferenceType> _orgNetworkRefsByName = new Dictionary<string, ReferenceType>();
    private ReferenceType _orgReference;
    private ReferenceType _tasksListRef;

    internal AdminOrganization(vCloudClient client, AdminOrgType adminOrgType_v1_5)
      : base(client, adminOrgType_v1_5)
    {
      this.SortAdminOrgRefs_v1_5();
    }

    public static AdminOrganization GetAdminOrgByReference(
      vCloudClient client,
      ReferenceType orgRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + orgRef.href);
        return new AdminOrganization(client, VcloudResource<AdminOrgType>.GetResourceByReference(client, orgRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static AdminOrganization GetAdminOrgById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        string str = client.VCloudApiURL + "/entity/" + vCloudId;
        return new AdminOrganization(client, VcloudEntity<AdminOrgType>.GetEntityById(client, vCloudId, "application/vnd.vmware.admin.organization+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgSettingsType GetOrgSettings()
    {
      return this.Resource.Settings;
    }

    public static OrgSettingsType GetOrgSettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      try
      {
        string url = adminOrgReference.href + "/settings";
        return SdkUtil.Get<OrgSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgSettingsType UpdateOrgSettings(OrgSettingsType orgSettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgSettingsType>(this.VcloudClient, this.Reference.href + "/settings", SerializationUtil.SerializeObject<OrgSettingsType>(orgSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.orgSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminCatalog CreateCatalog(AdminCatalogType adminCatalogType)
    {
      try
      {
        return new AdminCatalog(this.VcloudClient, SdkUtil.Post<AdminCatalogType>(this.VcloudClient, this.Resource.href + "/catalogs", SerializationUtil.SerializeObject<AdminCatalogType>(adminCatalogType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.catalog+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public User CreateUser(UserType userType)
    {
      try
      {
        return new User(this.VcloudClient, SdkUtil.Post<UserType>(this.VcloudClient, this.Reference.href + "/users", SerializationUtil.SerializeObject<UserType>(userType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.user+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Group ImportGroup(GroupType groupType)
    {
      try
      {
        return new Group(this.VcloudClient, SdkUtil.Post<GroupType>(this.VcloudClient, this.Reference.href + "/groups", SerializationUtil.SerializeObject<GroupType>(groupType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.group+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is obsolete  since API 5.1, SDK 5.1; Use method CreateAdminVdc with CreateVdcParamsType params instead ")]
    public AdminVdc CreateAdminVdc(AdminVdcType adminVdcType)
    {
      try
      {
        return new AdminVdc(this.VcloudClient, SdkUtil.Post<AdminVdcType>(this.VcloudClient, this.Reference.href + "/vdcs", SerializationUtil.SerializeObject<AdminVdcType>(adminVdcType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.vdc+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminVdc CreateAdminVdc(CreateVdcParamsType vdcParams)
    {
      return new AdminVdc(this.VcloudClient, SdkUtil.Post<AdminVdcType>(this.VcloudClient, this.Reference.href + "/vdcsparams", SerializationUtil.SerializeObject<CreateVdcParamsType>(vdcParams, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.createVdcParams+xml", 201));
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public AdminOrgNetwork CreateOrgNetwork(OrgNetworkType orgNetworkType)
    {
      try
      {
        return new AdminOrgNetwork(this.VcloudClient, SdkUtil.Post<OrgNetworkType>(this.VcloudClient, this.Reference.href + "/networks", SerializationUtil.SerializeObject<OrgNetworkType>(orgNetworkType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.orgNetwork+xml", 201));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetOrgReference()
    {
      try
      {
        if (this._orgReference != null)
          return this._orgReference;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetTaskListReference()
    {
      try
      {
        if (this._tasksListRef != null)
          return this._tasksListRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private void SortAdminOrgRefs_v1_5()
    {
      if (this.Resource.Users != null && this.Resource.Users.UserReference != null)
      {
        foreach (ReferenceType referenceType in this.Resource.Users.UserReference)
          this._userRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.Groups != null && this.Resource.Groups.GroupReference != null)
      {
        foreach (ReferenceType referenceType in this.Resource.Groups.GroupReference)
          this._groupRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.Catalogs != null && this.Resource.Catalogs.CatalogReference != null)
      {
        foreach (ReferenceType referenceType in this.Resource.Catalogs.CatalogReference)
          this._catalogRefs.Add(referenceType);
      }
      if (this.Resource.Vdcs != null && this.Resource.Vdcs.Vdc != null)
      {
        foreach (ReferenceType referenceType in this.Resource.Vdcs.Vdc)
          this._adminVdcRefsByName.Add(referenceType.name, referenceType);
      }
      if (this.Resource.Networks != null && this.Resource.Networks.Network != null)
      {
        foreach (ReferenceType referenceType in this.Resource.Networks.Network)
        {
          if (!this._orgNetworkRefsByName.ContainsKey(referenceType.name))
            this._orgNetworkRefsByName.Add(referenceType.name, referenceType);
        }
      }
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (this._orgReference != null && this._tasksListRef != null)
          break;
        if (linkType.rel.Equals("alternate") && linkType.type.Equals("application/vnd.vmware.vcloud.org+xml"))
          this._orgReference = (ReferenceType) linkType;
        else if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.vcloud.tasksList+xml"))
          this._tasksListRef = (ReferenceType) linkType;
      }
    }

    public static OrgVAppTemplateLeaseSettingsType GetvAppTemplateLeaseSettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      try
      {
        string url = adminOrgReference.href + "/settings/vAppTemplateLeaseSettings";
        return SdkUtil.Get<OrgVAppTemplateLeaseSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgVAppTemplateLeaseSettingsType GetvAppTemplateLeaseSettings()
    {
      try
      {
        return this.Resource.Settings.VAppTemplateLeaseSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgVAppTemplateLeaseSettingsType UpdatevAppTemplateLeaseSettings(
      OrgVAppTemplateLeaseSettingsType orgVAppTemplateLeaseSettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgVAppTemplateLeaseSettingsType>(this.VcloudClient, this.Reference.href + "/settings/vAppTemplateLeaseSettings", SerializationUtil.SerializeObject<OrgVAppTemplateLeaseSettingsType>(orgVAppTemplateLeaseSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.vAppTemplateLeaseSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static OrgLeaseSettingsType GetvAppLeaseSettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      try
      {
        string url = adminOrgReference.href + "/settings/vAppLeaseSettings";
        return SdkUtil.Get<OrgLeaseSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgLeaseSettingsType GetvAppLeaseSettings()
    {
      try
      {
        return this.Resource.Settings.VAppLeaseSettings;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgLeaseSettingsType UpdatevAppLeaseSettings(
      OrgLeaseSettingsType orgVAppLeaseSettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgLeaseSettingsType>(this.VcloudClient, this.Reference.href + "/settings/vAppLeaseSettings", SerializationUtil.SerializeObject<OrgLeaseSettingsType>(orgVAppLeaseSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.vAppLeaseSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static OrgFederationSettingsType GetFederationSettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      string url = adminOrgReference.href + "/settings/federation";
      return SdkUtil.Get<OrgFederationSettingsType>(client, url, 200);
    }

    public OrgFederationSettingsType GetFederationSettings()
    {
      return this.Resource.Settings.OrgFederationSettings;
    }

    public OrgFederationSettingsType UpdateFederationSettings(
      OrgFederationSettingsType orgFederationSettingsType)
    {
      return SdkUtil.Put<OrgFederationSettingsType>(this.VcloudClient, this.Reference.href + "/settings/federation", SerializationUtil.SerializeObject<OrgFederationSettingsType>(orgFederationSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.organizationFederationSettings+xml", 200);
    }

    public static OrgEmailSettingsType GetEmailSettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      try
      {
        string url = adminOrgReference.href + "/settings/email";
        return SdkUtil.Get<OrgEmailSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgEmailSettingsType GetEmailSettings()
    {
      return this.Resource.Settings.OrgEmailSettings;
    }

    public OrgEmailSettingsType UpdateEmailSettings(
      OrgEmailSettingsType orgEmailSettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgEmailSettingsType>(this.VcloudClient, this.Reference.href + "/settings/email", SerializationUtil.SerializeObject<OrgEmailSettingsType>(orgEmailSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.organizationEmailSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static OrgGeneralSettingsType GetGeneralSettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      try
      {
        string url = adminOrgReference.href + "/settings/general";
        return SdkUtil.Get<OrgGeneralSettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgGeneralSettingsType GetGeneralSettings()
    {
      return this.Resource.Settings.OrgGeneralSettings;
    }

    public OrgGeneralSettingsType UpdateGeneralSettings(
      OrgGeneralSettingsType orgGeneralSettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgGeneralSettingsType>(this.VcloudClient, this.Reference.href + "/settings/general", SerializationUtil.SerializeObject<OrgGeneralSettingsType>(orgGeneralSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.organizationGeneralSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static OrgPasswordPolicySettingsType GetPasswordPolicySettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      try
      {
        string url = adminOrgReference.href + "/settings/passwordPolicy";
        return SdkUtil.Get<OrgPasswordPolicySettingsType>(client, url, 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgPasswordPolicySettingsType GetPasswordPolicySettings()
    {
      return this.Resource.Settings.OrgPasswordPolicySettings;
    }

    public OrgPasswordPolicySettingsType UpdatePasswordPolicySettings(
      OrgPasswordPolicySettingsType orgPasswordPolicySettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgPasswordPolicySettingsType>(this.VcloudClient, this.Reference.href + "/settings/passwordPolicy", SerializationUtil.SerializeObject<OrgPasswordPolicySettingsType>(orgPasswordPolicySettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.organizationPasswordPolicySettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public AdminOrganization UpdateAdminOrg(AdminOrgType adminOrgType)
    {
      try
      {
        return new AdminOrganization(this.VcloudClient, SdkUtil.Put<AdminOrgType>(this.VcloudClient, this.Reference.href, SerializationUtil.SerializeObject<AdminOrgType>(adminOrgType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.organization+xml", 200));
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
        AdminOrganization.DeleteAdminOrg(this.VcloudClient, this.Reference.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Delete(vCloudClient client, ReferenceType adminOrgRef)
    {
      try
      {
        AdminOrganization.DeleteAdminOrg(client, adminOrgRef.href);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void DeleteAdminOrg(vCloudClient client, string adminOrgUrl)
    {
      try
      {
        SdkUtil.Delete<TaskType>(client, adminOrgUrl, 204);
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
        AdminOrganization.ExecuteOrgAction(this.VcloudClient, this.Reference.href + "/action/enable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Enable(vCloudClient client, ReferenceType orgRef)
    {
      try
      {
        string orgActionUrl = orgRef.href + "/action/enable";
        AdminOrganization.ExecuteOrgAction(client, orgActionUrl, (string) null, (string) null, 204);
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
        AdminOrganization.ExecuteOrgAction(this.VcloudClient, this.Reference.href + "/action/disable", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static void Disable(vCloudClient client, ReferenceType adminOrgRef)
    {
      try
      {
        string orgActionUrl = adminOrgRef.href + "/action/disable";
        AdminOrganization.ExecuteOrgAction(client, orgActionUrl, (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private static void ExecuteOrgAction(
      vCloudClient client,
      string orgActionUrl,
      string content,
      string contentType,
      int statusCode)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.POST_URL_MSG) + " - " + orgActionUrl);
        SdkUtil.Post<TaskType>(client, orgActionUrl, content, contentType, statusCode);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public Dictionary<string, ReferenceType> GetUserRefsByName()
    {
      return this._userRefsByName;
    }

    public List<ReferenceType> GetUserRefs()
    {
      if (this._userRefsByName.Values != null)
        return this._userRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetUserRefByName(string name)
    {
      return this._userRefsByName[name];
    }

    public Dictionary<string, ReferenceType> GetGroupRefsByName()
    {
      return this._groupRefsByName;
    }

    public List<ReferenceType> GetGroupRefs()
    {
      if (this._groupRefsByName.Values != null)
        return this._groupRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetGroupRefByName(string name)
    {
      return this._groupRefsByName[name];
    }

    public List<ReferenceType> GetCatalogRefs()
    {
      return this._catalogRefs;
    }

    public Dictionary<string, ReferenceType> GetAdminVdcRefsByName()
    {
      return this._adminVdcRefsByName;
    }

    public List<ReferenceType> GetAdminVdcRefs()
    {
      if (this._adminVdcRefsByName.Values != null)
        return this._adminVdcRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    public ReferenceType GetAdminVdcRefByName(string name)
    {
      return this._adminVdcRefsByName[name];
    }

    [Obsolete("This method is deprecated  since SDK 5.5. Use the Resource.Networks.Please note when used against API 1.5 it returns the Org Network references.When used against API 5.1 it returns Org Vdc Network references.")]
    public Dictionary<string, ReferenceType> GetAdminOrgNetworkRefsByName()
    {
      return this._orgNetworkRefsByName;
    }

    [Obsolete("This method is deprecated  since  SDK 5.5. Use the Resource.Networks.Please note when used against API 1.5 it returns the Org Network references.When used against API 5.1 it returns Org Vdc Network references.")]
    public List<ReferenceType> GetAdminOrgNetworkRefs()
    {
      if (this._orgNetworkRefsByName.Values != null)
        return this._orgNetworkRefsByName.Values.ToList<ReferenceType>();
      return new List<ReferenceType>();
    }

    [Obsolete("This method is deprecated  since SDK 5.5. Use the Resource.Networks.Please note when used against API 1.5 it returns the Org Network references.When used against API 5.1 it returns Org Vdc Network references.")]
    public ReferenceType GetAdminOrgNetworkRefByName(string name)
    {
      return this._orgNetworkRefsByName[name];
    }

    public void CreateEvent(EventType eventType)
    {
      try
      {
        SdkUtil.Post<EventType>(this.VcloudClient, this.Reference.href + "/events", SerializationUtil.SerializeObject<EventType>(eventType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.event+xml", 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgGuestPersonalizationSettingsType GetGuestPersonalizationSettings()
    {
      try
      {
        return SdkUtil.Get<OrgGuestPersonalizationSettingsType>(this.VcloudClient, this.Reference.href + "/settings/guestPersonalizationSettings", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgOperationLimitsSettingsType GetOperationLimitsSettings()
    {
      try
      {
        return SdkUtil.Get<OrgOperationLimitsSettingsType>(this.VcloudClient, this.Reference.href + "/settings/operationLimitsSettings", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgGuestPersonalizationSettingsType UpdateGuestPersonalizationSettings(
      OrgGuestPersonalizationSettingsType orgGuestPersonalizationSettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgGuestPersonalizationSettingsType>(this.VcloudClient, this.Reference.href + "/settings/guestPersonalizationSettings", SerializationUtil.SerializeObject<OrgGuestPersonalizationSettingsType>(orgGuestPersonalizationSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.guestPersonalizationSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public OrgOperationLimitsSettingsType UpdateOperationLimitsSettings(
      OrgOperationLimitsSettingsType operationLimitsSettingsType)
    {
      try
      {
        return SdkUtil.Put<OrgOperationLimitsSettingsType>(this.VcloudClient, this.Reference.href + "/settings/operationLimitsSettings", SerializationUtil.SerializeObject<OrgOperationLimitsSettingsType>(operationLimitsSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.operationLimitsSettings+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetLdapCertificate()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/settings/ldap/action/resetLdapCertificate", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetLdapKeyStore()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/settings/ldap/action/resetLdapKeyStore", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public void ResetLdapSspiKeytab()
    {
      try
      {
        SdkUtil.Post<TaskType>(this.VcloudClient, this.Reference.href + "/settings/ldap/action/resetLdapSspiKeytab", (string) null, (string) null, 204);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public CertificateUploadSocketType UpdateLdapCertificate(
      CertificateUpdateParamsType certificateUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<CertificateUploadSocketType>(this.VcloudClient, this.Reference.href + "/settings/ldap/action/updateLdapCertificate", SerializationUtil.SerializeObject<CertificateUpdateParamsType>(certificateUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.certificateUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public KeystoreUploadSocketType UpdateLdapKeyStore(
      KeystoreUpdateParamsType keystoreUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<KeystoreUploadSocketType>(this.VcloudClient, this.Reference.href + "/settings/ldap/action/updateLdapKeyStore", SerializationUtil.SerializeObject<KeystoreUpdateParamsType>(keystoreUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.keystoreUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public SspiKeytabUploadSocketType UpdateLdapSspiKeytab(
      SspiKeytabUpdateParamsType sspiKeytabUpdateParamsType)
    {
      try
      {
        return SdkUtil.Post<SspiKeytabUploadSocketType>(this.VcloudClient, this.Reference.href + "/settings/ldap/action/updateLdapSspiKeytab", SerializationUtil.SerializeObject<SspiKeytabUpdateParamsType>(sspiKeytabUpdateParamsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.sspiKeytabUpdateParams+xml", 200);
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public OrgLdapSettingsType GetLdapSettings()
    {
      return this.Resource.Settings.OrgLdapSettings;
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public static OrgLdapSettingsType GetLdapSettings(
      vCloudClient client,
      ReferenceType adminOrgReference)
    {
      string url = adminOrgReference.href + "/settings/ldap";
      return SdkUtil.Get<OrgLdapSettingsType>(client, url, 200);
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public OrgLdapSettingsType UpdateLdapSettings(
      OrgLdapSettingsType orgLdapSettingsType)
    {
      return SdkUtil.Put<OrgLdapSettingsType>(this.VcloudClient, this.Reference.href + "/settings/ldap", SerializationUtil.SerializeObject<OrgLdapSettingsType>(orgLdapSettingsType, "com.vmware.vcloud.api.rest.schema"), "application/vnd.vmware.admin.organizationLdapSettings+xml", 200);
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
