// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.VcloudConstants
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System.Runtime.InteropServices;

namespace com.vmware.vcloud.sdk
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct VcloudConstants
  {
    public const string GLOBAL_SDK_LOGGER_NAME = "com.vmware.vcloud.sdk";
    public const string VCLOUD_API_V1_5_NAMESPACE = "http://www.vmware.com/vcloud/v1.5";
    public const string VCLOUD_PREFIX = "vcloud";
    public const string API_URI_PREFIX = "api";
    public const string ACCEPT_HEADER_NAME = "Accept";
    public const string LOCATION_HEADER = "Location";
    public const string VCLOUD_AUTHORIZATION_HEADER = "x-vcloud-authorization";
    public const string UTF_8_ENCODING = "UTF-8";
    public const string CONTENT_RANGE_HEADER = "Content-Range";
    public const string CONTENT_RANGE_BYTES_HEADER = "bytes ";
    public const string VERSION_1_5_HEADER = "application/*+xml;version=1.5";
    public const string VERSION_5_1_HEADER = "application/*+xml;version=5.1";
    public const string VERSION_5_5_HEADER = "application/*+xml;version=5.5";
    public const string SYSTEM_ORG = "System";
    public const string AUTHORIZATION_HEADER = "Authorization";
    public const string SIGN_ATTRIBUTE = "SIGN";
    public const string TOKEN_ATTRIBUTE = "token";
    public const string ORG_ATTRIBUTE = "org";
    public const string SIGNATURE_ATTRIBUTE = "signature";
    public const string SIGNATURE_ALGORITHM_ATTRIBUTE = "signature_alg";
    public const string VERSION_V1_5 = "v1.5";

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct SDKException
    {
      public const string NAME = "name";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VirtualDisk
    {
      public const string BUS_TYPE = "busType";
      public const string BUS_SUB_TYPE = "busSubType";
      public const string CAPACITY = "capacity";
      public const string DISK = "disk";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct VirtualNetworkCard
    {
      public const string IP_ADDRESS = "ipAddress";
      public const string IP_ADDRESSING_MODE = "ipAddressingMode";
      public const string PRIMARY_NETWORK_CONNECTION = "primaryNetworkConnection";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct QueryConstants
    {
      public const string OPEN_PARENTHESES = "(";
      public const string CLOSE_PARENTHESES = ")";
      public const string QUESTION_MARK = "?";
      public const string AMPERSAND = "&";
      public const string QUERY = "/query";
      public const string COMMA_SEPERATION = ",";
      public const string METADATA = "metadata";
      public const string AT = "@";
      public const string COLON = ":";
      public const string TYPED_STRING = "STRING";
      public const string TYPED_BOOLEAN = "BOOLEAN";
      public const string TYPED_NUMBER = "NUMBER";
      public const string TYPED_DATETIME = "DATETIME";

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct Params
      {
        public const string TYPE = "type=";
        public const string SORT_ASC = "sortAsc=";
        public const string SORT_DESC = "sortDesc=";
        public const string FIELDS = "fields=";
        public const string PAGE = "page=";
        public const string OFFSET = "offset=";
        public const string PAGE_SIZE = "pageSize=";
        public const string FORMAT = "format=";
        public const string FILTER = "filter=";
      }

      [StructLayout(LayoutKind.Sequential, Size = 1)]
      public struct SpecializedQuery
      {
        public const string CATALOGS = "/catalogs/query";
        public const string MEDIA_LIST = "/mediaList/query";
        public const string VAPPTEMPLATES = "/vAppTemplates/query";
        public const string VAPPS = "/vApps/query";
        public const string VMS = "/vms/query";
        public const string DISKS = "/disks/query";
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct OvfResourceConstants
    {
      public const string RASD_RESOURCE_TYPE_CPU = "3";
      public const string RASD_RESOURCE_TYPE_MEMORY = "4";
      public const string RASD_RESOURCE_TYPE_IDE_CONTROLLER = "5";
      public const string RASD_RESOURCE_TYPE_SCSI_CONTROLLER = "6";
      public const string RASD_RESOURCE_TYPE_DISK = "17";
      public const string RASD_RESOURCE_TYPE_NETWORK_ADAPTER = "10";
      public const string RASD_RESOURCE_TYPE_FLOPPY_DRIVE = "14";
      public const string RASD_RESOURCE_TYPE_CDROM_DRIVE = "15";
      public const string RASD_RESOURCE_TYPE_SERIAL_PORT = "21";
      public const string RASD_BUS_SUB_TYPE_BUS_LOGIC = "buslogic";
      public const string RASD_BUS_SUB_TYPE_LSI_LOGIC = "lsilogic";
      public const string RASD_BUS_SUB_TYPE_LSI_LOGIC_SAS = "lsilogicsas";
      public const string RASD_BUS_SUB_TYPE_VIRTUAL_SCSI = "VirtualSCSI";
      public const string RASD_NETWORK_ADAPTER_SUB_TYPE = "PCNet32";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct JaxbContext
    {
      public const string ovfSchema = "com.vmware.vcloud.api.rest.schema.ovf";
      public const string ovfVmwareSchema = "com.vmware.vcloud.api.rest.schema.ovf.vmware";
      public const string ovfEnvSchema = "com.vmware.vcloud.api.rest.schema.ovf.environment";
      public const string versioningSchema = "com.vmware.vcloud.api.rest.schema.versioning";
      public const string vcloudSchema = "com.vmware.vcloud.api.rest.schema";
      public const string vCloudExtensionSchema = "com.vmware.vcloud.api.rest.schema.extension";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Uri
    {
      public const string API_VERSIONS = "/versions";
      public const string SESSIONS = "/sessions";
      public const string SESSION = "/session";
      public const string ENTITY = "/entity";
      public const string SCHEMA = "/schema/";
      public const string ORGANIZATION = "/org/";
      public const string VDC = "/vdc/";
      public const string VAPP_TEMPLATE = "/vAppTemplate/";
      public const string VAPP = "/vApp/";
      public const string TASK = "/task/";
      public const string TASKS_LIST = "/tasksList/";
      public const string MEDIA = "/media/";
      public const string NETWORK = "/network/";
      public const string ADD_CATALOG_ITEMS_PATH = "/catalogItems";
      public const string CATALOG = "/catalog/";
      public const string CATALOG_ITEM = "/catalogItem/";
      public const string ERROR = "/error/";
      public const string CONTROL_ACCESS = "/controlAccess/";
      public const string QUESTION = "/question";
      public const string OWNER = "/owner";
      public const string SHADOW_VMS = "/shadowVms";
      public const string METADATA = "/metadata";
      public const string DISK_CREATE = "/disk";
      public const string DISK_ATTACHED_VMS = "/attachedVms";
      public const string VM_CAPABILITIES = "/vmCapabilities";
      public const string SUPPORTED_SYSTEMS_INFO = "/supportedSystemsInfo";
      public const string FILES = "/files";
      public const string API_DEFINITIONS = "/apidefinitions";
      public const string SERVICES = "/service";
      public const string RUNTIME_INFO_SECTION = "/runtimeInfoSection/";
      public const string LEASE_SETTINGS_SECTION = "/leaseSettingsSection/";
      public const string STARTUP_SECTION = "/startupSection/";
      public const string NETWORK_SECTION = "/networkSection/";
      public const string NETWORK_CONNECTION_SECTION = "/networkConnectionSection/";
      public const string PRODUCT_SECTIONS = "/productSections/";
      public const string NETWORK_CONFIG_SECTION = "/networkConfigSection/";
      public const string VIRTUAL_HARDWARE_SECTION = "/virtualHardwareSection/";
      public const string OPERATING_SYSTEM_SECTION = "/operatingSystemSection/";
      public const string GUEST_CUSTOMIZATION_SECTION = "/guestCustomizationSection/";
      public const string CUSTOMIZATION_SECTION = "/customizationSection/";
      public const string VIRTUAL_HARDWARE_SECTION_CPU = "/virtualHardwareSection/cpu";
      public const string VIRTUAL_HARDWARE_SECTION_MEMORY = "/virtualHardwareSection/memory";
      public const string VIRTUAL_HARDWARE_SECTION_DISKS = "/virtualHardwareSection/disks";
      public const string VIRTUAL_HARDWARE_SECTION_SERIAL_PORTS = "/virtualHardwareSection/serialPorts";
      public const string VIRTUAL_HARDWARE_SECTION_NETWORKCARDS = "/virtualHardwareSection/networkCards";
      public const string VIRTUAL_HARDWARE_SECTION_MEDIA = "/virtualHardwareSection/media";
      public const string ALLOCATED_ADDRESSES = "/allocatedAddresses";
      public const string COMPLIANCE_RESULT = "/complianceResult";
      public const string SNAPSHOT_SECTION = "/snapshotSection";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct RelationType
    {
      public const string UP = "up";
      public const string CATALOG_ITEM = "catalogItem";
      public const string CONTROL_ACCESS = "controlAccess";
      public const string DOWN = "down";
      public const string REPAIR = "repair";
      public const string SYNC_SYSLOG_SETTINGS = "syncSyslogSettings";
      public const string UPLOAD_DEFAULT = "upload:default";
      public const string DOWNLOAD_DEFAULT = "download:default";
      public const string NEXT_PAGE = "nextPage";
      public const string ALTERNATE = "alternate";
      public const string LAST_PAGE = "lastPage";
      public const string PREVIOUS_PAGE = "previousPage";
      public const string FIRST_PAGE = "firstPage";
      public const string STORAGE_PROFILE = "storageProfile";
      public const string DOWNLOAD_IDENTITY = "download:identity";
      public const string ORG_VDC_NETWORK = "orgVdcNetworks";
      public const string EDGE_GATEWAY = "edgeGateways";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct MediaType
    {
      public const string ORGANIZATION = "application/vnd.vmware.vcloud.org+xml";
      public const string ORGANIZATION_LIST = "application/vnd.vmware.vcloud.orgList+xml";
      public const string VDC = "application/vnd.vmware.vcloud.vdc+xml";
      public const string UPLOAD_VAPP_TEMPLATE_PARAMS = "application/vnd.vmware.vcloud.uploadVAppTemplateParams+xml";
      public const string INSTANTIATE_OVF_PARAMS = "application/vnd.vmware.vcloud.instantiateOvfParams+xml";
      public const string INSTANTIATE_VAPP_TEMPLATE_PARAMS = "application/vnd.vmware.vcloud.instantiateVAppTemplateParams+xml";
      public const string CLONE_VAPP_PARAMS = "application/vnd.vmware.vcloud.cloneVAppParams+xml";
      public const string MOVE_VAPP_PARAMS = "application/vnd.vmware.vcloud.moveVAppParams+xml";
      public const string CLONE_VAPP_TEMPLATE_PARAMS = "application/vnd.vmware.vcloud.cloneVAppTemplateParams+xml";
      public const string MOVE_VAPP_TEMPLATE_PARAMS = "application/vnd.vmware.vcloud.moveVAppTemplateParams+xml";
      public const string CLONE_MEDIA_PARAMS = "application/vnd.vmware.vcloud.cloneMediaParams+xml";
      public const string DISK_CREATE_PARAMS = "application/vnd.vmware.vcloud.diskCreateParams+xml";
      public const string MOVE_MEDIA_PARAMS = "application/vnd.vmware.vcloud.moveMediaParams+xml";
      public const string DEPLOY_VAPP_PARAMS = "application/vnd.vmware.vcloud.deployVAppParams+xml";
      public const string UNDEPLOY_VAPP_PARAMS = "application/vnd.vmware.vcloud.undeployVAppParams+xml";
      public const string UNDEPLOY_VAPP_PARAMS_EXTENDED = "application/vnd.vmware.vcloud.undeployVAppParamsExtended+xml";
      public const string CAPTURE_VAPP_PARAMS = "application/vnd.vmware.vcloud.captureVAppParams+xml";
      public const string COMPOSE_VAPP_PARAMS = "application/vnd.vmware.vcloud.composeVAppParams+xml";
      public const string VAPP_TEMPLATE = "application/vnd.vmware.vcloud.vAppTemplate+xml";
      public const string VAPP = "application/vnd.vmware.vcloud.vApp+xml";
      public const string VAPP_NETWORK = "application/vnd.vmware.vcloud.vAppNetwork+xml";
      public const string VM_CAPABILITIES = "application/vnd.vmware.vcloud.vmCapabilitiesSection+xml";
      public const string VM = "application/vnd.vmware.vcloud.vm+xml";
      public const string VM_ATTACH_DETACH_DISK_PARAMS = "application/vnd.vmware.vcloud.diskAttachOrDetachParams+xml";
      public const string MEDIA = "application/vnd.vmware.vcloud.media+xml";
      public const string DISK = "application/vnd.vmware.vcloud.disk+xml";
      public const string VDC_STORAGE_PROFILE = "application/vnd.vmware.vcloud.vdcStorageProfile+xml";
      public const string NETWORK = "application/vnd.vmware.vcloud.network+xml";
      public const string ORG_NETWORK = "application/vnd.vmware.vcloud.orgNetwork+xml";
      public const string ORG_VDC_NETWORK = "application/vnd.vmware.vcloud.orgVdcNetwork+xml";
      public const string TASK = "application/vnd.vmware.vcloud.task+xml";
      public const string TASKS_LIST = "application/vnd.vmware.vcloud.tasksList+xml";
      public const string CATALOG = "application/vnd.vmware.vcloud.catalog+xml";
      public const string CATALOG_ITEM = "application/vnd.vmware.vcloud.catalogItem+xml";
      public const string ERROR = "application/vnd.vmware.vcloud.error+xml";
      public const string SCREEN_TICKET = "application/vnd.vmware.vcloud.screenTicket+xml";
      public const string RELOCATE_VM = "application/vnd.vmware.vcloud.relocateVmParams+xml";
      public const string CONTROL_ACCESS = "application/vnd.vmware.vcloud.controlAccess+xml";
      public const string MEDIA_INSERT_EJECT_PARAMS = "application/vnd.vmware.vcloud.mediaInsertOrEjectParams+xml";
      public const string QUESTION = "application/vnd.vmware.vcloud.vmPendingQuestion+xml";
      public const string ANSWER = "application/vnd.vmware.vcloud.vmPendingAnswer+xml";
      public const string RECOMPOSE_VAPP_PARAMS = "application/vnd.vmware.vcloud.recomposeVAppParams+xml";
      public const string OWNER = "application/vnd.vmware.vcloud.owner+xml";
      public const string BLOCKING_TASK = "application/vnd.vmware.admin.blockingTask+xml";
      public const string METADATA = "application/vnd.vmware.vcloud.metadata+xml";
      public const string METADATA_VALUE = "application/vnd.vmware.vcloud.metadata.value+xml";
      public const string ENABLE_DOWNLOAD_PARAMS = "application/vnd.vmware.vcloud.enableDownloadParams+xml";
      public const string SERVICE = "application/vnd.vmware.vcloud.service+xml";
      public const string API_DEFINITION = "application/vnd.vmware.vcloud.apidefinition+xml";
      public const string RECONFIGURE_VM = "application/vnd.vmware.vcloud.vm+xml";
      public const string UPLOAD_VAPPTEMPLATE = "application/vnd.vmware.vcloud.uploadVAppTemplateParams+xml";
      public const string LEASE_SETTINGS_SECTION = "application/vnd.vmware.vcloud.leaseSettingsSection+xml";
      public const string STARTUP_SECTION = "application/vnd.vmware.vcloud.startupSection+xml";
      public const string NETWORK_SECTION = "application/vnd.vmware.vcloud.networkSection+xml";
      public const string NETWORK_CONNECTION_SECTION = "application/vnd.vmware.vcloud.networkConnectionSection+xml";
      public const string PRODUCT_SECTIONS = "application/vnd.vmware.vcloud.productSections+xml";
      public const string NETWORK_CONFIG_SECTION = "application/vnd.vmware.vcloud.networkConfigSection+xml";
      public const string VIRTUAL_HARDWARE_SECTION = "application/vnd.vmware.vcloud.virtualHardwareSection+xml";
      public const string OPERATING_SYSTEM_SECTION = "application/vnd.vmware.vcloud.operatingSystemSection+xml";
      public const string GUEST_CUSTOMIZATION_SECTION = "application/vnd.vmware.vcloud.guestCustomizationSection+xml";
      public const string CUSTOMIZATION_SECTION = "application/vnd.vmware.vcloud.customizationSection+xml";
      public const string CREATE_SNAPSHOT_PARAMS = "application/vnd.vmware.vcloud.createSnapshotParams+xml";
      public const string RASD_ITEM = "application/vnd.vmware.vcloud.rasdItem+xml";
      public const string RASD_ITEMS_LIST = "application/vnd.vmware.vcloud.rasdItemsList+xml";
      public const string OVF = "text/xml";
      public const string QUERY_ALTERNATE_REFERENCES = "application/vnd.vmware.vcloud.query.references+xml";
      public const string QUERY_ALTERNATE_ID_RECORDS = "application/vnd.vmware.vcloud.query.idrecords+xml";
      public const string QUERY_ALTERNATE_RECORDS = "application/vnd.vmware.vcloud.query.records+xml";
      public const string COPY_OR_MOVE_CATALOG_ITEM = "application/vnd.vmware.vcloud.copyOrMoveCatalogItemParams+xml";
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ActionUri
    {
      public const string UPLOAD_VAPP_TEMPLATE = "/action/uploadVAppTemplate";
      public const string INSTANTIATE_OVF = "/action/instantiateOvf";
      public const string VDC_MEDIA = "/media";
      public const string CLONE_MEDIA = "/action/cloneMedia";
      public const string MOVE_MEDIA = "/action/moveMedia";
      public const string CLONE_VAPP_TEMPLATE = "/action/cloneVAppTemplate";
      public const string MOVE_VAPP_TEMPLATE = "/action/moveVAppTemplate";
      public const string INSTANTIATE_VAPP_TEMPLATE = "/action/instantiateVAppTemplate";
      public const string CLONE_VAPP = "/action/cloneVApp";
      public const string MOVE_VAPP = "/action/moveVApp";
      public const string CAPTURE_VAPP = "/action/captureVApp";
      public const string COMPOSE_VAPP = "/action/composeVApp";
      public const string VAPP_DISCARD_STATE = "/action/discardSuspendedState";
      public const string ENABLE_DOWNLOAD = "/action/enableDownload";
      public const string ENABLE_LOSSLESS_DOWNLOAD = "/action/enableDownloadExt";
      public const string DISABLE_DOWNLOAD = "/action/disableDownload";
      public const string UPLOAD_VAPPTEMPLATE = "/action/upload";
      public const string VAPP_DEPLOY = "/action/deploy";
      public const string VAPP_UNDEPLOY = "/action/undeploy";
      public const string VAPP_UNDEPLOY_EXTENDED = "/action/undeployExtended";
      public const string VAPP_POWER_ON = "/power/action/powerOn";
      public const string VAPP_POWER_OFF = "/power/action/powerOff";
      public const string VAPP_RESET = "/power/action/reset";
      public const string VAPP_SUSPEND = "/power/action/suspend";
      public const string VAPP_SHUTDOWN = "/power/action/shutdown";
      public const string VAPP_REBOOT = "/power/action/reboot";
      public const string VAPP_SCREEN = "/screen";
      public const string VAPP_ACQUIRE_TICKET = "/screen/action/acquireTicket";
      public const string VM_INSERT_MEDIA = "/media/action/insertMedia";
      public const string VM_EJECT_MEDIA = "/media/action/ejectMedia";
      public const string VAPP_QUESTION_ANSWER = "/question/action/answer";
      public const string RECOMPOSE_VAPP = "/action/recomposeVApp";
      public const string INSTALL_VMWARETOOLS = "/action/installVMwareTools";
      public const string UPGRADE_HARDWARE = "/action/upgradeHardwareVersion";
      public const string CONSOLIDATE = "/action/consolidate";
      public const string RELOCATE_VM = "/action/relocate";
      public const string ENABLE_NESTED_HYPERVISOR = "/action/enableNestedHypervisor";
      public const string DISABLE_NESTED_HYPERVISOR = "/action/disableNestedHypervisor";
      public const string VM_ATTACH_DISK = "/disk/action/attach";
      public const string VM_DETACH_DISK = "/disk/action/detach";
      public const string CHECK_COMPLIANCE = "/action/checkCompliance";
      public const string CREATE_SNAPSHOT = "/action/createSnapshot";
      public const string REMOVE_ALL_SNAPSHOTS = "/action/removeAllSnapshots";
      public const string REVERT_TO_CURRENT_SNAPSHOT = "/action/revertToCurrentSnapshot";
      public const string RECONFIGURE_VM = "/action/reconfigureVm";
      public const string VAPP_MKS_ACQUIRE_TICKET = "/screen/action/acquireMksTicket";
      public const string ENABLE_MAINTENANCE_MODE = "/action/enterMaintenanceMode";
      public const string DISABLE_MAINTENANCE_MODE = "/action/exitMaintenanceMode";
      public const string VAPP_NETWORK_RESET = "/action/reset";
      public const string OVF = "/ovf";
      public const string CONTROL_ACCESS = "/action/controlAccess";
      public const string CONTROL_ACCESS_VIEW = "/controlAccess/";
      public const string CANCEL_TASK = "/action/cancel";
      public const string COPY_CATALOG_ITEM = "/action/copy";
      public const string MOVE_CATALOG_ITEM = "/action/move";
      public const string SYNC = "/action/sync";
    }
  }
}
