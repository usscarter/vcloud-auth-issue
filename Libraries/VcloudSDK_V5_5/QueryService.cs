// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.QueryService
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;
using System.Text;

namespace com.vmware.vcloud.sdk
{
  public class QueryService
  {
    protected vCloudClient _client;

    internal QueryService(vCloudClient client)
    {
      this._client = client;
    }

    public string BuildQuery(FormatType formatType)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (formatType.Value() != FormatType.NULL.Value())
      {
        stringBuilder.Append("&format=");
        stringBuilder.Append(formatType.Value());
      }
      return stringBuilder.ToString();
    }

    public string BuildQuery(string queryTypeValue)
    {
      try
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (queryTypeValue == null)
          throw new VCloudException(SdkUtil.GetI18nString(SdkMessage.QUERY_TYPE_NOT_FOUND));
        stringBuilder.Append("/query?type=");
        stringBuilder.Append(queryTypeValue);
        return stringBuilder.ToString();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public string BuildQuery<T>(QueryParams<T> queryParams) where T : QueryField
    {
      try
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (queryParams != null)
        {
          foreach (T key in queryParams.SortFields.Keys)
          {
            if (queryParams.SortFields[key].Equals((object) SortType.SORT_ASC))
            {
              stringBuilder.Append("&sortAsc=");
              stringBuilder.Append(key.Value());
            }
            else
            {
              stringBuilder.Append("&sortDesc=");
              stringBuilder.Append(key.Value());
            }
          }
          if (queryParams.Fields.Count > 0 || queryParams.GetMetadataFields().Count > 0)
          {
            stringBuilder.Append("&fields=");
            int num1 = 0;
            foreach (T field in queryParams.Fields)
            {
              QueryField queryField = (QueryField) field;
              stringBuilder.Append(queryField.Value());
              ++num1;
              if (num1 != queryParams.Fields.Count)
                stringBuilder.Append(",");
            }
            if (num1 > 0 && queryParams.GetMetadataFields().Count > 0)
              stringBuilder.Append(",");
            int num2 = 0;
            foreach (string metadataField in queryParams.GetMetadataFields())
            {
              stringBuilder.Append(metadataField);
              ++num2;
              if (num2 != queryParams.GetMetadataFields().Count)
                stringBuilder.Append(",");
            }
          }
          if (queryParams.Page.HasValue)
          {
            stringBuilder.Append("&page=");
            stringBuilder.Append((object) queryParams.Page);
          }
          if (queryParams.Offset.HasValue)
          {
            stringBuilder.Append("&offset=");
            stringBuilder.Append((object) queryParams.Offset);
          }
          if (queryParams.PageSize.HasValue)
          {
            stringBuilder.Append("&pageSize=");
            stringBuilder.Append((object) queryParams.PageSize);
          }
          if (queryParams.Filter != null && queryParams.Filter.GetFilterText() != null && !string.IsNullOrEmpty(queryParams.Filter.GetFilterText()))
          {
            stringBuilder.Append("&filter=");
            stringBuilder.Append(queryParams.Filter.GetFilterText());
          }
        }
        return stringBuilder.ToString();
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public T ExecuteQuery<T, U, W>(string query)
      where T : Result<U>
      where U : ContainerType
      where W : QueryResultRecordType
    {
      try
      {
        Logger.Log(TraceLevel.Information, SdkUtil.GetI18nString(SdkMessage.GET_URL_MSG) + " - " + query);
        ContainerType referencesContainerType = this.GetReferencesContainerType(this._client, query);
        if (referencesContainerType is ReferencesType)
          return new ReferenceResult(this._client, (ReferencesType) referencesContainerType) as T;
        return new RecordResult<W>(this._client, (QueryResultRecordsType) referencesContainerType) as T;
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private ContainerType GetReferencesContainerType(vCloudClient client, string query)
    {
      ContainerType containerType = (ContainerType) null;
      if (query.Contains("format=references"))
      {
        if (query.Contains("type=organization&") || query.Contains("/admin/orgs/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryOrgReferencesType>(client, query, 200);
        else if (query.Contains("type=orgVdc&") || query.Contains("/admin/vdcs/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryOrgVdcReferencesType>(client, query, 200);
        else if (query.Contains("type=media&") || query.Contains("/mediaList/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryMediaReferencesType>(client, query, 200);
        else if (query.Contains("type=vAppNetwork&"))
          containerType = (ContainerType) SdkUtil.Get<QueryVAppNetworkReferencesType>(client, query, 200);
        else if (query.Contains("type=vAppTemplate&") || query.Contains("/vAppTemplates/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryVAppTemplateReferencesType>(client, query, 200);
        else if (query.Contains("type=vApp&") || query.Contains("/vApps/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryVAppReferencesType>(client, query, 200);
        else if (query.Contains("type=vm&") || query.Contains("/vms/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryVMReferencesType>(client, query, 200);
        else if (query.Contains("type=orgNetwork&"))
          containerType = (ContainerType) SdkUtil.Get<QueryOrgNetworkReferencesType>(client, query, 200);
        else if (query.Contains("type=adminOrgNetwork&") || query.Contains("/admin/extension/orgNetworks/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryOrgNetworkReferencesType>(client, query, 200);
        else if (query.Contains("type=catalog&") || query.Contains("/catalogs/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryCatalogReferencesType>(client, query, 200);
        else if (query.Contains("type=adminOrgVdc&") || query.Contains("/admin/extension/orgVdcs/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryAdminVdcReferencesType>(client, query, 200);
        else if (query.Contains("type=providerVdc&") || query.Contains("/admin/extension/providerVdcReferences/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryVMWProviderVdcReferencesType>(client, query, 200);
        else if (query.Contains("type=externalNetwork&") || query.Contains("/admin/extension/externalNetworkReferences/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryNetworkReferencesType>(client, query, 200);
        else if (query.Contains("type=group&") || query.Contains("/admin/groups/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryGroupReferencesType>(client, query, 200);
        else if (query.Contains("type=user&") || query.Contains("/admin/users/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryUserReferencesType>(client, query, 200);
        else if (query.Contains("type=strandedUser&") || query.Contains("/admin/strandedUsers/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryUserReferencesType>(client, query, 200);
        else if (query.Contains("type=strandedItems&") || query.Contains("/admin/extension/strandedItems/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryStrandedItemReferencesType>(client, query, 200);
        else if (query.Contains("type=role&") || query.Contains("/admin/roles/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryRoleReferencesType>(client, query, 200);
        else if (query.Contains("type=datastore&") || query.Contains("/admin/extension/datastores/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryDatastoreReferencesType>(client, query, 200);
        else if (query.Contains("type=networkPool&") || query.Contains("/admin/extension/networkPoolReferences/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryNetworkPoolReferencesType>(client, query, 200);
        else if (query.Contains("type=virtualCenter&") || query.Contains("/admin/extension/vimServerReferences/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryVirtualCenterReferencesType>(client, query, 200);
        else if (query.Contains("type=host&") || query.Contains("/admin/extension/hostReferences/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryHostReferencesType>(client, query, 200);
        else if (query.Contains("type=adminVApp&") || query.Contains("/admin/extension/vapps/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryVAppReferencesType>(client, query, 200);
        else if (query.Contains("type=adminVM&"))
          containerType = (ContainerType) SdkUtil.Get<QueryVMReferencesType>(client, query, 200);
        else if (query.Contains("type=vAppOrgNetworkRelation&"))
          containerType = (ContainerType) SdkUtil.Get<QueryVAppOrgNetworkRelationReferencesType>(client, query, 200);
        else if (query.Contains("type=adminUser&"))
          containerType = (ContainerType) SdkUtil.Get<QueryUserReferencesType>(client, query, 200);
        else if (query.Contains("type=adminGroup&"))
          containerType = (ContainerType) SdkUtil.Get<QueryGroupReferencesType>(client, query, 200);
        else if (query.Contains("type=adminVAppNetwork&"))
          containerType = (ContainerType) SdkUtil.Get<QueryVAppNetworkReferencesType>(client, query, 200);
        else if (query.Contains("type=adminCatalog&"))
          containerType = (ContainerType) SdkUtil.Get<QueryCatalogReferencesType>(client, query, 200);
        else if (query.Contains("type=adminCatalogItem&"))
          containerType = (ContainerType) SdkUtil.Get<QueryCatalogItemReferencesType>(client, query, 200);
        else if (query.Contains("type=catalogItem&"))
          containerType = (ContainerType) SdkUtil.Get<QueryCatalogItemReferencesType>(client, query, 200);
        else if (query.Contains("type=adminMedia&"))
          containerType = (ContainerType) SdkUtil.Get<QueryMediaReferencesType>(client, query, 200);
        else if (query.Contains("type=adminVAppTemplate&"))
          containerType = (ContainerType) SdkUtil.Get<QueryVAppTemplateReferencesType>(client, query, 200);
        else if (query.Contains("type=adminShadowVM&"))
          containerType = (ContainerType) SdkUtil.Get<QueryVMReferencesType>(client, query, 200);
        else if (query.Contains("type=task&"))
          containerType = (ContainerType) SdkUtil.Get<QueryTaskReferencesType>(client, query, 200);
        else if (query.Contains("type=adminTask&"))
          containerType = (ContainerType) SdkUtil.Get<QueryTaskReferencesType>(client, query, 200);
        else if (query.Contains("type=blockingTask&"))
          containerType = (ContainerType) SdkUtil.Get<QueryBlockingTaskReferencesType>(client, query, 200);
        else if (query.Contains("type=right&") || query.Contains("/admin/rights/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryRightReferencesType>(client, query, 200);
        else if (query.Contains("type=disk&") || query.Contains("/disks/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryDiskReferencesType>(client, query, 200);
        else if (query.Contains("type=service&"))
          containerType = (ContainerType) SdkUtil.Get<QueryServiceReferencesType>(client, query, 200);
        else if (query.Contains("type=serviceLink&"))
          containerType = (ContainerType) SdkUtil.Get<QueryServiceLinkReferencesType>(client, query, 200);
        else if (query.Contains("type=apiDefinition&"))
          containerType = (ContainerType) SdkUtil.Get<QueryApiDefinitionReferencesType>(client, query, 200);
        else if (query.Contains("type=fileDescriptor&"))
          containerType = (ContainerType) SdkUtil.Get<QueryFileDescriptorReferencesType>(client, query, 200);
        else if (query.Contains("type=resourceClassAction&"))
          containerType = (ContainerType) SdkUtil.Get<QueryResourceClassActionReferencesType>(client, query, 200);
        else if (query.Contains("type=resourceClass&"))
          containerType = (ContainerType) SdkUtil.Get<QueryResourceClassReferencesType>(client, query, 200);
        else if (query.Contains("type=aclRule&"))
          containerType = (ContainerType) SdkUtil.Get<QueryAclRuleReferencesType>(client, query, 200);
        else if (query.Contains("type=serviceResource&"))
          containerType = (ContainerType) SdkUtil.Get<QueryServiceResourceResourceReferencesType>(client, query, 200);
        else if (query.Contains("type=orgVdcNetwork&"))
          containerType = (ContainerType) SdkUtil.Get<QueryOrgVdcNetworkReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/links"))
          containerType = (ContainerType) SdkUtil.Get<QueryServiceLinkReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/apidefinitions"))
          containerType = (ContainerType) SdkUtil.Get<QueryAdminApiDefinitionReferencesType>(client, query, 200);
        else if (query.Contains("api/service?"))
          containerType = (ContainerType) SdkUtil.Get<QueryServiceReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/files"))
          containerType = (ContainerType) SdkUtil.Get<QueryAdminFileDescriptorReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/resourceclasses"))
          containerType = (ContainerType) SdkUtil.Get<QueryResourceClassReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/resourceclassactions"))
          containerType = (ContainerType) SdkUtil.Get<QueryResourceClassActionReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/aclrules"))
          containerType = (ContainerType) SdkUtil.Get<QueryAclRuleReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/serviceresources"))
          containerType = (ContainerType) SdkUtil.Get<QueryServiceResourceResourceReferencesType>(client, query, 200);
        else if (query.Contains("api/service") && query.Contains("/apidefinitions"))
          containerType = (ContainerType) SdkUtil.Get<QueryApiDefinitionReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/extServices"))
          containerType = (ContainerType) SdkUtil.Get<QueryAdminServiceReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/vdc") && query.Contains("/edgeGateways"))
          containerType = (ContainerType) SdkUtil.Get<QueryEdgeGatewayReferencesType>(client, query, 200);
        else if (query.Contains("type=orgVdcGateway&"))
          containerType = (ContainerType) SdkUtil.Get<QueryOrgVdcGatewayReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service") && query.Contains("/apifilters"))
          containerType = (ContainerType) SdkUtil.Get<QueryApiFilterReferencesType>(client, query, 200);
        else if (query.Contains("type=adminDisk&"))
          containerType = (ContainerType) SdkUtil.Get<QueryAdminDiskReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/vdc") && query.Contains("/networks"))
          containerType = (ContainerType) SdkUtil.Get<QueryOrgVdcNetworkReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/service"))
          containerType = (ContainerType) SdkUtil.Get<QueryAdminServiceReferencesType>(client, query, 200);
        else if (query.Contains("api/admin/extension/resourcePool") && query.Contains("/vmList"))
          containerType = (ContainerType) SdkUtil.Get<QueryVMReferencesType>(client, query, 200);
        else if (query.Contains("type=edgeGateway&"))
          containerType = (ContainerType) SdkUtil.Get<QueryEdgeGatewayReferencesType>(client, query, 200);
        else if (query.Contains("type=strandedItem&") || query.Contains("/admin/extension/strandedItem/query"))
          containerType = (ContainerType) SdkUtil.Get<QueryStrandedItemReferencesType>(client, query, 200);
      }
      else
        containerType = (ContainerType) SdkUtil.Get<QueryResultRecordsType>(client, query, 200);
      return containerType;
    }

    public ReferenceResult QueryReferences<T>(
      QueryReferenceType queryReferenceType,
      QueryParams<T> queryParams)
      where T : QueryField
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + this.BuildQuery(queryReferenceType.Value()) + this.BuildQuery<T>(queryParams) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<U> QueryRecords<T, U>(
      QueryRecordType queryRecordType,
      QueryParams<T> queryParams)
      where T : QueryField
      where U : QueryResultRecordType
    {
      try
      {
        return this.ExecuteQuery<RecordResult<U>, QueryResultRecordsType, U>(this._client.VCloudApiURL + this.BuildQuery(queryRecordType.Value()) + this.BuildQuery<T>(queryParams) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<U> QueryIdRecords<T, U>(
      QueryRecordType queryRecordType,
      QueryParams<T> queryParams)
      where T : QueryField
      where U : QueryResultRecordType
    {
      try
      {
        return this.ExecuteQuery<RecordResult<U>, QueryResultRecordsType, U>(this._client.VCloudApiURL + this.BuildQuery(queryRecordType.Value()) + this.BuildQuery<T>(queryParams) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryReferences(QueryReferenceType queryReferenceType)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + this.BuildQuery(queryReferenceType.Value()) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public T QueryRecords<T, U>(QueryRecordType queryRecordType)
      where T : RecordResult<U>
      where U : QueryResultRecordType
    {
      try
      {
        return this.ExecuteQuery<T, QueryResultRecordsType, U>(this._client.VCloudApiURL + this.BuildQuery(queryRecordType.Value()) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public T QueryIdRecords<T, U>(QueryRecordType queryRecordType)
      where T : RecordResult<U>
      where U : QueryResultRecordType
    {
      try
      {
        return this.ExecuteQuery<T, QueryResultRecordsType, U>(this._client.VCloudApiURL + this.BuildQuery(queryRecordType.Value()) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryCatalogReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/catalogs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultCatalogRecordType> QueryCatalogRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultCatalogRecordType>, QueryResultRecordsType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/catalogs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultCatalogRecordType> QueryCatalogIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultCatalogRecordType>, QueryResultRecordsType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/catalogs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultCatalogRecordType> QueryCatalogRecords(
      QueryParams<QueryCatalogField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultCatalogRecordType>, QueryResultRecordsType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/catalogs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryCatalogField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultCatalogRecordType> QueryCatalogIdRecords(
      QueryParams<QueryCatalogField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultCatalogRecordType>, QueryResultRecordsType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/catalogs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryCatalogField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryCatalogReferences(
      QueryParams<QueryCatalogField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/catalogs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryCatalogField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryvAppReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/vApps/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppRecordType> QueryvAppRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppRecordType>, QueryResultRecordsType, QueryResultVAppRecordType>(this._client.VCloudApiURL + "/vApps/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppRecordType> QueryvAppIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppRecordType>, QueryResultRecordsType, QueryResultVAppRecordType>(this._client.VCloudApiURL + "/vApps/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppRecordType> QueryvAppRecords(
      QueryParams<QueryVAppField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppRecordType>, QueryResultRecordsType, QueryResultVAppRecordType>(this._client.VCloudApiURL + "/vApps/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVAppField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppRecordType> QueryvAppIdRecords(
      QueryParams<QueryVAppField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppRecordType>, QueryResultRecordsType, QueryResultVAppRecordType>(this._client.VCloudApiURL + "/vApps/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVAppField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryvAppReferences(
      QueryParams<QueryVAppField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/vApps/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVAppField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryVmReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/vms/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMRecordType> QueryVmRecords(
      QueryParams<QueryVMField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMRecordType>, QueryResultRecordsType, QueryResultVMRecordType>(this._client.VCloudApiURL + "/vms/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVMField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMRecordType> QueryVmIdRecords(
      QueryParams<QueryVMField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMRecordType>, QueryResultRecordsType, QueryResultVMRecordType>(this._client.VCloudApiURL + "/vms/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVMField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMRecordType> QueryVmRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMRecordType>, QueryResultRecordsType, QueryResultVMRecordType>(this._client.VCloudApiURL + "/vms/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMRecordType> QueryVmIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMRecordType>, QueryResultRecordsType, QueryResultVMRecordType>(this._client.VCloudApiURL + "/vms/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryVmReferences(QueryParams<QueryVMField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/vms/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVMField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryvAppTemplateReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/vAppTemplates/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppTemplateRecordType> QueryvAppTemplateRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppTemplateRecordType>, QueryResultRecordsType, QueryResultVAppTemplateRecordType>(this._client.VCloudApiURL + "/vAppTemplates/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppTemplateRecordType> QueryvAppTemplateIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppTemplateRecordType>, QueryResultRecordsType, QueryResultVAppTemplateRecordType>(this._client.VCloudApiURL + "/vAppTemplates/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppTemplateRecordType> QueryvAppTemplateRecords(
      QueryParams<QueryVAppTemplateField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppTemplateRecordType>, QueryResultRecordsType, QueryResultVAppTemplateRecordType>(this._client.VCloudApiURL + "/vAppTemplates/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVAppTemplateField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVAppTemplateRecordType> QueryvAppTemplateIdRecords(
      QueryParams<QueryVAppTemplateField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVAppTemplateRecordType>, QueryResultRecordsType, QueryResultVAppTemplateRecordType>(this._client.VCloudApiURL + "/vAppTemplates/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVAppTemplateField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryvAppTemplateReferences(
      QueryParams<QueryVAppTemplateField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/vAppTemplates/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVAppTemplateField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryMediaReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/mediaList/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultMediaRecordType> QueryMediaRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultMediaRecordType>, QueryResultRecordsType, QueryResultMediaRecordType>(this._client.VCloudApiURL + "/mediaList/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultMediaRecordType> QueryMediaIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultMediaRecordType>, QueryResultRecordsType, QueryResultMediaRecordType>(this._client.VCloudApiURL + "/mediaList/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultMediaRecordType> QueryMediaRecords(
      QueryParams<QueryMediaField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultMediaRecordType>, QueryResultRecordsType, QueryResultMediaRecordType>(this._client.VCloudApiURL + "/mediaList/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryMediaField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultMediaRecordType> QueryMediaIdRecords(
      QueryParams<QueryMediaField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultMediaRecordType>, QueryResultRecordsType, QueryResultMediaRecordType>(this._client.VCloudApiURL + "/mediaList/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryMediaField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryMediaReferences(
      QueryParams<QueryMediaField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/mediaList/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryMediaField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryDiskReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultDiskRecordType>(this._client.VCloudApiURL + "/disks/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDiskRecordType> QueryDiskRecords(
      QueryParams<QueryDiskField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDiskRecordType>, QueryResultRecordsType, QueryResultDiskRecordType>(this._client.VCloudApiURL + "/disks/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryDiskField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDiskRecordType> QueryDiskIdRecords(
      QueryParams<QueryDiskField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDiskRecordType>, QueryResultRecordsType, QueryResultDiskRecordType>(this._client.VCloudApiURL + "/disks/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryDiskField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDiskRecordType> QueryDiskRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDiskRecordType>, QueryResultRecordsType, QueryResultDiskRecordType>(this._client.VCloudApiURL + "/disks/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDiskRecordType> QueryDiskIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDiskRecordType>, QueryResultRecordsType, QueryResultDiskRecordType>(this._client.VCloudApiURL + "/disks/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryDiskReferences(
      QueryParams<QueryDiskField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultDiskRecordType>(this._client.VCloudApiURL + "/disks/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryDiskField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    private string ValidateFirstQueryString(string queryString)
    {
      if (queryString != string.Empty && queryString.Substring(0, 1) == "&")
        return queryString.Substring(1);
      return queryString;
    }
  }
}
