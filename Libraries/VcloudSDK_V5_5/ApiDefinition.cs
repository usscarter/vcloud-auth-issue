// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.ApiDefinition
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk
{
  public class ApiDefinition : VcloudEntity<ApiDefinitionType>
  {
    private ReferenceType serviceRef;

    internal ApiDefinition(vCloudClient client, ApiDefinitionType apiDefinitionParams)
      : base(client, apiDefinitionParams)
    {
      this.SortApiDefinitionRefs();
    }

    private void SortApiDefinitionRefs()
    {
      if (this.Resource == null)
        return;
      foreach (LinkType linkType in this.Resource.Link)
      {
        if (linkType.rel.Equals("up") && linkType.type.Equals("application/vnd.vmware.vcloud.service+xml"))
          this.serviceRef = (ReferenceType) linkType;
      }
    }

    public static ApiDefinition GetApiDefinitionByReference(
      vCloudClient client,
      ReferenceType reference)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + reference.href);
        return new ApiDefinition(client, VcloudResource<ApiDefinitionType>.GetResourceByReference(client, reference));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public static ApiDefinition GetApiDefinitionById(
      vCloudClient client,
      string vCloudId)
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_VCLOUD_ID_MSG) + " - " + vCloudId);
        return new ApiDefinition(client, VcloudEntity<ApiDefinitionType>.GetEntityById(client, vCloudId, "application/vnd.vmware.vcloud.apidefinition+xml"));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultFileDescriptorRecordType> GetFileDescriptorRecords()
    {
      try
      {
        return this.VcloudClient.GetQueryService().ExecuteQuery<RecordResult<QueryResultFileDescriptorRecordType>, QueryResultRecordsType, QueryResultFileDescriptorRecordType>(this.Reference.href + "/files?" + this.VcloudClient.GetQueryService().BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceType GetServiceReference()
    {
      try
      {
        if (this.serviceRef != null)
          return this.serviceRef;
        throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.REFERENCE_NOT_FOUND_MSG));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }
  }
}
