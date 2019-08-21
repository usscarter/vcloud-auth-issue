// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.AdminExtensionConstants
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Runtime.InteropServices;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  internal class AdminExtensionConstants
  {
    public const string GLOBAL_SDK_LOGGER_NAME = "com.vmware.vcloud.sdk";

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Uri
    {
      public const string ENTITY = "/entity";
      public const string EXTENSION = "/admin/extension";
      public const string BLOCKING_TASK = "/blockingTask";
      public const string APPROVALS = "/approvals";
      public const string BLOCKING_TASKS = "/blockingTasks";
      public const string HOST = "/host/";
      public const string VIRTUAL_CENTER = "/vimServer/";
      public const string SHIELD_MANAGER = "/shieldmanager/";
      public const string PROVIDER_VDC = "/providervdc/";
      public const string EXTERNAL_NET = "/externalnet/";
      public const string NETWORK_POOL = "/networkPool/";
      public const string ADD_PVDCS_PATH = "/providervdcs";
      public const string ADD_PVDCS_PARAMS = "/providervdcsparams";
      public const string ADD_ENETS_PATH = "/externalnets";
      public const string ADD_POOLS_PATH = "/networkPools";
      public const string VMS_OBJECT_REFS_LIST = "/vmsList";
      public const string IMPORT_VM_AS_VAPP = "/importVmAsVApp";
      public const string IMPORT_VM_AS_VAPP_TEMPLATE = "/importVmAsVAppTemplate";
      public const string IMPORT_MEDIA = "/importMedia";
      public const string IMPORT_VM_INTO_EXISTING_VAPP = "/importVmIntoExistingVApp";
      public const string RESOURCE_POOL_LIST = "/resourcePoolList";
      public const string RESOURCEPOOLS = "/resourcePools";
      public const string HOST_REFERENCES = "/hostReferences";
      public const string DATASTORE_REFERENCES = "/datastores";
      public const string NETWORK_REFERENCES = "/networks";
      public const string PROVIDER_VDC_REFERENCES = "/providerVdcReferences";
      public const string EXTERNAL_NETWORK_REFERENCES = "/externalNetworkReferences";
      public const string NETWORK_POOL_REFERENCES = "/networkPoolReferences";
      public const string VIM_SERVER_REFERENCES = "/vimServerReferences";
      public const string LICENSING = "/licensing/";
      public const string LICENSING_REPORT_LIST = "reports";
      public const string LICENSING_REPORT = "report/";
      public const string SETTINGS = "/settings";
      public const string LDAP_SETTINGS = "/ldapSettings";
      public const string KERBEROS = "/kerberosSettings";
      public const string GENERAL = "/general";
      public const string EMAIL_TEMPLATE = "/email";
      public const string OPERATIONS = "/operations";
      public const string PASSWORD_POLICY_SETTINGS = "/passwordPolicy";
      public const string AMQP = "/amqp";
      public const string NOTIFICATIONS = "/notifications";
      public const string BRANDING = "/branding";
      public const string LICENSE = "/license";
      public const string LOOKUP_SERVICE = "/lookupService";
      public const string EMAIL = "/email";
      public const string AVAILABLE_STORAGE_PROFILES = "/availableStorageProfiles";
      public const string STORAGE_PROFILES = "/storageProfiles";
      public const string SERVICE = "/service";
      public const string VSPHERE_WEB_CLIENT_URL = "/vSphereWebClientUrl";
      public const string EXTENSION_SERVICES = "/extensionServices";
      public const string LIST_VM = "/vmList";
      public const string LOCALIZATION_BUNDLES = "localizationbundles";
      public const string AUTHORIZATION_CHECK = "/authorizationcheck";
      public const string VENDOR_SERVICES = "/vendorServices";
      public const string CATALOG = "/catalog";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ActionUri
    {
      public const string HOST = "/host";
      public const string PREPARE_HOST = "/action/prepare";
      public const string UNPREPARE_HOST = "/action/unprepare";
      public const string DISABLE = "/action/disable";
      public const string ENABLE = "/action/enable";
      public const string FORCE_DELETE = "/action/forceDelete";
      public const string MERGE = "/action/merge";
      public const string REGISTER_VIM_SERVER = "/action/registervimserver";
      public const string UNREGISTER_VIM_SERVER = "/action/unregister";
      public const string REPAIR_HOST = "/action/repair";
      public const string UPGRADE_HOST = "/action/upgrade";
      public const string FORCE_VIM_SERVER_RECONNECT = "/action/forcevimserverreconnect";
      public const string PROVIDER_VDC_ENABLE = "/action/enable";
      public const string PROVIDER_VDC_DISABLE = "/action/disable";
      public const string EXTERNAL_NETWORK_RESET = "/action/reset";
      public const string ABORT = "/action/abort";
      public const string FAIL = "/action/fail";
      public const string RESUME = "/action/resume";
      public const string TEST = "/action/test";
      public const string UPDATE_PROGRESS = "/action/updateProgress";
      public const string UPDATE_RESOURCE_POOLS = "/action/updateResourcePools";
      public const string REFRESH_STORAGE_PROFILES = "/action/refreshStorageProfiles";
      public const string MIGRATE_VMS = "/action/migrateVms";
      public const string CLEAR_UNUSED_RIGHTS = "/action/clearunusedrights";
      public const string REFRESH_VIM_SERVER = "/action/refresh";
      public const string CLEAR_UNUSED_LOCALIZATION_BUNDLES = "/action/clearunusedlocalizationbundles";
      public const string RESET_AMQP_CERTIFICATE = "/action/resetAmqpCertificate";
      public const string RESET_AMQP_TRUST_STORE = "/action/resetAmqpTruststore";
      public const string RESET_VC_TRUST_STORE = "/action/resetVcTrustsore";
      public const string RESET_LDAP_CERTIFICATE = "/action/resetLdapCertificate";
      public const string RESET_LDAP_KEY_STORE = "/action/resetLdapKeyStore";
      public const string RESET_LDAP_SSPI_KEY_TAB = "/action/resetLdapSspiKeytab";
      public const string UPDATE_AMQP_CERTIFICATE = "/action/updateAmqpCertificate";
      public const string UPDATE_AMQP_TRUSTSTORE = "/action/updateAmqpTruststore";
      public const string UPDATE_VC_TRUSTSORE = "/action/updateVcTrustsore";
      public const string UPDATE_LDAP_CERTIFICATE = "/action/updateLdapCertificate";
      public const string UPDATE_LDAP_KEYSTORE = "/action/updateLdapKeyStore";
      public const string UPDATE_LDAP_SSPI_KEYTAB = "/action/updateLdapSspiKeytab";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct RelationType
    {
      public const string ALTERNATE = "alternate";
      public const string DOWN = "down";
      public const string UP = "up";
      public const string UPLOAD_DEFAULT = "upload:default";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct MediaType
    {
      public const string VMW_EXTENSIONM = "application/vnd.vmware.admin.vmwExtension+xml";
      public const string VMW_PROVIDER_VDC_REFERENCESM = "application/vnd.vmware.admin.vmwProviderVdcReferences+xml";
      public const string VMW_EXTERNAL_NETWORK_REFERENCESM = "application/vnd.vmware.admin.vmwExternalNetworkReferences+xml";
      public const string VMW_NETWORK_POOL_REFERENCESM = "application/vnd.vmware.admin.vmwNetworkPoolReferences+xml";
      public const string VMW_VIM_SERVER_REFERENCESM = "application/vnd.vmware.admin.vmwVimServerReferences+xml";
      public const string VMW_HOST_REFERENCESM = "application/vnd.vmware.admin.vmwHostReferences+xml";
      public const string HOSTM = "application/vnd.vmware.admin.host+xml";
      public const string STRANDED_ITEM = "application/vnd.vmware.admin.strandedItem+xml";
      public const string VIRUAL_CENTERM = "application/vnd.vmware.admin.vmwvirtualcenter+xml";
      public const string SHIELD_MANAGER = "application/vnd.vmware.admin.vshieldmanager+xml";
      public const string VMW_PROVIDER_VDCM = "application/vnd.vmware.admin.vmwprovidervdc+xml";
      public const string VMW_PROVIDER_VDC_PARAMS = "application/vnd.vmware.admin.createProviderVdcParams+xml";
      public const string PROVIDER_VDC = "application/vnd.vmware.admin.providervdc+xml";
      public const string VMW_EXTERNAL_NETM = "application/vnd.vmware.admin.vmwexternalnet+xml";
      public const string NETWORK = "application/vnd.vmware.admin.network+xml";
      public const string DATASTORE = "application/vnd.vmware.admin.datastore+xml";
      public const string VMW_NETWORKPOOL = "application/vnd.vmware.admin.networkPool+xml";
      public const string PREPARE_HOST_PARAMSM = "application/vnd.vmware.admin.prepareHostParams+xml";
      public const string REGISTER_VIM_SERVERM = "application/vnd.vmware.admin.registerVimServerParams+xml";
      public const string VMS_OBJECT_REFS_LISTM = "application/vnd.vmware.admin.vmsObjectRefsList+xml";
      public const string IMPORT_VM_AS_VAPP_PARAMS = "application/vnd.vmware.admin.importVmAsVAppParams+xml";
      public const string IMPORT_VM_AS_VAPP_TEMPLATE_PARAMS = "application/vnd.vmware.admin.importVmAsVAppTemplateParams+xml";
      public const string IMPORT_VM_INTO_EXISTING_VAPP_PARAMS = "application/vnd.vmware.admin.importVmIntoExistingVAppParams+xml";
      public const string IMPORT_MEDIA_PARAMS = "application/vnd.vmware.admin.importMediaParams+xml";
      public const string RESOURCE_POOL_LIST = "application/vnd.vmware.admin.resourcePoolList+xml";
      public const string RESOURCEPOOL_SET_UPDATE_PARAMS = "application/vnd.vmware.admin.resourcePoolSetUpdateParams+xml";
      public const string LICENSING_REPORT = "application/vnd.vmware.admin.licensingReport+xml";
      public const string LICENSING_REPORT_LIST = "application/vnd.vmware.admin.licensingReportList+xml";
      public const string VDC_REFERENCES = "application/vnd.vmware.admin.vdcReferences+xml";
      public const string BLOCKING_TASK_OPERATION_PARAMSM = "application/vnd.vmware.admin.blockingTaskOperationParams+xml";
      public const string BLOCKING_TASK = "application/vnd.vmware.admin.blockingTask+xml";
      public const string BLOCKING_TASK_UPDATE_PROGRESS_OPERATION_PARAMSM = "application/vnd.vmware.admin.blockingTaskUpdateProgressOperationParams+xml";
      public const string TASK = "application/vnd.vmware.vcloud.task+xml";
      public const string SYSTEM_SETTINGS = "application/vnd.vmware.admin.systemSettings+xml";
      public const string GENERAL_SETTINGS = "application/vnd.vmware.admin.generalSettings+xml";
      public const string KERBEROS_SETTINGS = "application/vnd.vmware.admin.kerberosSettings+xml";
      public const string BRANDING_SETTINGS = "application/vnd.vmware.admin.brandingSettings+xml";
      public const string EMAIL_SETTINGS = "application/vnd.vmware.admin.emailSettings+xml";
      public const string LICENSE_SETTINGS = "application/vnd.vmware.admin.licenseSettings+xml";
      public const string EMAIL_TEMPLATE = "application/vnd.vmware.admin.emailTemplate+xml";
      public const string ENABLED_TASK_OPERATIONS = "application/vnd.vmware.admin.taskOperationList+xml";
      public const string APPROVAL_SETTINGS = "application/vnd.vmware.admin.approvalSettings+xml";
      public const string EXTENSION_SETTINGS = "application/vnd.vmware.admin.extensionSettings+xml";
      public const string SYSTEM_PASSWORD_POLICY_SETTINGS = "application/vnd.vmware.admin.systemPasswordPolicySettings+xml";
      public const string AMQP_SETTINGS = "application/vnd.vmware.admin.amqpSettings+xml";
      public const string NOTOFICATIONS_SETTINGS = "application/vnd.vmware.admin.notificationsSettings+xml";
      public const string LDAP_SETTINGS = "application/vnd.vmware.admin.ldapSettings+xml";
      public const string UPDATE_PROVIDER_VDC_STORAGE_PROFILES = "application/vnd.vmware.admin.updateProviderVdcStorageProfiles+xml";
      public const string VMW_PROVIDER_VDC_STORAGE_PROFILE = "application/vnd.vmware.admin.vmwPvdcStorageProfile+xml";
      public const string MIGRATE_VM_PARAMS = "application/vnd.vmware.admin.migrateVmParams+xml";
      public const string SERVICE_PARAMS = "application/vnd.vmware.admin.service+xml";
      public const string MERGE_PARAMS = "application/vnd.vmware.admin.providerVdcMergeParams+xml";
      public const string LOOKUP_SERVICE = "application/vnd.vmware.admin.lookupServiceParams+xml";
      public const string OPERATION_AMQP_CERTIFICATE = "application/vnd.vmware.admin.certificateUpdateParams+xml";
      public const string OPERATION_AMQP_TRUSTSTORE = "application/vnd.vmware.admin.trustStoreUpdateParams+xml";
      public const string OPERATION_VC_TRUSTSORE = "application/vnd.vmware.admin.vcTrustStoreUpdateParams+xml";
      public const string OPERATION_LDAP_CERTIFICATE = "application/vnd.vmware.admin.certificateUpdateParams+xml";
      public const string OPERATION_LDAP_KEYSTORE = "application/vnd.vmware.admin.keystoreUpdateParams+xml";
      public const string OPERATION_LDAP_SSPI_KEYTAB = "application/vnd.vmware.admin.sspiKeytabUpdateParams+xml";
      public const string LOCALIZATION_BUNDLES = "application/vnd.vmware.admin.bundleUploadParams+xml";
      public const string AUTHORIZATION_CHECK = "application/vnd.vmware.admin.authorizationCheckParams+xml";
      public const string CATALOG_SETTINGS = "application/vnd.vmware.admin.catalogSettings+xml";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct QueryConstants
    {
      public const string QUESTION_MARK = "?";

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct SpecializedQuery
      {
        public const string VMW_HOSTS = "/admin/extension/hostReferences/query";
        public const string VMW_DATASTORES = "/admin/extension/datastores/query";
        public const string VMW_EXTERNAL_NETWORKS = "/admin/extension/externalNetworkReferences/query";
        public const string VMW_NETWORK_POOLS = "/admin/extension/networkPoolReferences/query";
        public const string VMW_PROVIDER_VDCS = "/admin/extension/providerVdcReferences/query";
        public const string VMW_VIM_SERVERS = "/admin/extension/vimServerReferences/query";
        [Obsolete("This query constant type is deprecated  since API 5.1, SDK 5.1")]
        public const string ORG_NETWORKS = "/admin/extension/orgNetworks/query";
        public const string ADMIN_VAPPS = "/admin/extension/vapps/query";
        public const string ADMIN_ORG_VDCS = "/admin/extension/orgVdcs/query";
        public const string STRANDED_ITEMS = "/admin/extension/strandedItems/query";
        public const string EXTENSION_SERVICES = "/admin/extension/service/query";
      }
    }
  }
}
