// Decompiled with JetBrains decompiler
// Type: com.vmware.vcloud.sdk.admin.extensions.ExtensionQueryService
// Assembly: VcloudSDK_V5_5, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D83F2C96-44DB-4DCD-8DAE-C27B36ED5CD5
// Assembly location: C:\github\vcloud-auth-issue\Libraries\VcloudSDK_V5_5.dll

using com.vmware.vcloud.api.rest.schema;
using com.vmware.vcloud.sdk.constants.query;
using com.vmware.vcloud.sdk.utility;
using System;

namespace com.vmware.vcloud.sdk.admin.extensions
{
  public class ExtensionQueryService : AdminQueryService
  {
    internal ExtensionQueryService(vCloudClient client)
      : base(client)
    {
    }

    public ReferenceResult QueryHostReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultHostRecordType>(this._client.VCloudApiURL + "/admin/extension/hostReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultHostRecordType> QueryHostRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultHostRecordType>, QueryResultRecordsType, QueryResultHostRecordType>(this._client.VCloudApiURL + "/admin/extension/hostReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultHostRecordType> QueryHostRecords(
      QueryParams<QueryHostField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultHostRecordType>, QueryResultRecordsType, QueryResultHostRecordType>(this._client.VCloudApiURL + "/admin/extension/hostReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryHostField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultHostRecordType> QueryHostIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultHostRecordType>, QueryResultRecordsType, QueryResultHostRecordType>(this._client.VCloudApiURL + "/admin/extension/hostReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultHostRecordType> QueryHostIdRecords(
      QueryParams<QueryHostField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultHostRecordType>, QueryResultRecordsType, QueryResultHostRecordType>(this._client.VCloudApiURL + "/admin/extension/hostReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryHostField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryHostReferences(
      QueryParams<QueryHostField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultHostRecordType>(this._client.VCloudApiURL + "/admin/extension/hostReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryHostField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryDatastoreReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/datastores/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDatastoreRecordType> QueryDatastoreRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDatastoreRecordType>, QueryResultRecordsType, QueryResultDatastoreRecordType>(this._client.VCloudApiURL + "/admin/extension/datastores/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDatastoreRecordType> QueryDatastoreRecords(
      QueryParams<QueryDatastoreField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDatastoreRecordType>, QueryResultRecordsType, QueryResultDatastoreRecordType>(this._client.VCloudApiURL + "/admin/extension/datastores/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryDatastoreField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDatastoreRecordType> QueryDatastoreIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDatastoreRecordType>, QueryResultRecordsType, QueryResultDatastoreRecordType>(this._client.VCloudApiURL + "/admin/extension/datastores/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultDatastoreRecordType> QueryDatastoreIdRecords(
      QueryParams<QueryDatastoreField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultDatastoreRecordType>, QueryResultRecordsType, QueryResultDatastoreRecordType>(this._client.VCloudApiURL + "/admin/extension/datastores/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryDatastoreField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryDatastoreReferences(
      QueryParams<QueryDatastoreField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/datastores/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryDatastoreField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryExternalNetworkReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/externalNetworkReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkRecordType> QueryExternalNetworkRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkRecordType>, QueryResultRecordsType, QueryResultNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/externalNetworkReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkRecordType> QueryExternalNetworkRecords(
      QueryParams<QueryNetworkField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkRecordType>, QueryResultRecordsType, QueryResultNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/externalNetworkReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryNetworkField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkRecordType> QueryExternalNetworkIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkRecordType>, QueryResultRecordsType, QueryResultNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/externalNetworkReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkRecordType> QueryExternalNetworkIdRecords(
      QueryParams<QueryNetworkField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkRecordType>, QueryResultRecordsType, QueryResultNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/externalNetworkReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryNetworkField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryExternalNetworkReferences(
      QueryParams<QueryNetworkField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/externalNetworkReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryNetworkField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryNetworkPoolReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/networkPoolReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkPoolRecordType> QueryNetworkPoolRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkPoolRecordType>, QueryResultRecordsType, QueryResultNetworkPoolRecordType>(this._client.VCloudApiURL + "/admin/extension/networkPoolReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkPoolRecordType> QueryNetworkPoolRecords(
      QueryParams<QueryNetworkPoolField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkPoolRecordType>, QueryResultRecordsType, QueryResultNetworkPoolRecordType>(this._client.VCloudApiURL + "/admin/extension/networkPoolReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryNetworkPoolField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkPoolRecordType> QueryNetworkPoolIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkPoolRecordType>, QueryResultRecordsType, QueryResultNetworkPoolRecordType>(this._client.VCloudApiURL + "/admin/extension/networkPoolReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultNetworkPoolRecordType> QueryNetworkPoolIdRecords(
      QueryParams<QueryNetworkPoolField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultNetworkPoolRecordType>, QueryResultRecordsType, QueryResultNetworkPoolRecordType>(this._client.VCloudApiURL + "/admin/extension/networkPoolReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryNetworkPoolField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryNetworkPoolReferences(
      QueryParams<QueryNetworkPoolField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/networkPoolReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryNetworkPoolField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryProviderVdcReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/providerVdcReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMWProviderVdcRecordType> QueryProviderVdcRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMWProviderVdcRecordType>, QueryResultRecordsType, QueryResultVMWProviderVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/providerVdcReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMWProviderVdcRecordType> QueryProviderVdcRecords(
      QueryParams<QueryVMWProviderVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMWProviderVdcRecordType>, QueryResultRecordsType, QueryResultVMWProviderVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/providerVdcReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVMWProviderVdcField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMWProviderVdcRecordType> QueryProviderVdcIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMWProviderVdcRecordType>, QueryResultRecordsType, QueryResultVMWProviderVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/providerVdcReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVMWProviderVdcRecordType> QueryProviderVdcIdRecords(
      QueryParams<QueryVMWProviderVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVMWProviderVdcRecordType>, QueryResultRecordsType, QueryResultVMWProviderVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/providerVdcReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVMWProviderVdcField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryProviderVdcReferences(
      QueryParams<QueryVMWProviderVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/providerVdcReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVMWProviderVdcField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryVimServerReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/vimServerReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVirtualCenterRecordType> QueryVimServerRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVirtualCenterRecordType>, QueryResultRecordsType, QueryResultVirtualCenterRecordType>(this._client.VCloudApiURL + "/admin/extension/vimServerReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVirtualCenterRecordType> QueryVimServerRecords(
      QueryParams<QueryVirtualCenterField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVirtualCenterRecordType>, QueryResultRecordsType, QueryResultVirtualCenterRecordType>(this._client.VCloudApiURL + "/admin/extension/vimServerReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVirtualCenterField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVirtualCenterRecordType> QueryVimServerIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVirtualCenterRecordType>, QueryResultRecordsType, QueryResultVirtualCenterRecordType>(this._client.VCloudApiURL + "/admin/extension/vimServerReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultVirtualCenterRecordType> QueryVimServerIdRecords(
      QueryParams<QueryVirtualCenterField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultVirtualCenterRecordType>, QueryResultRecordsType, QueryResultVirtualCenterRecordType>(this._client.VCloudApiURL + "/admin/extension/vimServerReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVirtualCenterField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryVimServerReferences(
      QueryParams<QueryVirtualCenterField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/vimServerReferences/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryVirtualCenterField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public ReferenceResult QueryAllOrgNetworkReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/orgNetworks/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public RecordResult<QueryResultAdminOrgNetworkRecordType> QueryAllOrgNetworkRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminOrgNetworkRecordType>, QueryResultRecordsType, QueryResultAdminOrgNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/orgNetworks/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public RecordResult<QueryResultAdminOrgNetworkRecordType> QueryAllOrgNetworkRecords(
      QueryParams<QueryAdminOrgNetworkField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminOrgNetworkRecordType>, QueryResultRecordsType, QueryResultAdminOrgNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/orgNetworks/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminOrgNetworkField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public RecordResult<QueryResultAdminOrgNetworkRecordType> QueryAllOrgNetworkIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminOrgNetworkRecordType>, QueryResultRecordsType, QueryResultAdminOrgNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/orgNetworks/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public RecordResult<QueryResultAdminOrgNetworkRecordType> QueryAllOrgNetworkIdRecords(
      QueryParams<QueryAdminOrgNetworkField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminOrgNetworkRecordType>, QueryResultRecordsType, QueryResultAdminOrgNetworkRecordType>(this._client.VCloudApiURL + "/admin/extension/orgNetworks/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminOrgNetworkField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    [Obsolete("This method is deprecated  since API 5.1, SDK 5.1")]
    public ReferenceResult QueryAllOrgNetworkReferences(
      QueryParams<QueryAdminOrgNetworkField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/orgNetworks/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminOrgNetworkField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryAllOrgVdcReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/orgVdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVdcRecordType> QueryAllOrgVdcRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVdcRecordType>, QueryResultRecordsType, QueryResultAdminVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/orgVdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVdcRecordType> QueryAllOrgVdcRecords(
      QueryParams<QueryAdminVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVdcRecordType>, QueryResultRecordsType, QueryResultAdminVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/orgVdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminVdcField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVdcRecordType> QueryAllOrgVdcIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVdcRecordType>, QueryResultRecordsType, QueryResultAdminVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/orgVdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVdcRecordType> QueryAllOrgVdcIdRecords(
      QueryParams<QueryAdminVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVdcRecordType>, QueryResultRecordsType, QueryResultAdminVdcRecordType>(this._client.VCloudApiURL + "/admin/extension/orgVdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminVdcField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryAllOrgVdcReferences(
      QueryParams<QueryAdminVdcField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/orgVdcs/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminVdcField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryAllVappReferences()
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/vapps/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.REFERENCE_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVAppRecordType> QueryAllVappRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVAppRecordType>, QueryResultRecordsType, QueryResultAdminVAppRecordType>(this._client.VCloudApiURL + "/admin/extension/vapps/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVAppRecordType> QueryAllVappRecords(
      QueryParams<QueryAdminVAppField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVAppRecordType>, QueryResultRecordsType, QueryResultAdminVAppRecordType>(this._client.VCloudApiURL + "/admin/extension/vapps/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminVAppField>(queryParams)) + this.BuildQuery(FormatType.RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVAppRecordType> QueryAllVappIdRecords()
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVAppRecordType>, QueryResultRecordsType, QueryResultAdminVAppRecordType>(this._client.VCloudApiURL + "/admin/extension/vapps/query?" + this.ValidateFirstQueryString(this.BuildQuery(FormatType.ID_RECORD_VIEW)));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public RecordResult<QueryResultAdminVAppRecordType> QueryAllVappIdRecords(
      QueryParams<QueryAdminVAppField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<RecordResult<QueryResultAdminVAppRecordType>, QueryResultRecordsType, QueryResultAdminVAppRecordType>(this._client.VCloudApiURL + "/admin/extension/vapps/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminVAppField>(queryParams)) + this.BuildQuery(FormatType.ID_RECORD_VIEW));
      }
      catch (Exception ex)
      {
        throw new VCloudException(ex.Message);
      }
    }

    public ReferenceResult QueryAllVappReferences(
      QueryParams<QueryAdminVAppField> queryParams)
    {
      try
      {
        return this.ExecuteQuery<ReferenceResult, ReferencesType, QueryResultCatalogRecordType>(this._client.VCloudApiURL + "/admin/extension/vapps/query?" + this.ValidateFirstQueryString(this.BuildQuery<QueryAdminVAppField>(queryParams)) + this.BuildQuery(FormatType.REFERENCE_VIEW));
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
