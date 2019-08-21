// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.AdminsConstants
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System.Runtime.InteropServices;

namespace com.vmware.vcloud.sdk.admin
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  internal struct AdminsConstants
  {
    public const string GLOBAL_SDK_LOGGER_NAME = "com.vmware.vcloud.sdk";
    public const string ACTION = "/action";

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Uri
    {
      public const string ADMIN_PREFIX = "/admin";
      public const string ADMIN = "/admin/";
      public const string PROVIDER_VDC = "/providervdc/";
      public const string VDC_REFERENCES = "/vdcReferences";
      public const string ADMIN_VDC = "/vdc/";
      public const string ORGANIZATION = "/org/";
      public const string USER = "/user/";
      public const string GROUP = "/group/";
      public const string RIGHT = "/right/";
      public const string ROLE = "/role/";
      public const string CATALOG = "/catalog/";
      public const string NETWORK = "/network/";
      public const string NETWORK_POOL = "/networkPool/";
      public const string CATALOG_ITEM = "/catalogItem/";
      public const string ADD_USERS_PATH = "/users";
      public const string ADD_GROUPS_PATH = "/groups";
      public const string ADD_CATALOGS_PATH = "/catalogs";
      public const string ADD_CATALOG_ITEMS_PATH = "/catalogItems";
      public const string ADD_ORGANIZATIONS_PATH = "orgs";
      public const string ADD_VDCS_PATH = "/vdcs";
      public const string ADD_VDCS_PARAMS = "/vdcsparams";
      public const string ADD_NETWORKS_PATH = "/networks";
      public const string ADD_ROLES_PATH = "roles";
      public const string CATALOG_PUBLISH = "/publish";
      public const string OWNER = "/owner";
      public const string SETTINGS = "/settings";
      public const string EVENTS = "/events";
      public const string GENERAL_SETTINGS = "/general";
      public const string GUEST_PERSONALIZATION_SETTINGS = "/guestPersonalizationSettings";
      public const string OPERATION_LIMIT_SETTINGS = "/operationLimitsSettings";
      public const string VAPP_TEMPLATE_LEASE_SETTINGS = "/vAppTemplateLeaseSettings";
      public const string VAPP_LEASE_SETTINGS = "/vAppLeaseSettings";
      public const string EMAIL_SETTINGS = "/email";
      public const string FEDERATION_SETTINGS = "/federation";
      public const string PASSWORD_POLICY_SETTINGS = "/passwordPolicy";
      public const string STORAGE_PROFILE = "/vdcStorageProfile";
      public const string STORAGE_PROFILES = "/vdcStorageProfiles";
      public const string ALLOCATED_ADDRESSES = "/allocatedAddresses";
      public const string ENTITY_RIGHTS = "/entityRights";
      public const string GRANTED_RIGHTS = "/grantedRights";
      public const string EDGE_GATEWAYS = "/edgeGateways";
      public const string LDAP = "/ldap";
      public const string LDAP_SETTINGS = "/ldapSettings";
      public const string PUBLISH_TO_EXTERNAL_ORGS = "/publishToExternalOrganizations";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct RelationType
    {
      public const string UP = "up";
      public const string ALTERNATE = "alternate";
      public const string DOWN = "down";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct MediaType
    {
      public const string ADMIN_MEDIA_TYPE_PREFIX = "application/vnd.vmware.admin.";
      public const string VCLOUD = "application/vnd.vmware.admin.vcloud+xml";
      public const string PROVIDER_VDC = "application/vnd.vmware.admin.providervdc+xml";
      public const string ADMIN_VDC = "application/vnd.vmware.admin.vdc+xml";
      public const string ADMIN_VDC_PARAMS = "application/vnd.vmware.admin.createVdcParams+xml";
      public const string VDC = "application/vnd.vmware.vcloud.vdc+xml";
      public const string VAPP_TEMPLATE = "application/vnd.vmware.vcloud.vAppTemplate+xml";
      public const string VAPP = "application/vnd.vmware.vcloud.vApp+xml";
      public const string VM = "application/vnd.vmware.vcloud.vm+xml";
      public const string MEDIA = "application/vnd.vmware.vcloud.media+xml";
      public const string SYSTEM_ADMIN_ORGANIZATION = "application/vnd.vmware.admin.systemOrganization+xml";
      public const string ADMIN_ORGANIZATION = "application/vnd.vmware.admin.organization+xml";
      public const string ORGANIZATION = "application/vnd.vmware.vcloud.org+xml";
      public const string TASKS_LIST = "application/vnd.vmware.vcloud.tasksList+xml";
      public const string USER = "application/vnd.vmware.admin.user+xml";
      public const string GROUP = "application/vnd.vmware.admin.group+xml";
      public const string ROLE = "application/vnd.vmware.admin.role+xml";
      public const string RIGHT = "application/vnd.vmware.admin.right+xml";
      public const string ADMIN_CATALOG = "application/vnd.vmware.admin.catalog+xml";
      public const string CATALOG = "application/vnd.vmware.vcloud.catalog+xml";
      public const string ADMIN_CATALOG_ITEM = "application/vnd.vmware.admin.catalogItem+xml";
      public const string CATALOG_ITEM = "application/vnd.vmware.vcloud.catalogItem+xml";
      public const string ADMIN_NETWORK = "application/vnd.vmware.admin.network+xml";
      public const string ORG_NETWORK = "application/vnd.vmware.admin.orgNetwork+xml";
      public const string ORG_VDC_NETWORK = "application/vnd.vmware.vcloud.orgVdcNetwork+xml";
      public const string USER_ORG_NETWORK = "application/vnd.vmware.vcloud.orgNetwork+xml";
      public const string NETWORK = "application/vnd.vmware.vcloud.network+xml";
      public const string NETWORK_POOL = "application/vnd.vmware.admin.networkPool+xml";
      public const string CATALOG_PUBLISH = "application/vnd.vmware.admin.publishCatalogParams+xml";
      public const string OWNER = "application/vnd.vmware.vcloud.owner+xml";
      public const string ORG_SETTINGS = "application/vnd.vmware.admin.orgSettings+xml";
      public const string EVENT = "application/vnd.vmware.admin.event+xml";
      public const string VAPP_TEMPLATE_LEASE_SETTINGS = "application/vnd.vmware.admin.vAppTemplateLeaseSettings+xml";
      public const string VAPP_LEASE_SETTINGS = "application/vnd.vmware.admin.vAppLeaseSettings+xml";
      public const string EMAIL_SETTINGS = "application/vnd.vmware.admin.organizationEmailSettings+xml";
      public const string FEDERATION_SETTINGS = "application/vnd.vmware.admin.organizationFederationSettings+xml";
      public const string GENERAL_SETTINGS = "application/vnd.vmware.admin.organizationGeneralSettings+xml";
      public const string GUEST_PERSONALIZATION_SETTINGS = "application/vnd.vmware.admin.guestPersonalizationSettings+xml";
      public const string OPERATION_LIMIT_SETTINGS = "application/vnd.vmware.admin.operationLimitsSettings+xml";
      public const string ORGANIZATION_PASSWORD_POLICY_SETTINGS = "application/vnd.vmware.admin.organizationPasswordPolicySettings+xml";
      public const string ORG_VDC_RESOURCEPOOL_SET = "application/vnd.vmware.admin.OrganizationVdcResourcePoolSet+xml";
      public const string DISK = "application/vnd.vmware.vcloud.disk+xml";
      public const string UPDATE_VDCSTORAGE_PROFILES = "application/vnd.vmware.admin.updateVdcStorageProfiles+xml";
      public const string ENTITY_REFERENCES = "application/vnd.vmware.admin.entityReferences+xml";
      public const string ADMIN_VDC_STORAGE_PROFILE = "application/vnd.vmware.admin.vdcStorageProfile+xml";
      public const string PROVIDER_VDC_STORAGE_PROFILE = "application/vnd.vmware.admin.pvdcStorageProfile+xml";
      public const string EDGE_GATEWAY = "application/vnd.vmware.admin.edgeGateway+xml";
      public const string OPERATION_LDAP_SSPI_KEYTAB = "application/vnd.vmware.admin.sspiKeytabUpdateParams+xml";
      public const string OPERATION_LDAP_CERTIFICATE = "application/vnd.vmware.admin.certificateUpdateParams+xml";
      public const string OPERATION_LDAP_KEY_STORE = "application/vnd.vmware.admin.keystoreUpdateParams+xml";
      public const string EDGE_GATEWAY_CONFIGURE_SERVICES = "application/vnd.vmware.admin.edgeGatewayServiceConfiguration+xml";
      public const string LDAP_SETTINGS = "application/vnd.vmware.admin.organizationLdapSettings+xml";
      public const string PUBLISH_TO_EXTERNAL_ORGS = "application/vnd.vmware.admin.publishExternalCatalogParams+xml";
      public const string SUBSCRIBE_TO_EXTERNAL_CATALOG = "application/vnd.vmware.admin.externalCatalogSubscriptionParams+xml";
      public const string REGISTER_VAPP = "application/vnd.vmware.admin.registerVAppParams+xml";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ActionUri
    {
      public const string ORG_ENABLE = "/action/enable";
      public const string ORG_DISABLE = "/action/disable";
      public const string VDC_ENABLE = "/action/enable";
      public const string VDC_DISABLE = "/action/disable";
      public const string NETWORK_RESET = "/action/reset";
      public const string USER_UNLOCK = "/action/unlock";
      public const string SYNC_SYSLOG_SERVER = "/action/syncSyslogServerSettings";
      public const string EDGE_GATEWAY_REAPPLY_SERVICES = "/action/reapplyServices";
      public const string EDGE_GATEWAY_REDEPLOY = "/action/redeploy";
      public const string EDGE_GATEWAY_SYNC_SYSLOG_SERVER_SETTINGS = "/action/syncSyslogServerSettings";
      public const string EDGE_GATEWAY_UPGRADE_CONFIG = "/action/upgradeConfig";
      public const string ORG_RESET_LDAP_CERTIFICATE = "/action/resetLdapCertificate";
      public const string ORG_RESET_LDAP_KEY_STORE = "/action/resetLdapKeyStore";
      public const string OPERATION_LDAP_SSPI_KEYTAB = "/action/updateLdapSspiKeytab";
      public const string OPERATION_LDAP_CERTIFICATE = "/action/updateLdapCertificate";
      public const string OPERATION_LDAP_KEY_STORE = "/action/updateLdapKeyStore";
      public const string EDGE_GATEWAY_CONFIGURE_SERVICES = "/action/configureServices";
      public const string RESET_LDAP_SSPI_KEY_TAB = "/action/resetLdapSspiKeytab";
      public const string SUBSCRIBE_TO_EXTERNAL_CATALOG = "/action/subscribeToExternalCatalog";
      public const string REGISTER_VAPP = "/action/registerVApp";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct QueryConstants
    {
      public const string QUESTION_MARK = "?";
      public const int MAX_PAGE_SIZE = 128;

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct SpecializedQuery
      {
        public const string GROUPS = "/admin/groups/query";
        public const string USERS = "/admin/users/query";
        public const string STRANDED_USERS = "/admin/strandedUsers/query";
        public const string ROLES = "/admin/roles/query";
        public const string RIGHTS = "/admin/rights/query";
        public const string ORGS = "/admin/orgs/query";
        public const string ORG_VDCS = "/admin/vdcs/query";
      }
    }
  }
}
