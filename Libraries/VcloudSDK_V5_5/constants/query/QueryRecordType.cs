// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryRecordType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryRecordType
  {
    public static QueryRecordType ORGANIZATION = QueryRecordType.Get("organization");
    public static QueryRecordType ORGVDC = QueryRecordType.Get("orgVdc");
    public static QueryRecordType MEDIA = QueryRecordType.Get("media");
    public static QueryRecordType VAPPTEMPLATE = QueryRecordType.Get("vAppTemplate");
    public static QueryRecordType VAPP = QueryRecordType.Get("vApp");
    public static QueryRecordType VM = QueryRecordType.Get("vm");
    [Obsolete("This record type is deprecated  since API 5.1, SDK 5.1")]
    public static QueryRecordType ORGNETWORK = QueryRecordType.Get("orgNetwork");
    [Obsolete("This record type is deprecated  since API 5.1, SDK 5.1")]
    public static QueryRecordType ADMINORGNETWORK = QueryRecordType.Get("adminOrgNetwork");
    public static QueryRecordType VAPPNETWORK = QueryRecordType.Get("vAppNetwork");
    public static QueryRecordType CATALOG = QueryRecordType.Get("catalog");
    public static QueryRecordType ADMINORGVDC = QueryRecordType.Get("adminOrgVdc");
    public static QueryRecordType PROVIDERVDC = QueryRecordType.Get("providerVdc");
    public static QueryRecordType EXTERNALNETWORK = QueryRecordType.Get("externalNetwork");
    public static QueryRecordType GROUP = QueryRecordType.Get("group");
    public static QueryRecordType USER = QueryRecordType.Get("user");
    public static QueryRecordType STRANDEDUSER = QueryRecordType.Get("strandedUser");
    public static QueryRecordType ROLE = QueryRecordType.Get("role");
    [Obsolete("This query constant is obsolete since API 5.1, SDK 5.1")]
    public static QueryRecordType ALLOCATEDEXTERNALADDRESS = QueryRecordType.Get("allocatedExternalAddress");
    public static QueryRecordType EVENT = QueryRecordType.Get("event");
    public static QueryRecordType RESOURCEPOOL = QueryRecordType.Get("resourcePool");
    public static QueryRecordType DATASTORE = QueryRecordType.Get("datastore");
    public static QueryRecordType NETWORKPOOL = QueryRecordType.Get("networkPool");
    public static QueryRecordType PORTGROUP = QueryRecordType.Get("portgroup");
    public static QueryRecordType DVSWITCH = QueryRecordType.Get("dvSwitch");
    public static QueryRecordType CELL = QueryRecordType.Get("cell");
    public static QueryRecordType VIRTUALCENTER = QueryRecordType.Get("virtualCenter");
    public static QueryRecordType HOST = QueryRecordType.Get("host");
    public static QueryRecordType ADMINVAPP = QueryRecordType.Get("adminVApp");
    public static QueryRecordType RIGHT = QueryRecordType.Get("right");
    public static QueryRecordType ADMINVM = QueryRecordType.Get("adminVM");
    [Obsolete("This query constant is obsolete  since API 5.1, SDK 5.1")]
    public static QueryRecordType ADMINALLOCATEDEXTERNALADDRESS = QueryRecordType.Get("adminAllocatedExternalAddress");
    [Obsolete("This query constant is obsolete  since API 5.1, SDK 5.1")]
    public static QueryRecordType VAPPORGNETWORKRELATION = QueryRecordType.Get("vAppOrgNetworkRelation");
    public static QueryRecordType PROVIDERVDCRESOURCEPOOLRELATION = QueryRecordType.Get("providerVdcResourcePoolRelation");
    public static QueryRecordType ORGVDCRESOURCEPOOLRELATION = QueryRecordType.Get("orgVdcResourcePoolRelation");
    [Obsolete("This QueryRecordType is obsolete since API 5.1, SDK 5.1; use DATASTOREPROVIDERVDCRELATION instead")]
    public static QueryRecordType DATSTOREPROVIDERVDCRELATION = QueryRecordType.Get("datastoreProviderVdcRelation");
    public static QueryRecordType DATASTOREPROVIDERVDCRELATION = QueryRecordType.Get("datastoreProviderVdcRelation");
    public static QueryRecordType ADMINUSER = QueryRecordType.Get("adminUser");
    public static QueryRecordType ADMINGROUP = QueryRecordType.Get("adminGroup");
    public static QueryRecordType ADMINVAPPNETWORK = QueryRecordType.Get("adminVAppNetwork");
    public static QueryRecordType ADMINCATALOG = QueryRecordType.Get("adminCatalog");
    public static QueryRecordType ADMINCATALOGITEM = QueryRecordType.Get("adminCatalogItem");
    public static QueryRecordType CATALOGITEM = QueryRecordType.Get("catalogItem");
    public static QueryRecordType ADMINMEDIA = QueryRecordType.Get("adminMedia");
    public static QueryRecordType ADMINVAPPTEMPLATE = QueryRecordType.Get("adminVAppTemplate");
    public static QueryRecordType ADMINSHADOWVM = QueryRecordType.Get("adminShadowVM");
    public static QueryRecordType TASK = QueryRecordType.Get("task");
    public static QueryRecordType ADMINTASK = QueryRecordType.Get("adminTask");
    public static QueryRecordType BLOCKINGTASK = QueryRecordType.Get("blockingTask");
    public static QueryRecordType DISK = QueryRecordType.Get("disk");
    public static QueryRecordType VMDISKRELATION = QueryRecordType.Get("vmDiskRelation");
    public static QueryRecordType ADMINDISK = QueryRecordType.Get("adminDisk");
    public static QueryRecordType ADMINVMDISKRELATION = QueryRecordType.Get("adminVMDiskRelation");
    public static QueryRecordType CONDITION = QueryRecordType.Get("condition");
    public static QueryRecordType STRANDEDITEM = QueryRecordType.Get("strandedItem");
    public static QueryRecordType ADMINSERVICE = QueryRecordType.Get("adminService");
    public static QueryRecordType SERVICE = QueryRecordType.Get("service");
    public static QueryRecordType SERVICELINK = QueryRecordType.Get("serviceLink");
    public static QueryRecordType ORGVDCSTORAGEPROFILE = QueryRecordType.Get("orgVdcStorageProfile");
    public static QueryRecordType ADMINORGVDCSTORAGEPROFILE = QueryRecordType.Get("adminOrgVdcStorageProfile");
    public static QueryRecordType PROVIDERVDCSTORAGEPROFILE = QueryRecordType.Get("providerVdcStorageProfile");
    public static QueryRecordType APIFILTER = QueryRecordType.Get("apiFilter");
    public static QueryRecordType ADMINAPIDEFINITION = QueryRecordType.Get("adminApiDefinition");
    public static QueryRecordType APIDEFINITION = QueryRecordType.Get("apiDefinition");
    public static QueryRecordType ADMINFILEDESCRIPTOR = QueryRecordType.Get("adminFileDescriptor");
    public static QueryRecordType FILEDESCRIPTOR = QueryRecordType.Get("fileDescriptor");
    public static QueryRecordType RESOURCECLASSACTION = QueryRecordType.Get("resourceClassAction");
    public static QueryRecordType ACLRULE = QueryRecordType.Get("aclRule");
    public static QueryRecordType RESOURCECLASS = QueryRecordType.Get("resourceClass");
    public static QueryRecordType SERVICERESOURCE = QueryRecordType.Get("serviceResource");
    public static QueryRecordType EDGEGATEWAY = QueryRecordType.Get("edgeGateway");
    public static QueryRecordType ORGVDCNETWORK = QueryRecordType.Get("orgVdcNetwork");
    public static QueryRecordType VAPPORGVDCNETWORKRELATION = QueryRecordType.Get("vAppOrgVdcNetworkRelation");
    public static QueryRecordType EXTERNALLOCALIZATION = QueryRecordType.Get("externalLocalization");
    public static QueryRecordType RESOURCEPOOLVMLIST = QueryRecordType.Get("resourcePoolVmList");
    public static QueryRecordType ADMINEVENT = QueryRecordType.Get("adminEvent");
    private string _value;

    private static QueryRecordType Get(string str)
    {
      return new QueryRecordType(str);
    }

    private QueryRecordType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryRecordType> Values()
    {
      QueryRecordType queryRecordType = new QueryRecordType();
      List<QueryRecordType> queryRecordTypeList = new List<QueryRecordType>();
      foreach (FieldInfo field in queryRecordType.GetType().GetFields())
        queryRecordTypeList.Add((QueryRecordType) field.GetValue((object) queryRecordType));
      return queryRecordTypeList;
    }

    public static QueryRecordType FromValue(string value)
    {
      foreach (QueryRecordType queryRecordType in QueryRecordType.Values())
      {
        if (queryRecordType.Value().Equals(value))
          return queryRecordType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
