// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.constants.query.QueryReferenceType
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.vmware.vcloud.sdk.constants.query
{
  public struct QueryReferenceType
  {
    public static QueryReferenceType ORGANIZATION = QueryReferenceType.Get("organization");
    public static QueryReferenceType ORGVDC = QueryReferenceType.Get("orgVdc");
    public static QueryReferenceType MEDIA = QueryReferenceType.Get("media");
    public static QueryReferenceType VAPPTEMPLATE = QueryReferenceType.Get("vAppTemplate");
    public static QueryReferenceType VAPP = QueryReferenceType.Get("vApp");
    public static QueryReferenceType VM = QueryReferenceType.Get("vm");
    [Obsolete("This reference type is deprecated  since API 5.1, SDK 5.1")]
    public static QueryReferenceType ORGNETWORK = QueryReferenceType.Get("orgNetwork");
    [Obsolete("This reference type is deprecated  since API 5.1, SDK 5.1")]
    public static QueryReferenceType ADMINORGNETWORK = QueryReferenceType.Get("adminOrgNetwork");
    public static QueryReferenceType VAPPNETWORK = QueryReferenceType.Get("vAppNetwork");
    public static QueryReferenceType CATALOG = QueryReferenceType.Get("catalog");
    public static QueryReferenceType ADMINORGVDC = QueryReferenceType.Get("adminOrgVdc");
    public static QueryReferenceType PROVIDERVDC = QueryReferenceType.Get("providerVdc");
    public static QueryReferenceType EXTERNALNETWORK = QueryReferenceType.Get("externalNetwork");
    public static QueryReferenceType GROUP = QueryReferenceType.Get("group");
    public static QueryReferenceType USER = QueryReferenceType.Get("user");
    public static QueryReferenceType STRANDEDUSER = QueryReferenceType.Get("strandedUser");
    public static QueryReferenceType ROLE = QueryReferenceType.Get("role");
    public static QueryReferenceType DATASTORE = QueryReferenceType.Get("datastore");
    public static QueryReferenceType NETWORKPOOL = QueryReferenceType.Get("networkPool");
    public static QueryReferenceType VIRTUALCENTER = QueryReferenceType.Get("virtualCenter");
    public static QueryReferenceType HOST = QueryReferenceType.Get("host");
    public static QueryReferenceType ADMINVAPP = QueryReferenceType.Get("adminVApp");
    public static QueryReferenceType RIGHT = QueryReferenceType.Get("right");
    public static QueryReferenceType ADMINVM = QueryReferenceType.Get("adminVM");
    [Obsolete("This query constant is obsolete  since API 5.1, SDK 5.1")]
    public static QueryReferenceType VAPPORGNETWORKRELATION = QueryReferenceType.Get("vAppOrgNetworkRelation");
    public static QueryReferenceType ADMINUSER = QueryReferenceType.Get("adminUser");
    public static QueryReferenceType ADMINGROUP = QueryReferenceType.Get("adminGroup");
    public static QueryReferenceType ADMINVAPPNETWORK = QueryReferenceType.Get("adminVAppNetwork");
    public static QueryReferenceType ADMINCATALOG = QueryReferenceType.Get("adminCatalog");
    public static QueryReferenceType ADMINCATALOGITEM = QueryReferenceType.Get("adminCatalogItem");
    public static QueryReferenceType CATALOGITEM = QueryReferenceType.Get("catalogItem");
    public static QueryReferenceType ADMINMEDIA = QueryReferenceType.Get("adminMedia");
    public static QueryReferenceType ADMINVAPPTEMPLATE = QueryReferenceType.Get("adminVAppTemplate");
    public static QueryReferenceType ADMINSHADOWVM = QueryReferenceType.Get("adminShadowVM");
    public static QueryReferenceType TASK = QueryReferenceType.Get("task");
    public static QueryReferenceType ADMINTASK = QueryReferenceType.Get("adminTask");
    public static QueryReferenceType BLOCKINGTASK = QueryReferenceType.Get("blockingTask");
    public static QueryReferenceType DISK = QueryReferenceType.Get("disk");
    public static QueryReferenceType ADMINDISK = QueryReferenceType.Get("adminDisk");
    public static QueryReferenceType STRANDEDITEM = QueryReferenceType.Get("strandedItem");
    public static QueryReferenceType ADMINSERVICE = QueryReferenceType.Get("adminService");
    public static QueryReferenceType SERVICE = QueryReferenceType.Get("service");
    public static QueryReferenceType SERVICELINK = QueryReferenceType.Get("serviceLink");
    public static QueryReferenceType ORGVDCSTORAGEPROFILE = QueryReferenceType.Get("orgVdcStorageProfile");
    public static QueryReferenceType ADMINORGVDCSTORAGEPROFILE = QueryReferenceType.Get("adminOrgVdcStorageProfile");
    public static QueryReferenceType PROVIDERVDCSTORAGEPROFILE = QueryReferenceType.Get("providerVdcStorageProfile");
    public static QueryReferenceType APIFILTER = QueryReferenceType.Get("apiFilter");
    public static QueryReferenceType ADMINAPIDEFINITION = QueryReferenceType.Get("adminApiDefinition");
    public static QueryReferenceType APIDEFINITION = QueryReferenceType.Get("apiDefinition");
    public static QueryReferenceType ADMINFILEDESCRIPTOR = QueryReferenceType.Get("adminFileDescriptor");
    public static QueryReferenceType RESOURCECLASSACTION = QueryReferenceType.Get("resourceClassAction");
    public static QueryReferenceType ACLRULE = QueryReferenceType.Get("aclRule");
    public static QueryReferenceType RESOURCECLASS = QueryReferenceType.Get("resourceClass");
    public static QueryReferenceType SERVICERESOURCE = QueryReferenceType.Get("serviceResource");
    public static QueryReferenceType EDGEGATEWAY = QueryReferenceType.Get("edgeGateway");
    public static QueryReferenceType ORGVDCNETWORK = QueryReferenceType.Get("orgVdcNetwork");
    public static QueryReferenceType VAPPORGVDCNETWORKRELATION = QueryReferenceType.Get("vAppOrgVdcNetworkRelation");
    public static QueryReferenceType RESOURCEPOOLVMLIST = QueryReferenceType.Get("resourcePoolVmList");
    private string _value;

    private static QueryReferenceType Get(string str)
    {
      return new QueryReferenceType(str);
    }

    private QueryReferenceType(string value)
    {
      this._value = value;
    }

    public string Value()
    {
      return this._value;
    }

    public static List<QueryReferenceType> Values()
    {
      QueryReferenceType queryReferenceType = new QueryReferenceType();
      List<QueryReferenceType> queryReferenceTypeList = new List<QueryReferenceType>();
      foreach (FieldInfo field in queryReferenceType.GetType().GetFields())
        queryReferenceTypeList.Add((QueryReferenceType) field.GetValue((object) queryReferenceType));
      return queryReferenceTypeList;
    }

    public static QueryReferenceType FromValue(string value)
    {
      foreach (QueryReferenceType queryReferenceType in QueryReferenceType.Values())
      {
        if (queryReferenceType.Value().Equals(value))
          return queryReferenceType;
      }
      throw new ArgumentException(value.ToString());
    }
  }
}
