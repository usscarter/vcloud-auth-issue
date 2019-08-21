// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.BlockingTaskOperationType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct BlockingTaskOperationType
  {
    public static BlockingTaskOperationType VDC_CREATE_VDC = BlockingTaskOperationType.Get("vdcCreateVdc");
    public static BlockingTaskOperationType VDC_DELETE_VDC = BlockingTaskOperationType.Get("vdcDeleteVdc");
    public static BlockingTaskOperationType VDC_UPDATE_VDC = BlockingTaskOperationType.Get("vdcUpdateVdc");
    public static BlockingTaskOperationType VDC_ENABLE_DOWNLOAD = BlockingTaskOperationType.Get("vdcEnableDownload");
    public static BlockingTaskOperationType VAPP_MIGRATE_VMS = BlockingTaskOperationType.Get("vappMigrateVms");
    public static BlockingTaskOperationType RCL_CREATE_PROVIDER_VDC = BlockingTaskOperationType.Get("rclCreateProviderVdc");
    public static BlockingTaskOperationType RCL_DELETE_PROVIDER_VDC = BlockingTaskOperationType.Get("rclDeleteProviderVdc");
    public static BlockingTaskOperationType RCL_MERGE_PROVIDER_VDC = BlockingTaskOperationType.Get("rclMergePvdc");
    public static BlockingTaskOperationType NETWORK_CREATE_NETWORK_POOL = BlockingTaskOperationType.Get("networkCreateNetworkPool");
    public static BlockingTaskOperationType NETWORK_ENABLE_CROSSHOST_SERVICE = BlockingTaskOperationType.Get("networkCreateFencePoolTypeNetworkPool");
    public static BlockingTaskOperationType NETWORK_CREATE_PROVIDER_NETWORK = BlockingTaskOperationType.Get("networkCreateExternalNetwork");
    public static BlockingTaskOperationType NETWORK_DELETE_NETWORK_POOL = BlockingTaskOperationType.Get("networkDeleteNetworkPool");
    public static BlockingTaskOperationType NETWORK_UPDATE_NETWORK_POOL = BlockingTaskOperationType.Get("networkUpdateNetworkPool");
    public static BlockingTaskOperationType NETWORK_UPDATE_VLAN_POOL = BlockingTaskOperationType.Get("networkUpdateVlanPool");
    public static BlockingTaskOperationType IMPORT_SINGLETON_TEMPLATE = BlockingTaskOperationType.Get("importSingletonTemplate");
    public static BlockingTaskOperationType IMPORT_SINGLETON_VAPP = BlockingTaskOperationType.Get("importSingletonVapp");
    public static BlockingTaskOperationType IMPORT_MEDIA = BlockingTaskOperationType.Get("importMedia");
    public static BlockingTaskOperationType IMPORT_INTO_EXISTING_VAPP = BlockingTaskOperationType.Get("importIntoExistingVapp");
    public static BlockingTaskOperationType IMPORT_VC_VMS_INTO_EXISTING_VAPP = BlockingTaskOperationType.Get("importVcVmsIntoExistingVApp");
    public static BlockingTaskOperationType VAPP_UPDATE_VM = BlockingTaskOperationType.Get("vappUpdateVm");
    public static BlockingTaskOperationType TEMPLATE_UPDATE_VM = BlockingTaskOperationType.Get("templateUpdateVm");
    public static BlockingTaskOperationType VAPP_DEPLOY = BlockingTaskOperationType.Get("vappDeploy");
    public static BlockingTaskOperationType VAPP_POWER_OFF = BlockingTaskOperationType.Get("vappPowerOff");
    public static BlockingTaskOperationType VAPP_SUSPEND = BlockingTaskOperationType.Get("vappSuspend");
    public static BlockingTaskOperationType VAPP_RESET = BlockingTaskOperationType.Get("vappReset");
    public static BlockingTaskOperationType VAPP_REBOOT_GUEST = BlockingTaskOperationType.Get("vappRebootGuest");
    public static BlockingTaskOperationType VAPP_SHUTDOWN_GUEST = BlockingTaskOperationType.Get("vappShutdownGuest");
    public static BlockingTaskOperationType VAPP_UPGRADE_HW_VERSION = BlockingTaskOperationType.Get("vappUpgradeHwVersion");
    public static BlockingTaskOperationType VAPP_UNDEPLOY_POWER_OFF = BlockingTaskOperationType.Get("vappUndeployPowerOff");
    public static BlockingTaskOperationType VAPP_UNDEPLOY_SUSPEND = BlockingTaskOperationType.Get("vappUndeploySuspend");
    public static BlockingTaskOperationType VAPP_ATTACH_DISK = BlockingTaskOperationType.Get("vappAttachDisk");
    public static BlockingTaskOperationType VAPP_DETACH_DISK = BlockingTaskOperationType.Get("vappDetachDisk");
    public static BlockingTaskOperationType VAPP_CHECK_VM_COMPLIANCE = BlockingTaskOperationType.Get("vappCheckVmCompliance");
    public static BlockingTaskOperationType VAPP_CREATE_SNAPSHOT = BlockingTaskOperationType.Get("vappCreateSnapshot");
    public static BlockingTaskOperationType VAPP_REVERT_TO_CURRENT_SNAPSHOT = BlockingTaskOperationType.Get("vappRevertToCurrentSnapshot");
    public static BlockingTaskOperationType VAPP_REMOVE_ALL_SNAPSHOTS = BlockingTaskOperationType.Get("vappRemoveAllSnapshots");
    public static BlockingTaskOperationType VDC_INSTANTIATE_VAPP = BlockingTaskOperationType.Get("vdcInstantiateVapp");
    public static BlockingTaskOperationType VDC_COMPOSE_VAPP = BlockingTaskOperationType.Get("vdcComposeVapp");
    public static BlockingTaskOperationType VDC_RECOMPOSE_VAPP = BlockingTaskOperationType.Get("vdcRecomposeVapp");
    public static BlockingTaskOperationType VDC_CAPTURE_TEMPLATE = BlockingTaskOperationType.Get("vdcCaptureTemplate");
    public static BlockingTaskOperationType VDC_COPY_VAPP = BlockingTaskOperationType.Get("vdcCopyVapp");
    public static BlockingTaskOperationType VDC_COPY_TEMPLATE = BlockingTaskOperationType.Get("vdcCopyTemplate");
    public static BlockingTaskOperationType VDC_COPY_MEDIA = BlockingTaskOperationType.Get("vdcCopyMedia");
    public static BlockingTaskOperationType VDC_UPDATE_VAPP = BlockingTaskOperationType.Get("vdcUpdateVapp");
    public static BlockingTaskOperationType VDC_UPDATE_TEMPLATE = BlockingTaskOperationType.Get("vdcUpdateTemplate");
    public static BlockingTaskOperationType VDC_UPDATE_MEDIA = BlockingTaskOperationType.Get("vdcUpdateMedia");
    public static BlockingTaskOperationType VDC_DELETE_VAPP = BlockingTaskOperationType.Get("vdcDeleteVapp");
    public static BlockingTaskOperationType VDC_DELETE_TEMPLATE = BlockingTaskOperationType.Get("vdcDeleteTemplate");
    public static BlockingTaskOperationType VDC_DELETE_MEDIA = BlockingTaskOperationType.Get("vdcDeleteMedia");
    public static BlockingTaskOperationType VDC_CREATE_DISK = BlockingTaskOperationType.Get("vdcCreateDisk");
    public static BlockingTaskOperationType VDC_DELETE_DISK = BlockingTaskOperationType.Get("vdcDeleteDisk");
    public static BlockingTaskOperationType VDC_UPDATE_DISK = BlockingTaskOperationType.Get("vdcUpdateDisk");
    public static BlockingTaskOperationType VDC_UPDATE_STORAGE_PROFILES = BlockingTaskOperationType.Get("vdcUpdateStorageProfiles");
    public static BlockingTaskOperationType VDC_UPLOAD_MEDIA = BlockingTaskOperationType.Get("vdcUploadMedia");
    public static BlockingTaskOperationType VDC_UPLOAD_OVF_CONTENTS = BlockingTaskOperationType.Get("vdcUploadOvfContents");
    public static BlockingTaskOperationType CATALOG_ITEM_ENABLE_DOWNLOAD = BlockingTaskOperationType.Get("catalogItemEnableDownload");
    public static BlockingTaskOperationType CATALOG_SYNC = BlockingTaskOperationType.Get("catalogSync");
    public static BlockingTaskOperationType CATALOG_SYNC_ALL = BlockingTaskOperationType.Get("catalogSyncAll");
    public static BlockingTaskOperationType CATALOG_DELETE = BlockingTaskOperationType.Get("catalogDelete");
    public static BlockingTaskOperationType CATALOG_DELETE_BACKING = BlockingTaskOperationType.Get("catalogDeleteBacking");
    public static BlockingTaskOperationType NETWORK_DELETE = BlockingTaskOperationType.Get("networkDelete");
    public static BlockingTaskOperationType NETWORK_UPDATE_NETWORK = BlockingTaskOperationType.Get("networkUpdateNetwork");
    public static BlockingTaskOperationType RCL_ENABLE_VXLAN_FOR_PROVIDER_VDC = BlockingTaskOperationType.Get("rclEnableVxlanForProviderVdc");
    public static BlockingTaskOperationType NETWORK_REPAIR_NETWORK_POOL = BlockingTaskOperationType.Get("networkRepairNetworkPool");
    public static BlockingTaskOperationType NETWORK_MERGE_NETWORK_POOLS = BlockingTaskOperationType.Get("networkMergeNetworkPools");
    private string _value;

    private static BlockingTaskOperationType Get(string str)
    {
      return new BlockingTaskOperationType(str);
    }

    private BlockingTaskOperationType(string value)
    {
      this._value = value;
    }

    public static BlockingTaskOperationType FromValue(string value)
    {
      foreach (BlockingTaskOperationType taskOperationType in BlockingTaskOperationType.Values())
      {
        if (taskOperationType.Value().Equals(value))
          return taskOperationType;
      }
      throw new ArgumentException(value.ToString());
    }

    public string Value()
    {
      return this._value;
    }

    public static List<BlockingTaskOperationType> FromValues(
      List<string> values)
    {
      List<BlockingTaskOperationType> taskOperationTypeList = new List<BlockingTaskOperationType>();
      foreach (string str in values)
        taskOperationTypeList.Add(BlockingTaskOperationType.FromValue(str));
      return taskOperationTypeList;
    }

    public static List<string> ToValues(List<BlockingTaskOperationType> systemOperations)
    {
      List<string> stringList = new List<string>();
      foreach (BlockingTaskOperationType systemOperation in systemOperations)
        stringList.Add(systemOperation.Value());
      return stringList;
    }

    public static List<BlockingTaskOperationType> Values()
    {
      BlockingTaskOperationType taskOperationType = new BlockingTaskOperationType();
      List<BlockingTaskOperationType> taskOperationTypeList = new List<BlockingTaskOperationType>();
      foreach (FieldInfo field in taskOperationType.GetType().GetFields())
        taskOperationTypeList.Add((BlockingTaskOperationType) field.GetValue((object) taskOperationType));
      return taskOperationTypeList;
    }
  }
}
