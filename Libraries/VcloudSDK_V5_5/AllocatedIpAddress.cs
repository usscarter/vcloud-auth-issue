// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.AllocatedIpAddress
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk
{
  public class AllocatedIpAddress : VcloudResource<AllocatedIpAddressType>
  {
    private ReferenceType vappRef;
    private ReferenceType vmRef;
    private ReferenceType orgVdcNetworkRef;
    private ReferenceType orgRef;

    public AllocatedIpAddress(vCloudClient client, AllocatedIpAddressType resourceType)
      : base(client, resourceType)
    {
      this.sortRefs();
    }

    private void sortRefs()
    {
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.org+xml"))
          this.orgRef = (ReferenceType) linkType;
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.orgVdcNetwork+xml"))
          this.orgVdcNetworkRef = (ReferenceType) linkType;
        if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.vcloud.vApp+xml"))
          this.vappRef = (ReferenceType) linkType;
        if (linkType.rel.Equals("down") && linkType.type.Equals("application/vnd.vmware.vcloud.vm+xml"))
          this.vmRef = (ReferenceType) linkType;
      }
    }

    public ReferenceType getOrgVdcNetworkReference()
    {
      try
      {
        if (this.orgVdcNetworkRef == null)
          Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        return this.orgVdcNetworkRef;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType getOrgReference()
    {
      try
      {
        if (this.orgRef == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        return this.orgRef;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType getVappReference()
    {
      try
      {
        if (this.vappRef == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        return this.vappRef;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType getVMReference()
    {
      try
      {
        if (this.vmRef == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
        return this.vmRef;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
