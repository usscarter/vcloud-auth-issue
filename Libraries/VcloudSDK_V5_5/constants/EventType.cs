// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.EventType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants
{
  public struct EventType
  {
    public static EventType SESSION_LOGIN = EventType.Get("com/vmware/vcloud/event/session/login");
    public static EventType USER_IMPORT = EventType.Get("com/vmware/vcloud/event/user/import");
    public static EventType USER_REMOVE = EventType.Get("com/vmware/vcloud/event/user/remove");
    public static EventType USER_MODIFY = EventType.Get("com/vmware/vcloud/event/user/modify");
    public static EventType USER_ENABLE = EventType.Get("com/vmware/vcloud/event/user/enable");
    public static EventType USER_DISABLE = EventType.Get("com/vmware/vcloud/event/user/disable");
    public static EventType USER_LOCKOUT = EventType.Get("com/vmware/vcloud/event/user/lockout");
    public static EventType USER_UNLOCK = EventType.Get("com/vmware/vcloud/event/user/unlock");
    public static EventType USER_LOCK_EXPIRED = EventType.Get("com/vmware/vcloud/event/user/lock_expired");
    public static EventType GROUP_IMPORT = EventType.Get("com/vmware/vcloud/event/group/import");
    public static EventType GROUP_REMOVE = EventType.Get("com/vmware/vcloud/event/group/remove");
    public static EventType GROUP_PRIVILEGE_MODIFY = EventType.Get("com/vmware/vcloud/event/group/privilege/modify");
    public static EventType ROLE_CREATE = EventType.Get("com/vmware/vcloud/event/role/create");
    public static EventType ROLE_MODIFY = EventType.Get("com/vmware/vcloud/event/role/modify");
    public static EventType ROLE_DELETE = EventType.Get("com/vmware/vcloud/event/role/delete");
    public static EventType ORG_CREATE = EventType.Get("com/vmware/vcloud/event/org/create");
    public static EventType ORG_MODIFY = EventType.Get("com/vmware/vcloud/event/org/modify");
    public static EventType ORG_DELETE = EventType.Get("com/vmware/vcloud/event/org/delete");
    public static EventType USER_CREATE = EventType.Get("com/vmware/vcloud/event/user/create");
    public static EventType USER_DELETE = EventType.Get("com/vmware/vcloud/event/user/delete");
    public static EventType NETWORK_CREATE = EventType.Get("com/vmware/vcloud/event/network/create");
    public static EventType NETWORK_MODIFY = EventType.Get("com/vmware/vcloud/event/network/modify");
    public static EventType NETWORK_DELETE = EventType.Get("com/vmware/vcloud/event/network/delete");
    public static EventType NETWORK_DEPLOY = EventType.Get("com/vmware/vcloud/event/network/deploy");
    public static EventType NETWORK_UNDEPLOY = EventType.Get("com/vmware/vcloud/event/network/undeploy");
    public static EventType VDC_CREATE_REQUEST = EventType.Get("com/vmware/vcloud/event/vdc/create_request");
    public static EventType VDC_CREATE = EventType.Get("com/vmware/vcloud/event/vdc/create");
    public static EventType VDC_MODIFY = EventType.Get("com/vmware/vcloud/event/vdc/modify");
    public static EventType VDC_DELETE_REQUEST = EventType.Get("com/vmware/vcloud/event/vdc/delete_request");
    public static EventType VDC_DELETE = EventType.Get("com/vmware/vcloud/event/vdc/delete");
    public static EventType VDC_FAST_PROVISIONING_MODIFY = EventType.Get("com/vmware/vcloud/event/vdc/fast_provisioning/modify");
    public static EventType VDC_THIN_PROVISIONING_MODIFY = EventType.Get("com/vmware/vcloud/event/vdc/thin_provisioning/modify");
    public static EventType PROVIDERVDC_CREATE_REQUEST = EventType.Get("com/vmware/vcloud/event/providerVdc/create_request");
    public static EventType PROVIDERVDC_CREATE = EventType.Get("com/vmware/vcloud/event/providerVdc/create");
    public static EventType PROVIDERVDC_MODIFY = EventType.Get("com/vmware/vcloud/event/providerVdc/modify");
    public static EventType PROVIDERVDC_MERGE_REQUEST = EventType.Get("com/vmware/vcloud/event/providerVdc/merge_request");
    public static EventType PROVIDERVDC_MERGE = EventType.Get("com/vmware/vcloud/event/providerVdc/merge");
    public static EventType PROVIDERVDC_MERGE_WITH = EventType.Get("com/vmware/vcloud/event/providerVdc/mergeWith");
    public static EventType PROVIDERVDC_DELETE_REQUEST = EventType.Get("com/vmware/vcloud/event/providerVdc/delete_request");
    public static EventType PROVIDERVDC_DELETE = EventType.Get("com/vmware/vcloud/event/providerVdc/delete");
    public static EventType VAPPTEMPLATE_CREATE = EventType.Get("com/vmware/vcloud/event/vappTemplate/create");
    public static EventType VAPPTEMPLATE_IMPORT = EventType.Get("com/vmware/vcloud/event/vappTemplate/import");
    public static EventType VAPPTEMPLATE_MODIFY = EventType.Get("com/vmware/vcloud/event/vappTemplate/modify");
    public static EventType VAPPTEMPLATE_DELETE = EventType.Get("com/vmware/vcloud/event/vappTemplate/delete");
    public static EventType VAPPTEMPLATE_CREATE_REQUEST = EventType.Get("com/vmware/vcloud/event/vappTemplate/create_request");
    public static EventType VAPPTEMPLATE_IMPORT_REQUEST = EventType.Get("com/vmware/vcloud/event/vappTemplate/import_request");
    public static EventType VAPPTEMPLATE_MODIFY_REQUEST = EventType.Get("com/vmware/vcloud/event/vappTemplate/modify_request");
    public static EventType VAPPTEMPLATE_DELETE_REQUEST = EventType.Get("com/vmware/vcloud/event/vappTemplate/delete_request");
    public static EventType MEDIA_CREATE = EventType.Get("com/vmware/vcloud/event/media/create");
    public static EventType MEDIA_IMPORT = EventType.Get("com/vmware/vcloud/event/media/import");
    public static EventType MEDIA_MODIFY = EventType.Get("com/vmware/vcloud/event/media/modify");
    public static EventType MEDIA_DELETE = EventType.Get("com/vmware/vcloud/event/media/delete");
    public static EventType MEDIA_CREATE_REQUEST = EventType.Get("com/vmware/vcloud/event/media/create_request");
    public static EventType MEDIA_IMPORT_REQUEST = EventType.Get("com/vmware/vcloud/event/media/import_request");
    public static EventType MEDIA_MODIFY_REQUEST = EventType.Get("com/vmware/vcloud/event/media/modify_request");
    public static EventType MEDIA_DELETE_REQUEST = EventType.Get("com/vmware/vcloud/event/media/delete_request");
    public static EventType MEDIA_UPLOAD_TIMEOUT = EventType.Get("com/vmware/vcloud/event/media/upload_timeout");
    public static EventType MEDIA_QUARANTINE_REJECT = EventType.Get("com/vmware/vcloud/event/media/quarantine_reject");
    public static EventType VAPP_CREATE = EventType.Get("com/vmware/vcloud/event/vapp/create");
    public static EventType VAPP_IMPORT = EventType.Get("com/vmware/vcloud/event/vapp/import");
    public static EventType VAPP_MODIFY = EventType.Get("com/vmware/vcloud/event/vapp/modify");
    public static EventType VAPP_DELETE = EventType.Get("com/vmware/vcloud/event/vapp/delete");
    public static EventType VAPP_DEPLOY = EventType.Get("com/vmware/vcloud/event/vapp/deploy");
    public static EventType VAPP_UNDEPLOY = EventType.Get("com/vmware/vcloud/event/vapp/undeploy");
    public static EventType VAPP_RUNTIME_LEASE_EXPIRY = EventType.Get("com/vmware/vcloud/event/vapp/runtime_lease_expiry");
    public static EventType VAPP_LEASE_EXPIRATION_CHANGEDY = EventType.Get("com/vmware/vcloud/event/vapp/lease_expiration_changed");
    public static EventType VAPP_CREATE_REQUEST = EventType.Get("com/vmware/vcloud/event/vapp/create_request");
    public static EventType VAPP_IMPORT_REQUEST = EventType.Get("com/vmware/vcloud/event/vapp/import_request");
    public static EventType VAPP_MODIFY_REQUEST = EventType.Get("com/vmware/vcloud/event/vapp/modify_request");
    public static EventType VAPP_DELETE_REQUEST = EventType.Get("com/vmware/vcloud/event/vapp/delete_request");
    public static EventType VAPP_DEPLOY_REQUEST = EventType.Get("com/vmware/vcloud/event/vapp/deploy_request");
    public static EventType VAPP_UNDEPLOY_REQUEST = EventType.Get("com/vmware/vcloud/event/vapp/undeploy_request");
    public static EventType VM_CREATE_REQUEST = EventType.Get("com/vmware/vcloud/event/vm/create_request");
    public static EventType VAPP_QUARANTINE_REJECT = EventType.Get("com/vmware/vcloud/event/vapp/quarantine_reject");
    public static EventType VAPP_UPLOAD_TIMEOUT = EventType.Get("com/vmware/vcloud/event/vapp/upload_timeout");
    public static EventType VM_CREATE = EventType.Get("com/vmware/vcloud/event/vm/create");
    public static EventType VM_MODIFY_REQUEST = EventType.Get("com/vmware/vcloud/event/vm/modify_request");
    public static EventType VM_MODIFY = EventType.Get("com/vmware/vcloud/event/vm/modify");
    public static EventType VM_DELETE = EventType.Get("com/vmware/vcloud/event/vm/delete");
    public static EventType VM_CHANGE_STATE = EventType.Get("com/vmware/vcloud/event/vm/change_state");
    public static EventType VM_DEPLOY_REQUEST = EventType.Get("com/vmware/vcloud/event/vm/deploy_request");
    public static EventType VM_DEPLOY = EventType.Get("com/vmware/vcloud/event/vm/deploy");
    public static EventType VM_UNDEPLOY_REQUEST = EventType.Get("com/vmware/vcloud/event/vm/undeploy_request");
    public static EventType VM_UNDEPLOY = EventType.Get("com/vmware/vcloud/event/vm/undeploy");
    public static EventType VM_CONSOLIDATE_REQUEST = EventType.Get("com/vmware/vcloud/event/vm/consolidate_request");
    public static EventType VM_CONSOLIDATE = EventType.Get("com/vmware/vcloud/event/vm/consolidate");
    public static EventType VM_RELOCATE_REQUEST = EventType.Get("com/vmware/vcloud/event/vm/relocate_request");
    public static EventType VM_RELOCATE = EventType.Get("com/vmware/vcloud/event/vm/relocate");
    public static EventType VM_MIGRATE_REQUEST = EventType.Get("com/vmware/vcloud/event/vm/migrate_request");
    public static EventType VM_MIGRATE = EventType.Get("com/vmware/vcloud/event/vm/migrate");
    public static EventType VM_IP_ADDRESS_CHANGED = EventType.Get("com/vmware/vcloud/event/vm/ip_address_changed");
    public static EventType VC_CREATE = EventType.Get("com/vmware/vcloud/event/vc/create");
    public static EventType VC_MODIFY = EventType.Get("com/vmware/vcloud/event/vc/modify");
    public static EventType VC_DELETE = EventType.Get("com/vmware/vcloud/event/vc/delete");
    public static EventType VC_REFRESH = EventType.Get("com/vmware/vcloud/event/vc/refresh");
    public static EventType CATALOG_CREATE = EventType.Get("com/vmware/vcloud/event/catalog/create");
    public static EventType CATALOG_DELETE = EventType.Get("com/vmware/vcloud/event/catalog/delete");
    public static EventType CATALOG_MODIFY = EventType.Get("com/vmware/vcloud/event/catalog/modify");
    public static EventType CATALOG_PUBLISH = EventType.Get("com/vmware/vcloud/event/catalog/publish");
    public static EventType CATALOGITEM_CREATE = EventType.Get("com/vmware/vcloud/event/catalogItem/create");
    public static EventType CATALOGITEM_DELETE = EventType.Get("com/vmware/vcloud/event/catalogItem/delete");
    public static EventType CATALOGITEM_MODIFY = EventType.Get("com/vmware/vcloud/event/catalogItem/modify");
    public static EventType TASK_CREATE = EventType.Get("com/vmware/vcloud/event/task/create");
    public static EventType TASK_START = EventType.Get("com/vmware/vcloud/event/task/start");
    public static EventType TASK_ABORT = EventType.Get("com/vmware/vcloud/event/task/abort");
    public static EventType TASK_COMPLETE = EventType.Get("com/vmware/vcloud/event/task/complete");
    public static EventType TASK_FAIL = EventType.Get("com/vmware/vcloud/event/task/fail");
    public static EventType BLOCKINGTASK_CREATE = EventType.Get("com/vmware/vcloud/event/blockingtask/create");
    public static EventType BLOCKINGTASK_RESUME = EventType.Get("com/vmware/vcloud/event/blockingtask/resume");
    public static EventType BLOCKINGTASK_ABORT = EventType.Get("com/vmware/vcloud/event/blockingtask/abort");
    public static EventType BLOCKINGTASK_FAIL = EventType.Get("com/vmware/vcloud/event/blockingtask/fail");
    public static EventType DATASTORE_MODIFY = EventType.Get("com/vmware/vcloud/event/datastore/modify");
    public static EventType DATASTORE_DELETE = EventType.Get("com/vmware/vcloud/event/datastore/delete");
    public static EventType DISK_CREATE_REQUEST = EventType.Get("com/vmware/vcloud/event/disk/create_request");
    public static EventType DISK_CREATE = EventType.Get("com/vmware/vcloud/event/disk/create");
    public static EventType DISK_DELETE_REQUEST = EventType.Get("com/vmware/vcloud/event/disk/delete_request");
    public static EventType DISK_DELETE = EventType.Get("com/vmware/vcloud/event/disk/delete");
    public static EventType DISK_MODIFY = EventType.Get("com/vmware/vcloud/event/disk/modify");
    public static EventType DISK_ATTACH = EventType.Get("com/vmware/vcloud/event/disk/attach");
    public static EventType DISK_DETACH = EventType.Get("com/vmware/vcloud/event/disk/detach");
    public static EventType PROVIDERVDCSTORAGEPROFILE_ADD = EventType.Get("com/vmware/vcloud/event/providerVdcStorageProfile/add");
    public static EventType PROVIDERVDCSTORAGEPROFILE_REMOVE = EventType.Get("com/vmware/vcloud/event/providerVdcStorageProfile/remove");
    public static EventType PROVIDERVDCSTORAGEPROFILE_MODIFY = EventType.Get("com/vmware/vcloud/event/providerVdcStorageProfile/modify");
    public static EventType VDCSTORAGEPROFILE_ADD = EventType.Get("com/vmware/vcloud/event/vdcStorageProfile/add");
    public static EventType VDCSTORAGEPROFILE_REMOVE = EventType.Get("com/vmware/vcloud/event/vdcStorageProfile/remove");
    public static EventType VDCSTORAGEPROFILE_MODIFY = EventType.Get("com/vmware/vcloud/event/vdcStorageProfile/modify");
    public static EventType GATEWAY_CREATE = EventType.Get("com/vmware/vcloud/event/gateway/create");
    public static EventType GATEWAY_MODIFY = EventType.Get("com/vmware/vcloud/event/gateway/modify");
    public static EventType GATEWAY_DELETE = EventType.Get("com/vmware/vcloud/event/gateway/delete");
    public static EventType NETWORK_UPGRADE = EventType.Get("com/vmware/vcloud/event/network/upgrade");
    public static EventType GATEWAY_UPGRADE = EventType.Get("com/vmware/vcloud/event/gateway/upgrade");
    private string _value;

    private static EventType Get(string str)
    {
      return new EventType(str);
    }

    private EventType(string value)
    {
      this._value = value;
    }

    public static EventType FromValue(string value)
    {
      EventType eventType1 = new EventType();
      foreach (FieldInfo field in eventType1.GetType().GetFields())
      {
        EventType eventType2 = (EventType) field.GetValue((object) eventType1);
        if (eventType2.Value() == value)
          return eventType2;
      }
      throw new ArgumentException(value.ToString());
    }

    public string Value()
    {
      return this._value;
    }

    public static List<EventType> Values()
    {
      EventType eventType = new EventType();
      List<EventType> eventTypeList = new List<EventType>();
      foreach (FieldInfo field in eventType.GetType().GetFields())
        eventTypeList.Add((EventType) field.GetValue((object) eventType));
      return eventTypeList;
    }
  }
}
