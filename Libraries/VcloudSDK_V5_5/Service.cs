// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.Service
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;

namespace com.vmware.vcloud.sdk
{
  public class Service : VcloudEntity<ServiceType>
  {
    public Service(vCloudClient client, ServiceType serviceResource)
      : base(client, serviceResource)
    {
    }

    public static Service GetServiceByReference(vCloudClient client, ReferenceType reference)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
      return new Service(client, VcloudResource<ServiceType>.GetResourceByReference(client, reference));
    }

    public static Service GetServiceById(vCloudClient client, string vCloudId)
    {
      Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
      return new Service(client, VcloudEntity<ServiceType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.service+xml"));
    }

    public ReferenceResult GetApiDefinitionRefs()
    {
      return this.VcloudClient.GetQueryService().ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this.Reference.href + "/apidefinitions?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.REFERENCE_VIEW));
    }
  }
}
