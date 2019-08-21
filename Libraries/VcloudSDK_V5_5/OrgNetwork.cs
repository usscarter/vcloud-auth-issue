// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.OrgNetwork
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk
{
  [Obsolete("This OrgNetwork class is obsolete since SDK 5.1;OrgNetwork helper class works only for API 1.5. For API 5.1 use the OrgVdcNetwork instead.")]
  public class OrgNetwork : VcloudEntity<OrgNetworkType>
  {
    private ReferenceType _orgReference;

    internal OrgNetwork(vCloudClient client, OrgNetworkType orgNetworkType)
      : base(client, orgNetworkType)
    {
      this.SortReferences_v1_5();
    }

    public static OrgNetwork GetOrgNetworkByReference(
      vCloudClient client,
      ReferenceType networkRef)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + networkRef.href);
        return new OrgNetwork(client, VcloudResource<OrgNetworkType>.GetResourceByReference(client, networkRef));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static OrgNetwork GetOrgNetworkById(vCloudClient client, string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new OrgNetwork(client, VcloudEntity<OrgNetworkType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.network+xml"));
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

    private void SortReferences_v1_5()
    {
      if (this.Resource.Link == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.org+xml"))
        {
          this._orgReference = (ReferenceType) linkType;
          break;
        }
      }
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
